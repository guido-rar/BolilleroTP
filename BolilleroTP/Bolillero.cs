using System.Collections.Generic;
using System.Linq;

namespace BolilleroTP
{
    public class Bolillero : BolitaAleatoria, BolitaSimple
    {
        public List<int> BolillasFuera { get; private set; }
        public List<int> Bolitas { get; private set; }
        public List<int> numerosWin { get; private set; }
        private int JugarNveces;

        public Bolillero(List<int> numWin, int jugarXveces, int rango)
        {
            numerosWin = numWin;
            JugarNveces = jugarXveces;
            Bolitas = new List<int>();
            BolillasFuera = new List<int>();

            for (int i = 0; i < rango; i++)
            {
                Bolitas.Add(i);
            }
        }


        public void PrimerBolita(List<int> Bolitas, List<int> BolillasFuera)
        {
            if (Bolitas.Count > 0)
            {
                var bolita = Bolitas[0];
                Bolitas.RemoveAt(0);
                BolillasFuera.Add(bolita);
            }
        }

        
        public bool JugarPrimera()
        {
            BolillasFuera.Clear(); 

            for (int i = 0; i < numerosWin.Count && i < Bolitas.Count; i++)
            {
                PrimerBolita(Bolitas, BolillasFuera);
            }

            bool gano = numerosWin.SequenceEqual(BolillasFuera);
            return gano;
        }

       
        public bool JugarRndm()
        {
            BolillasFuera.Clear();

            for (int i = 0; i < numerosWin.Count && Bolitas.Count > 0; i++)
            {
                SacarAleatorio(Bolitas, BolillasFuera);
            }

            bool gano = numerosWin.SequenceEqual(BolillasFuera);
            return gano;
        }

        
        public int JugarNVeces(bool usarPrimera = true)
        {
            int aciertos = 0;

            for (int i = 0; i < JugarNveces; i++)
            {
                bool gano = usarPrimera ? JugarPrimera() : JugarRndm();
                if (gano) aciertos++;
                MeterBolillasdeAfuera();
            }

            return aciertos;
        }

     
        public void MeterBolillasdeAfuera()
        {
            Bolitas.AddRange(BolillasFuera);
            BolillasFuera.Clear();
        }

        
        void BolitaSimple.PrimerBolita(List<int> Bolitas, List<int> BolillasFuera)
        {
            PrimerBolita(Bolitas, BolillasFuera);
        }
    }
}