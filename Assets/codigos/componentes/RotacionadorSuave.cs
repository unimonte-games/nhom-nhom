using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class RotacionadorSuave : MonoBehaviour
    {
        public float vel;
        public Quaternion rotacaoAlvo;
        public bool atualizar;

        public Transform tr;

        void Update()
        {
            if (SistemaPausa.pausado)
                return;

            if (atualizar)
                tr.rotation = Quaternion.Lerp(tr.rotation, rotacaoAlvo, Time.deltaTime * vel);
        }
    }
}
