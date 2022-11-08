// See https://aka.ms/new-console-template for more information
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
fastWash.lavatrici[0].StatoMacchina();
fastWash.lavatrici[4].StatoMacchina();
fastWash.asciugatrici[0].StatoMacchina();
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
            if (lavatrici[i].ProgrammaCorrente != null)
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
            if (asciugatrici[i].ProgrammaCorrente != null)
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
