using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class Prato : MonoBehaviour {
        public float tempoConsumo, tempoPreparo;
        public int precoBase, precoVariacao1;

        public MeshRenderer meshRend;
        public int cor_i;
        public int[] matCores;
        public Color[] paletaPrato;

        public int ObtemPreco() {
            return precoBase + precoVariacao1;
        }

        void Start() {
            MudaCores();
        }

        void MudaCores() {
            if (!meshRend) {
                Debug.LogWarning("Não foi possível mudar a cor do prato, meshRend está nulo!");
                return;
            }

            Color cor = paletaPrato[cor_i];
            for (int i = 0; i < matCores.Length; i++)
                meshRend.materials[matCores[i]].SetColor("_main_color", cor);
        }
    }
}
