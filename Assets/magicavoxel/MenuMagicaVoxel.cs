using UnityEngine;
using UnityEditor;
using System.IO;

namespace IntegracaoMagicaVoxel
{
    public class MenuMagicaVoxel : EditorWindow
    {
        static Object objDicio, objCena;

        [MenuItem("MagicaVoxel/Gerar Cena")]
        public static void GerarCena()
        {
            IntegracaoMagicaVoxel.LerArqPly();
        }

        [MenuItem("MagicaVoxel/Configurações")]
        public static void mostrarJanela()
        {
            GetWindow<MenuMagicaVoxel>("Config MagicaVoxel");
        }

        private void OnGUI()
        {
            GUILayout.Label("Arquivos", EditorStyles.boldLabel);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Cena:");
            objCena = EditorGUILayout.ObjectField(objCena, typeof(Object), false);
            IntegracaoMagicaVoxel.pathCena = AssetDatabase.GetAssetPath(objCena);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Dicionário:");
            objDicio = EditorGUILayout.ObjectField(objDicio, typeof(Object), false);
            IntegracaoMagicaVoxel.pathDicio = AssetDatabase.GetAssetPath(objDicio);
            GUILayout.EndHorizontal();

            // Botão de popular o dicionário
            if (GUILayout.Button("Atualizar Dicionário"))
                IntegracaoMagicaVoxel.PopularDicionario();

            // Visualização dos  itens do dicionário
            GUILayout.Label("Entradas no dicionário:", EditorStyles.foldout);
            if (IntegracaoMagicaVoxel.dicionario != null)
                foreach (var item in IntegracaoMagicaVoxel.dicionario)
                    EditorGUILayout.SelectableLabel(item.Key + " : " + item.Value);
        }

        private void OnEnable()
        {
            objCena = AssetDatabase.LoadAssetAtPath(
                IntegracaoMagicaVoxel.pathCena, typeof(Object));

            objDicio = AssetDatabase.LoadAssetAtPath(
                IntegracaoMagicaVoxel.pathDicio, typeof(Object));
        }
    }
}
