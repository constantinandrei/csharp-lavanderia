// See https://aka.ms/new-console-template for more information
public class Lavatrice : MacchinarioLavanderia
{
    public Lavaggio[] lavaggiDisponibili = new Lavaggio[3];

    public int Detersivo { get; set; }
    public int MaxDetersivo { get; set; }
    public int Ammorbidente { get; set; }
    public int MaxAmmorbidente { get; set; }
    public int DurataLavaggio { get; set; }
    public Lavaggio LavaggioAttuale { get; set; }
   
    public Lavatrice(int id)
    {
        Id = id;
        MaxDetersivo = 1000;
        MaxAmmorbidente = 500;
        Gettoni = 0;
        Detersivo = MaxDetersivo;
        Ammorbidente = MaxAmmorbidente;
        DurataLavaggio = 0;


        // inserisco i programmi di lavaggio
        lavaggiDisponibili[0] = new Lavaggio("rinfrescante", 2, 20, 20, 5);
        lavaggiDisponibili[1] = new Lavaggio("rinnovante", 3, 40, 40, 10);
        lavaggiDisponibili[2] = new Lavaggio("sgrassante", 4, 60, 60, 15);

    }

    public void AvviaLavaggio(string lavaggio)
    {
        bool lavaggioTrovato = false;
        int indiceLavaggio = 0;

        for (int i = 0; i < lavaggiDisponibili.Length; i++)
        {
            if (lavaggio.Equals(lavaggiDisponibili[i].Nome))
            {
                indiceLavaggio = i;
                lavaggioTrovato = true;
            }
        }

        if (lavaggioTrovato)
        {
            LavaggioAttuale = lavaggiDisponibili[indiceLavaggio];
            Detersivo -= lavaggiDisponibili[indiceLavaggio].Detersivo;
            Ammorbidente -= lavaggiDisponibili[indiceLavaggio].Ammorbidente;
            Gettoni += lavaggiDisponibili[indiceLavaggio].Costo;
            DurataLavaggio = lavaggiDisponibili[indiceLavaggio].Durata;
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
        //string stato = "inattiva";
        //if (IsActive)
        //    stato = "attiva";
        //Console.WriteLine("Stato:             {0}", stato);
        //if (IsActive) 
        //{
        //    Console.WriteLine("Lavaggio:          {0}", LavaggioAttuale.Nome);
        //    Console.WriteLine("Durata Lavaggio:   min {0}", DurataLavaggio);
        //}
        Console.WriteLine("Detersivo:         ml {0}", Detersivo);
        Console.WriteLine("Ammorbidente:      ml {0}", Ammorbidente);
        Console.WriteLine("Gettoni:           {0}", Gettoni);
        Console.WriteLine();
    }
}
