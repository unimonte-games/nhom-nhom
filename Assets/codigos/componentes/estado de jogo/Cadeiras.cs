using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class Cadeiras : MonoBehaviour
    {
        public bool podeEntrar;
        public Transform trRaiz, saida;
        [Header("Auto Gerado:")]
        public Transform[] trFolhas;
        public bool[] b_trFolhas;

    #if UNITY_EDITOR
        [Space(10)]
        [SerializeField] bool __DEV_AutoValidar;
    #endif // UNITY_EDITOR

        public void AbrirVaga(Transform folha) {
            for (int i = 0; i < trFolhas.Length; i++)
                if (trFolhas[i] == folha) {
                    b_trFolhas[i] = false;
                    break;
                }
        }

        public bool HaVagas() {
            for (int i = 0; i < b_trFolhas.Length; i++)
                if (!b_trFolhas[i]) {
                    return true;
                }

            return false;
        }

        public Transform[] ObterRotaSaida(Transform folha) {
            List<Transform> rota = new List<Transform>();

            Transform pai = folha;

            while (pai != saida) {
                if (pai == null)
                    Debug.Break(); // impedindo o travamento do Unity :)

                rota.Add(pai);
                pai = pai.parent;
            }

            rota.Add(saida);
            return rota.ToArray();
        }

        public Transform[] ObterRota() {
            podeEntrar = false;
            Transform folha = trRaiz;

            for (int i = 0; i < b_trFolhas.Length; i++) {
                if (!b_trFolhas[i]) {
                    folha = trFolhas[i];
                    b_trFolhas[i] = true;
                    break;
                }
            }

            List<Transform> rota = new List<Transform>();
            BuscaRota(rota, trRaiz, folha);

            return rota.ToArray();
        }

        bool BuscaRota(List<Transform> l, Transform i_tr, Transform folhaAlvo) {
            l.Add(i_tr);

            int cc = i_tr.childCount;

            if (cc == 0) { // é folha
                if (i_tr == folhaAlvo) {
                    return true;
                } else {
                    l.Remove(i_tr);
                    return false;
                }
            } else { // galho
                for (int i = 0; i < cc; i++) {
                    if (BuscaRota(l, i_tr.GetChild(i), folhaAlvo))
                        return true;
                }
                l.Remove(i_tr);
                return false;
            }
        }

        void Start() {
            StartCoroutine(CO_AtualizaPodeEntrar());
        }

        IEnumerator CO_AtualizaPodeEntrar() {
            while(true) {
                podeEntrar = HaVagas();
                yield return new WaitForSeconds(Random.Range(1f, 3f));
            }
        }

    #if UNITY_EDITOR
        void __DEV_ObtemFolhas(List<Transform> l, Transform i_tr) {
            int cc = i_tr.childCount;

            if (cc == 0)
                l.Add(i_tr);
            else
                for (int i = 0; i < cc; i++)
                    __DEV_ObtemFolhas(l, i_tr.GetChild(i));
        }

        void OnValidate() {
            if (!__DEV_AutoValidar || !trRaiz)
                return;

            List<Transform> l = new List<Transform>();
            __DEV_ObtemFolhas(l, trRaiz);
            trFolhas = l.ToArray();
            b_trFolhas = new bool[trFolhas.Length];
        }
    #endif // UNITY_EDITOR
    }
}
