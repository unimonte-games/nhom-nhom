using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndaNaFila : MonoBehaviour
{
    Fila fila;
    static int ultimoIDFila = 1;

    int id, espaco_i;

    Transform pontoFila;

    ControladorVaiAtePonto ctrlVaiPonto;

    void ObtemEspaco() {
        espaco_i = fila.RegistraEspaco(id);
        if (espaco_i >= 0) {
            pontoFila = fila.fila_trs[espaco_i];
            ctrlVaiPonto.trAlvo = pontoFila;
        }
    }

    void Awake() {
        fila = FindObjectOfType<Fila>();
        ctrlVaiPonto = GetComponent<ControladorVaiAtePonto>();
        id = ++ultimoIDFila;
    }

    void Start() {
        ObtemEspaco();
    }

    void Update() {
        espaco_i = fila.ObtemIndicePorID(id, espaco_i);

        if (espaco_i >= 0) {
            if (pontoFila != fila.fila_trs[espaco_i])
                ctrlVaiPonto.trAlvo = pontoFila;
        } else
            ObtemEspaco();
    }
}
