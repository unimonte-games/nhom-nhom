using UnityEngine;
using UnityEngine.UI;

namespace NhomNhom 
{
    public class MenuRelatorio : MonoBehaviour
    {
        public Cofre cofre;
        public Sprite[] slimotes = new Sprite[3];
        public Sprite[] estrelas = new Sprite[3];
        public Text textoCofreFase;
        public Text textoCofreTotal;
        public Image elementoSlimotes;
        public Image elementoEstrelas;

        private void Awake()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        public void mostraRelatorio()
        {
            SistemaPausa.ForcarPausa();
            transform.GetChild(0).gameObject.SetActive(true);

            int pontuacao;
            if (cofre.cofreFase <= 0.33 * cofre.cofreObjetivo)
                pontuacao = 0;
            else if (cofre.cofreFase <= 0.66 * cofre.cofreObjetivo)
                pontuacao = 1;
            else
                pontuacao = 2;

            // Desenha elementos
            elementoSlimotes.sprite = slimotes[pontuacao];
            elementoEstrelas.sprite = estrelas[pontuacao];
            textoCofreFase.text = cofre.cofreFase + "/" + cofre.cofreObjetivo;
            textoCofreTotal.text = string.Format("{0}\n{1}\n____________ +\n{2}",
                cofre.cofreFase, Cofre.cofreGeral, cofre.cofreFase + Cofre.cofreGeral);

            // Adiciona o dinheiro ganho na fase ao dinheiro total
            Cofre.cofreGeral += cofre.cofreFase;
        }
    }
}