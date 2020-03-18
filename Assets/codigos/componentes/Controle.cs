using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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

                // !espacoItem.Vazio() deve assegurar que item soltado não seja nula!
                Assert.IsNotNull(item);

                if (!listaDeEspacosItensProximas.Vazio()) {
                    GameObject espacoGbj = listaDeEspacosItensProximas.ObterMaisProximo();

                    // !listaDeEspacosItensProximas.Vazio() deve assegurar que espacoGbj não seja nula!
                    Assert.IsNotNull(espacoGbj);

                    var espacoItemProximo = espacoGbj.GetComponent<EspacoItem>();

                    // espacoGbj deve conter um componente Espacoitem
                    Assert.IsNotNull(espacoItemProximo);

                    espacoItemProximo.Abrigar(item);
                }
            }
            else if (!listaDeItensProximos.Vazio()) {
                // a verificação de Vazio acima garante que ObterMaisProximo não retornará nula
                GameObject itemGbj = listaDeItensProximos.ObterMaisProximo();

                // !listaDeItensProximos.Vazio() deve assegurar que itemGbj não seja nula
                Assert.IsNotNull(itemGbj);

                var item = itemGbj.GetComponent<Item>();

                // itemGbj deve conter um componente Item
                Assert.IsNotNull(item);

                espacoItem.Abrigar(item);
            }
        }
    }
}
