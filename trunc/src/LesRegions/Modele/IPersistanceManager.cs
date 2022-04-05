using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{
    public interface IPersistanceManager
    {
        void Sauvegarde(IEnumerable<Utilisateur> utilisateurs, IEnumerable<Region> regions);
        (IEnumerable<Utilisateur> utilisateurs, IEnumerable<Region> regions) Charge();
    }
}
