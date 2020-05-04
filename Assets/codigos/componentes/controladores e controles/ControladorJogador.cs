using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class ControladorJogador : MonoBehaviour
    {
        public float velocidade;
        public ControlesEixos ctrlEixos;

        Controle controle;

        static int jogadorNum = 1;

    #region // implementação do IImplControle {
        float ObterVelocidade() {
            return velocidade;
        }

        ControlesValores ObterControlesValores(ref ControlesEixos ctrlEixos) {
            ControlesValores resultado = new ControlesValores();
            resultado.eixoHorizontal = Input.GetAxisRaw(ctrlEixos.eixoHorizontal);
            resultado.eixoVertical = Input.GetAxisRaw(ctrlEixos.eixoVertical);

            // truque que aprendi :D
            // considere a expressão x && y, se x for false, y não será avaliado
            // ou seja, é o mesmo que if (ctrlEixos.eixoAcao1 != "") resultado.eixoAcao1 = Input.GetButtonDown(ctrlEixos.eixoAcao1);
            // o nome disso é Avaliação curto-circuito: https://pt.wikipedia.org/wiki/Express%C3%A3o_(computa%C3%A7%C3%A3o)#Avalia%C3%A7%C3%A3o_curto-circuito
            resultado.eixoAcao1 = ctrlEixos.eixoAcao1 != "" && Input.GetButtonDown(ctrlEixos.eixoAcao1);
            resultado.eixoAcao2 = ctrlEixos.eixoAcao2 != "" && Input.GetButtonDown(ctrlEixos.eixoAcao2);

            return resultado;
        }

    #endregion // implementação do IImplControle }

    #region // unity callbacks {
        void Awake() {
            controle = GetComponent<Controle>();
        }

        void Start() {
            if (jogadorNum > 1 && jogadorNum <= 4) {
                ctrlEixos.eixoHorizontal = string.Concat(ctrlEixos.eixoHorizontal, " ", jogadorNum.ToString());
                ctrlEixos.eixoVertical = string.Concat(ctrlEixos.eixoVertical, " ", jogadorNum.ToString());
                ctrlEixos.eixoAcao1 = string.Concat(ctrlEixos.eixoAcao1, " ", jogadorNum.ToString());
            }
            else if (jogadorNum > 4)
                Destroy(gameObject);

            jogadorNum++;
        }

        void Update() {
            controle.velocidade = ObterVelocidade();
            controle.ctrlValores = ObterControlesValores(ref ctrlEixos);
        }
    #endregion // unity callbacks }
    }
}
