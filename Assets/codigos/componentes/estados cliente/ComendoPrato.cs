using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class ComendoPrato : MonoBehaviour {
        float tempoInicio, intervaloPrato;

        void Start() {
            tempoInicio = Time.time;
            Item itemPrato = transform.Find("ref_item").GetComponent<EspacoItem>().Soltar();

            Prato prato = itemPrato.GetComponent<Prato>();
            intervaloPrato = prato.intervalo;
            GetComponent<EstadosCliente>().precoPrato = prato.ObtemPreco();

            Destroy(itemPrato.gameObject, intervaloPrato);

            Paciencia paciencia = GetComponent<Paciencia>();
            paciencia.Recuperar();
            paciencia.consumir = false;
        }

        public bool Comeu() {
            return Time.time - tempoInicio > intervaloPrato;
        }
    }
}
