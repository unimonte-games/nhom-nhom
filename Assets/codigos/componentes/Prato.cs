using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class Prato : MonoBehaviour {
        public float tempoConsumo, tempoPreparo;
        public int precoBase, precoVariacao1;

        public int ObtemPreco() {
            return precoBase + precoVariacao1;
        }
    }
}
