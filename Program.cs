// See https://aka.ms/new-console-template for more information
using System;

namespace csharp_biblioteca
{
/*  Si vuole progettare un sistema per la gestione di una biblioteca.
    Gli utenti registrati al sistema, fornendo cognome, nome, email, password, recapito telefonico,
    possono effettuare dei prestiti sui documenti che sono di vario tipo (libri, DVD).
    I documenti sono caratterizzati da un codice identificativo di tipo stringa 
    (ISBN per i libri, numero seriale per i DVD), titolo, anno, settore (storia, matematica, economia, …),
    stato (In Prestito, Disponibile), uno scaffale in cui è posizionato, un elenco di autori (Nome, Cognome).
    Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.
    L’utente deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, 
    effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
    Il sistema per ogni prestito determina un numero progressivo di tipo alfanumerico.
    Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un utente.
*/
    internal class Program
    {
        static void Main(string[] args)
        {
        
            Library l = new Library("National");
            if (File.Exists("db.txt"))
            {
                l.RestoreUsers("db.txt");
            }
            Shelf shOne = new Shelf("sh001");
            Shelf shTwo = new Shelf("sh002");
            Shelf shThree = new Shelf("sh003");

            Book b1 = new Book("ISBN1", "Title1", 1995, "Thriller", 400);
            Book b2 = new Book("ISBN2", "Title2", 1998, "Thriller", 500);
            Book b3 = new Book("ISBN3", "Title3", 2005, "Thriller", 600);
           
            Auth a1 = new Auth("Mario", "Rossi");
            Auth a2 = new Auth("Mario", "Bianchi");

            b1.Authors.Add(a1);
            b2.Authors.Add(a1);

            b1.Shelf = shOne;
            b2.Shelf = shTwo;
            b3.Shelf = shThree; 

            l.Documents.Add(b1);
            l.Documents.Add (b2);
            l.Documents.Add (b3);
         
            Users u1 = new Users("Rossi", "Mario", "344585556", "mariorossi@gmail.com","password");
            Users u2 = new Users("Bianchi", "Mario", "3445123123", "mariobianchi@gmail.com", "password");

            //Add users to List
            l.ListUsers.AddUser(u1);
            l.ListUsers.AddUser(u2);
            //Save on FileSystem
            l.SaveUsers("db.txt", u1);
            l.SaveUsers("db.txt", u2);

            Loan Loan1 = new Loan("L0001", new DateTime(2022, 05, 20), new DateTime(2022, 08, 20),u1,b1);
            Loan Loan2 = new Loan("L002", new DateTime(2020, 08, 15), new DateTime(2020, 10, 15), u2, b3);

            l.Loans.Add(Loan1);
            l.Loans.Add(Loan2);

            /*Console.WriteLine("Cosa vuoi fare?");
            Console.WriteLine("1: Stampare un Utente");
            Console.WriteLine("2: Stampare un Libro");
            Console.WriteLine("3: Stampare un DvD");*/

            List<Documents> results = l.SearchByCode("ISBN1");

            foreach(Documents d in results)
            {
                Console.WriteLine (d.ToString());
            }


        }
    }
}
