// See https://aka.ms/new-console-template for more information
using System;
using System.Dynamic;
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
fastWash.lavatrici[0].AvviaProgramma("rinnovante");
fastWash.lavatrici[2].AvviaProgramma("sgrassante");
fastWash.asciugatrici[1].AvviaProgramma("rapido");
fastWash.asciugatrici[2].AvviaProgramma("rapido");
fastWash.asciugatrici[4].AvviaProgramma("intenso");

string[] vociMenu = { "Stato macchine", "Dettaglio Macchina", "Incasso totale" };
string userInput;

do
{
    StampaMenu(vociMenu);
    userInput = Chiedi("Scegliere un azione, scrivere 'esc' per uscire");

    switch (userInput)
    {
        case "1":
            fastWash.StatoMacchine();
            break;
        case "2":
            fastWash.StatoMacchine();
            string codiceMacchina = Chiedi("per quale macchina vuoi vedere lo stato? (inserire il codice)");
            StampaStatoMacchina(codiceMacchina);
            break;
        case "3":
            fastWash.IncassoTotale();
            break;
        default:
            break;
    }
} while (userInput != "esc");

string Chiedi(string messaggio)
{
    Console.WriteLine(messaggio);
    return Console.ReadLine();
}

void StampaMenu(string[] voci)
{
    int i = 1;
    foreach (string voce in voci)
    {
        Console.WriteLine("{0}. {1}", i, voce);
        i++;
    }
}

void StampaStatoMacchina(string codice)
{
    string tipoMacchina = codice.Substring(0, 1);
    int idMacchina = Convert.ToInt32(codice.Substring(1, 1));

    switch (tipoMacchina)
    {
        case "a":
            fastWash.asciugatrici[idMacchina - 1].StatoMacchina();
            break;
        case "l":
            fastWash.lavatrici[idMacchina - 1].StatoMacchina();
            break;
        default:
            break;
    }
}