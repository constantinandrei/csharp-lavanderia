// See https://aka.ms/new-console-template for more information
public class Lavanderia
{
    public string Nome {get;}
    public Lavatrice[] lavatrici = new Lavatrice[5];
    public Asciugatrice[] asciugatrici = new Asciugatrice[5];
    public double ValoreGettone { get;set;}
    public Lavanderia(string nome)
    {
        Nome = nome;
        ValoreGettone = 0.5;
        for (int i = 0; i < lavatrici.Length; i++)
        {
            lavatrici[i] = new Lavatrice(i + 1);
        }
        for (int i = 0; i < asciugatrici.Length; i++)
        {
            asciugatrici[i] = new Asciugatrice(i + 1);
        }
    }

    public void StatoMacchine()
    {
        Console.WriteLine("Lavanderia " + Nome);
        Console.WriteLine("-----------");
        Console.WriteLine("Stato Lavatrici:");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("numero  | stato                 ");
        Console.WriteLine("--------------------------------");
        for (int i = 0; i < lavatrici.Length; i++)
        {
            string stato = "ferma";
            if (lavatrici[i].ProgrammaCorrente != null)
                stato = "in funzione";
            Console.WriteLine($" l{lavatrici[i].Id}     | {stato} ");
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine();
        Console.WriteLine("Stato Asciugatrici:");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("numero  | stato                 ");
        Console.WriteLine("--------------------------------");
        for (int i = 0; i < asciugatrici.Length; i++)
        {
            string stato = "ferma";
            if (asciugatrici[i].ProgrammaCorrente != null)
                stato = "in funzione";
            Console.WriteLine($" a{asciugatrici[i].Id}     | {stato} ");
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine();
    
}



    public void IncassoTotale()
    {
        int gettoni = 0;
        for (int i = 0; i < lavatrici.Length; i++)
        {
            gettoni += lavatrici[i].Gettoni;
        }
        for (int i = 0; i < asciugatrici.Length; i++)
        {
            gettoni += asciugatrici[i].Gettoni;
        }

        Console.WriteLine();
        Console.WriteLine("Incasso totale lavanderia: " + (gettoni * ValoreGettone) + " euro");
        Console.WriteLine();
    }
}
