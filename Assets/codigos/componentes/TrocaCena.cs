using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NhomNhom
{
    public class TrocaCena : MonoBehaviour
    {
        public void avancaCena()
        {
            try
            {
                string cenaAtual = SceneManager.GetActiveScene().name;
                int indice = (int) Enum.Parse(typeof(Cenas), cenaAtual);

                indice++;
                int qtdCenas = Enum.GetValues(typeof(Cenas)).Length;
                Cenas proxCena = indice > qtdCenas -2 ? (Cenas)(-1) : (Cenas)indice;

                SceneManager.LoadScene(proxCena.ToString());
            }
            catch (Exception e)
            {
                Debug.LogError("Não foi possível localizar a próxima cena. " + e);
            }
        }

        public void carregaCena(int index)
        {
            string cena = ((Cenas)index).ToString();
            SceneManager.LoadScene(cena);
        }

        public void recarregaCena()
        {
            string cenaAtual = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(cenaAtual);
        }

        public void fechaCena()
        {
            Application.Quit();
        }
    }
}