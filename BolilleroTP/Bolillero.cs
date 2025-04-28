using BolilleroTP;

public class Bolillero : BolitaAleatoria, BolitaSimple
{
    public List<int> BolillasFuera;
    public List<int> Bolitas;
    public List<int> numerosWin;
    int JugarNveces;

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

 parent of 5f25fc7 (V.1 Bolillero)
    public void PrimerBolita(List<int> Bolitas, List<int> BolillasFuera)
    {
        var bolita = Bolitas[0];    // Toma la bolilla de la primera posición
        Bolitas.RemoveAt(0);         // Elimina la bolilla del bolillero
        BolillasFuera.Add(bolita);  // Agrega la bolilla a la lista de bolillas fuera
    }



    public bool JugarPrimera()
    {
        bool gano = false;

        // Este bucle debería estar extrayendo las bolillas en el orden correcto
        for (int i = 0; i < numerosWin.Count; i++)
        {
            PrimerBolita(Bolitas, BolillasFuera);  // Extrae la bolilla
        }

        // Compara si las bolillas fuera coinciden con la jugada ganadora
        if (numerosWin.SequenceEqual(BolillasFuera))
        {
            gano = true;
        }
        MeterBolillasdeAfuera();  // Vuelve a colocar las bolillas fuera al bolillero
        return gano;
    }



    public bool JugarRndm()
    {
        bool gano = false;

        for (int i = 0; i < numerosWin.Count; i++)
        {
        SacarAleatorio(Bolitas, BolillasFuera);

            SacarAleatorio(Bolitas, BolillasFuera); 
 parent of 5f25fc7 (V.1 Bolillero)
        }

        if (numerosWin.SequenceEqual(BolillasFuera))
        {
            gano = true;
        }
        MeterBolillasdeAfuera();
        return gano;
    }

    public void MeterBolillasdeAfuera()
    {
        Bolitas.AddRange(BolillasFuera);
        BolillasFuera.Clear();
    }

    void BolitaSimple.PrimerBolita(List<int> Bolitas, List<int> BolillasFuera)
    {
        if (Bolitas.Count > 0)
        {
            var bolita = Bolitas[0];
            Bolitas.RemoveAt(0);
            BolillasFuera.Add(bolita);
        }
    }
}

 parent of 5f25fc7 (V.1 Bolillero)
