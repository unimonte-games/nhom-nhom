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
    Transform tr;

    Vector3 direcao;

    void Awake() {
        compVelocidade = GetComponent<Velocidade>();
        tr = GetComponent<Transform>();
    }

    void Update() {
        // rotação e direção
        float H = ctrlValores.eixoHorizontal;
        float V = ctrlValores.eixoVertical;

        direcao.x = 0;
        direcao.y = 0;
        direcao.z = 0;
        if ((H < -0.1f || H > 0.1f) || (V < -0.1f || V > 0.1f)) {

            if (H < -0.1f)
                direcao.x = -1;
            else if (H > 0.1f)
                direcao.x =  1;

            if (V < -0.1f)
                direcao.z = -1;
            else if (V > 0.1f)
                direcao.z =  1;

            direcao.Normalize();

            tr.LookAt(tr.position + direcao);
        }

        // velocidade
        compVelocidade.direcao.x = 0;
        compVelocidade.direcao.y = 0;
        compVelocidade.direcao.z = Mathf.Ceil(direcao.magnitude);
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
