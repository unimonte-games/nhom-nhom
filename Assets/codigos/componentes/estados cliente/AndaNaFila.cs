using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class AndaNaFila : MonoBehaviour
    {
        Fila fila;

        int espaco_i;

        Transform pontoFila, tr;
        ControladorVaiAtePonto ctrlVaiPonto;
        ControleCliente ctrlCliente;

        public bool EstaNaFrente() {
            return espaco_i == 0 && ctrlVaiPonto.estaNoPonto;
        }

        void ObtemEspaco() {
            espaco_i = fila.RegistraEspaco(ctrlCliente.id);
            if (espaco_i >= 0) {
                pontoFila = fila.fila_trs[espaco_i];
                ctrlVaiPonto.trAlvo = pontoFila;
            }
        }

        void Awake() {
            fila = FindObjectOfType<Fila>();
            tr = GetComponent<Transform>();
            ctrlVaiPonto = GetComponent<ControladorVaiAtePonto>();
            ctrlCliente = GetComponent<ControleCliente>();
        }

        void Start() {
            GetComponent<ControleCliente>().olhador.rotSuave.atualizar = false;
            ObtemEspaco();
        }

        void Update() {
            if (espaco_i >= 0 && ctrlVaiPonto.estaNoPonto)
                tr.rotation = ctrlVaiPonto.trAlvo.rotation;

            espaco_i = fila.ObtemIndicePorID(ctrlCliente.id, espaco_i);

            if (espaco_i >= 0) {
                if (pontoFila != fila.fila_trs[espaco_i]) {
                    pontoFila = fila.fila_trs[espaco_i];
                    ctrlVaiPonto.trAlvo = pontoFila;
                    ctrlVaiPonto.estaNoPonto = false;
                }
            } else
                ObtemEspaco();
        }
    }
}
