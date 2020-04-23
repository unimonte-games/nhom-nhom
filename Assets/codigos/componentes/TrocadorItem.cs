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
            if (espacoBalcao.Vazio() ||
                espacoBalcao.itemAbrigado.GetComponent<TipoItem>().tipo != TipoItem.Tipo.Pedido
            )
                return;

            Item itemItem = espacoBalcao.Soltar();

            // itemItem não pode ser nulo por conta da verificação do Vazio
            Assert.IsNotNull(itemItem);

            GbjID itemGID = itemItem.GetComponent<GbjID>();

            // itemGID não deve ser nulo
            Assert.IsNotNull(itemGID);

            for (int i = 0; i < transacoes.Length; i++) {
                if (itemGID.id == transacoes[i].entrada) {
                    StartCoroutine(InstanciarPrato(i, itemItem.transform.position, itemItem.idDono));
                    break;
                }
            }

            Destroy(itemItem.gameObject);
        }

        IEnumerator InstanciarPrato(int i_trancacao, Vector3 pos, int idDono) {
            var pratoGbj = Instantiate<GameObject>(
                transacoes[i_trancacao].saida, pos, Quaternion.identity
            );

            var pratoPrato = pratoGbj.GetComponent<Prato>();
            pratoGbj.SetActive(false);

            yield return new WaitForSeconds(pratoPrato.tempoPreparo);

            pratoGbj.SetActive(true);

            var novoItemItem = pratoGbj.GetComponent<Item>();
            Assert.IsNotNull(novoItemItem);
            novoItemItem.idDono = idDono;

            espacoBalcao.Abrigar(novoItemItem);
        }
    }
}
