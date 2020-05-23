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

        public Transform barraValor;
        public SpriteRenderer barraValorSprite, slimoteSprite;
        public Gradient gradienteBarra;

        public bool bravo;

        Vector3 escala = Vector3.one;

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
            if (consumir)
                paciencia -= consumoPorSeg * (bravo ? multiplicadorBravo : 1f) * Time.deltaTime;

            float t = Mathf.Clamp01(paciencia / pacienciaInicial);
            escala.x = t;
            if (escala.x < 0.00001f)
                escala = Vector3.zero;

            barraValor.localScale = escala;

            barraValorSprite.enabled = consumir;
            barraValorSprite.color = bravo ? Color.magenta : gradienteBarra.Evaluate(t);

            slimoteSprite.enabled = consumir;
            slimoteSprite.sprite = slimotes[ObterMarca()];


            // é modificado como true pelo aguarda prato
            // a cada quadro enquanto prato errado estiver
            // sobre a mesa
            bravo = false;
        }
    }
}
