// See https://aka.ms/new-console-template for more information
using System;
using System.IO;


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
            //Fileconfig.ReadAllSettings();
            //Check if Environment Variable "Public" is there
            string vPublicEnv = Environment.GetEnvironmentVariable("PUBLIC");
            if(vPublicEnv != null)
                Console.WriteLine("Valore: {0}", vPublicEnv);
            //Standard Path in Local
            string stPath = vPublicEnv + "/Biblioteca";
            //Filesystem Path 
            string filePath = stPath + "/biblioteca.txt";
            //Check if the "Biblioteca" folder is there
            if (!Directory.Exists(stPath))
            {
                Console.WriteLine("Inserisci la path del file di configurazione, se sei sul Server premi INVIO");
                string Path = Console.ReadLine();
                if (Path == "")
                {
                    try
                    {
                        // Try to create the directory.
                        Directory.CreateDirectory(stPath);
                        Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(stPath));
                        StreamWriter sw = new StreamWriter("library-info.txt");
                        sw.WriteLine("Section : fileConfig");
                        sw.WriteLine(filePath);
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The process failed: {0}", ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        // Try to create the directory.
                        Directory.CreateDirectory(stPath);
                        Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(stPath));
                        StreamWriter sw = new StreamWriter("library-info.txt");
                        sw.WriteLine("Section : fileConfig");
                        sw.WriteLine(Path);
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The process failed: {0}", ex.ToString());
                    }
                }
            }

            Library l = new Library("National");

            Console.WriteLine("Sono qui");
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line;
                string genString = "";
                while ((line = sr.ReadLine()) != null)
                {
                    genString += line;
                    line = sr.ReadLine();
                }
                sr.Close();
                if(genString.Length > 0)
                    l.RestoreUsers(filePath);
           
            }
            Console.WriteLine("Non sono entrato nel restore");
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
            l.SaveUsers(filePath, u1);
            l.SaveUsers(filePath, u2);

            Loan Loan1 = new Loan("L0001", new DateTime(2022, 05, 20), new DateTime(2022, 08, 20),u1,b1);
            Loan Loan2 = new Loan("L002", new DateTime(2020, 08, 15), new DateTime(2020, 10, 15), u2, b3);

            l.Loans.Add(Loan1);
            l.Loans.Add(Loan2);

           

            List<Documents> results = l.SearchByCode("ISBN1");

            foreach(Documents d in results)
            {
                Console.WriteLine (d.ToString());
            }


        }
    }
}
