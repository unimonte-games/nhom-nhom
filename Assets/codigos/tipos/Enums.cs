using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Camadas
{
    Piso = 1 << 8,
}

public enum Cenas
{
    menu_inicial=0, tutorial, externo_pequeno, interno_pequeno, externo_medio, interno_grande,
}

public enum EfeitoSonoro {
    PedidoNovo = 0,
    SlimePasso,
    Pago,
    PedidoEntregue,
}
