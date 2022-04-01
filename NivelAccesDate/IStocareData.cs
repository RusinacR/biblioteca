using LibrarieModele;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddCarte(Carte s);
        Carte[] GetCarte(out int nrCarte);
    }
}
