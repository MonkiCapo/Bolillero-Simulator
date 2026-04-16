using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boliteca;

public class Bolillero : IBolillero
{
    public int CantidadAJugar { get; set; }
    public List<int> bolillas { get; private set; }
    public List<int> BolillasExtraidas { get; private set; }
    private IRandomBolilla randomBolilla;

    public Bolillero(int CantidadAJugar, IRandomBolilla randomBolilla)
    {
        bolillas = new List<int>();
        BolillasExtraidas = new List<int>();
        this.CantidadAJugar = CantidadAJugar;
        this.randomBolilla = randomBolilla;

        for (int i = 0; i <= CantidadAJugar; i++)
        {
            bolillas.Add(i);
        }
    }

    public int obtenerBolilla()
    {
        int indice = randomBolilla.Next(0, bolillas.Count);
        int bolillaSeleccionada = bolillas[indice];

        bolillas.RemoveAt(indice);
        BolillasExtraidas.Add(bolillaSeleccionada);

        return bolillaSeleccionada;
    }
    
    public void ReingresarBolillas(List<int> bolillasAReingresar)
    {
        bolillas.AddRange(bolillasAReingresar);

        foreach (var b in bolillasAReingresar)
        {
            BolillasExtraidas.Remove(b);
        }
    }

    public bool Jugar(List<int> jugada)
    {
        List<int> bolillasExtraidas = new List<int>();

        foreach (var bolilla in jugada)
        {
            int sacada = obtenerBolilla();
            bolillasExtraidas.Add(sacada);

            if (sacada != bolilla)
            {
                ReingresarBolillas(bolillasExtraidas);
                return false;
            }
        }
        ReingresarBolillas(bolillasExtraidas);
        return true;
    }

    public int JugarNVeces(List<int> jugada, int cantidadJugar)
    {
        int aciertos = 0;

        for (int i = 0; i < cantidadJugar; i++)
        {
            if (Jugar(jugada))
            {
                aciertos++;
            }
        }

        return aciertos;
    }
}
