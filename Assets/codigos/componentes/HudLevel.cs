using UnityEngine;
using UnityEngine.UI;

namespace NhomNhom
{
    public class HudLevel : MonoBehaviour
    {
        public HorizontalLayoutGroup painelJogadores;
        public HorizontalLayoutGroup painelFase;
        public Text textoCofre;
        public Text textoClientes;
        public Text[] listaPontuacoes;

        private void Awake()
        {
            foreach (Text text in listaPontuacoes)
                text.transform.parent.gameObject.SetActive(false);

            AtualizarLayout.atualizar(painelFase);
        }

        public void atualizaCofre(int valorParcial, int valorTotal)
        {
            textoCofre.text = string.Concat(valorParcial, "/", valorTotal);
        }

        public void atualizaClientes(int valorParcial, int valorTotal)
        {
            textoClientes.text = string.Concat(valorParcial, "/", valorTotal);
        }

        public void ativaPontuacaoJogador(int indice)
        {
            listaPontuacoes[indice].transform.parent.gameObject.SetActive(true);
            AtualizarLayout.atualizar(painelJogadores);
        }

        public void atualizaPontuacao(int indice, int valorPontuacao)
        {
            listaPontuacoes[indice].text = valorPontuacao.ToString();
        }

        public int[] getPontuacoes()
        {
            int qtdJogadores = 0;
            for (int i = 0; i < 4; i++)
            {
                if (listaPontuacoes[i].transform.parent.gameObject.activeSelf)
                    qtdJogadores++;
            }

            int[] pontuacoes = new int[qtdJogadores];
            for (int i = 0; i < qtdJogadores; i++)
                pontuacoes[i] = int.Parse(listaPontuacoes[i].text);

            return pontuacoes;
        }
    }
}
