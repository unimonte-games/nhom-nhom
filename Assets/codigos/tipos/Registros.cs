using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    //[System.Serializable]
    public class ControlesEixos {
        public string eixoHorizontal;
        public string eixoVertical;
        public string eixoAcao1; // pegar/soltar item
        public string eixoAcao2;
    }

    //[System.Serializable]
    public class ControlesValores {
        public float eixoHorizontal;
        public float eixoVertical;
        public bool eixoAcao1;
        public bool eixoAcao2;
    }

    //[System.Serializable]
    public class Transacao {
        public string entrada; public GameObject saida;
    }
}
