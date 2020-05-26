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

            AudioClip clip = SistemaEfeitoSonoro.ObterClipe(efeitoSonoro);
            audioSrc.clip = clip;
            audioSrc.Play();

            Destroy(gameObject, audioSrc.clip.length);
        }
    }
}
