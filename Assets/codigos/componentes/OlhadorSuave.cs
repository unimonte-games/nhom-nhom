using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlhadorSuave : MonoBehaviour
{
    public Vector3 alvo;
    public RotacionadorSuave rotSuave;

    void Update()
    {
        if (!rotSuave.atualizar)
            return;

        // zoado, mas funcional :|
        Quaternion rotBkup = rotSuave.tr.rotation;
        rotSuave.tr.LookAt(alvo);
        rotSuave.rotacaoAlvo = rotSuave.tr.rotation;
        rotSuave.tr.rotation = rotBkup;
    }
}
