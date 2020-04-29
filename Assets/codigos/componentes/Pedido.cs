using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedido : MonoBehaviour
{
    public string pratoId;
    public int cor_prato;

    void Start() {
        cor_prato = Random.Range(0, 3);
    }
}
