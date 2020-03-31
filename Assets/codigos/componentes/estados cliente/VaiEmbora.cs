using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiEmbora : MonoBehaviour
{
    Cadeiras cadeiras;

    Transform[] pontos;
    int i_ponto;
    ControladorVaiAtePonto ctrlVaiAtePonto;

    public bool FoiEmbora() {
        return i_ponto == pontos.Length - 1 && ctrlVaiAtePonto.estaNoPonto;
    }

    void Awake() {
        cadeiras = FindObjectOfType<Cadeiras>();
        ctrlVaiAtePonto = GetComponent<ControladorVaiAtePonto>();
    }

    void Start() {
        pontos = cadeiras.ObterRotaSaida(
            GetComponent<ControleCliente>().ptCadeira
        );

        ctrlVaiAtePonto.trAlvo = pontos[i_ponto];
        ctrlVaiAtePonto.ativo = true;
    }

    void Update() {
        if (ctrlVaiAtePonto.estaNoPonto && !FoiEmbora())
            i_ponto++;

        ctrlVaiAtePonto.trAlvo = pontos[i_ponto];
    }
}
