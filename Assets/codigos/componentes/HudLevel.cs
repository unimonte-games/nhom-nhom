using UnityEngine;
using UnityEngine.UI;

public class HudLevel : MonoBehaviour
{
    public Text textoCofre;

    public void atualizaCofre(int valor)
    {
        textoCofre.text = valor.ToString();
    }
}
