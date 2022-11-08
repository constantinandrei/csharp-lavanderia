// See https://aka.ms/new-console-template for more information
public class Lavatrice : MacchinarioLavanderia
{

    public Serbatoio Detersivo { get; set; }
    public Serbatoio Ammorbidente { get; set; }
    public Lavaggio[] ProgrammiDisponibili { get; set; }

    public Lavaggio ProgrammaCorrente { get; set; }

    public Lavatrice(int id)
    {
        Id = id;
        Gettoni = 0;
        Detersivo = new Serbatoio(1000);
        Ammorbidente = new Serbatoio(500);

        ProgrammiDisponibili = new Lavaggio[3];

        // inserisco i programmi di lavaggio
        ProgrammiDisponibili[0] = new Lavaggio("rinfrescante", 2, 20, 20, 5);
        ProgrammiDisponibili[1] = new Lavaggio("rinnovante", 3, 40, 40, 10);
        ProgrammiDisponibili[2] = new Lavaggio("sgrassante", 4, 60, 60, 15);

    }

    public void AvviaLavaggio(string lavaggio)
    {
        bool lavaggioTrovato = false;
        int indiceLavaggio = 0;

        for (int i = 0; i < ProgrammiDisponibili.Length; i++)
        {
            if (lavaggio.Equals(ProgrammiDisponibili[i].Nome))
            {
                indiceLavaggio = i;
                lavaggioTrovato = true;
            }
        }

        if (lavaggioTrovato)
        {

            ProgrammaCorrente = ProgrammiDisponibili[indiceLavaggio];
            Ammorbidente.UsaLiquido(ProgrammiDisponibili[indiceLavaggio].Ammorbidente); 
            Detersivo.UsaLiquido(ProgrammiDisponibili[indiceLavaggio].Detersivo); 
            Gettoni += ProgrammiDisponibili[indiceLavaggio].Costo;
        }
    }

    //2 - Possa essere richiesto il dettaglio di una macchina:
    //Tutte le informazioni relative alla macchina, nome del macchinario,
    //stato del macchinario (in funzione o no), tipo di lavaggio in corso,
    //quantità di detersivo presente (se una lavatrice), durata del lavaggio.
    public void StatoMacchina()
    {
        Console.WriteLine();
        Console.WriteLine("Lavatrice:         {0}", Id);
        string stato = "inattiva";
        if (ProgrammaCorrente != null)
            stato = "attiva";
        Console.WriteLine("Stato:             {0}", stato);
        if (ProgrammaCorrente != null)
        {
            Console.WriteLine("Lavaggio:          {0}", ProgrammaCorrente.Nome);
            Console.WriteLine("Durata Lavaggio:   min {0}", ProgrammaCorrente.Durata);
        }
        Console.WriteLine("Detersivo:         ml {0}", Detersivo.Livello);
        Console.WriteLine("Ammorbidente:      ml {0}", Ammorbidente.Livello);
        Console.WriteLine("Gettoni:           {0}", Gettoni);
        Console.WriteLine();
    }
}
