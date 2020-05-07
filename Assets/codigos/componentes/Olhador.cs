using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olhador : MonoBehaviour
{
    public bool ativo;
    public Transform alvo;
    Transform tr;

    void Awake() {
        tr = GetComponent<Transform>();
    }

    public void Update() {
        if (!ativo || !tr || !alvo)
            return;
        tr.LookAt(alvo);
    }
}
