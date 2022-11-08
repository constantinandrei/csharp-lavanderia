// See https://aka.ms/new-console-template for more information
public abstract class MacchinarioLavanderia
{
    public int Id { get; set; }

    public int Gettoni { get; set; }
    public ProgrammaMacchinario[] ProgrammiDisponibili { get; set; }
    
    public ProgrammaMacchinario ProgrammaCorrente { get; set; }

}