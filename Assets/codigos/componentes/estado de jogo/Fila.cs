using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class Fila : MonoBehaviour
    {
        public int qtdClientes, qtdClientesSimultaneos, limiteClientesSimultaneos;
        public float intervaloMinimo, intervaloMaximo;
        public GameObject[] clientes;
        public Transform[] fila_trs;
        public HudLevel hudLevel;

        int clientesInstanciados = 0;

        int[] espacosOcupados;

        void Awake() {
            espacosOcupados = new int[fila_trs.Length];
        }

        void Start() {
            StartCoroutine(InstanciarClientes());
        }

        IEnumerator InstanciarClientes() {
            Cadeiras cadeiras = FindObjectOfType<Cadeiras>();

            while (clientesInstanciados < qtdClientes) {
                if (SistemaPausa.pausado)
                    yield return new WaitWhile(() => SistemaPausa.pausado);

                if (qtdClientesSimultaneos < limiteClientesSimultaneos) {
                    var clienteGbj = Instantiate<GameObject>(
                        clientes[Random.Range(0, clientes.Length)],
                        cadeiras.saida.position,
                        Quaternion.identity
                    );
                    clienteGbj.GetComponent<ControleCliente>().id = clientesInstanciados+1;
                    qtdClientesSimultaneos++;
                    clientesInstanciados++;
                    hudLevel.atualizaClientes(clientesInstanciados, qtdClientes);
                }

                yield return new WaitForSeconds(Random.Range(intervaloMinimo, intervaloMaximo));
            }
        }

        public bool AcabouClientes() {
            return clientesInstanciados == qtdClientes && qtdClientesSimultaneos == 0;
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
