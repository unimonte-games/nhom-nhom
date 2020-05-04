using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionarJogadores : MonoBehaviour
{
    public GameObject jogador;
    public Transform localInicial;
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
        Instantiate(jogador, localInicial.position, Quaternion.identity);
    }
}
