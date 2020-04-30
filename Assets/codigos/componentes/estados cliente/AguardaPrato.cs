﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace NhomNhom {

    public class AguardaPrato : MonoBehaviour {
        ControladorVaiAtePonto ctrlVaiAtePonto;
        Transform tr;
        ObjetosAlcancaveis objsEspacos;

        bool mesaObtida;
        EspacoItem espacoMesa, espacoCliente;
        Item pedidoItem;

        Paciencia paciencia;

        string idPratoEsperado;
        int cor_esperada;

        public bool ComPrato() {
            if (!espacoMesa || espacoMesa.Vazio())
                return false;

            string id = espacoMesa.itemAbrigado.GetComponent<GbjID>().id;

            bool ePrato = id.Substring(0, 6) == "#prato";

            if (ePrato) {
                int cor_i = espacoMesa.itemAbrigado.GetComponent<Prato>().cor_i;

                if (cor_i == cor_esperada && id == idPratoEsperado) {
                    Item pratoItem = espacoMesa.Soltar();
                    Vector3 pos = pratoItem.transform.position;
                    espacoCliente.Abrigar(pratoItem);
                    pratoItem.transform.position = pos;
                    return true;
                } else {
                    SlimeBravo();
                    return false;
                }
            }

            return false;
        }

        void SlimeBravo() {
            // Mudar ícone
            // diminuir paciência mais rápido
            paciencia.bravo = true;
        }

        void Awake() {
            ctrlVaiAtePonto = GetComponent<ControladorVaiAtePonto>();
            tr = GetComponent<Transform>();
            paciencia = GetComponent<Paciencia>();
        }

        void Start() {
            ctrlVaiAtePonto.ativo = false;

            objsEspacos = tr.Find("sensor_espacos").GetComponent<ObjetosAlcancaveis>();
            Assert.IsNotNull(objsEspacos);

            espacoCliente = tr.Find("ref_item").GetComponent<EspacoItem>();
            espacoCliente.itemAbrigado.gameObject.SetActive(true);

            pedidoItem = espacoCliente.Soltar();

            {
                var trocadorItem = FindObjectOfType<TrocadorItem>();
                var itemPedido = pedidoItem.GetComponent<Pedido>();
                itemPedido.Inicializar();
                idPratoEsperado = itemPedido.pratoId;
                cor_esperada = itemPedido.cor_prato;
            }

            paciencia.Recuperar();
            paciencia.consumir = true;
        }

        void Update() {
            if (ctrlVaiAtePonto.estaNoPonto) {
                if (!mesaObtida) {
                    GameObject gbjMesa = objsEspacos.ObterMaisProximo();
                    espacoMesa = gbjMesa.GetComponent<EspacoItem>();
                    Assert.IsNotNull(espacoMesa);

                    espacoMesa.Abrigar(pedidoItem);

                    mesaObtida = true;

                    tr.LookAt(espacoMesa.transform);
                    tr.eulerAngles = new Vector3(0, tr.eulerAngles.y, 0);
                }
            }
        }
    }
}
