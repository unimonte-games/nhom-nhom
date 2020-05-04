using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentarShaderStd : MonoBehaviour
{
    public Transform luzDirecional, direcaoCamera;
    public Material[] matsSlimes, matsCenarios;

    void Start() {
        Atualizar();
    }

    void OnValidate() {
        Atualizar();
    }

    [ContextMenu("Atualizar")]
    void Atualizar() {
        if (!luzDirecional | !direcaoCamera || matsSlimes.Length == 0 || matsCenarios.Length == 0)
            return;

        for (int i = 0; i < matsSlimes.Length; i++) {
            Material mat = matsSlimes[i];
            if (mat)
                mat.SetVector("_light_dir", luzDirecional.forward.normalized * -1);
        }

        // for (int i = 0; i < matsCenarios.Length; i++) {
        //     Material mat = matsCenarios[i];
        //     if (mat)
        //         mat.SetVector("_cam_dir", direcaoCamera.forward.normalized * 1);
        // }
    }

    void OnDrawGizmos() {
        Atualizar();
    }
}
