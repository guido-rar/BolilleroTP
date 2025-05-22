using BolilleroTP;

public class Bolillero 
{
    public List<int> BolillasFuera;
    public List<int> Bolitas;
    public List<int> numerosWin;



    public Bolillero(List<int> numWin, int rango)
    {
        numerosWin = numWin;
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
        int rangoOriginal = Bolitas.Count + BolillasFuera.Count;


        Bolillero clon = new Bolillero(numerosWinClon, rangoOriginal);
        clon.BolillasFuera = new List<int>(BolillasFuera);

        clon.Bolitas = new List<int>(Bolitas);
        return clon;
    }

    public long JugarNVeces(int numJugadas, ILogica logica)
    {
        long aciertos = 0;

        for (int i = 0; i < numJugadas; i++)
        {
            if (Jugar(logica)) aciertos++;

        }

        return aciertos;
    }

    public bool Jugar(ILogica logica)
    {

        for (int i = 0; i < numerosWin.Count; i++)
        {
            int bolilla = logica.SacarBolita(this);
        }

        bool gano = numerosWin.SequenceEqual(BolillasFuera);

        MeterBolillasdeAfuera();
        return gano;
    }

    public void MeterBolillasdeAfuera()
    {
        Bolitas.AddRange(BolillasFuera);
        BolillasFuera.Clear();
    }

}