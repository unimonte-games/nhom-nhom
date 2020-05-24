using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class SistemaEfeitoSonoro : MonoBehaviour
    {
        public GameObject prefabEfeitoSonoro;
        public AudioClip[] sonsEfeitosSonoros;

        static SistemaEfeitoSonoro singleton;

        void Awake() {
            singleton = this;
        }

        public static AudioClip ObterClipe(EfeitoSonoro efeito) {
            if (singleton)
                return singleton._ObterClipe(efeito);
            return null;
        }

        AudioClip _ObterClipe(EfeitoSonoro efeito) {
            return sonsEfeitosSonoros[(int)efeito];
        }

        public static void Disparar(EfeitoSonoro efeito) {
            singleton._Disparar(efeito);
        }

        void _Disparar(EfeitoSonoro efeito) {
            GameObject novoEfeitoSonoro = Instantiate<GameObject>(
                prefabEfeitoSonoro, Vector3.zero, Quaternion.identity
            );

            DisparadorEfeitoSonoro dispEfeitoSonoro = novoEfeitoSonoro.GetComponent<DisparadorEfeitoSonoro>();
            dispEfeitoSonoro.efeitoSonoro = efeito;
            dispEfeitoSonoro.Emitir();
        }
    }
}
