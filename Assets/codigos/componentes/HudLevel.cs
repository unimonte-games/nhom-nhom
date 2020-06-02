using UnityEngine;
using UnityEngine.UI;

namespace NhomNhom
{
    public class HudLevel : MonoBehaviour
    {
        public Text textoCofre;

        public void atualizaCofre(int valor)
        {
            textoCofre.text = valor.ToString();
        }
    }
}
