using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Camadas
{
    Piso = 1 << 8,
}

public enum Cenas
{
    menu_inicial=-1, menu_selecao_fase, tutorial, externo_medio, interno_grande,
}

public enum EfeitoSonoro {
    PedidoNovo = 0,
    SlimePasso,
    Pago,
    PedidoEntregue,
}
