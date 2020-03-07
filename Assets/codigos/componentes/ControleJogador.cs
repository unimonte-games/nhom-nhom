using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : ImplControle
{
    public float velocidade;
    public ControlesEixos ctrlEixos;

    Controle controle;

#region // implementação do IImplControle {
    protected override float ObterVelocidade() {
        return velocidade;
    }

    protected override ControlesValores ObterControlesValores(ref ControlesEixos ctrlEixos) {
        ControlesValores resultado;
        resultado.eixoHorizontal = Input.GetAxis(ctrlEixos.eixoHorizontal);
        resultado.eixoVertical = Input.GetAxis(ctrlEixos.eixoVertical);

        // truque que aprendi :D
        // considere a expressão x && y, se x for false, y não será avaliado
        // ou seja, é o mesmo que if (ctrlEixos.eixoAcao1 != "") resultado.eixoAcao1 = Input.GetButtonDown(ctrlEixos.eixoAcao1);
        // o nome disso é Avaliação curto-circuito: https://pt.wikipedia.org/wiki/Express%C3%A3o_(computa%C3%A7%C3%A3o)#Avalia%C3%A7%C3%A3o_curto-circuito
        resultado.eixoAcao1 = ctrlEixos.eixoAcao1 != "" && Input.GetButtonDown(ctrlEixos.eixoAcao1);
        resultado.eixoAcao2 = ctrlEixos.eixoAcao2 != "" && Input.GetButtonDown(ctrlEixos.eixoAcao2);

        return resultado;
    }

    protected override void Aplicar() {
        controle.velocidade = ObterVelocidade();
        controle.ctrlValores = ObterControlesValores(ref ctrlEixos);
    }
#endregion // implementação do IImplControle }

#region // unity callbacks {
    void Awake() {
        controle = GetComponent<Controle>();
    }

    void Update() {
        Aplicar();
    }
#endregion // unity callbacks }
}
