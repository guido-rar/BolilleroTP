using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolilleroTP
{
    public abstract class BolitaAleatoria : BolitaSimple
    {
        Random IndiceRnd = new Random();

        public void SacarBolita(List<int> Bolitas, List<int> BolillasFuera)
        {
            throw new NotImplementedException();
        }

        public void SacarAleatorio(List<int> Bolitas, List<int> BolillasFuera)
        {
            var indiceRnd = IndiceRnd.Next(0, Bolitas.Count);
            var bolilla = Bolitas[indiceRnd];
            Bolitas.RemoveAt(indiceRnd);
            BolillasFuera.Add(bolilla); 
        }
    }
}
