using System.Collections.Generic;
using Xunit;
using BolilleroTP;

namespace TestSimulaciones
{
    public class UnitTest2
    {
        private Bolillero bolillero;
        private Simulacion simulacion= new Simulacion();

        public UnitTest2()
        {
            List<int> numerosWin = new List<int> { 0, 1, 2};
            bolillero = new Bolillero(numerosWin, 1, 3);
        }

        [Fact]
        public void SimuHilosOK()
        {
            long result=simulacion.SimularConHilos(bolillero, 34, 5);
            Assert.True(result>0);
        }

    }
}