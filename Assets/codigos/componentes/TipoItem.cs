using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class TipoItem : MonoBehaviour
    {
        public enum Tipo {
            Pedido, Prato
        }

        public Tipo tipo;
    }
}
