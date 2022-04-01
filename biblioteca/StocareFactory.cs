using NivelAccesDate;
using LibrarieModele;

using System.Configuration;
using System;

namespace biblioteca
{
    public static class StocareFactory
    {
        private const string FORMAT_SALVARE = "FormatSalvare";
        private const string NUME_FISIER = "NumeFisier";
        public static IStocareData GetAdministratorStocare()
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisier = ConfigurationManager.AppSettings[NUME_FISIER];
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "bin":
                        return new AdministrareCarti_FisierBinar(numeFisier + "." + formatSalvare);
                    case "txt":
                        return new AdministrareCarti_FisierText(numeFisier + "." + formatSalvare);
                }
            }

            return null;
        }
    }
}
