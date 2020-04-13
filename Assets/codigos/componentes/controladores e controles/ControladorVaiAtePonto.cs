using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class ControladorVaiAtePonto : MonoBehaviour
    {
        public float distanciaMinima, velocidade;
        public Transform trAlvo;
        public bool estaNoPonto, ativo;

        Transform tr;
        Controle controle;
        Vector3 diff, dir;

        float ObterVelocidade() {
            if (trAlvo && !estaNoPonto)
                return velocidade;
            else
                return 0;
        }

        ControlesValores ObterControlesValores() {
            ControlesValores resultado = new ControlesValores();

            if (trAlvo || !estaNoPonto) {
                resultado.eixoHorizontal = dir.x;
                resultado.eixoVertical   = dir.z;
            } else
                resultado.eixoHorizontal = resultado.eixoVertical = 0;

            resultado.eixoAcao1 = resultado.eixoAcao2 = false;

            return resultado;
        }

        void Awake() {
            tr = GetComponent<Transform>();
            controle = GetComponent<Controle>();
        }

        void Update() {
            if (trAlvo) {
                diff = trAlvo.position - tr.position;
                dir = diff.normalized;
                estaNoPonto = diff.magnitude < distanciaMinima;
            } else {
                diff = Vector3.zero;
                dir = Vector3.zero;
            }

            if (ativo) {
                controle.velocidade = ObterVelocidade();
                controle.ctrlValores = ObterControlesValores();
            } else {
                controle.velocidade = 0f;
                controle.ctrlValores.eixoHorizontal = 0f;
                controle.ctrlValores.eixoVertical = 0f;
                controle.ctrlValores.eixoAcao1 = false;
                controle.ctrlValores.eixoAcao2 = false;
            }
        }
    }
}
