using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class AdicionarJogadores : MonoBehaviour
    {
        public GameObject jogador;
        public Transform localInicial;
        public Color[] coresContorno = new Color[4];
        public static int jogadorQtd = 1;

        void Awake() {
            ControladorJogador.jogadorNum = 0;
            for (int i = 1; i <= jogadorQtd; i++)
                InstanciarJogador(i);

            if (jogadorQtd > 1)
            IncrementararBalanceamento();
        }

        void Update() {
            if (SistemaPausa.pausado)
                return;

            if (jogadorQtd < 4 && Input.GetKeyDown(KeyCode.Return))
            {
                jogadorQtd++;
                InstanciarJogador(jogadorQtd);
                IncrementararBalanceamento();
            }
        }

        void InstanciarJogador(int numeroJogador) {
            GameObject jogadorGbj = Instantiate<GameObject>(
                jogador, localInicial.position, Quaternion.identity
            );
            jogadorGbj.GetComponent<ControleJogador>().meshRendSlime.material.SetColor(
                "_outline_color", coresContorno[numeroJogador - 1]
            );

            SistemaCamera.DefinirJogador(jogadorGbj.transform, numeroJogador - 1);
        }

        void IncrementararBalanceamento()
        {
            Fila fila = FindObjectOfType<Fila>();
            fila.IncrementarClientes();
            FindObjectOfType<Cofre>().IncrementarObjetivo(fila.qtdClientes);
        }
    }
}
