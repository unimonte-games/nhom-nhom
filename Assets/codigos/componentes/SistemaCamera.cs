using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class SistemaCamera : MonoBehaviour
    {
        public Transform[] jogadores = new Transform[4];
        public float zoomVel, minFov, maxFov;

        Transform tr;
        Camera cam;
        OlhadorSuave olhadorSuave;
        Vector3 pontoMedio;

        static SistemaCamera singleton;

        void Awake() {
            singleton = this;
            tr = GetComponent<Transform>();
            olhadorSuave = GetComponent<OlhadorSuave>();
            cam = GetComponent<Camera>();
        }

        void Update() {
            if (SistemaPausa.pausado)
                return;

            if (jogadores == null || jogadores.Length == 0)
                return;

            pontoMedio = CalculaPontoMedio();
            olhadorSuave.alvo = pontoMedio;

            ControlarFOV();
        }

        void ControlarFOV() {
            float mouseScrollDt = Input.mouseScrollDelta.y;

            bool usingPlus = (
                Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus) ||
                Input.GetKey(KeyCode.Equals) || mouseScrollDt < -0.01f
            );

            bool usingMinus = (
                Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus) || mouseScrollDt > 0.01f
            );

            float plusVel  = (usingPlus ? -1 : 0) * zoomVel * Time.deltaTime;
            float minusVel = (usingMinus ? 1 : 0) * zoomVel * Time.deltaTime;

            cam.fieldOfView += plusVel + minusVel;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, minFov, maxFov);

        }

        Vector3 CalculaPontoMedio() {
            Vector3 resultado = Vector3.zero;

            int qtd = 0;

            for (int i = 0; i < jogadores.Length; i++)
                if (jogadores[i]) {
                    qtd++;
                    resultado += jogadores[i].position;
                }

            resultado /= qtd;

            return resultado;
        }

        public static void DefinirJogador(Transform tr, int i) {
            if (singleton)
                singleton._DefinirJogador(tr, i);
            else
                Debug.Log("sem singleton");
        }

        void _DefinirJogador(Transform tr, int i) {
            jogadores[i] = tr;
        }
    }
}
