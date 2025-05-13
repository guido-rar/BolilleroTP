using System.Collections.Generic;
using Xunit;
using BolilleroTP;

namespace TestBolillero
{
    public class UnitTest1
    {
        private Bolillero bolillero;

        public UnitTest1()
        {

            List<int> numerosWin = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bolillero = new Bolillero(numerosWin, 1, 10);
        }

   
        [Fact]
        public void SacarBolilla()
        {

            Assert.Equal(10, bolillero.Bolitas.Count);
            Assert.Empty(bolillero.BolillasFuera);


            bolillero.PrimerBolita(bolillero.Bolitas, bolillero.BolillasFuera);


            Assert.Contains(0, bolillero.BolillasFuera);


            Assert.Equal(9, bolillero.Bolitas.Count);


            Assert.Single(bolillero.BolillasFuera);
        }

        [Fact]
        public void ReIngresar()
        {

            bolillero.PrimerBolita(bolillero.Bolitas, bolillero.BolillasFuera);


            Assert.Equal(9, bolillero.Bolitas.Count);
            Assert.Single(bolillero.BolillasFuera);


            bolillero.MeterBolillasdeAfuera();


            Assert.Equal(10, bolillero.Bolitas.Count);


            Assert.Empty(bolillero.BolillasFuera);
        }

        [Fact]
        public void JugarGana()
        {

            bool resultado = bolillero.JugarPrimera();
            Assert.True(resultado);
        }

        [Fact]
        public void JugarPierde()
        {
            List<int> numerosWin = new List<int> { 4, 2, 1 };
            Bolillero bolilleroPierde = new Bolillero(numerosWin, 1, 10);


            bool resultado = bolilleroPierde.JugarPrimera();
            Assert.False(resultado);
        }

        [Fact]
        public void GanarNVeces()
        {

            List<int> jugada = new List<int> { 0, 1 };
            Bolillero bolilleroGana = new Bolillero(jugada, 1, 10);


            long vecesGanadas = bolilleroGana.JugarNVeces(10);
            Assert.True(vecesGanadas>0);
        }



        [Fact]
        public void JugarRandomOK()
        {

            Assert.Equal(10, bolillero.Bolitas.Count);
            Assert.Empty(bolillero.BolillasFuera);

            bolillero.JugarRndm();

            Assert.Equal(10, bolillero.Bolitas.Count);
            Assert.Empty(bolillero.BolillasFuera);
        }
    }
}