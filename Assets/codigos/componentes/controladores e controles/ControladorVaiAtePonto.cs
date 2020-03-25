using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVaiAtePonto : MonoBehaviour
{
    public float distanciaMinima, velocidade;
    public Transform trAlvo;
    public bool estaNoPonto;

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
        ControlesValores resultado;

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

        controle.velocidade = ObterVelocidade();
        controle.ctrlValores = ObterControlesValores();
    }
}
