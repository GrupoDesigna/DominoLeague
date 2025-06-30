using System.Collections.Generic;
using UnityEngine;

public class Mesa : MonoBehaviour
{
    public List<Ficha> Fichas = new List<Ficha>();

    public void ColocarFicha(Ficha ficha)
    {
        Fichas.Add(ficha);
    }
}
