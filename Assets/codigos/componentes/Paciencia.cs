using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class Paciencia : MonoBehaviour {
        public bool consumir;

        public float paciencia;
        public float multiplicadorBravo;
        public float consumoPorSeg;
        public float[] divisoes;
        public Sprite[] slimotes;

        float pacienciaInicial;

        public GameObject barraBorda, slimoteBorda;
        public TransformacaoLerp trLepBarra;
        public SpriteRenderer barraValorSprite, slimoteSprite;
        public Gradient gradienteBarra;

        public bool bravo;

        public int ObterMarca() {
            for (int i = 0; i < divisoes.Length; i++)
                if (paciencia < divisoes[i])
                    return i;
            return divisoes.Length;
        }

        public void Recuperar() {
            paciencia = pacienciaInicial;
        }

        void Start() {
            pacienciaInicial = paciencia;
        }

        void Update() {
            if (SistemaPausa.pausado)
                return;

            if (consumir)
                paciencia -= consumoPorSeg * (bravo ? multiplicadorBravo : 1f) * Time.deltaTime;

            float t = Mathf.Clamp01(paciencia / pacienciaInicial);
            trLepBarra.t = t;

            barraBorda.SetActive(consumir);
            barraValorSprite.color = bravo ? Color.magenta : gradienteBarra.Evaluate(t);

            slimoteBorda.SetActive(consumir);
            slimoteSprite.sprite = slimotes[ObterMarca()];


            // é modificado como true pelo aguarda prato
            // a cada quadro enquanto prato errado estiver
            // sobre a mesa
            bravo = false;
        }
    }
}
