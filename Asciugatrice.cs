// See https://aka.ms/new-console-template for more information
public class Asciugatrice : MacchinarioLavanderia
{
    public Asciugatura[] asciugatureDisponibili = new Asciugatura[2];
    public int DurataAsciugatura { get; set; }
    public Asciugatura AsciugaturaAttuale { get; set; }

    public Asciugatrice(int id)
    {
        Id = id;
        DurataAsciugatura = 0;


        // inserisco i programmi di lavaggio
        asciugatureDisponibili[0] = new Asciugatura("rapido", 2, 30);
        asciugatureDisponibili[1] = new Asciugatura("intenso", 4, 60);

    }

    public void AvviaAsciugatura(string asciugatura)
    {
        bool asciugaturaTrovata = false;
        int indiceAsciugatura = 0;

        for (int i = 0; i < asciugatureDisponibili.Length; i++)
        {
            if (asciugatura.Equals(asciugatureDisponibili[i].Nome))
            {
                indiceAsciugatura = i;
                asciugaturaTrovata = true;
            }
        }

        if (asciugaturaTrovata)
        {
            AsciugaturaAttuale = asciugatureDisponibili[indiceAsciugatura];
            DurataAsciugatura = asciugatureDisponibili[indiceAsciugatura].Durata;
            Gettoni += asciugatureDisponibili[indiceAsciugatura].Costo;
            
        }
    }

    //2 - Possa essere richiesto il dettaglio di una macchina:
    //Tutte le informazioni relative alla macchina, nome del macchinario,
    //stato del macchinario (in funzione o no), tipo di lavaggio in corso,
    //quantità di detersivo presente (se una lavatrice), durata del lavaggio.
    public void StatoMacchina()
    {
        Console.WriteLine();
        Console.WriteLine("Asciugatrice:         {0}", Id);
        //string stato = "inattiva";
        //if (IsActive)
        //    stato = "attiva";
        //Console.WriteLine("Stato:                {0}", stato);
        //if (IsActive)
        //{
        //    Console.WriteLine("Asciugatura:          {0}", AsciugaturaAttuale.Nome);
        //    Console.WriteLine("Durata Asciugatura:   min {0}", DurataAsciugatura);
        //}
        //Console.WriteLine("Gettoni:              {0}", Gettoni);
        //Console.WriteLine();
    }
}
