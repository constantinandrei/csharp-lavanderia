// See https://aka.ms/new-console-template for more information
public class Serbatoio
{
    int MaxVolume { get; set; }
    int Livello { get; set; }

    public Serbatoio(int maxVolume)
    {
        MaxVolume = maxVolume;
        Livello = maxVolume;
    }
}
