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
        bool estaNoPonto;

        public bool Chegou() {
            return i_ponto == pontos.Length - 1 && ctrlVaiPonto.estaNoPonto && estaNoPonto;
        }

        void Awake() {
            cadeiras = FindObjectOfType<Cadeiras>();
            ctrlVaiPonto = GetComponent<ControladorVaiAtePonto>();
        }
        void Start() {
            pontos = cadeiras.ObterRota();
            GetComponent<ControleCliente>().ptCadeira = pontos[pontos.Length-1];
            ctrlVaiPonto.trAlvo = pontos[i_ponto];
        }

        void Update() {
            if (ctrlVaiPonto.estaNoPonto && !Chegou() && i_ponto < pontos.Length - 1)
                i_ponto++;

            ctrlVaiPonto.trAlvo = pontos[i_ponto];

            Vector3 diff = ctrlVaiPonto.trAlvo.position - transform.position;
            estaNoPonto = diff.magnitude < ctrlVaiPonto.distanciaMinima;
        }
    }
}
