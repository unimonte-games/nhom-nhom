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
        public static Color[] paletaPrato = new Color[3] {
            new Color(250f/255f, 52f/255f , 52f/255f , 255f/255f),
            new Color(52f/255f , 250f/255f, 52f/255f , 255f/255f),
            new Color(52f/255f , 52f/255f , 250f/255f, 255f/255f)
        };

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
