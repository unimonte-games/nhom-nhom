using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class ComendoPrato : MonoBehaviour {
        float tempoInicio, intervaloPrato;

        void Start() {
            tempoInicio = Time.time;
            Item itemPrato = transform.Find("ref_item").GetComponent<EspacoItem>().Soltar();
            intervaloPrato = itemPrato.GetComponent<Prato>().intervalo;
            Destroy(itemPrato.gameObject, intervaloPrato);
        }

        public bool Comeu() {
            return Time.time - tempoInicio > intervaloPrato;
        }
    }
}
