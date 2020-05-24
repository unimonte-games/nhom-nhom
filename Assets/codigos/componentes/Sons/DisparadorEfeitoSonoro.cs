using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class DisparadorEfeitoSonoro : MonoBehaviour
    {
        public EfeitoSonoro efeitoSonoro;
        AudioSource audioSrc;

        void Awake() {
            audioSrc = GetComponent<AudioSource>();
        }

        public void Emitir() {
            transform.position = Camera.main.transform.position;

            audioSrc.clip = SistemaEfeitoSonoro.ObterClipe(efeitoSonoro);
            audioSrc.Play();

            Destroy(gameObject, audioSrc.clip.length);
        }
    }
}
