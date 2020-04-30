using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionadorSuave : MonoBehaviour
{
    public float vel;
    public Quaternion rotacaoAlvo;
    public bool atualizar;

    public Transform tr;

    void Update()
    {
        if (atualizar)
            tr.rotation = Quaternion.Lerp(tr.rotation, rotacaoAlvo, Time.deltaTime * vel);
    }
}
