using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {
    public class Pedido : MonoBehaviour
    {
        public string pratoId;
        public int cor_prato;

        public string[] pratosPossiveis;

        public void Inicializar() {
            pratoId = pratosPossiveis[Random.Range(0, pratosPossiveis.Length)];
            cor_prato = Random.Range(0, 3);
            SistemaEfeitoSonoro.Disparar(EfeitoSonoro.PedidoNovo);
        }
    }
}
