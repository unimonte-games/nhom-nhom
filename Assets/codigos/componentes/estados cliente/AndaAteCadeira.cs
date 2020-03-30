using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndaAteCadeira : MonoBehaviour
{
    Cadeiras cadeiras;

    Transform[] pontos;
    int i_ponto;
    ControladorVaiAtePonto ctrlVaiPonto;

    public bool Chegou() {
        return i_ponto == pontos.Length - 1;
    }

    void Awake() {
        cadeiras = FindObjectOfType<Cadeiras>();
        ctrlVaiPonto = GetComponent<ControladorVaiAtePonto>();
    }
    void Start() {
        pontos = cadeiras.ObterRota();
        ctrlVaiPonto.trAlvo = pontos[i_ponto];
    }

    void Update() {
        if (ctrlVaiPonto.estaNoPonto) {
            if (!Chegou())
                i_ponto++;
        } else {
            ctrlVaiPonto.estaNoPonto = false;
        }
        ctrlVaiPonto.trAlvo = pontos[i_ponto];
    }
}
