// See https://aka.ms/new-console-template for more information
public class Serbatoio
{
   int MaxVolume { get; }
   public int Livello { get; set; }

    public Serbatoio(int maxVolume)
    {
        MaxVolume = maxVolume;
        Livello = maxVolume;
    }

    public bool UsaLiquido (int ammount)
    {
        if (Livello >= ammount)
        {
            Livello -= ammount;
            return true;
        }

        return false;
    }

    public bool Riempi (int ammount)
    {
        if (MaxVolume - Livello > ammount)
        {
            Livello += ammount;
            return true;
        }
        return false ;
    }
}
