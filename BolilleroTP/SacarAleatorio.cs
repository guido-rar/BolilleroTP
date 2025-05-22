using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolilleroTP
{
    public class SacarAleatorio : ILogica
    {
        private Random random = new Random();

        public int SacarBolita(Bolillero bolillero)
        {

            int indice = random.Next(bolillero.Bolitas.Count);
            int bolita = bolillero.Bolitas[indice];
            bolillero.Bolitas.RemoveAt(indice);
            bolillero.BolillasFuera.Add(bolita);

            return bolita;
        }
    }
}
