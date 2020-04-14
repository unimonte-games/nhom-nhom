using UnityEngine;

public class RotacionarCentro : MonoBehaviour
{
    [ContextMenu("Rotação Manual")]
    public void Rotacionar()
    {
        float deltaX = transform.localPosition.x;
        float deltaZ = transform.localPosition.z;

        Vector3 direcao;
        float maior;

        if (deltaX > deltaZ)
        {
            direcao = Vector3.right;
            maior = deltaX;
        }
        else
        {
            direcao = Vector3.forward;
            maior = deltaZ;
        }

        if (maior > 0) direcao = -direcao;

        transform.rotation = Quaternion.LookRotation(direcao);
    }
}
