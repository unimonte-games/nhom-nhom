using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace NhomNhom {

    public class AguardaPrato : MonoBehaviour {
        ControladorVaiAtePonto ctrlVaiAtePonto;
        ControleCliente ctrlCliente;
        Transform tr;
        ObjetosAlcancaveis objsEspacos;

        bool mesaObtida;
        EspacoItem espacoMesa, espacoCliente;
        Item pedidoItem;

        Paciencia paciencia;
        BolhaCliente bolha;

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
                    pratoItem.bloqueado = true;
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
            ctrlCliente = GetComponent<ControleCliente>();
            tr = GetComponent<Transform>();
            paciencia = GetComponent<Paciencia>();
            bolha = GetComponent<BolhaCliente>();
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

                bolha.DefinirImgPrato(idPratoEsperado);
                bolha.Exibir();
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

                    Vector3 pontoOlhar = new Vector3(
                        espacoMesa.transform.position.x,
                        tr.position.y,
                        espacoMesa.transform.position.z
                    );

                    ctrlCliente.OlharPonto(pontoOlhar);
                    // var rotY = new Vector3(0, tr.eulerAngles.y, 0);
                    // tr.eulerAngles = rotY;
                }
            }
        }
    }
}
