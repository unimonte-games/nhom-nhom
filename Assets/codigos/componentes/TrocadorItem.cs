using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace NhomNhom {

    public class TrocadorItem : MonoBehaviour
    {
        public Transacao[] transacoes;
        public EspacoItem espacoBalcao;
        public Temporizador temporizador;

        bool tinhaPrato = false;

        void Update() {
            if (SistemaPausa.pausado)
                return;

            if (espacoBalcao.Vazio()) {
                if (tinhaPrato)
                    SistemaEfeitoSonoro.Disparar(EfeitoSonoro.PratoPego);
                tinhaPrato = false;
                return;
            }

            if (espacoBalcao.itemAbrigado.GetComponent<TipoItem>().tipo != TipoItem.Tipo.Pedido)
                return;

            SistemaEfeitoSonoro.Disparar(EfeitoSonoro.PedidoEntregue);
            Item itemItem = espacoBalcao.Soltar();

            // itemItem não pode ser nulo por conta da verificação do Vazio
            Assert.IsNotNull(itemItem);

            Pedido itemPedido = itemItem.GetComponent<Pedido>();
            Assert.IsNotNull(itemPedido);

            for (int i = 0; i < transacoes.Length; i++)
                if (itemPedido.pratoId == transacoes[i].entrada) {
                    StartCoroutine(InstanciarPrato(i, itemItem.transform.position, itemPedido.cor_prato));
                    break;
                }

            Destroy(itemItem.gameObject);

        }

        IEnumerator InstanciarPrato(int i_trancacao, Vector3 pos, int cor_prato) {
            var pratoGbj = Instantiate<GameObject>(
                transacoes[i_trancacao].saida, pos, Quaternion.identity
            );

            pratoGbj.SetActive(false);

            var pratoPrato = pratoGbj.GetComponent<Prato>();
            pratoPrato.cor_i = cor_prato;
            temporizador.Iniciar(pratoPrato.tempoPreparo);
            yield return new WaitForSeconds(pratoPrato.tempoPreparo);

            pratoGbj.SetActive(true);

            var novoItemItem = pratoGbj.GetComponent<Item>();
            Assert.IsNotNull(novoItemItem);

            espacoBalcao.Abrigar(novoItemItem);

            tinhaPrato = true;
        }
    }
}
