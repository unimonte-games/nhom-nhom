using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class PagamentoFeedback : MonoBehaviour
    {
        public TransformacaoLerp trLerp;
        public SpriteRenderer sprRend;
        public Sprite[] spritesRecompensa;
        public float duracaoAparecer, duracaoPermanencia;

        bool apareceuCompleto;
        float tInicio, tAtual;

        public void Iniciar(int recompensaIdx) {
            trLerp.ativo = true;
            tInicio = Time.time;
            sprRend.sprite = spritesRecompensa[recompensaIdx];
            sprRend.enabled = true;
        }

        void Update() {
            if (SistemaPausa.pausado)
                return;

            if (!trLerp.ativo)
                return;

            tAtual = Time.time;
            float diff = tAtual - tInicio;
            float t = 0;

            if (!apareceuCompleto) {
                if (diff <= duracaoAparecer) {
                    t = diff / duracaoAparecer;
                    trLerp.t = t;
                } else {
                    apareceuCompleto = true;
                    trLerp.t = 1;
                    tInicio = Time.time;
                }
            } else {
                float duracaoPermanencia2x = duracaoPermanencia * 2;
                if (diff <= duracaoPermanencia2x) {
                    t = diff / duracaoPermanencia2x;
                    t = t*2 - 1; // [0, 1]*2 - 1 -> [0, 2] - 1 -> [-1, 1]
                    if (t >= 0f) { // logo fica metade do tempo sem fazer nada
                        Color c = sprRend.color;
                        c.a = 1 - t; // 1 - [0, 1] -> [1, 0]
                        sprRend.color = c;
                    }
                } else {
                    Color c = sprRend.color;
                    c.a = 0;
                    sprRend.color = c;
                    trLerp.ativo = false;
                }
            }
        }
    }
}
