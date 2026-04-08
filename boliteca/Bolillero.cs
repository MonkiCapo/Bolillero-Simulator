using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boliteca;

public class Bolillero : IBolillero
{
    public int CantidadAJugar { get; set; }
    public List<Bolilla> bolillas { get; set; }

    public Random r = new Random();

    public Bolillero(int CantidadAJugar)
    {
        bolillas = new List<Bolilla>();
        this.CantidadAJugar = CantidadAJugar;
    }

    public Bolilla obtenerBolilla()
    {
        int indice = r.Next(0, bolillas.Count);
        Bolilla bolillaSeleccionada = bolillas[indice];

        bolillas.RemoveAt(indice);

        return bolillaSeleccionada;
    }
}
