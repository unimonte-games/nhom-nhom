using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class ControleCliente : MonoBehaviour
    {
        public Transform ptCadeira;
        public int id;

        Transform tr;
        Controle ctrl;
        Velocidade compVelocidade;

        Vector3 direcao;

        void Awake() {
            compVelocidade = GetComponent<Velocidade>();
            tr = GetComponent<Transform>();
            ctrl = GetComponent<Controle>();
        }

        void Update() {
            float H = ctrl.ctrlValores.eixoHorizontal;
            float V = ctrl.ctrlValores.eixoVertical;

            direcao.x = H;
            direcao.y = 0;
            direcao.z = V;

            direcao.Normalize();
            compVelocidade.direcao.x = 0;
            compVelocidade.direcao.y = 0;

            if (direcao.magnitude > 0.1f) {
                tr.LookAt(tr.position + direcao);

                compVelocidade.direcao.z = Mathf.Ceil(direcao.magnitude);
                compVelocidade.velocidade = ctrl.velocidade;
            } else {
                compVelocidade.direcao.z = 0;
                compVelocidade.velocidade = 0;
            }
        }
    }
}
