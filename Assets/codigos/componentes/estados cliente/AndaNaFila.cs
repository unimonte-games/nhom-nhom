using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class AndaNaFila : MonoBehaviour
    {
        Fila fila;
        static int ultimoIDFila = 1;

        public int id;
        int espaco_i;

        Transform pontoFila, tr;
        ControladorVaiAtePonto ctrlVaiPonto;

        public bool EstaNaFrente() {
            return espaco_i == 0 && ctrlVaiPonto.estaNoPonto;
        }

        void ObtemEspaco() {
            espaco_i = fila.RegistraEspaco(id);
            if (espaco_i >= 0) {
                pontoFila = fila.fila_trs[espaco_i];
                ctrlVaiPonto.trAlvo = pontoFila;
            }
        }

        void Awake() {
            fila = FindObjectOfType<Fila>();
            tr = GetComponent<Transform>();
            ctrlVaiPonto = GetComponent<ControladorVaiAtePonto>();
            id = ++ultimoIDFila;
        }

        void Start() {
            ObtemEspaco();
        }

        void Update() {
            if (espaco_i >= 0 && ctrlVaiPonto.estaNoPonto) {
                tr.rotation = ctrlVaiPonto.trAlvo.rotation;
            }


            espaco_i = fila.ObtemIndicePorID(id, espaco_i);

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
