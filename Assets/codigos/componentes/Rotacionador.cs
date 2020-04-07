using UnityEngine;

namespace NhomNhom {
    public class Rotacionador : MonoBehaviour
    {
        [Tooltip("Deixe em branco para apontar para um espaço vazio. Para mais de 1 valor separe-os por ';'")]
        public string alvo;

        [ContextMenu("Rotação Manual")]
        public void Rotacionar()
        {
            Vector3[] direcoes = new Vector3[4] {
                transform.forward, -transform.forward, transform.right, -transform.right
            };

            RaycastHit hit;
            GbjID idHit;
            bool achou = false;

            string[] alvos = alvo.Split(';');

            for (int j = 0; j < alvos.Length; j++)
            {
                for (int i = 0; !achou && i < direcoes.Length; i++)
                {
                    // Verifica ID caso encontre um obj
                    if (Physics.Raycast(transform.position, direcoes[i], out hit, 1f))
                    {
                        idHit = hit.transform.GetComponent<GbjID>();
                        if (idHit.id == alvos[j]) achou = true;
                    }
                    // Verifica se não contém alvo (rotaciona para um espaço vazio)
                    else if (alvo == "") achou = true;

                    // Aponta o obj na direção atual
                    if (achou)
                        transform.rotation = Quaternion.LookRotation(direcoes[i]);
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
