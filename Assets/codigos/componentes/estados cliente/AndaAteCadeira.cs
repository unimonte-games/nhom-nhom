using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class AndaAteCadeira : MonoBehaviour
    {
        Cadeiras cadeiras;

        Transform[] pontos;
        int i_ponto;
        ControladorVaiAtePonto ctrlVaiPonto;

        public bool Chegou() {
            return i_ponto == pontos.Length - 1 && ctrlVaiPonto.estaNoPonto;
        }

        void Awake() {
            cadeiras = FindObjectOfType<Cadeiras>();
            ctrlVaiPonto = GetComponent<ControladorVaiAtePonto>();
        }

        void Start() {
            GetComponent<ControleCliente>().olhador.rotSuave.atualizar = true;
            pontos = cadeiras.ObterRota();
            GetComponent<ControleCliente>().ptCadeira = pontos[pontos.Length-1];
            ctrlVaiPonto.trAlvo = pontos[i_ponto];
        }

        void Update() {
            if (SistemaPausa.pausado)
                return;

            if (ctrlVaiPonto.estaNoPonto && !Chegou() && i_ponto < pontos.Length - 1) {
                i_ponto++;
                ctrlVaiPonto.trAlvo = pontos[i_ponto];
                ctrlVaiPonto.estaNoPonto = false;
            }
        }
    }
}
