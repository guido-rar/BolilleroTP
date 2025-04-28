using BolilleroTP;
namespace TestBolillero
{
    public class UnitTest1
    {
        [Fact]
        public void JugarRandomOK()
        {
            List<int> numerosWin = new List<int> { 1, 2, 8, 5, 4, 9, 7, 3, 0, 6 };

            Bolillero mibolillero = new Bolillero(numerosWin, 10, 10);


            Assert.True(mibolillero.JugarPrimera());
        }

        [Fact]

        public void SacarBolillaOK()
        {
            List<int> numerosWin = new List<int> { 1, 2, 8, 5, 4, 9, 7, 3, 0, 6 };

            Bolillero mibolillero = new Bolillero(numerosWin, 10, 10);

            mibolillero.JugarPrimera();  // Esto debería ejecutar la extracción de bolillas

            // Verifica que la bolilla 0 esté fuera del bolillero
            Assert.Contains(0, mibolillero.BolillasFuera);

            // Verifica que ahora haya 9 bolillas dentro del bolillero
            Assert.Equal(9, mibolillero.Bolitas.Count);

            // Verifica que solo haya una bolilla fuera del bolillero
            Assert.Single(mibolillero.BolillasFuera);
        }


    }
} 