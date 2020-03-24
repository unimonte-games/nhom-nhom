using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class IntegracaoMagicaVoxel : MonoBehaviour
{
    /// <summary>
    /// Lê um arquivo .ply exportado no modo "CloudPoint" pelo MagicaVoxel (não testado em
    /// outros programas) e gera o cenário na Unity, usando as cores dos blocos como códigos
    /// para a substituição pelos modelos referentes
    /// </summary>

    public static void PopularDicionario(ref Dictionary<string, string> dicionario, string path)
    {
        var arqRef = new StreamReader(path);

        try
        {
            string[] linha;
            do
            {
                linha = arqRef.ReadLine().Split(':');
                dicionario.Add(linha[0], linha[1]);

            } while (!arqRef.EndOfStream);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Erro ao analizar o arquivo de dicionário para o MagicaVoxel\n" + e);
        }
    }

    public static void GerarCena(ref Dictionary<string, string> dicionario, string path)
    {
        Debug.Log("Gerando a Cena...");
        // ----------------------------------
        //
            
        var arqPly = new StreamReader(path);

        Transform paiCenario = new GameObject("Cenario Importado").transform;

        // Pula o cabeçalho do arquivo
        while (arqPly.ReadLine() != "end_header") ;

        // Lê a disposição dos cubos
        string[] linha;
        do
        {
            linha = arqPly.ReadLine().Split(' ');

            // Popular posição
            Vector3 posi = new Vector3();
            posi.x = int.Parse(linha[0]);
            posi.z = int.Parse(linha[1]);
            posi.y = int.Parse(linha[2]);

            // Popular chave
            var chave = String.Format("{0} {1} {2}", linha[3], linha[4], linha[5]);

            // Verifica se a chave está presente no dicionário
            string nomePrefab;
            if (dicionario.ContainsKey(chave))
            {
                nomePrefab = dicionario[chave];

                if (nomePrefab != "vazio")
                {
                    try
                    {
                        // Instancia Prefab na posição correta
                        GameObject obj = Instantiate(
                            Resources.Load(@"magicavoxel/prefabs/" + nomePrefab)) as GameObject;
                        obj.transform.position = posi;
                        obj.transform.parent = paiCenario;
                    }

                    // Mensagem de erro
                    catch { Debug.LogError("Prefab não encontrado: " + nomePrefab); }
                }
            }

            // Mensagem de erro
            else
                Debug.LogError("Chave não encontrada no dicionário: " + chave);

        } while (!arqPly.EndOfStream);

        //
        // ----------------------------------
        Debug.Log("Cena gerada!");
    }
}
