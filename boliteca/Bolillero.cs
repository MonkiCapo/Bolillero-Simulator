using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boliteca;

public class Bolillero : IBolillero
{
    public int CantidadAJugar { get; set; }
    public List<Bolilla> bolillas { get; set; }
    public List<Bolilla> BolillasExtraidas { get; set; }
    private IRandomBolilla randomBolilla;

    public Bolillero(int CantidadAJugar, IRandomBolilla randomBolilla)
    {
        bolillas = new List<Bolilla>();
        BolillasExtraidas = new List<Bolilla>();
        this.CantidadAJugar = CantidadAJugar;
        this.randomBolilla = randomBolilla;

        for (int i = 0; i <= CantidadAJugar; i++)
        {
            bolillas.Add(new Bolilla(i));
        }
    }

    public Bolilla obtenerBolilla()
    {
        int indice = randomBolilla.Next(0, bolillas.Count);
        Bolilla bolillaSeleccionada = bolillas[indice];

        bolillas.RemoveAt(indice);
        BolillasExtraidas.Add(bolillaSeleccionada);

        return bolillaSeleccionada;
    }
    public void ReingresarBolillas(List<Bolilla> bolillasAReingresar)
    {
        bolillas.AddRange(bolillasAReingresar);

        foreach (var b in bolillasAReingresar)
        {
            BolillasExtraidas.Remove(b);
        }
    }

    public bool Jugar(List<Bolilla> jugada)
    {
        List<Bolilla> bolillasExtraidas = new List<Bolilla>();

        foreach (var bolilla in jugada)
        {
            Bolilla sacada = obtenerBolilla();
            bolillasExtraidas.Add(sacada);

            if (sacada.NumeroBolilla != bolilla.NumeroBolilla)
            {
                ReingresarBolillas(bolillasExtraidas);
                return false;
            }
        }
        ReingresarBolillas(bolillasExtraidas);
        return true;
    }

    public int JugarNVeces(List<Bolilla> jugada, int cantidadJugar)
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
