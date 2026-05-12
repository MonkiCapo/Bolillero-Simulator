using Xunit;
using boliteca;
using System.Collections.Generic;
using System.Threading.Tasks;

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

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(100)]
    public void SimularSinHilos_DevuelveUnResultadoValido(int cantidadSimulacion)
    {
        var bolillero = new Bolillero(9, new Primero());
        var simulacion = new Simulacion();
        var jugada = new List<int> { 0, 1 };

        long resultado = simulacion.simularSinHilos(bolillero, jugada, cantidadSimulacion);

        Assert.InRange(resultado, 0, cantidadSimulacion);
    }

    [Theory]
    [InlineData(5, 2)]
    [InlineData(10, 4)]
    [InlineData(100, 10)]
    public void SimularConHilos_DevuelveUnResultadoValido(int cantidadSimulacion, int cantidadHilos)
    {
        var bolillero = new Bolillero(9, new Primero());
        var simulacion = new Simulacion();
        var jugada = new List<int> { 0, 1 };

        long resultado = simulacion.SimularConHilos(bolillero, jugada, cantidadSimulacion, cantidadHilos);

        Assert.InRange(resultado, 0, cantidadSimulacion);
    }

    [Theory]
    [InlineData(5, 2)]
    [InlineData(10, 4)]
    [InlineData(100, 10)]
    public async Task SimularConHilosAsync_DevuelveUnResultadoValido(int cantidadSimulacion, int cantidadHilos)
    {
        var bolillero = new Bolillero(9, new Primero());
        var simulacion = new Simulacion();
        var jugada = new List<int> { 0, 1 };
        long resultado = await simulacion.simularConHilosAsync(bolillero, jugada, cantidadSimulacion, cantidadHilos);

        Assert.InRange(resultado, 0, cantidadSimulacion);
    }
}
