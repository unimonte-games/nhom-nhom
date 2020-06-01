using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class EstadosCliente : MonoBehaviour
    {
        public enum Estado {
            NaFila = 0, AteCadeira, AguardaPrato, ComendoPrato, VaiEmbora
        }

        public Estado estado = Estado.NaFila;

        public int precoPrato;

        Fila fila;
        Cadeiras cadeiras;

        AndaNaFila     c_andaNaFila;
        AndaAteCadeira c_andaAteCadeira;
        AguardaPrato   c_aguardaPrato;
        ComendoPrato   c_comendoPrato;
        VaiEmbora      c_vaiEmbora;
        ControleCliente ctrlCliente;

        public void ProximoEstado() {
            if (estado != Estado.VaiEmbora) {
                estado = (Estado)( (int)estado + 1 );
                AbreEstado(estado);
            } else {
                Destroy(gameObject);
                fila.qtdClientesSimultaneos--;
                if (fila.AcabouClientes())
                    FindObjectOfType<MenuRelatorio>().mostraRelatorio();
            }
        }

        void AbreEstado(Estado e) {
            if (c_andaNaFila) {
                fila.AbrirVaga(ctrlCliente.id);
                Destroy(c_andaNaFila);
            }
            if (c_andaAteCadeira) {
                Destroy(c_andaAteCadeira);
            }
            if (c_aguardaPrato) {
                Destroy(c_aguardaPrato);
            }
            if (c_comendoPrato) {
                Destroy(c_comendoPrato);
            }

            switch (e) {
                case Estado.NaFila:       c_andaNaFila     = gameObject.AddComponent<AndaNaFila>();     break;
                case Estado.AteCadeira:   c_andaAteCadeira = gameObject.AddComponent<AndaAteCadeira>(); break;
                case Estado.AguardaPrato: c_aguardaPrato   = gameObject.AddComponent<AguardaPrato>();   break;
                case Estado.ComendoPrato: c_comendoPrato   = gameObject.AddComponent<ComendoPrato>();   break;
                case Estado.VaiEmbora:    c_vaiEmbora      = gameObject.AddComponent<VaiEmbora>();      break;
            }
        }

        bool DeveIrParaProximoEstado() {
            switch (estado) {
                case Estado.NaFila:       return cadeiras.HaVagas() && cadeiras.podeEntrar && c_andaNaFila.EstaNaFrente();
                case Estado.AteCadeira:   return c_andaAteCadeira.Chegou();
                case Estado.AguardaPrato: return c_aguardaPrato.ComPrato();
                case Estado.ComendoPrato: return c_comendoPrato.Comeu();
                case Estado.VaiEmbora:    return c_vaiEmbora.FoiEmbora();
            }

            return false;
        }

        void Awake() {
            fila = FindObjectOfType<Fila>();
            cadeiras = FindObjectOfType<Cadeiras>();
            ctrlCliente = GetComponent<ControleCliente>();
        }

        void Start() {
            AbreEstado(Estado.NaFila);
        }

        void Update() {
            if (SistemaPausa.pausado)
                return;

            if (DeveIrParaProximoEstado()) {
                ProximoEstado();
            }
        }
    }
}
