namespace BolilleroTP
{
    public class Simulacion
    {

        public long SimulacionSinHilos(Bolillero bolilla1, int cantSimu)
        {
            ILogica logica = new SacarAleatorio();
            long cantWin = 0;
            for (int i = 0; i < cantSimu; i++)
            {
                cantWin += bolilla1.JugarNVeces(cantSimu);
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
            Task<long>[] tareas = OptiSimu(bolillero, cantSimu, cantHilos);

            await Task.WhenAll(tareas);


            long totalWins = tareas.Sum(t => t.Result);
            return totalWins;
        }


        public Task<long>[] OptiSimu(Bolillero bolillero, int cantSimu, int cantHilos)
        {
            Task<long>[] tareas = new Task<long>[cantHilos];
            ILogica logica = new SacarAleatorio();

            int simus = cantSimu / cantHilos;
            int simusEx = cantSimu % cantHilos;
            int simusPorHilo = 0;
            for (int i = 0; i < cantHilos; i++)
            {
                Bolillero clon = bolillero.Clonar();
                simusPorHilo = simus + (i < simusEx ? 1 : 0);

                tareas[i] = (Task<long>.Run(() =>

                    clon.JugarNVeces(simusPorHilo)
                ));
            }
            return tareas;
        }

        public async Task<long> SimularParallelAsync(Bolillero bolilleroModelo, int CantidadSimu, int CantidadHilos)
        {
            if (CantidadSimu <= 0 || CantidadHilos <= 0)
            {
                return 0;
            }


            long[] resultadosPorBloque = new long[CantidadHilos];


            await Task.Run(() =>
            {
                long simusBasePorBloque = CantidadSimu / CantidadHilos;
                long simusExtra = CantidadSimu % CantidadHilos;

                Parallel.For(0, CantidadHilos, i =>
                {

                    long simusParaEsteBloque = simusBasePorBloque + (i < simusExtra ? 1 : 0);

                    if (simusParaEsteBloque > 0)
                    {

                        Bolillero clon = bolilleroModelo.Clonar();

                        long aciertosEsteBloque = clon.JugarNVeces(simusParaEsteBloque);

                        resultadosPorBloque[i] = aciertosEsteBloque;
                    }
                    else
                    {
                       
                        resultadosPorBloque[i] = 0;
                    }
                });
            });

            
            long aciertosTotales = 0;
            for (int k = 0; k < resultadosPorBloque.Length; k++)
            {
                aciertosTotales += resultadosPorBloque[k];
            }
          
            return aciertosTotales;
        }

    }
}





