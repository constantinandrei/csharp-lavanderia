// See https://aka.ms/new-console-template for more information
public class Lavaggio : ProgrammaMacchinario
{
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }

    public Lavaggio(string nome, int costo, int durata, int detersivo, int ammorbidente) : base( nome, costo, durata)
    {
        Detersivo = detersivo;
        Ammorbidente = ammorbidente;
    }
}
