﻿using System;
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
                Cenas proxCena = indice > qtdCenas -1 ? 0 : (Cenas)indice;

                SceneManager.LoadScene(proxCena.ToString());
            }
            catch (Exception e)
            {
                Debug.LogError("Não foi possível localizar a próxima cena. " + e);
            }
        }

        public void carregaCena(int index)
        {
            if (index == 0)
            {
                AdicionarJogadores.jogadorQtd = 1;
                Cofre.cofreGeral = 0;
            }
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