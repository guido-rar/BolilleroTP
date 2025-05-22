using System.Collections.Generic;
using Xunit;
using BolilleroTP;

namespace TestBolillero
{
    public class UnitTest1
    {
        private Bolillero bolillero;
        private ILogica logicaPrimera = new SacarPrimera();
        private ILogica logicaRndm = new SacarAleatorio();
        public UnitTest1()
        {

            List<int> numerosWin = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bolillero = new Bolillero(numerosWin, 10,logicaPrimera);


        }


        [Fact]
        public void SacarBolilla()
        {

            Assert.Equal(10, bolillero.Bolitas.Count);
            Assert.Empty(bolillero.BolillasFuera);


            logicaPrimera.SacarBolita(bolillero);


            Assert.Contains(0, bolillero.BolillasFuera);


            Assert.Equal(9, bolillero.Bolitas.Count);


            Assert.Single(bolillero.BolillasFuera);
        }

        [Fact]
        public void ReIngresar()
        {

            logicaPrimera.SacarBolita(bolillero);


            Assert.Equal(9, bolillero.Bolitas.Count);
            Assert.Single(bolillero.BolillasFuera);


            bolillero.MeterBolillasdeAfuera();


            Assert.Equal(10, bolillero.Bolitas.Count);


            Assert.Empty(bolillero.BolillasFuera);
        }

        [Fact]
        public void JugarGana()
        {

            bool resultado = bolillero.Jugar();
            Assert.True(resultado);
        }

        [Fact]
        public void JugarPierde()
        {
            List<int> numerosWin = new List<int> { 4, 2, 1 };
            Bolillero bolilleroPierde = new Bolillero(numerosWin, 10,logicaPrimera);


            bool resultado = bolilleroPierde.Jugar();
            Assert.False(resultado);
        }

        [Fact]
        public void GanarNVeces()
        {

            List<int> jugada = new List<int> { 0, 1 };
            Bolillero bolilleroGana = new Bolillero(jugada, 10, logicaPrimera);


            long vecesGanadas = bolilleroGana.JugarNVeces(10);
            Assert.True(vecesGanadas > 0);
        }



        [Fact]
        public void JugarRandomOK()
        {
            List<int> numerosWin = new List<int> { 4, 2, 1 };
            Bolillero bolilleroRndm = new Bolillero(numerosWin,  10, logicaRndm);

            Assert.Equal(10, bolillero.Bolitas.Count);
            Assert.Empty(bolillero.BolillasFuera);

            logicaRndm.SacarBolita(bolillero);

            Assert.Equal(9, bolillero.Bolitas.Count);
            Assert.Single(bolillero.BolillasFuera);
        }
    }
}