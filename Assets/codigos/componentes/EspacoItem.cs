using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EspacoItem : MonoBehaviour
{
    public Item itemAbrigado;

    Transform tr;

    public bool Vazio() {
        return itemAbrigado == null;
    }

    public Item Soltar() {
        if (!Vazio() && itemAbrigado.espacoPertencente == this) {
            Item itemQueEstavaAbrigado = itemAbrigado;
            itemAbrigado.LimparPosse();

            // itemQueEstavaAbrigado não deve ser nula
            Assert.IsNotNull(itemQueEstavaAbrigado);

            return itemQueEstavaAbrigado;
        }
        return null;
    }

    public void Abrigar(Item item) {
        if (Vazio()) {
            item.DefinirPosse(this);
        }
    }

    void Awake() {
        tr = GetComponent<Transform>();
    }
}
