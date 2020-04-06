using UnityEngine;

namespace NhomNhom {
    public class Rotacionador : MonoBehaviour
    {
        public string alvo;

        public void Rotacionar()
        {
            Vector3[] direcoes = new Vector3[4] {
                transform.forward, -transform.forward, transform.right, -transform.right
            };

            RaycastHit hit;
            GbjID idHit;

            for (int i = 0; i < direcoes.Length; i++)
            {
                if (Physics.Raycast(transform.position, direcoes[i], out hit, 1f))
                {
                    idHit = hit.transform.parent.GetComponent<GbjID>();
                    if (idHit != null && idHit.id == alvo)
                    {
                        transform.rotation = Quaternion.LookRotation(direcoes[i]);
                        break;
                    }
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward);
            Gizmos.DrawLine(transform.position, transform.position - transform.forward);
            Gizmos.DrawLine(transform.position, transform.position + transform.right);
            Gizmos.DrawLine(transform.position, transform.position - transform.right);
        }
    }

}
