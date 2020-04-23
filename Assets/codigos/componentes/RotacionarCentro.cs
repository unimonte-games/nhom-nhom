using UnityEngine;

namespace NhomNhom
{
    public class RotacionarCentro : MonoBehaviour
{
    public bool verificarEixoZ;

    [ContextMenu("Rotação Manual")]
    public void Rotacionar()
    {
        Vector3 direcao;

        if (verificarEixoZ)
        {
            if (transform.localPosition.z < transform.parent.localPosition.z)
                direcao = transform.forward;
            else
                direcao = -transform.forward;
        }
        else
        {
            if (transform.localPosition.x < transform.parent.localPosition.x)
                direcao = transform.right;
            else
                direcao = -transform.right;
        }

        transform.rotation = Quaternion.LookRotation(direcao);
    }
}
}
