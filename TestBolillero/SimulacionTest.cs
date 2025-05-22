using System.Collections.Generic;
using Xunit;
using BolilleroTP;

namespace TestSimulaciones
{
    public class SimulacionTest
    {
        private Bolillero bolillero;
        private Simulacion simulacion = new Simulacion();

        public SimulacionTest()
        {
            List<int> numerosWin = new List<int> { 0, 1, 2 };
            bolillero = new Bolillero(numerosWin, 3, );
        }

        [Fact]
        public void SimuHilosOK()
        {
            bool SiempreGana = false;
            long result = simulacion.SimularConHilos(bolillero, 100000000, 5);
            if (result > 0)
            {
                SiempreGana = true;
            }

            Assert.True(SiempreGana);
        }
    }
}