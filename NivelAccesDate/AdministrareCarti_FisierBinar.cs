using LibrarieModele;
using System;
using System.Collections.Generic;

namespace NivelAccesDate
{
  
    public class AdministrareCarti_FisierBinar : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareCarti_FisierBinar(string numeFisiser)
        {
            this.NumeFisier = NumeFisier;
        }

        public void AddCarte(Carte s)
        {
            throw new Exception("Optiunea AddStudent nu este implementata");
        }

        public Carte[] GetCarte(out int nrCarte)
        {
            throw new Exception("Optiunea GetCarte nu este implementata");
        }
    }
}
