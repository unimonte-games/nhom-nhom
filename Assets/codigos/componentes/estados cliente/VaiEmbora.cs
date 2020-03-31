using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaiEmbora : MonoBehaviour
{
    public Transform ptFolha;

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
        ptFolha = GetComponent<ControleCliente>().ptCadeira;

        pontos = cadeiras.ObterRotaSaida(ptFolha);

        ctrlVaiAtePonto.trAlvo = pontos[i_ponto];
        ctrlVaiAtePonto.ativo = true;
    }

    void Update() {
        if (ctrlVaiAtePonto.estaNoPonto && !FoiEmbora())
            i_ponto++;

        ctrlVaiAtePonto.trAlvo = pontos[i_ponto];
    }
}
