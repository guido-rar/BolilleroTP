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

    public Bolillero Clonar()
    {
        List<int> numerosWinClon = new List<int>(numerosWin);
        int jugarXvecesClon = JugarNveces;
        int rangoOriginal = Bolitas.Count + BolillasFuera.Count;


        Bolillero clon = new Bolillero(numerosWinClon, jugarXvecesClon, rangoOriginal);
        clon.BolillasFuera = new List<int>(BolillasFuera);

        clon.Bolitas = new List<int>(Bolitas);
        return clon;
    }

    public long JugarNVeces(int numJugadas, bool usarPrimera = true)
    {
        long aciertos = 0;

        for (int i = 0; i < numJugadas; i++)
        {
            bool gano = usarPrimera ? JugarPrimera() : JugarRndm();
            if (gano) aciertos++;

        }

        return aciertos;
    }


    public void PrimerBolita(List<int> Bolitas, List<int> BolillasFuera)
    {
        var bolita = Bolitas[0];    
        Bolitas.RemoveAt(0);        
        BolillasFuera.Add(bolita);  
    }



    public bool JugarPrimera()
    {
        bool gano = false;

       
        for (int i = 0; i < numerosWin.Count; i++)
        {
            PrimerBolita(Bolitas, BolillasFuera);  
        }

        
        if (numerosWin.SequenceEqual(BolillasFuera))
        {
            gano = true;
        }
        MeterBolillasdeAfuera(); 
        return gano;
    }



    public bool JugarRndm()
    {
        bool gano = false;

        for (int i = 0; i < numerosWin.Count; i++)
        {
            SacarAleatorio(Bolitas, BolillasFuera);
        }

        if (numerosWin.SequenceEqual(BolillasFuera))
        {
            gano = true;
        }
        
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