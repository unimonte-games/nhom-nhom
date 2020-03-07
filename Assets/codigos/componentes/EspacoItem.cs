using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspacoItem : MonoBehaviour
{
    public Item itemAbrigado;

    Transform tr;

    public bool Vazio() {
        return itemAbrigado == null;
    }

    public Item Soltar() {
        if (!Vazio()) {
            itemAbrigado.LimparPosse();
            return itemAbrigado;
        }
        return null;
    }

    public void Abrigar(Item item) {
        if (Vazio())
            item.DefinirPosse(this);
    }

    void Awake() {
        tr = GetComponent<Transform>();
    }
}
