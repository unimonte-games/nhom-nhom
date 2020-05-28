using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class Olhador : MonoBehaviour
    {
        public bool ativo, iniciarOlhandoCamera;
        public Transform alvo;
        Transform tr;

        void Awake() {
            tr = GetComponent<Transform>();
        }

        void Start() {
            if (iniciarOlhandoCamera)
                alvo = Camera.main.transform;
        }

        public void Update() {
            if (SistemaPausa.pausado)
                return;

            if (!ativo || !tr || !alvo)
                return;

            tr.LookAt(alvo);
        }
    }
}
