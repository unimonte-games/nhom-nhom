using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ImplControle : MonoBehaviour
{
    protected abstract float ObterVelocidade();
    protected abstract ControlesValores ObterControlesValores(ref ControlesEixos ctrlEixos);
    protected abstract void Aplicar();
}
