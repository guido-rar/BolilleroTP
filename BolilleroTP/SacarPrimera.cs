namespace BolilleroTP;

public class SacarPrimera : ILogica
{
    public int SacarBolita(Bolillero bolillero)
    {

        int bolita = bolillero.Bolitas[0];
        bolillero.Bolitas.RemoveAt(0);
        bolillero.BolillasFuera.Add(bolita);

        return bolita;
    }
}

