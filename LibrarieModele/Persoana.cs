using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
   public class Persoana
    {
        private const int DIFERIT = 1;
        private const int EGAL = 0;
        private const int MAX_CARTI = 10;

        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int NrCarti { get; set; }
        public string NumeComplet { get { return Nume + " " + Prenume + " " + NrCarti + " carti"; } }

        public Persoana(string nume, string prenume)
        {
            Nume = nume;
            Prenume = prenume;
            NrCarti = 0;
        }

        public Persoana(string date)
        {
            string[] info = date.Split(new string[] { "," }, StringSplitOptions.None);
            Nume = info[0];
            Prenume = info[1];
            NrCarti = 0;
        }

        public bool MaxCarti()
        {
            if (MAX_CARTI == NrCarti)
                return true;
            else
                return false;
        }

        public string ConversieLaSir()
        {
            return NumeComplet + " " + NrCarti.ToString() + " carti";
        }

        public int Compara(Persoana p)
        {
            if (this.Nume.CompareTo(p.Nume) == DIFERIT)
                return DIFERIT;
            else
            {
                if (this.Prenume.CompareTo(p.Prenume) == EGAL)
                    return EGAL;
                else
                    return DIFERIT;
            }

        }
    }
}
