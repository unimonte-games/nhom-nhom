using UnityEngine;
using UnityEngine.UI;

namespace NhomNhom
{
    public class HudLevel : MonoBehaviour
    {
        public Text textoCofre;
        public Text textoClientes;

        public void atualizaCofre(int valorParcial, int valorTotal)
        {
            textoCofre.text = string.Concat(valorParcial, "/", valorTotal);
        }

        public void atualizaClientes(int valorParcial, int valorTotal)
        {
            textoClientes.text = string.Concat(valorParcial, "/", valorTotal);
        }
    }
}
