using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class SistemaPausa : MonoBehaviour
    {
        public static bool pausado;
        public GameObject pausaMenu;

        static SistemaPausa singleton;

        void Awake() {
            // por segurança, colocar este componente em todas as cenas,
            // em especial nas fases, assim, o `pausado` é resetado devidamente.
            pausado = false;
            singleton = this;
            Resumir();
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (pausado)
                    Resumir();
                else
                    Pausar();
            }
        }

        public static void Pausar() {
            pausado = true;
            Time.timeScale = 0f;
            singleton.pausaMenu.SetActive(true);
        }

        public static void Resumir() {
            pausado = false;
            Time.timeScale = 1f;
            singleton.pausaMenu.SetActive(false);
        }

        public void _Pausar() { Pausar(); }
        public void _Resumir() { Resumir(); }
    }
}
