using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class MenuMagicaVoxel : EditorWindow
{
    static Dictionary<string, string> dicionario = new Dictionary<string, string>();
    static Object pathPly, pathDicio;

    [MenuItem("MagicaVoxel/Gerar Cena")]
    public static void GerarCena()
    {
        string auxPath, fullPath;
        auxPath = Application.dataPath;

        fullPath = auxPath + AssetDatabase.GetAssetPath(pathDicio).Remove(0, 6);
        IntegracaoMagicaVoxel.PopularDicionario(ref dicionario, fullPath);

        fullPath = auxPath + AssetDatabase.GetAssetPath(pathPly).Remove(0, 6);
        IntegracaoMagicaVoxel.GerarCena(ref dicionario, fullPath);
    }

    [MenuItem("MagicaVoxel/Configurações")]
    public static void mostrarJanela()
    {
        GetWindow<MenuMagicaVoxel>("Configurações Integração MagicaVoxel");
    }

    private void OnGUI()
    {
        pathPly = EditorGUILayout.ObjectField(pathPly, typeof(Object), false);
        pathDicio = EditorGUILayout.ObjectField(pathDicio, typeof(Object), false);
        GUILayout.Label(Application.dataPath + AssetDatabase.GetAssetPath(pathDicio));
    }
}
