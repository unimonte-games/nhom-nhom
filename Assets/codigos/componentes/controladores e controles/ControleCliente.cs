using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCliente : MonoBehaviour
{
    public Transform ptCadeira;

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

        if (direcao.magnitude > 0.1f) {
            direcao.Normalize();
            tr.LookAt(tr.position + direcao);

            compVelocidade.direcao.x = 0;
            compVelocidade.direcao.y = 0;
            compVelocidade.direcao.z = Mathf.Ceil(direcao.magnitude);
            compVelocidade.velocidade = ctrl.velocidade;
        }
    }
}
