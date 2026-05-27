namespace boliteca
{
    public class Simulacion
    {
        public List<Task<long>> CreardorDeTareas(Bolillero bolillero, List<int> jugada, int cantidadSimulacion, int cantidadHilos)
        {
            var tareas = new List<Task<long>>();

            int baseCantidad = cantidadSimulacion / cantidadHilos;
            int resto = cantidadSimulacion % cantidadHilos;

            for (int i = 0; i < cantidadHilos; i++)
            {
                int cantidadParaEsteHilo = baseCantidad + (i < resto ? 1 : 0);

                tareas.Add(Task.Run(() => simularSinHilos(bolillero.Clone(), jugada, cantidadParaEsteHilo)
                ));
            }

            return tareas;
        }

        public long simularSinHilos(Bolillero bolillero, List<int> jugada, int cantidadSimulacion) =>
            bolillero.JugarNVeces(jugada, cantidadSimulacion);
            
        public long SimularConHilos(Bolillero bolillero, List<int> jugada, int cantidadSimulacion, int cantidadHilos)
        {
            var tareas = CreardorDeTareas(bolillero, jugada, cantidadSimulacion, cantidadHilos);

            Task.WaitAll(tareas);

            return tareas.Sum(t => t.Result);
        }

        public async Task<long> simularConHilosAsync(Bolillero bolillero, List<int> jugada, int cantidadSimulacion, int cantidadHilos)
        {
            var tareas = CreardorDeTareas(bolillero, jugada, cantidadSimulacion, cantidadHilos);
            
            var resultados = await Task.WhenAll(tareas);

            return resultados.Sum();
        }
    }
}