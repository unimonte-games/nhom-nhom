using System.Collections;
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
                if (transform.localPosition.x > transform.parent.localPosition.x)
                    direcao = transform.parent.right;
                else
                    direcao = -transform.parent.right;
            }
            else
            {
                if (transform.localPosition.z > transform.parent.localPosition.z)
                    direcao = transform.parent.forward;
                else
                    direcao = -transform.parent.forward;
            }

            transform.rotation = Quaternion.LookRotation(direcao);
        }
    }
}
