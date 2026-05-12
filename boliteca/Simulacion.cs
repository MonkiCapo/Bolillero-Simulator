using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boliteca
{
    public class Simulacion
    {
        public long simularSinHilos(Bolillero bolillero, List<int> jugada, int CantidadSimulacion)
        {
            long Ganadas = 0;

            for (int i = 0; i < CantidadSimulacion; i++)
            {
                if (bolillero.Jugar(jugada))
                {
                    Ganadas++;
                }
            }

            return Ganadas;
        }

        public long SimularConHilos(Bolillero bolillero, List<int> jugada, int CantidadSimulacion, int cantidadHilos)
        {
            var tareas = new List<Task<long>>();

            int baseCantidad = CantidadSimulacion / cantidadHilos;
            int resto = CantidadSimulacion % cantidadHilos;

            for (int i = 0; i < cantidadHilos; i++)
            {
                int cantidadParaEsteHilo = baseCantidad + (i < resto ? 1 : 0);

                tareas.Add(Task.Run(() =>
                    simularSinHilos(bolillero.Clone(), jugada, cantidadParaEsteHilo)
                ));
            }

            var resultados = Task.WhenAll(tareas).Result;
            return resultados.Sum();
        }

        public Task<long> simularSinHilosAsync(Bolillero bolillero, List<int> jugada, int CantidadSimulacion)
        {
            
        }
    }
}