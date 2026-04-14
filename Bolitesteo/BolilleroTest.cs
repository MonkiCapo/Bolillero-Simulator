using Xunit;
using boliteca;
using System.Collections.Generic;


namespace Bolitesteo;

public class BolilleroTest
{
    private Bolillero bolillero;

    public BolilleroTest()
    {
        bolillero = new Bolillero(9, new Primero());
    }

    [Fact]
    public void SacarBolilla()
    {
        var bolilla = bolillero.obtenerBolilla();

        Assert.Equal(0, bolilla.NumeroBolilla);
        Assert.Equal(9, bolillero.bolillas.Count);
        Assert.Single(bolillero.BolillasExtraidas);
    }

    [Fact]
    public void ReIngresar()
    {
        var bolilla = bolillero.obtenerBolilla();

        bolillero.ReingresarBolillas(new List<Bolilla> { bolilla });

        Assert.Equal(10, bolillero.bolillas.Count);
        Assert.Empty(bolillero.BolillasExtraidas);
    }

    [Fact]
    public void JugarGana()
    {
        var jugada = new List<Bolilla>
        {
            new Bolilla(0),
            new Bolilla(1),
            new Bolilla(2),
            new Bolilla(3)
        };

        bool resultado = bolillero.Jugar(jugada);

        Assert.True(resultado);
    }

    [Fact]
    public void GanarNVeces()
    {
        var jugada = new List<Bolilla>
        {
            new Bolilla(0),
            new Bolilla(1)
        };

        int resultado = bolillero.JugarNVeces(jugada, 1);

        Assert.Equal(1, resultado);
    }
}
