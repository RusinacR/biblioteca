using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Carte
    {

        private const int DIFERIT= 1;
        private const int EGAL = 0;
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        public static int NextID { get; set; } = 0;
        public int Cod { get; set; }
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public string Editura { get; set; }
        public int NumarExemplare { get; set; }
        public string NumeComplet { get { return Titlu + " " + Autor + " " + Editura; } }
        //public GenCarte { get; set; }
        //public LimbaCarte { get; set; }
        public Carte(string titlu, string autor, string editura, int nrexemplare)
        {
            Titlu = titlu;
            Autor = autor;
            Editura = editura;
            Cod = ++NextID;
            NumarExemplare = nrexemplare;
        }
        public Carte(string date)
        {
            string[] infoCarte = date.Split(SEPARATOR_PRINCIPAL_FISIER);
            Titlu = infoCarte[0];
            Autor = infoCarte[1];
            Editura = infoCarte[2];
            Cod = ++NextID;
        }

        public string ConversieLaSir()
        {
            return NumeComplet + " " + Cod.ToString() + "\nNumar exemplare: " + NumarExemplare.ToString();
        }

        public int Compare(Carte c)
        {
            if (this.Cod != c.Cod)
                return DIFERIT;
            else 
            {
                if (this.Titlu.CompareTo(c.Titlu) == EGAL)
                    return EGAL;
                else 
                    return DIFERIT;
            }
        }   

        public string ConversieLaSir_PentruFisier()
        {
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                SEPARATOR_PRINCIPAL_FISIER, (Titlu ?? "Necunoscut"), 
                (Autor ?? "Necunoscut"), (Editura ?? "Necunoscut"), 
                Cod.ToString(), NumarExemplare.ToString());
            return s;
        }

    }
}
