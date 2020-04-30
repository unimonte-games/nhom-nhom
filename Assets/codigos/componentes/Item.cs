using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace NhomNhom {
    // OBSERVAÇÃO: Item não deve mandar ordens para EspacoItem, por exemplo,
    // o LimparPosse não deve pedir para EspacoItem.Soltar() (senão entra em recursão sem caso base)
    public class Item : MonoBehaviour
    {
        public EspacoItem espacoPertencente;
        public bool bloqueado;

        Transform tr;

        public void LimparPosse() {
            if (espacoPertencente && !bloqueado) {
                tr.SetParent(null);
                espacoPertencente.itemAbrigado = null;
                espacoPertencente = null;
            }
        }

        public void DefinirPosse(EspacoItem novoEspacoPertencente) {
            if (bloqueado)
                return;
            LimparPosse();
            espacoPertencente = novoEspacoPertencente;
            espacoPertencente.itemAbrigado = this;
            tr.SetParent(espacoPertencente.transform);
            tr.localPosition = Vector3.zero;
            tr.rotation = novoEspacoPertencente.transform.rotation;
        }

        void Awake() {
            tr = GetComponent<Transform>();
        }
    }
}
