// See https://aka.ms/new-console-template for more information
using System;

//Una lavanderia è aperta 24 ore su 24 e permette ai clienti di servizi autonomamente di 5 Lavatrici e 5 Asciugatrici.
//I clienti che usufruiscono delle macchine, possono effettuare diversi programmi di lavaggio e asciugatura ognuno con un costo diverso (in gettoni) e di una specifica durata.
//Ogni gettone costa 0.50 centesimi di euro e ogni lavaggio consuma detersivo e ammorbidente dai serbatoi della lavatrice.
//Ogni lavatrice può tenere fino ad un massimo di 1 litro di detersivo e 500ml di ammorbidente.
//I programmi di lavaggio hanno quindi queste caratteristiche
//Rinfrescante, costo di 2 gettoni, durata di 20 minuti, consumo di 20ml di detersivo e 5ml di ammorbidente.
//Rinnovante, costo di 3 gettoni, durata di 40 minuti, consumo di 40ml di detersivo e 10ml di ammorbidente.
//Sgrassante, costo di 4 gettoni, durata di 60 minuti, consumo di 60 ml di detersivo e 15ml di ammorbidente.
//Le asciugatrici invece hanno soltanto due programmi di asciugatura, rapido 2 gettoni e intenso 4 gettoni della durata di 30 minuti e 60 minuti rispettivamente.
//Si richiede di creare un sistema di controllo in grado di riportare lo stato della lavanderia, in particolare si vuole richiedere:
//1 - Lo stato generale di utilizzo delle macchine: un elenco di tutte le macchine che semplicemente dica quali sono in funzione e quali non lo sono (in lavaggio / asciugatura oppure ferme)
//2 - Possa essere richiesto il dettaglio di una macchina: Tutte le informazioni relative alla macchina, nome del macchinario, stato del macchinario (in funzione o no), tipo di lavaggio in corso,
//quantità di detersivo presente (se una lavatrice), durata del lavaggio.
//3 - l’attuale incasso generato dall’utilizzo delle macchine.
//Buon Lavoro!


Lavanderia fastWash = new Lavanderia("Fast Wash");
fastWash.lavatrici[0].AvviaLavaggio("rinnovante");
fastWash.lavatrici[2].AvviaLavaggio("sgrassante");
fastWash.StatoMacchine();

public class Lavanderia
{
    public string Nome {get;}
    public Lavatrice[] lavatrici = new Lavatrice[5];
    public Lavanderia(string nome)
    {
        Nome = nome;
        for (int i = 0; i < lavatrici.Length; i++)
        {
            lavatrici[i] = new Lavatrice(i + 1);
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
            if (lavatrici[i].IsActive)
                stato = "in funzione";
            Console.WriteLine($"  {lavatrici[i].Id}     | {stato} ");
        }

        Console.WriteLine("--------------------------------");
    }
}

public class Lavatrice
{
    public Lavaggio[] lavaggiDisponibili = new Lavaggio[3];
    public int Id { get; }
    public int Gettoni { get; set; }
    public int Detersivo { get; set; }
    public int MaxDetersivo { get; set; }
    public int Ammorbidente { get; set; }
    public int MaxAmmorbidente { get; set; }
    public bool IsActive { get; set; }
    public string LavaggioAttuale { get; set; }
   
    public Lavatrice(int id)
    {
        Id = id;
        MaxDetersivo = 1000;
        MaxAmmorbidente = 500;
        Gettoni = 0;
        Detersivo = MaxDetersivo;
        Ammorbidente = MaxAmmorbidente;
        IsActive = false;


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
            LavaggioAttuale = lavaggiDisponibili[indiceLavaggio].Nome;
            Detersivo -= lavaggiDisponibili[indiceLavaggio].Detersivo;
            Detersivo -= lavaggiDisponibili[indiceLavaggio].Ammorbidente;
            Gettoni += lavaggiDisponibili[indiceLavaggio].Costo;
            IsActive = true;
        }
    }

}

public class Lavaggio
{
    public string Nome { get; set; }
    public int Costo { get; set; }
    public int Durata { get; set; }
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }

    public Lavaggio(string nome, int costo, int durata, int detersivo, int ammorbidente)
    {
        Nome = nome;
        Costo = costo;
        Durata = durata;
        Detersivo = detersivo;
        Ammorbidente = ammorbidente;
    }
}