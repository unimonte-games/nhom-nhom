using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueAlturaDeChao : MonoBehaviour
{
    public Vector3 deslocamento, deslocamentoOrigem;
    public LayerMask camada;

    Transform tr;
    Vector3 pos;

    Vector3 up3 = Vector3.up * 3;

    void Awake() {
        tr = GetComponent<Transform>();
    }

    void Start() {
        pos = tr.position;
    }

    void Update() {
        pos = tr.position;

        RaycastHit rhit;
        if (Physics.Raycast(
            pos + deslocamentoOrigem,
            Vector3.down,
            out rhit,
            100,
            camada
        )) {
            pos = rhit.point + deslocamento;
            tr.position = pos;
        }
    }
}
