using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class Fila : MonoBehaviour
    {
        public GameObject[] clientes;
        public Transform[] fila_trs;
        int[] espacosOcupados;

        void Awake() {
            espacosOcupados = new int[fila_trs.Length];
        }

        void Start() {
            StartCoroutine(InstanciarClientes());
        }

        IEnumerator InstanciarClientes() {
            Cadeiras cadeiras = FindObjectOfType<Cadeiras>();

            for (int i = 0; i < clientes.Length; i++) {
                var clienteGbj = Instantiate<GameObject>(clientes[i], cadeiras.saida.position, Quaternion.identity);
                clienteGbj.GetComponent<ControleCliente>().id = i+1;

                yield return new WaitForSeconds(Random.Range(1f, 2f));
            }
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
            int ultimo_ocupado = -1;

            for (int i = 0; i < espacosOcupados.Length; i++)
                if (espacosOcupados[i] != 0)
                    ultimo_ocupado = i;

            if (ultimo_ocupado == espacosOcupados.Length - 1) // está lotado
                return -1;

            int vaga_i = ultimo_ocupado + 1;
            espacosOcupados[vaga_i] = id;
            return vaga_i;
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
                yield return new WaitForSeconds(0.5f); // WaitForEndOfFrame();
                if (espacosOcupados[i] == 0) {
                    espacosOcupados[i] = espacosOcupados[i+1];
                    espacosOcupados[i+1] = 0;
                }
            }
        }
    }
}
