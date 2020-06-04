using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NhomNhom 
{
    public class MenuRelatorio : MonoBehaviour
    {
        public GameObject itemSelecionado;
        public Cofre cofre;
        public Sprite[] slimotes = new Sprite[4];
        public Sprite[] estrelas = new Sprite[3];
        public Text textoCofreFase;
        public Text textoCofreAntigo;
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

            // Adiciona o dinheiro ganho na fase ao dinheiro total
            Cofre.cofreGeral += cofre.cofreFase;
        }
    }
}