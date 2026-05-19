// Autor: Hothazie Mircea
// Functionalitate: Implementarea repository-ului pentru meciuri.
//                  Stocheaza si gestioneaza meciurile in memorie,
//                  implementand contractul definit de IMeciRepository.

using System;
using System.Collections.Generic;
using SportBet.Models;

namespace SportBet.Repositories
{
    /// <summary>
    /// Implementare in-memory a repository-ului pentru entitatea Meci.
    /// </summary>
    public class MeciRepository : IMeciRepository
    {
        #region Campuri private

        /// <summary>Lista interna care stocheaza toate meciurile.</summary>
        private readonly List<Meci> _meciuri;

        /// <summary>Contor pentru generarea ID-urilor unice.</summary>
        private int _nextId;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor implicit. Initializeaza lista si contorul de ID-uri.
        /// </summary>
        public MeciRepository()
        {
            _meciuri = new List<Meci>();
            _nextId = 1;
        }

        #endregion

        #region Implementare IMeciRepository

        /// <summary>
        /// Returneaza toate meciurile din sursa de date.
        /// </summary>
        /// <returns>Lista cu toate meciurile.</returns>
        public List<Meci> GetAll()
        {
            return new List<Meci>(_meciuri);
        }

        /// <summary>
        /// Cauta si returneaza un meci dupa ID-ul sau unic.
        /// </summary>
        /// <param name="id">Identificatorul meciului.</param>
        /// <returns>Obiectul Meci sau null daca nu exista.</returns>
        public Meci GetById(int id)
        {
            foreach (Meci meci in _meciuri)
            {
                if (meci.Id == id)
                    return meci;
            }

            return null;
        }

        /// <summary>
        /// Returneaza meciurile disponibile pentru pariere
        /// (status Programat si data in viitor).
        /// </summary>
        /// <returns>Lista cu meciurile disponibile.</returns>
        public List<Meci> GetMeciuriDisponibile()
        {
            List<Meci> rezultat = new List<Meci>();

            foreach (Meci meci in _meciuri)
            {
                if (meci.EsteDisponibilPariere())
                    rezultat.Add(meci);
            }

            return rezultat;
        }

        /// <summary>
        /// Returneaza meciurile filtrate dupa tipul de sport.
        /// </summary>
        /// <param name="sport">Tipul de sport pentru filtrare.</param>
        /// <returns>Lista cu meciurile de tipul specificat.</returns>
        public List<Meci> GetBySport(SportTip sport)
        {
            List<Meci> rezultat = new List<Meci>();

            foreach (Meci meci in _meciuri)
            {
                if (meci.Sport == sport)
                    rezultat.Add(meci);
            }

            return rezultat;
        }

        /// <summary>
        /// Returneaza meciurile filtrate dupa liga/campionat.
        /// </summary>
        /// <param name="liga">Numele ligii.</param>
        /// <returns>Lista cu meciurile din liga specificata.</returns>
        public List<Meci> GetByLiga(string liga)
        {
            if (string.IsNullOrWhiteSpace(liga))
                return new List<Meci>();

            List<Meci> rezultat = new List<Meci>();

            foreach (Meci meci in _meciuri)
            {
                if (string.Equals(meci.Liga, liga, StringComparison.OrdinalIgnoreCase))
                    rezultat.Add(meci);
            }

            return rezultat;
        }

        /// <summary>
        /// Returneaza meciurile programate intr-un interval de date.
        /// </summary>
        /// <param name="dataInceput">Data de start a intervalului.</param>
        /// <param name="dataSfarsit">Data de sfarsit a intervalului.</param>
        /// <returns>Lista cu meciurile din intervalul specificat.</returns>
        public List<Meci> GetByInterval(DateTime dataInceput, DateTime dataSfarsit)
        {
            List<Meci> rezultat = new List<Meci>();

            foreach (Meci meci in _meciuri)
            {
                if (meci.DataOra >= dataInceput && meci.DataOra <= dataSfarsit)
                    rezultat.Add(meci);
            }

            return rezultat;
        }

        /// <summary>
        /// Returneaza meciurile cu un anumit status.
        /// </summary>
        /// <param name="status">Statusul de filtrat.</param>
        /// <returns>Lista cu meciurile avand statusul specificat.</returns>
        public List<Meci> GetByStatus(StatusMeci status)
        {
            List<Meci> rezultat = new List<Meci>();

            foreach (Meci meci in _meciuri)
            {
                if (meci.Status == status)
                    rezultat.Add(meci);
            }

            return rezultat;
        }

        /// <summary>
        /// Adauga un meci nou in sursa de date.
        /// Daca ID-ul este 0, se genereaza automat un ID unic.
        /// </summary>
        /// <param name="meci">Obiectul Meci de adaugat.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool Add(Meci meci)
        {
            if (meci == null)
                return false;

            if (meci.Id == 0)
                meci.Id = _nextId++;
            else if (GetById(meci.Id) != null)
                return false; // ID duplicat

            _meciuri.Add(meci);
            return true;
        }

        /// <summary>
        /// Actualizeaza datele unui meci existent (identificat dupa ID).
        /// </summary>
        /// <param name="meci">Obiectul Meci cu datele actualizate.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool Update(Meci meci)
        {
            if (meci == null)
                return false;

            for (int i = 0; i < _meciuri.Count; i++)
            {
                if (_meciuri[i].Id == meci.Id)
                {
                    _meciuri[i] = meci;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sterge un meci din sursa de date dupa ID.
        /// </summary>
        /// <param name="id">Identificatorul meciului de sters.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool Delete(int id)
        {
            Meci meciDeEliminat = GetById(id);

            if (meciDeEliminat == null)
                return false;

            _meciuri.Remove(meciDeEliminat);
            return true;
        }

        /// <summary>
        /// Seteaza scorul final al unui meci si il marcheaza ca Finalizat.
        /// </summary>
        /// <param name="meciId">ID-ul meciului.</param>
        /// <param name="scorGazda">Scorul echipei gazda.</param>
        /// <param name="scorOaspete">Scorul echipei oaspete.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool SetScorFinal(int meciId, int scorGazda, int scorOaspete)
        {
            Meci meci = GetById(meciId);

            if (meci == null)
                return false;

            if (scorGazda < 0 || scorOaspete < 0)
                return false;

            meci.SetScorFinal(scorGazda, scorOaspete);
            return true;
        }

        #endregion
    }
}