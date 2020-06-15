using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

namespace NhomNhom {
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
            public static string pathDicio;
            public static string pathCena;

            public static void GerenciaConfigs(bool sobrescrever)
            {
                string arqPath = Application.dataPath + "/magicavoxel/.configply";

                try
                {
                    if (sobrescrever)
                    {
                        var arqConfig = new StreamWriter(arqPath);
                        arqConfig.WriteLine(pathCena);
                        arqConfig.WriteLine(pathDicio);
                        arqConfig.Close();
                    }
                    else
                    {
                        var arqConfig = new StreamReader(arqPath);
                        pathCena = arqConfig.ReadLine();
                        pathDicio = arqConfig.ReadLine();
                        arqConfig.Close();
                    }
                }
                catch
                { Debug.LogError("Erro ao acessar configurações do MagicaVoxel"); }
            }

            public static void RegerarCena()
            {
                // Encontra o obj com o nome especificado
                GameObject gbCenario = GameObject.Find("Cenario Importado");

                // Aborta caso o objeto não exista
                if (gbCenario == null) return;

                // Encontra o prefab mais proximo do obj e o carrega na memória
                string prefabPath = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(gbCenario.transform.parent);
                GameObject prefab = PrefabUtility.LoadPrefabContents(prefabPath);

                // Encontra o obj com o nome especificado dentro do prefab
                gbCenario = prefab.transform.Find("Cenario Importado").gameObject;

                // Executa o script e define o obj de retorno como filho do prefab
                Transform novoCenario = LerArqPly(gbCenario);
                novoCenario.parent = prefab.transform;

                // Salva as alterações e descarrefa o prefab da memória
                PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
                PrefabUtility.UnloadPrefabContents(prefab);
            }

            public static void LerArqDicio()
            {
                if (dicionario == null) dicionario = new Dictionary<string, string>();
                else dicionario.Clear();

                if (string.IsNullOrEmpty(pathDicio))
                    GerenciaConfigs(false);

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

                arqRef.Close();
            }

            public static Transform LerArqPly(GameObject cenarioAntigo = null)
            {
                /*var objsParaRot = new List<Rotacionador>();

                // Atualiza o dicionário
                LerArqDicio();

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
                    InstanciarModelo(chave, posi, paiCenario, ref objsParaRot);

                } while (!arqPly.EndOfStream);

                arqPly.Close();

                if (cenarioAntigo != null)
                {
                    paiCenario.position = cenarioAntigo.transform.position;
                    paiCenario.rotation = cenarioAntigo.transform.rotation;
                    DestroyImmediate(cenarioAntigo);
                }

                // Rotaciona os filhos
                foreach (Rotacionador obj in objsParaRot)
                    obj.Rotacionar();

                return paiCenario;*/
                return GameObject.FindWithTag("MainCamera").transform;
            }

            /*private static void InstanciarModelo(string chave, Vector3 posi, Transform pai, ref List<Rotacionador> lista)
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
                            GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(
                                Resources.Load(@"magicavoxel/prefabs/Moveis_" + nomePrefab)) as GameObject;
                            obj.transform.localPosition = posi;
                            obj.transform.parent = pai;

                            // Adiciona objs com o componente Rotacionador na lista
                            var rot = obj.GetComponent<Rotacionador>();
                            if (rot) lista.Add(rot);
                        }

                        // Mensagem de erro
                        catch { Debug.LogError("Prefab não encontrado: " + nomePrefab); }
                    }
                }

                // Mensagem de erro
                else
                {
                    Debug.LogWarning("Chave não encontrada no dicionário: " + chave);

                    GameObject obj = Instantiate(
                                Resources.Load(@"magicavoxel/prefabs/debug")) as GameObject;
                    obj.transform.position = posi;
                    obj.transform.parent = pai;
                }
            }*/
        }
    }
}
