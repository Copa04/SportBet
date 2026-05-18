// Autor: Echipa SportBet
// Functionalitate: Implementarea repository-ului pentru tichete.
//                  Stocheaza si gestioneaza tichetele in memorie,
//                  implementand contractul definit de ITichetRepository.

using System;
using System.Collections.Generic;
using SportBet.Models;

namespace SportBet.Repositories
{
    /// <summary>
    /// Implementare in-memory a repository-ului pentru entitatea Tichet.
    /// </summary>
    public class TichetRepository : ITichetRepository
    {
        #region Campuri private

        /// <summary>Lista interna care stocheaza toate tichetele.</summary>
        private readonly List<Tichet> _tichete;

        /// <summary>Contor pentru generarea ID-urilor unice.</summary>
        private int _nextId;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor implicit. Initializeaza lista si contorul de ID-uri.
        /// </summary>
        public TichetRepository()
        {
            _tichete = new List<Tichet>();
            _nextId = 1;
        }

        #endregion

        #region Implementare ITichetRepository

        /// <summary>
        /// Returneaza toate tichetele din sursa de date.
        /// </summary>
        /// <returns>Lista cu toate tichetele.</returns>
        public List<Tichet> GetAll()
        {
            return new List<Tichet>(_tichete);
        }

        /// <summary>
        /// Cauta si returneaza un tichet dupa ID-ul sau unic.
        /// </summary>
        /// <param name="id">Identificatorul tichetului.</param>
        /// <returns>Obiectul Tichet sau null daca nu exista.</returns>
        public Tichet GetById(int id)
        {
            foreach (Tichet tichet in _tichete)
            {
                if (tichet.Id == id)
                    return tichet;
            }

            return null;
        }

        /// <summary>
        /// Returneaza toate tichetele unui utilizator dupa ID-ul acestuia.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <returns>Lista cu tichetele utilizatorului.</returns>
        public List<Tichet> GetByUtilizatorId(int utilizatorId)
        {
            List<Tichet> rezultat = new List<Tichet>();

            foreach (Tichet tichet in _tichete)
            {
                if (tichet.UtilizatorId == utilizatorId)
                    rezultat.Add(tichet);
            }

            return rezultat;
        }

        /// <summary>
        /// Returneaza tichetele unui utilizator filtrate dupa status.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <param name="status">Statusul de filtrat.</param>
        /// <returns>Lista cu tichetele corespunzatoare.</returns>
        public List<Tichet> GetByUtilizatorIdSiStatus(int utilizatorId, StatusTichet status)
        {
            List<Tichet> rezultat = new List<Tichet>();

            foreach (Tichet tichet in _tichete)
            {
                if (tichet.UtilizatorId == utilizatorId && tichet.Status == status)
                    rezultat.Add(tichet);
            }

            return rezultat;
        }

        /// <summary>
        /// Returneaza tichetele care contin un pariu pe un meci dat.
        /// </summary>
        /// <param name="meciId">ID-ul meciului.</param>
        /// <returns>Lista cu tichetele care includ meciul specificat.</returns>
        public List<Tichet> GetByMeciId(int meciId)
        {
            List<Tichet> rezultat = new List<Tichet>();

            foreach (Tichet tichet in _tichete)
            {
                if (tichet.Pariuri == null)
                    continue;

                foreach (Pariu pariu in tichet.Pariuri)
                {
                    if (pariu.MeciId == meciId)
                    {
                        rezultat.Add(tichet);
                        break; // un singur pariu pe meci per tichet este suficient
                    }
                }
            }

            return rezultat;
        }

        /// <summary>
        /// Adauga un tichet nou in sursa de date.
        /// Daca ID-ul este 0, se genereaza automat un ID unic.
        /// </summary>
        /// <param name="tichet">Obiectul Tichet de adaugat.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool Add(Tichet tichet)
        {
            if (tichet == null)
                return false;

            if (tichet.Id == 0)
                tichet.Id = _nextId++;
            else if (GetById(tichet.Id) != null)
                return false; // ID duplicat

            _tichete.Add(tichet);
            return true;
        }

        /// <summary>
        /// Actualizeaza datele unui tichet existent (identificat dupa ID).
        /// </summary>
        /// <param name="tichet">Obiectul Tichet cu datele actualizate.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool Update(Tichet tichet)
        {
            if (tichet == null)
                return false;

            for (int i = 0; i < _tichete.Count; i++)
            {
                if (_tichete[i].Id == tichet.Id)
                {
                    _tichete[i] = tichet;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sterge un tichet din sursa de date dupa ID.
        /// </summary>
        /// <param name="id">Identificatorul tichetului de sters.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool Delete(int id)
        {
            Tichet tichetDeEliminat = GetById(id);

            if (tichetDeEliminat == null)
                return false;

            _tichete.Remove(tichetDeEliminat);
            return true;
        }

        /// <summary>
        /// Calculeaza suma totala mizata de un utilizator
        /// (suma MizaTotal din toate tichetele sale, indiferent de status).
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <returns>Suma totala a mizelor in RON.</returns>
        public decimal GetTotalMizatDeUtilizator(int utilizatorId)
        {
            decimal total = 0m;

            foreach (Tichet tichet in _tichete)
            {
                if (tichet.UtilizatorId == utilizatorId)
                    total += tichet.MizaTotal;
            }

            return total;
        }

        /// <summary>
        /// Calculeaza suma totala castigata de un utilizator
        /// (suma CastigEfectiv din tichetele cu status Castigat).
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <returns>Suma totala castigata in RON.</returns>
        public decimal GetTotalCastigatDeUtilizator(int utilizatorId)
        {
            decimal total = 0m;

            foreach (Tichet tichet in _tichete)
            {
                if (tichet.UtilizatorId == utilizatorId && tichet.Status == StatusTichet.Castigat)
                    total += tichet.CastigEfectiv;
            }

            return total;
        }

        /// <summary>
        /// Returneaza tichetele gata de decontare:
        /// status InAsteptare si toate meciurile asociate finalizate sau anulate.
        /// </summary>
        /// <returns>Lista cu tichetele de decontat.</returns>
        public List<Tichet> GetTicheteDeDecontat()
        {
            List<Tichet> rezultat = new List<Tichet>();

            foreach (Tichet tichet in _tichete)
            {
                if (tichet.Status == StatusTichet.InAsteptare && tichet.EsteGataDeDecontare())
                    rezultat.Add(tichet);
            }

            return rezultat;
        }

        #endregion
    }
}