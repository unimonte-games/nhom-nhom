using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformacaoLerp : MonoBehaviour
{
    public bool ativo;
    public bool transformarPosicao, transformarRotacao, transformarEscala;

    public Vector3[] vetoresPRE0 = new Vector3[3];
    public Vector3[] vetoresPRE1 = new Vector3[3];

    [Range(0, 1)] public float t;

    Transform tr;

    void Awake() {
        tr = GetComponent<Transform>();
    }

    public void Update() {
        if (!ativo)
            return;

        if (transformarPosicao)
            tr.localPosition = Vector3.Lerp(vetoresPRE0[0], vetoresPRE1[0], t);

        if (transformarRotacao)
            tr.localEulerAngles = Vector3.Lerp(vetoresPRE0[1], vetoresPRE1[1], t);

        if (transformarEscala)
            tr.localScale = Vector3.Lerp(vetoresPRE0[2], vetoresPRE1[2], t);
    }
}
