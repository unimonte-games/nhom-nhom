using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class Cofre : MonoBehaviour
    {
        public static int cofreGeral;
        public int cofreFase, cofreObjetivo;
        public HudLevel hudLevel;

        public void Pagar(int recompensa) {
            cofreFase += recompensa;
            hudLevel.atualizaCofre(cofreFase);
        }
    }
}
