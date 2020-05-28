using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class Velocidade : MonoBehaviour
    {
        public Vector3 direcao;
        public float velocidade;

        Transform tr;

        void Awake()
        {
            tr = GetComponent<Transform>();
        }

        void FixedUpdate()
        {
            if (SistemaPausa.pausado)
                return;

            if (direcao.magnitude < 0.02f || velocidade <= 0.02f && velocidade >= -0.02f)
                return;

            tr.Translate(direcao * velocidade * Time.deltaTime);
        }
    }
}
