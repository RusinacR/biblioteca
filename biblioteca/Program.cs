using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NivelAccesDate;
using LibrarieModele;

namespace biblioteca
{
    class Program
    {
        public const int DIFERIT = 1;
        public const int EGAL = 0;

        static void Main(string[] args)
        {
            Carte[] carti;
            IStocareData adminCarti = StocareFactory.GetAdministratorStocare();
            
            int nrCarti;
            carti = adminCarti.GetCarte(out nrCarti);
            Carte.NextID = nrCarti;

            string optiune;
            do
            {
                Console.WriteLine("\t\tARHIVA BIBLIOTECII ");
                Console.WriteLine("//-----------------------------------------------------------//");
                Console.WriteLine("\t\tL: Listare carti\n" +
                    "\t\tA: Adăugare carte\n" +
                    "\t\tM: Modificare carte\n" +
                    "\t\tX: Exit");
                Console.WriteLine("//-----------------------------------------------------------//");
                Console.WriteLine("Dati optiunea: ");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "L":
                        AfisareCarti(carti, nrCarti);
                        Console.ReadKey();
                        break;
                    case "A":
                        Carte s = CitireCarteTastatura();
                        carti[nrCarti] = s;
                        nrCarti++;
                        adminCarti.AddCarte(s);
                        Console.ReadKey();
                        break;
                    case "M":
                        Console.WriteLine("TitluL cărții: ");
                        string titlux = Console.ReadLine();
                        Console.WriteLine("Autorul cărții: ");
                        string autorx = Console.ReadLine();
                        Console.WriteLine("Editura cărții: ");
                        string editurax = Console.ReadLine();
                        s = CautareCarte(titlux, autorx, editurax, nrCarti, carti);
                        if (s != null)
                        {
                            int x;
                            Console.WriteLine("Număr de exemplare în bibliotecă:");
                            bool m = Int32.TryParse(Console.ReadLine(), out x);
                            if (m == true)
                                s.NumarExemplare = x;
                            else
                                Console.WriteLine(" Numarul introdus este invalid");
                        }
                        else
                            Console.WriteLine("Nu s-a găsit această carte");
                       
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Opțiune invalidă");
                        break;
                }
                Console.Clear();
            } while (optiune.ToUpper() != "X");
            Console.ReadKey();
        }
        public static Carte CitireCarteTastatura()
        {
            Console.WriteLine("Titlu: ");
            string titlu = Console.ReadLine();
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Console.WriteLine("Editura: ");
            string editura = Console.ReadLine();
            Console.WriteLine("Numar exemplare: ");
            int nrexemplare = Convert.ToInt32(Console.ReadLine());
            Carte c = new Carte(titlu, autor, editura, nrexemplare);
            return c;
        }
        public static Persoana CitirePersoanaTastatura()
        {
            Console.WriteLine("Introduceti numele: ");
            string nume = Console.ReadLine();
            Console.WriteLine("introduceti prenumele: ");
            string prenume = Console.ReadLine();
            Persoana c = new Persoana(nume, prenume);
            return c;
        }

        public static Persoana CautarePersoana(string nume, string prenume, int nrPersoane, Persoana[] persoana)
        {
            for (int i = 0; i < nrPersoane; i++)
            {
                if (string.Equals(nume, persoana[i] )&& string.Equals(prenume, persoana[i]))
                    return persoana[i];
            }
            return null;
        }

        public static void AfisareCarti(Carte[] carti, int nrCarti)
        {
            Console.WriteLine("Colectia de carti: ");
            for (int i = 0; i < nrCarti; i++)
            {
                Console.WriteLine(carti[i].ConversieLaSir());
            }
        }

        public static Carte CautareCarte(string titlux, string autorx, string editurax, int nrCarti, Carte[] carti)
        {
            for (int i = 0; i < nrCarti; i++)
            {
                if (titlux.CompareTo(carti[i].Titlu) == 0 && autorx.CompareTo(carti[i].Autor) == 0 && editurax.CompareTo(carti[i].Editura) == 0)
                    return carti[i];
            }
            return null;
        }
    }
}

