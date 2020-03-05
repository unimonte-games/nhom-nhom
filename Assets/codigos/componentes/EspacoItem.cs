using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Contém uma variável de transformação que funciona como âncora (feito
/// através do grafo de cena) e métodos de mudança de ancoragem, entretanto
/// essa mudança deverá ser feita exclusivamente pelo componente Item, já
/// que é ele quem detém quem contém a posse do item.
public class EspacoItem : MonoBehaviour
{
    /// Transform pai
    [Tooltip("Transform pai")]
    public Transform ancora;

    Transform tr;

    /// Muda o pai do objeto para o transform
    public void MudarAncora(Transform novaAncora) {
        tr.SetParent(novaAncora);
    }

    void Awake() {
        tr = GetComponent<Transform>();
    }
}
