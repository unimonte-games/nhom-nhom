using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class Paciencia : MonoBehaviour {
        public float paciencia;
        public float consumoPorSeg;
        public float[] divisoes;

        float pacienciaInicial;

        public Transform pseudoBarra;
        public MeshRenderer pseudoBarra_MR;

        public Gradient gradienteBarra;

        Vector3 escala = Vector3.one;

        public int ObterMarca() {
            for (int i = 0; i < divisoes.Length; i++)
                if (paciencia < divisoes[i])
                    return i;
            return divisoes.Length;
        }

        void Start() {
            pacienciaInicial = paciencia;
        }

        void Update() {
            paciencia -= consumoPorSeg * Time.deltaTime;

            float t = Mathf.Clamp01(paciencia / pacienciaInicial);
            escala.x = t;
            if (escala.x < 0.00001f)
                escala = Vector3.zero;

            pseudoBarra.localScale = escala;
            pseudoBarra_MR.material.color = gradienteBarra.Evaluate(t);
        }
    }
}
