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

        Assert.Equal(0, bolilla);
        Assert.Equal(9, bolillero.bolillas.Count);
        Assert.Single(bolillero.BolillasExtraidas);
    }

    [Fact]
    public void ReIngresar()
    {
        var bolilla = bolillero.obtenerBolilla();

        bolillero.ReingresarBolillas(new List<int> { bolilla });

        Assert.Equal(10, bolillero.bolillas.Count);
        Assert.Empty(bolillero.BolillasExtraidas);
    }

    [Fact]
    public void JugarGana()
    {
        var jugada = new List<int>{0, 1, 2, 3};

        bool resultado = bolillero.Jugar(jugada);

        Assert.True(resultado);
    }

    [Fact]
    public void JugarPierde()
    {
        var jugada = new List<int>{4, 2, 1, 0};

        bool resultado = bolillero.Jugar(jugada);

        Assert.False(resultado);
    }

    [Fact]
    public void GanarNVeces()
    {
        var jugada = new List<int>{0, 1};

        int resultado = bolillero.JugarNVeces(jugada, 1);

        Assert.Equal(1, resultado);
    }

    [Fact]
    public void ClonadoExitosamente()
    {
        var bolillero = new Bolillero(9, new Primero());
        bolillero.obtenerBolilla();

        var clone = bolillero.Clone();

        Assert.Equal(bolillero.bolillas.Count, clone.bolillas.Count);
        Assert.Equal(bolillero.BolillasExtraidas.Count, clone.BolillasExtraidas.Count);
        Assert.Equal(bolillero.bolillas, clone.bolillas);
        Assert.Equal(bolillero.BolillasExtraidas, clone.BolillasExtraidas);
    }

    [Fact]
    public void SimularSinHilos_DevuelveUnResultadoValido()
    {
        var bolillero = new Bolillero(9, new Primero());
        var simulacion = new Simulacion();
        var jugada = new List<int> { 0, 1 };

        long resultado = simulacion.simularSinHilos(bolillero, jugada, 5);

        Assert.InRange(resultado, 0, 5);
    }

    [Fact]
    public void SimularConHilos_DevuelveUnResultadoValido()
    {
        var bolillero = new Bolillero(9, new Primero());
        var simulacion = new Simulacion();
        var jugada = new List<int> { 0, 1 };

        long resultado = simulacion.SimularConHilos(bolillero, jugada, 5, 2);

        Assert.InRange(resultado, 0, 5);
    }
}
