using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NhomNhom 
{
    public class MenuRelatorio : MonoBehaviour
    {
        public HudLevel hudLevel;
        public GameObject itemSelecionado;
        public Cofre cofre;
        public Sprite[] slimotes = new Sprite[4];
        public Sprite[] estrelas = new Sprite[3];
        public Text textoCofreFase;
        public Text textoCofreAntigo;
        public Text textoCofreTotal;
        public Image elementoSlimotes;
        public Image elementoEstrelas;
        public Transform painelPontuacoes;
        public GameObject[] relatorioJogadores;

        private void Awake()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        public void mostraRelatorio()
        {
            SistemaPausa.ForcarPausa();
            transform.GetChild(0).gameObject.SetActive(true);
            FindObjectOfType<EventSystem>().SetSelectedGameObject(itemSelecionado);

            int pontuacao;
            if (cofre.cofreFase <= 0.33 * cofre.cofreObjetivo)
                pontuacao = 0;
            else if (cofre.cofreFase <= 0.66 * cofre.cofreObjetivo)
                pontuacao = 1;
            else if (cofre.cofreFase <= cofre.cofreObjetivo)
                pontuacao = 2;
            else
                pontuacao = 3;

            // Desenha elementos
            elementoSlimotes.sprite = slimotes[pontuacao];
            elementoEstrelas.sprite = estrelas[pontuacao == 3 ? 2 : pontuacao];

            textoCofreFase.text = cofre.cofreFase + "/" + cofre.cofreObjetivo;
            textoCofreAntigo.text = Cofre.cofreGeral.ToString();
            textoCofreTotal.text = (cofre.cofreFase + Cofre.cofreGeral).ToString();

            atualizaPontuacoes();

            // Adiciona o dinheiro ganho na fase ao dinheiro total
            Cofre.cofreGeral += cofre.cofreFase;
        }

        public void atualizaPontuacoes()
        {
            int[] pontuacoes = hudLevel.getPontuacoes();
            int[] posicoes = new[] { 1, 2, 3, 4 };
            System.Array.Sort(pontuacoes, posicoes);

            int colocacao = 1;
            int ultimaPontuacao = pontuacoes[pontuacoes.Length - 1];
            for (int i = pontuacoes.Length - 1; i >= 0 ; i--)
            {
                GameObject gbj = Instantiate(relatorioJogadores[posicoes[i] - 1], painelPontuacoes);
                Text texto = gbj.GetComponentInChildren<Text>();

                if (ultimaPontuacao != pontuacoes[i]) colocacao++;
                texto.text = string.Format("#{0}\n{1}", colocacao, pontuacoes[i]);
                ultimaPontuacao = pontuacoes[i];
            }

            var painel = painelPontuacoes.GetComponent<HorizontalLayoutGroup>();
            AtualizarLayout.atualizar(painel);
        }
    }
}