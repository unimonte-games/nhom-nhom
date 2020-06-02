using UnityEngine;

namespace NhomNhom
{
    [RequireComponent(typeof(MeshRenderer))]
    public class TrocaMaterial : MonoBehaviour
    {
        public Material[] materiais;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            TrocarMaterial();
        }

        public void TrocarMaterial()
        {
            int random = Random.Range(0, materiais.Length - 1);
            meshRenderer.material = materiais[random];
        }
    }
}
