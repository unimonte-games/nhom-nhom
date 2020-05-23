using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class AdicionarJogadores : MonoBehaviour
    {
        public GameObject jogador;
        public Transform localInicial;
        public Color[] coresContorno = new Color[4];
        public static int jogadorQtd;

        void Awake() {
            InstanciarJogador();
        }

        void Update() {
            if (jogadorQtd < 4 && Input.GetKeyDown(KeyCode.Return))
                InstanciarJogador();
        }

        void InstanciarJogador() {
            jogadorQtd++;
            GameObject jogadorGbj = Instantiate<GameObject>(
                jogador, localInicial.position, Quaternion.identity
            );
            jogadorGbj.GetComponent<ControleJogador>().meshRendSlime.material.SetColor(
                "_outline_color", coresContorno[jogadorQtd - 1]
            );
        }
    }
}
