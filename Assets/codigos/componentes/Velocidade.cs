using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Contém direção, magnitude do vetor de velocidade e relatividade local ou global.
///
/// Através da Callback de Atualização "Update", ele aplica o movimento na direção
/// de "direção" na velocidade "velocidade", relativo ao "relatividade".
public class Velocidade : MonoBehaviour
{
    /// direção do movimento
    [Tooltip("Direção do movimento")]
    public Vector3 direcao;

    /// velocidade do movimento (ou, a magnitude do vetor de movimento)
    [Tooltip("velocidade do movimento (ou, a magnitude do vetor de movimento)")]
    public float velocidade;

    /// Relatividade do movimento, isso é, se usará os eixos locais ou globais
    [Tooltip("Relatividade do movimento, isso é, se usará os eixos locais ou globais")]
    public Space relatividade;

    Transform tr;
    Vector3 vetorVelocidade = new Vector3(0, 0, 0);

    void Awake() {
        tr = GetComponent<Transform>();
    }

    void Update() {
        if (velocidade < 0.01f)
            return;

        float dt = Time.deltaTime;

        vetorVelocidade.x = direcao.x * velocidade * dt;
        vetorVelocidade.y = direcao.y * velocidade * dt;
        vetorVelocidade.z = direcao.z * velocidade * dt;

        tr.Translate(vetorVelocidade, relatividade);
    }
}
