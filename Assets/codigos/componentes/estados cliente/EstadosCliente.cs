using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosCliente : MonoBehaviour
{
    public enum Estado {
        NaFila = 0, AteCadeira, AguardaPrato, ComendoPrato, VaiEmbora
    }

    public Estado estado = Estado.NaFila;

    AndaNaFila     c_andaNaFila;
    AndaAteCadeira c_andaAteCadeira;
    AguardaPrato   c_aguardaPrato;
    ComendoPrato   c_comendoPrato;
    VaiEmbora      c_vaiEmbora;

    public void ProximoEstado() {
        if (estado != Estado.VaiEmbora) {
            estado = (Estado)( (int)estado + 1 );
            AbreEstado(estado);
        } else
            Destroy(gameObject);
    }

    void AbreEstado(Estado e) {
        if (c_andaNaFila)     Destroy(c_andaNaFila);
        if (c_andaAteCadeira) Destroy(c_andaAteCadeira);
        if (c_aguardaPrato)   Destroy(c_aguardaPrato);
        if (c_comendoPrato)   Destroy(c_comendoPrato);
        if (c_vaiEmbora)      Destroy(c_vaiEmbora);

        switch (e) {
            case Estado.NaFila:       c_andaNaFila     = gameObject.AddComponent<AndaNaFila>();     break;
            case Estado.AteCadeira:   c_andaAteCadeira = gameObject.AddComponent<AndaAteCadeira>(); break;
            case Estado.AguardaPrato: c_aguardaPrato   = gameObject.AddComponent<AguardaPrato>();   break;
            case Estado.ComendoPrato: c_comendoPrato   = gameObject.AddComponent<ComendoPrato>();   break;
            case Estado.VaiEmbora:    c_vaiEmbora      = gameObject.AddComponent<VaiEmbora>();      break;
        }
    }

    void Start() {
        AbreEstado(Estado.NaFila);
    }

    void Update() {
        bool deveIrParaProximoEstado = false;

        switch (estado) {
            case Estado.NaFila:       deveIrParaProximoEstado = c_andaNaFila.EstaNaFrente(); break;
            case Estado.AteCadeira:                                                          break;
            case Estado.AguardaPrato:                                                        break;
            case Estado.ComendoPrato:                                                        break;
            case Estado.VaiEmbora:                                                           break;
        }

        if (deveIrParaProximoEstado)
            ProximoEstado();
    }
}
