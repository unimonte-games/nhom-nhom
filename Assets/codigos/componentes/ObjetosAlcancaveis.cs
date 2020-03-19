using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ObjetosAlcancaveis : MonoBehaviour
{
    public string etiqueta;
    public List<GameObject> listaObjetos;

    Transform tr;

    public bool Vazio() {
        return listaObjetos.Count == 0;
    }

    public GameObject ObterMaisProximo() {
        if (Vazio())
            return null;

        GameObject resultado = listaObjetos[0];
        Transform res_tr = resultado.GetComponent<Transform>();
        float dist = Vector3.Distance(res_tr.position, tr.position);

        for (int i = 0; i < listaObjetos.Count; i++) {
            var gbj_i = listaObjetos[i];
            var tr_i = gbj_i.GetComponent<Transform>();
            float dist_i = Vector3.Distance(res_tr.position, tr.position);

            if (dist_i < dist) {
                dist = dist_i;
                resultado = gbj_i;
                res_tr = tr_i;
            }
        }

        // neste ponto o resultado não deverá ser nulo
        Assert.IsNotNull(resultado);

        return resultado;

    }

    bool EstaDentroDaLista(GameObject gbj) {
        for (int i = 0; i < listaObjetos.Count; i++)
            if (gbj == listaObjetos[i])
                return true;

        return false;
    }

    void Awake() {
        tr = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider col) {
        if (etiqueta != "" && !col.CompareTag(etiqueta))
            return;

        GameObject col_gbj = col.gameObject;

        if (!EstaDentroDaLista(col_gbj))
            listaObjetos.Add(col_gbj);
    }

    void OnTriggerExit(Collider col) {
        if (etiqueta != "" && !col.CompareTag(etiqueta))
            return;

        GameObject col_gbj = col.gameObject;

        if (EstaDentroDaLista(col_gbj))
            listaObjetos.Remove(col_gbj);
    }
}
