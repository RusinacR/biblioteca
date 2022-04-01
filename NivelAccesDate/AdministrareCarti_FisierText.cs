using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;

namespace NivelAccesDate
{
  
    public class AdministrareCarti_FisierText : IStocareData
    {
        private const int PAS_ALOCARE = 10;
        string NumeFisier { get; set; }
        public AdministrareCarti_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();

            
        }
        public void AddCarte(Carte s)
        {
            try
            {
                
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(s.ConversieLaSir_PentruFisier());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public Carte[] GetCarte(out int nrCarti)
        {
            Carte[] Carti = new Carte[PAS_ALOCARE];

            try
            {
               
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    nrCarti = 0;

         
                    while ((line = sr.ReadLine()) != null)
                    {
                        Carti[nrCarti++] = new Carte(line);
                        if (nrCarti == PAS_ALOCARE)
                        {
                            Array.Resize(ref Carti, nrCarti + PAS_ALOCARE);
                        }
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return Carti;
        }
    }
}
