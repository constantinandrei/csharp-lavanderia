// See https://aka.ms/new-console-template for more information
public abstract class ProgrammaMacchinario
{
    public string Nome { get; set; }
    public int Costo { get; set; }
    public int Durata { get; set; }

    public ProgrammaMacchinario(string nome, int costo, int durata)
    {
        Nome = nome;
        Costo = costo;
        Durata = durata;
    }
}