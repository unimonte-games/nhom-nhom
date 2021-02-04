using UnityEngine;

namespace NhomNhom {
    public class Cofre : MonoBehaviour
    {
        public static int cofreGeral;
        public int cofreFase, cofreObjetivo;
        public HudLevel hudLevel;
        private int[] pontuacaoJogadores;

        private void Awake()
        {
            pontuacaoJogadores = new int[4];
            Pagar(0);    
        }

        public void Pagar(int recompensa) {
            cofreFase += recompensa;
            hudLevel.atualizaCofre(cofreFase, cofreObjetivo);
        }

        public void IncrementarObjetivo(int qtdClientes)
        {
            // Preço do pedido base considerado como 12
            cofreObjetivo = (int) (qtdClientes * 0.95 * 12);
            Pagar(0);
        }

        public void adicionaPontuacao(int indice, float valor)
        {
            pontuacaoJogadores[indice] += (int) valor;
            hudLevel.atualizaPontuacao(indice, pontuacaoJogadores[indice]);
        }
    }
}
