// BolitaAleatoria.cs
using System;
using System.Collections.Generic;

namespace BolilleroTP
{
    public abstract class BolitaAleatoria
    {
        protected Random IndiceRnd = new Random();

        public virtual void SacarAleatorio(List<int> Bolitas, List<int> BolillasFuera)
        {
            if (Bolitas.Count > 0)
            {
                var indiceRnd = IndiceRnd.Next(0, Bolitas.Count);
                var bolilla = Bolitas[indiceRnd];
                Bolitas.RemoveAt(indiceRnd);
                BolillasFuera.Add(bolilla);
            }
        }
    }
}