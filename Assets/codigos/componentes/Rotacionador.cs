using UnityEngine;

public class Rotacionador : MonoBehaviour
{
    public string alvo;

    [ContextMenu("vai")]
    public void Rotacionar()
    {
        Vector3[] direcoes = new Vector3[4] {
            Vector3.forward, Vector3.back, Vector3.right, Vector3.left
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
        Gizmos.DrawLine(transform.position, transform.position + Vector3.forward);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.back);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left);
    }
}
