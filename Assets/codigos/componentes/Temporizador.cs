using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class Temporizador : MonoBehaviour
    {
        public GameObject tempoGbj;
        public MeshRenderer meshRend1, meshRend2;
        float t;

        public void Iniciar(float duracao) {
            t = 0;
            tempoGbj.SetActive(true);
            StartCoroutine(CO_Processo(duracao));
        }

        IEnumerator CO_Processo(float duracao) {
            float tempoPassado = 0;
            while (t < 1f) {
                yield return new WaitWhile(() => SistemaPausa.pausado);

                tempoPassado += Time.deltaTime;
                t = tempoPassado / duracao;

                if (meshRend1 && meshRend2) {
                    float _t = Mathf.Clamp(1 - t, 0.0001f, 0.9999f);
                    meshRend1.material.SetFloat("_Cutoff", _t);
                    meshRend2.material.SetFloat("_Cutoff", _t);
                }

                yield return new WaitForEndOfFrame();
            }
            tempoGbj.SetActive(false);
        }
    }
}
