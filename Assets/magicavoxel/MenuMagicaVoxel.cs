using UnityEngine;
using UnityEditor;

namespace NhomNhom {
    namespace IntegracaoMagicaVoxel
    {
        public class MenuMagicaVoxel : EditorWindow
        {
            static Object objDicio, objCena;
            static bool foldoutDicio = true;
            static Vector2 scrollPos;

            [MenuItem("MagicaVoxel/Gerar Cena")]
            public static void GerarCena()
            {
                IntegracaoMagicaVoxel.LerArqPly();
            }

            [MenuItem("MagicaVoxel/Atualizar Cena")]
            public static void AtualizarCena()
            {
                IntegracaoMagicaVoxel.RegerarCena();
            }

            [MenuItem("MagicaVoxel/Configurações")]
            public static void mostrarJanela()
            {
                GetWindow<MenuMagicaVoxel>("Config MagicaVoxel");
            }

            private void OnGUI()
            {
                GUILayout.Label("Arquivos", EditorStyles.boldLabel);

                // Seleção do arquivo de cena
                objCena = EditorGUILayout.ObjectField("Cena", objCena, typeof(Object), false);
                IntegracaoMagicaVoxel.pathCena = AssetDatabase.GetAssetPath(objCena);

                // Seleção do arquivo de dicionário
                objDicio = EditorGUILayout.ObjectField("Dicionário", objDicio, typeof(Object), false);
                IntegracaoMagicaVoxel.pathDicio = AssetDatabase.GetAssetPath(objDicio);

                // Salvar arquivos
                if (GUILayout.Button("Salvar arquivos"))
                {
                    IntegracaoMagicaVoxel.GerenciaConfigs(true);
                    Debug.Log("Configurações salvas");
                }

                GUILayout.Label("Dicionário", EditorStyles.boldLabel);

                // Atualizar dicionário
                if (GUILayout.Button("Atualizar dicionário"))
                    IntegracaoMagicaVoxel.LerArqDicio();

                // Visualização dos  itens do dicionário
                foldoutDicio = EditorGUILayout.Foldout(foldoutDicio, "Entradas no dicionário", true);
                EditorGUI.indentLevel++;
                if (foldoutDicio)
                {
                    scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

                    if (IntegracaoMagicaVoxel.dicionario != null)
                    {
                        GUILayoutOption[] layout = new GUILayoutOption[2];
                        layout[0] = GUILayout.Width(EditorGUIUtility.labelWidth);
                        layout[1] = GUILayout.Height(EditorGUIUtility.singleLineHeight);

                        foreach (var item in IntegracaoMagicaVoxel.dicionario)
                        {
                            // Chave / Valor
                            GUILayout.BeginHorizontal();
                            EditorGUILayout.SelectableLabel(item.Key, EditorStyles.textArea, layout);
                            EditorGUILayout.SelectableLabel(item.Value, EditorStyles.textArea, layout);
                            GUILayout.EndHorizontal();
                        }
                    }
                    else
                        GUILayout.Label("Atualize o dicionário", EditorStyles.centeredGreyMiniLabel);

                    EditorGUILayout.EndScrollView();
                }
            }

            private void OnEnable()
            {
                if (string.IsNullOrEmpty(IntegracaoMagicaVoxel.pathDicio))
                    IntegracaoMagicaVoxel.GerenciaConfigs(false);

                objCena = AssetDatabase.LoadAssetAtPath(
                    IntegracaoMagicaVoxel.pathCena, typeof(Object));

                objDicio = AssetDatabase.LoadAssetAtPath(
                    IntegracaoMagicaVoxel.pathDicio, typeof(Object));
            }
        }
    }
}
