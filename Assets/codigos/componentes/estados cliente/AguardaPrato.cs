using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

public class AguardaPrato : MonoBehaviour {
    ControladorVaiAtePonto ctrlVaiAtePonto;
    Transform tr;
    ObjetosAlcancaveis objsEspacos;

    bool mesaObtida;
    EspacoItem espacoMesa, espacoCliente;
    Item pedidoItem;

    public bool ComPrato() {
        if (!espacoMesa || espacoMesa.Vazio())
            return false;

        string id = espacoMesa.itemAbrigado.GetComponent<GbjID>().id;
        bool recebeuPrato = id.Substring(0, 6) == "#prato";

        if (recebeuPrato) {
            Item pratoItem = espacoMesa.Soltar();
            Vector3 pos = pratoItem.transform.position;
            espacoCliente.Abrigar(pratoItem);
            pratoItem.transform.position = pos;
        }

        return recebeuPrato;
    }

    void Awake() {
        ctrlVaiAtePonto = GetComponent<ControladorVaiAtePonto>();
        tr = GetComponent<Transform>();
    }

    void Start() {
        ctrlVaiAtePonto.ativo = false;
        objsEspacos = tr.Find("sensor_espacos").GetComponent<ObjetosAlcancaveis>();

        espacoCliente = tr.Find("ref_item").GetComponent<EspacoItem>();
        espacoCliente.itemAbrigado.gameObject.SetActive(true);
        pedidoItem = espacoCliente.Soltar();

        Assert.IsNotNull(objsEspacos);
    }

    void Update() {
        if (ctrlVaiAtePonto.estaNoPonto) {
            if (!mesaObtida) {
                GameObject gbjMesa = objsEspacos.ObterMaisProximo();
                espacoMesa = gbjMesa.GetComponent<EspacoItem>();

                Assert.IsNotNull(espacoMesa);

                espacoMesa.Abrigar(pedidoItem);

                mesaObtida = true;

                tr.LookAt(espacoMesa.transform);
                tr.eulerAngles = new Vector3(0, tr.eulerAngles.y, 0);
            }
        }
    }

}
