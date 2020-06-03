using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    public void avancaCena()
    {
        try
        {
            string cenaAtual = SceneManager.GetActiveScene().name;
            int indiceAtual = (int)Enum.Parse(typeof(Cenas), cenaAtual);
            string proxCena = ((Cenas)(indiceAtual + 1)).ToString();
            SceneManager.LoadScene(proxCena);
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
