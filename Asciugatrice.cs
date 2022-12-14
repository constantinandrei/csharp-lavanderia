// See https://aka.ms/new-console-template for more information
public class Asciugatrice : MacchinarioLavanderia
{
    public Asciugatura[] ProgrammiDisponibili { get; set; }

    public Asciugatura ProgrammaCorrente { get; set; }

    public Asciugatrice(int id)
    {
        Id = id;
        ProgrammiDisponibili = new Asciugatura[2];

        // inserisco i programmi di lavaggio
        ProgrammiDisponibili[0] = new Asciugatura("rapido", 2, 30);
        ProgrammiDisponibili[1] = new Asciugatura("intenso", 4, 60);

    }

    public override void AvviaProgramma(string asciugatura)
    {
        bool asciugaturaTrovata = false;
        int indiceAsciugatura = 0;

        for (int i = 0; i < ProgrammiDisponibili.Length; i++)
        {
            if (asciugatura.Equals(ProgrammiDisponibili[i].Nome))
            {
                indiceAsciugatura = i;
                asciugaturaTrovata = true;
            }
        }

        if (asciugaturaTrovata)
        {
            ProgrammaCorrente = ProgrammiDisponibili[indiceAsciugatura];
            Gettoni += ProgrammiDisponibili[indiceAsciugatura].Costo;
            
        }
    }

    //2 - Possa essere richiesto il dettaglio di una macchina:
    //Tutte le informazioni relative alla macchina, nome del macchinario,
    //stato del macchinario (in funzione o no), tipo di lavaggio in corso,
    //quantità di detersivo presente (se una lavatrice), durata del lavaggio.
    public override void StatoMacchina()
    {
        Console.WriteLine();
        Console.WriteLine("Asciugatrice:         {0}", Id);
        string stato = "inattiva";
        if (ProgrammaCorrente != null)
            stato = "attiva";
        Console.WriteLine("Stato:                {0}", stato);
        if (ProgrammaCorrente != null)
        {
            Console.WriteLine("Asciugatura:          {0}", ProgrammaCorrente.Nome);
            Console.WriteLine("Durata Asciugatura:   min {0}", ProgrammaCorrente.Durata);
        }
        Console.WriteLine("Gettoni:              {0}", Gettoni);
        Console.WriteLine();
    }
}
