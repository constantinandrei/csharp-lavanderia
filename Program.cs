﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Cryptography.X509Certificates;

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
fastWash.asciugatrici[1].AvviaAsciugatura("rapido");
fastWash.asciugatrici[2].AvviaAsciugatura("rapido");
fastWash.asciugatrici[4].AvviaAsciugatura("intenso");
fastWash.StatoMacchine();
fastWash.lavatrici[1].StatoMacchina();
fastWash.asciugatrici[4].StatoMacchina();
fastWash.IncassoTotale();

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
            if (lavatrici[i].IsActive)
                stato = "in funzione";
            Console.WriteLine($"  {lavatrici[i].Id}     | {stato} ");
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
            if (asciugatrici[i].IsActive)
                stato = "in funzione";
            Console.WriteLine($"  {asciugatrici[i].Id}     | {stato} ");
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

public class Lavatrice
{
    public Lavaggio[] lavaggiDisponibili = new Lavaggio[3];
    public int Id { get; }
    public int Gettoni { get; set; }
    public int Detersivo { get; set; }
    public int MaxDetersivo { get; set; }
    public int Ammorbidente { get; set; }
    public int MaxAmmorbidente { get; set; }
    public int DurataLavaggio { get; set; }
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
        DurataLavaggio = 0;
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
            Ammorbidente -= lavaggiDisponibili[indiceLavaggio].Ammorbidente;
            Gettoni += lavaggiDisponibili[indiceLavaggio].Costo;
            DurataLavaggio = lavaggiDisponibili[indiceLavaggio].Durata;
            IsActive = true;
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
        if (IsActive)
            stato = "attiva";
        Console.WriteLine("Stato:             {0}", stato);
        if (IsActive)
            Console.WriteLine("Lavaggio:          {0}", LavaggioAttuale);
        Console.WriteLine("Detersivo:         ml {0}", Detersivo);
        Console.WriteLine("Ammorbidente:      ml {0}", Ammorbidente);
        Console.WriteLine("Durata Lavaggio:   min {0}", DurataLavaggio);
        Console.WriteLine();
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

public class Asciugatrice
{
    public Asciugatura[] asciugatureDisponibili = new Asciugatura[2];
    public int Id { get; }
    public int DurataAsciugatura { get; set; }
    public int Gettoni { get; set; }
    public bool IsActive { get; set; }
    public string AsciugaturaAttuale { get; set; }

    public Asciugatrice(int id)
    {
        Id = id;
        DurataAsciugatura = 0;
        IsActive = false;


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
            AsciugaturaAttuale = asciugatureDisponibili[indiceAsciugatura].Nome;
            DurataAsciugatura = asciugatureDisponibili[indiceAsciugatura].Durata;
            Gettoni += asciugatureDisponibili[indiceAsciugatura].Costo;
            IsActive = true;
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
        if (IsActive)
            stato = "attiva";
        Console.WriteLine("Stato:             {0}", stato);
        if (IsActive)
            Console.WriteLine("Asciugatura:          {0}", AsciugaturaAttuale);
        Console.WriteLine("Durata Asciugatura:   min {0}", DurataAsciugatura);
        Console.WriteLine();
    }
}

public class Asciugatura
{
    public string Nome { get; set; }
    public int Costo { get; set; }
    public int Durata { get; set; }

    public Asciugatura(string nome, int costo, int durata)
    {
        Nome = nome;
        Costo = costo;
        Durata = durata;
    }
}