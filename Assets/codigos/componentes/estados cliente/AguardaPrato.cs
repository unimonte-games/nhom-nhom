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
    EspacoItem espacoMesa;

    public bool ComPrato() {
        if (!espacoMesa || espacoMesa.Vazio())
            return false;

        string id = espacoMesa.itemAbrigado.GetComponent<GbjID>().id;
        print(id);
        return id.Substring(0, 6) == "#prato";
    }

    void Awake() {
        ctrlVaiAtePonto = GetComponent<ControladorVaiAtePonto>();
        tr = GetComponent<Transform>();
    }

    void Start() {
        objsEspacos = tr.Find("sensor_espacos").GetComponent<ObjetosAlcancaveis>();
        Assert.IsNotNull(objsEspacos);
    }

    void Update() {
        if (ctrlVaiAtePonto.estaNoPonto) {
            if (!mesaObtida) {
                GameObject gbjMesa = objsEspacos.ObterMaisProximo();
                espacoMesa = gbjMesa.GetComponent<EspacoItem>();
                Assert.IsNotNull(espacoMesa);
                mesaObtida = true;
            } else {
                tr.LookAt(espacoMesa.transform);
                tr.eulerAngles = new Vector3(0, tr.eulerAngles.y, 0);
            }
        }
    }

}
