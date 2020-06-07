using UnityEngine;

namespace NhomNhom {
    public class Cofre : MonoBehaviour
    {
        public static int cofreGeral;
        public int cofreFase, cofreObjetivo;
        public HudLevel hudLevel;

        private void Awake()
        {
            Pagar(0);    
        }

        public void Pagar(int recompensa) {
            cofreFase += recompensa;
            hudLevel.atualizaCofre(cofreFase, cofreObjetivo);
        }

        public void IncrementarObjetivo(int qtdClientes)
        {
            // Preço do pedido base considerado como 12
            cofreObjetivo = (int) (qtdClientes * 0.8 * 12);
            Pagar(0);
        }
    }
}
