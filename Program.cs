﻿// See https://aka.ms/new-console-template for more information
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

Lavatrice test = new Lavatrice(1);

public class Lavatrice
{
    private Lavaggio[] lavaggiDisponibili = new Lavaggio[3];
    public int Id { get; }
    public int Gettoni { get; set; }
    public bool IsActive { get; set; }

    public Lavaggio LavaggioAttuale { get; set; }
   public Lavaggio LavaggiDisponibili { get; set; }
    public Lavatrice(int id)
    {
        Id = id;
        Gettoni = 0;
        IsActive = false;

        // inserisco i programmi di lavaggio
        lavaggiDisponibili[0] = new Lavaggio("rinfrescante", 2, 20, 20, 5);
        lavaggiDisponibili[1] = new Lavaggio("rinnovante", 3, 40, 40, 10);
        lavaggiDisponibili[2] = new Lavaggio("sgrassante", 4, 60, 60, 15);

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