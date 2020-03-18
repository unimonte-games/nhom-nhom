using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public EspacoItem espacoPertencente;
    Transform tr;

    public void LimparPosse() {
        if (espacoPertencente) {
            tr.SetParent(null);
            espacoPertencente.itemAbrigado = null;
            espacoPertencente = null;
        }
    }

    public void DefinirPosse(EspacoItem novoEspacoPertencente) {
        LimparPosse();
        novoEspacoPertencente.itemAbrigado = this;
        tr.SetParent(novoEspacoPertencente.transform);
        tr.localPosition = Vector3.zero;
    }

    void Awake() {
        tr = GetComponent<Transform>();
    }
}
