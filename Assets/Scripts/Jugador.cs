using System.Collections.Generic;

[System.Serializable]
public class Jugador
{
    public int ID;
    public string Nombre;
    public int Monedas;
    public int Rango;
    public List<Ficha> Mano = new List<Ficha>();

    public Jugador(int id, string nombre, int monedas = 0, int rango = 0)
    {
        ID = id;
        Nombre = nombre;
        Monedas = monedas;
        Rango = rango;
    }

    public void AgregarFicha(Ficha ficha)
    {
        Mano.Add(ficha);
    }
}
