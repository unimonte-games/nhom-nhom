using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fila : MonoBehaviour
{
    public Transform[] fila_trs;
    int[] espacosOcupados;

    void Awake() {
        espacosOcupados = new int[fila_trs.Length];
    }

    public void AbrirVaga(int id) {
        for (int i = 0; i < espacosOcupados.Length; i++) {
            if (espacosOcupados[i] == id) {
                espacosOcupados[i] = 0;
                break;
            }
        }

        StartCoroutine(CO_AtualizaLista());
    }

    public int RegistraEspaco(int id) {
        for (int i = 0; i < espacosOcupados.Length; i++) {
            if (espacosOcupados[i] == 0) {
                espacosOcupados[i] = id;
                return i;
            }
        }

        return -1;
    }

    public int ObtemIndicePorID(int id, int i) {
        if (espacosOcupados[i] == id)
            return i;
        for (int x = 0; x < espacosOcupados.Length; x++) {
            if (espacosOcupados[x] == id)
                return x;
        }
        return -1;
    }


    IEnumerator CO_AtualizaLista() {
        for (int i = 0; i < espacosOcupados.Length-1; i++) {
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            if (espacosOcupados[i] == 0) {
                espacosOcupados[i] = espacosOcupados[i+1];
                espacosOcupados[i+1] = 0;
            }
        }
    }
}
