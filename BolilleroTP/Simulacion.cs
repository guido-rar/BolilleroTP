namespace BolilleroTP
{
    public class Simulacion
    {
        public long SimulaciosSinHilos(Bolillero bolilla1,int jugadas, int cantSimu)
        {

            int cantWin;
            for (int i = 0; i < cantSimu; i++)
            {
                bolilla1.JugarRndm();
                if(bolilla1.JugarRndm())
                   {
                    cantWin++;
                   }
            }

            return cantWin;
        }
    }
}
