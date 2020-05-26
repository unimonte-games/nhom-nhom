using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olhador : MonoBehaviour
{
    public bool ativo, iniciarOlhandoCamera;
    public Transform alvo;
    Transform tr;

    void Awake() {
        tr = GetComponent<Transform>();
    }

    void Start() {
        if (iniciarOlhandoCamera)
            alvo = Camera.main.transform;
    }

    public void Update() {
        if (!ativo || !tr || !alvo)
            return;

        tr.LookAt(alvo);
    }
}
