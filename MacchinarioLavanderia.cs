// See https://aka.ms/new-console-template for more information
public abstract class MacchinarioLavanderia
{
    public int Id { get; set; }

    public int Gettoni { get; set; }
    public abstract void AvviaProgramma(string programma);
    public abstract void StatoMacchina();

}