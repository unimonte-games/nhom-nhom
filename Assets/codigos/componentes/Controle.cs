using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Contém controles do personagem.
///
/// Através da Callback de Atualização "Update", ele lê a entrada do jogo
/// através de uma abstração do próprio jogo, e escreve sobre o componente
/// de Velocidade e também modifica a posse de item caso o botão de Ação1
/// seja pressionado com um item próximo.
public class Controle : MonoBehaviour
{
    /// O sistema lê a entrada usando esses parâmetros
    [Tooltip("O sistema lê a entrada usando esses parâmetros")]
    public ControlesJogador controles;

    Velocidade compVelocidade;
    Item compItem;

    void Awake() {
        compVelocidade = GetComponent<Velocidade>();
    }

    void Update() {
        float dt = Time.deltaTime;

        // TODO: talvez seja necessário mudar pra uma abstração em cima do Input
        float eixoH = Input.GetAxis(controles.eixoHorizontal);
        float eixoV = Input.GetAxis(controles.eixoVertical);
        bool acao1  = Input.GetButtonDown(controles.eixoAcao1);

        compVelocidade.direcao.x = eixoH;
        compVelocidade.direcao.z = eixoV;
    }
}
