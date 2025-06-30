using System.Collections.Generic;
using UnityEngine;

public class Partida : MonoBehaviour
{
    public Mesa MesaDeJuego;
    public List<Jugador> Jugadores = new List<Jugador>();

    private void Start()
    {
        // Inicialización básica de ejemplo
        MesaDeJuego = GetComponent<Mesa>();
    }
}
