using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace NhomNhom {

    public class TrocadorItem : MonoBehaviour
    {
        public Transacao[] transacoes;

        EspacoItem espacoBalcao;

        void Awake() {
            espacoBalcao = GetComponent<EspacoItem>();
        }

        void Update() {
            if (espacoBalcao.Vazio())
                return;

            if (espacoBalcao.itemAbrigado.GetComponent<TipoItem>().tipo != TipoItem.Tipo.Pedido)
                return;

            Item itemItem = espacoBalcao.Soltar();

            // itemItem não pode ser nulo por conta da verificação do Vazio
            Assert.IsNotNull(itemItem);

            GbjID itemGID = itemItem.GetComponent<GbjID>();

            // itemGID não deve ser nulo
            Assert.IsNotNull(itemGID);

            for (int i = 0; i < transacoes.Length; i++)
            {
                if (itemGID.id == transacoes[i].entrada) {
                    var novoItemGbj = Instantiate<GameObject>(
                        transacoes[i].saida, itemItem.transform.position, Quaternion.identity
                    );
                    //novoItemGbj.transform.eulerAngles = Vector3.zero;

                    var novoItemItem = novoItemGbj.GetComponent<Item>();

                    // novoItemItem não deverá ser nulo
                    Assert.IsNotNull(novoItemItem);

                    espacoBalcao.Abrigar(novoItemItem);
                    break;
                }
            }

            Destroy(itemItem.gameObject);
        }
    }
}
