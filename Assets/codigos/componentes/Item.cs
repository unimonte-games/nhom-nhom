using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Contém quem detém a posse do item através do EspacoItem e métodos de
/// transferência de posse.
public class Item : MonoBehaviour
{
    /// Espaço ocupado por esse item
    [Tooltip("Espaço ocupado por esse item")]
    public EspacoItem espacoPertencente;

    /// Muda a posse do item para o espaço novoEspaco
    public void MudarPosse(EspacoItem novoEspaco) {

    }
}
