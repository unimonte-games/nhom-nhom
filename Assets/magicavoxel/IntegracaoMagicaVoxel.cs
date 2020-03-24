using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace IntegracaoMagicaVoxel
{
    public class IntegracaoMagicaVoxel : MonoBehaviour
    {
        /// <summary>
        /// Lê um arquivo .ply exportado no modo "CloudPoint" pelo MagicaVoxel (não testado em
        /// outros programas) e gera o cenário na Unity, usando as cores dos blocos como códigos
        /// para a substituição pelos modelos referentes
        /// </summary>

        public static Dictionary<string, string> dicionario;
        public static string pathDicio = "Assets/magicavoxel/dicionarioVoxel.txt";
        public static string pathCena = "Assets/magicavoxel/teste.ply";

        public static void PopularDicionario()
        {
            if (dicionario == null) dicionario = new Dictionary<string, string>();
            else dicionario.Clear();

            // Abre o arquivo no caminho completo (remove "Assets" do nome devido a duplicidade)
            var arqRef = new StreamReader(Application.dataPath + pathDicio.Remove(0, 6));

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

        public static void LerArqPly()
        {
            if (dicionario == null) PopularDicionario();

            // Cria obj pai do cenário
            Transform paiCenario = new GameObject("Cenario Importado").transform;

            // Abre o arquivo no caminho completo (remove "Assets" do nome devido a duplicidade)
            var arqPly = new StreamReader(Application.dataPath + pathCena.Remove(0, 6));

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
                string chave = string.Format("{0} {1} {2}", linha[3], linha[4], linha[5]);

                // Instancia o modelo
                InstanciarModelo(chave, posi, paiCenario);

            } while (!arqPly.EndOfStream);
        }

        private static void InstanciarModelo(string chave, Vector3 posi, Transform pai)
        {
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
                        obj.transform.parent = pai;
                    }

                    // Mensagem de erro
                    catch { Debug.LogError("Prefab não encontrado: " + nomePrefab); }
                }
            }

            // Mensagem de erro
            else
                Debug.LogError("Chave não encontrada no dicionário: " + chave);
        }
    }
}
