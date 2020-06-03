using UnityEngine;
using UnityEngine.UI;

namespace NhomNhom
{
    public class HudLevel : MonoBehaviour
    {
        public Text textoCofre;
        public Cofre cofre;

        public void atualizaCofre()
        {
            textoCofre.text = string.Concat(cofre.cofreFase, "/", cofre.cofreObjetivo);
        }
    }
}
