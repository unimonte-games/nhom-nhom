using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class OlhadorSuave : MonoBehaviour
    {
        public Vector3 alvo;
        public RotacionadorSuave rotSuave;

        void Update()
        {
            if (SistemaPausa.pausado)
                return;

            if (!rotSuave.atualizar)
                return;

            // zoado, mas funcional :|
            Quaternion rotBkup = rotSuave.tr.rotation;
            rotSuave.tr.LookAt(alvo);
            rotSuave.rotacaoAlvo = rotSuave.tr.rotation;
            rotSuave.tr.rotation = rotBkup;
        }
    }
}
