using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolhaCliente : MonoBehaviour
{
    [System.Serializable]
    public struct TuplaSpriteString {
        public string str;
        public Sprite sprite;
        public Sprite spriteCor;
    }

    public TuplaSpriteString[] comidaSprites;
    public SpriteRenderer comidaSprite, comidaSpriteCor;

    public Olhador olhador;
    public TransformacaoLerp trLerp;
    public float velocidadeBolha;

    void Start() {
        olhador.alvo = Camera.main.transform;
    }

    [ContextMenu("Testar Exibir")]
    public void Exibir() {
        StartCoroutine(CO_DeslizarTransformacao(1));
    }

    [ContextMenu("Testar Ocultar")]
    public void Ocultar() {
        StartCoroutine(CO_DeslizarTransformacao(0));
    }

    public void DefinirImgPrato(string pratoId, Color cor) {
        for (int i = 0; i < comidaSprites.Length; i++)
            if (comidaSprites[i].str == pratoId) {
                comidaSprite.sprite = comidaSprites[i].sprite;
                comidaSpriteCor.sprite = comidaSprites[i].spriteCor;
                comidaSpriteCor.color = cor;
            }
    }

    IEnumerator CO_DeslizarTransformacao(float end) {
        float _t = 0f;
        float start = Mathf.Abs(end - 1f);

        trLerp.ativo = true;

        while (_t < 1f) {
            trLerp.t = Mathf.Lerp(start, end, _t);
            _t += Time.deltaTime * velocidadeBolha;
            yield return new WaitForEndOfFrame();
        }

        trLerp.t = end;
        yield return new WaitForEndOfFrame();
        trLerp.ativo = false;
    }
}
