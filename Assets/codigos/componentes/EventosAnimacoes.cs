using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class EventosAnimacoes : MonoBehaviour
    {
        public void AnimMomento(string animNome) {
            switch (animNome)
            {
                case "slime-passo-1":
                case "slime-passo-2":
                    SistemaEfeitoSonoro.Disparar(EfeitoSonoro.SlimePasso);
                    break;
            }
        }
    }
}
