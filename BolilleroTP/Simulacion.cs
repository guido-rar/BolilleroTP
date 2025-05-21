namespace BolilleroTP
{
    public class Simulacion
    {

        public long SimulacionSinHilos(Bolillero bolilla1, int cantSimu)
        {

            long cantWin = 0;
            for (int i = 0; i < cantSimu; i++)
            {
                cantWin += bolilla1.JugarNVeces(cantSimu, false);
            }

            return cantWin;
        }

        public long SimularConHilos(Bolillero bolillero, int cantSimu, int cantHilos)
        {
            Task<long>[] tareas = OptiSimu(bolillero, cantSimu, cantHilos);

            Task.WaitAll(tareas);

            long totalWins = tareas.Sum(t => t.Result);
            return totalWins;
        }

        public async Task<long> SimularConHilosAsync(Bolillero bolillero, int cantSimu, int cantHilos)
        {
            Task<long>[] tareas= OptiSimu(bolillero, cantSimu, cantHilos);

            await Task.WhenAll(tareas);


            long totalWins = tareas.Sum(t => t.Result);
            return totalWins;
        }


        public Task<long>[] OptiSimu(Bolillero bolillero, int cantSimu, int cantHilos)
        {
            Task<long>[] tareas = new Task<long>[cantHilos];
         
            int simus = cantSimu / cantHilos;
            int simusEx = cantSimu % cantHilos;
            int simusPorHilo = 0;
            for (int i = 0; i < cantHilos; i++)
            {
                Bolillero clon = bolillero.Clonar();
                simusPorHilo = simus + (i < simusEx ? 1 : 0);

                tareas[i] = (Task<long>.Run(() =>

                    clon.JugarNVeces(simusPorHilo, false)
                ));
            }
            return tareas;
        }


    }
}


    


