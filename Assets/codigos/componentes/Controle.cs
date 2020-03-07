using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    public ObjetosAlcancaveis listaDeItensProximos, listaDeEspacosItensProximas;
    public EspacoItem espacoItem;
    public float velocidade;
    public ControlesValores ctrlValores;

    Velocidade compVelocidade;

    Vector3 direcao;

    void Awake() {
        compVelocidade = GetComponent<Velocidade>();
    }

    void Update() {
        // velocidade
        compVelocidade.direcao.x = ctrlValores.eixoHorizontal;
        compVelocidade.direcao.z = ctrlValores.eixoVertical;
        compVelocidade.velocidade = velocidade;

        // pegar ou soltar item
        if (ctrlValores.eixoAcao1) {
            if (!espacoItem.Vazio()) {
                Item item = espacoItem.Soltar();

                if (!listaDeEspacosItensProximas.Vazio()) {
                    GameObject espacoGbj = listaDeEspacosItensProximas.ObterMaisProximo();
                    var espacoItemProximo = espacoGbj.GetComponent<EspacoItem>();
                    espacoItemProximo.Abrigar(item);
                }
            }
            else if (!listaDeItensProximos.Vazio()) {
                // a verificação de Vazio acima garante que ObterMaisProximo não retornará null
                GameObject itemGbj = listaDeItensProximos.ObterMaisProximo();
                var item = itemGbj.GetComponent<Item>();
                espacoItem.Abrigar(item);
            }
        }
    }
}
