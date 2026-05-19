// Autor: Hothazie Mircea
// Functionalitate: Implementarea repository-ului pentru utilizatori.
//                  Stocheaza si gestioneaza utilizatorii in memorie,
//                  implementand contractul definit de IUtilizatorRepository.

using SportBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportBet.Repositories
{
    /// <summary>
    /// Implementare in-memory a repository-ului pentru entitatea Utilizator.
    /// </summary>
    public class UtilizatorRepository : IUtilizatorRepository
    {
        #region Campuri private

        /// <summary>Lista interna care stocheaza toti utilizatorii.</summary>
        private readonly List<Utilizator> _utilizatori;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor implicit. Initializeaza lista si contorul de ID-uri.
        /// </summary>
        public UtilizatorRepository()
        {
            _utilizatori = new List<Utilizator>();
        }

        #endregion

        #region Implementare IUtilizatorRepository

        /// <summary>
        /// Calculeaza urmatorul ID disponibil pe baza ID-urilor existente in lista.
        /// Returneaza 1 daca lista e goala, altfel returneaza maximul ID-urilor existente + 1.
        /// </summary>
        /// <returns>Urmatorul ID disponibil.</returns>
        private int GetNextId()
        {
            return _utilizatori.Count > 0 ? _utilizatori.Max(u => u.Id) + 1 : 1;
        }
        /// <summary>
        /// Returneaza toti utilizatorii din sursa de date.
        /// </summary>
        /// <returns>Lista cu toti utilizatorii.</returns>
        public List<Utilizator> GetAll()
        {
            return new List<Utilizator>(_utilizatori);
        }

        /// <summary>
        /// Cauta si returneaza un utilizator dupa ID-ul sau unic.
        /// </summary>
        /// <param name="id">Identificatorul utilizatorului.</param>
        /// <returns>Obiectul Utilizator sau null daca nu exista.</returns>
        public Utilizator GetById(int id)
        {
            foreach (Utilizator utilizator in _utilizatori)
            {
                if (utilizator.Id == id)
                    return utilizator;
            }

            return null;
        }

        /// <summary>
        /// Cauta un utilizator dupa username.
        /// </summary>
        /// <param name="username">Numele de utilizator.</param>
        /// <returns>Obiectul Utilizator sau null daca nu exista.</returns>
        public Utilizator GetByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            foreach (Utilizator utilizator in _utilizatori)
            {
                if (string.Equals(utilizator.Username, username, StringComparison.OrdinalIgnoreCase))
                    return utilizator;
            }

            return null;
        }

        /// <summary>
        /// Cauta un utilizator dupa adresa de email.
        /// </summary>
        /// <param name="email">Adresa de email.</param>
        /// <returns>Obiectul Utilizator sau null daca nu exista.</returns>
        public Utilizator GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            foreach (Utilizator utilizator in _utilizatori)
            {
                if (string.Equals(utilizator.Email, email, StringComparison.OrdinalIgnoreCase))
                    return utilizator;
            }

            return null;
        }

        /// <summary>
        /// Adauga un utilizator nou in sursa de date.
        /// Daca ID-ul este 0, se genereaza automat un ID unic.
        /// </summary>
        /// <param name="utilizator">Obiectul Utilizator de adaugat.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool Add(Utilizator utilizator)
        {
            if (utilizator == null)
                return false;

            // Verificam unicitatea username-ului si email-ului
            if (UsernameExista(utilizator.Username))
                return false;

            if (EmailExista(utilizator.Email))
                return false;

            if (utilizator.Id == 0)
                utilizator.Id = GetNextId();
            else if (GetById(utilizator.Id) != null)
                return false; 

            _utilizatori.Add(utilizator);
            return true;
        }

        /// <summary>
        /// Actualizeaza datele unui utilizator existent (identificat dupa ID).
        /// </summary>
        /// <param name="utilizator">Obiectul Utilizator cu datele actualizate.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool Update(Utilizator utilizator)
        {
            if (utilizator == null)
                return false;

            for (int i = 0; i < _utilizatori.Count; i++)
            {
                if (_utilizatori[i].Id == utilizator.Id)
                {
                    _utilizatori[i] = utilizator;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sterge un utilizator din sursa de date dupa ID.
        /// </summary>
        /// <param name="id">Identificatorul utilizatorului de sters.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool Delete(int id)
        {
            Utilizator utilizatorDeEliminat = GetById(id);

            if (utilizatorDeEliminat == null)
                return false;

            _utilizatori.Remove(utilizatorDeEliminat);
            return true;
        }

        /// <summary>
        /// Verifica daca un username este deja folosit (case-insensitive).
        /// </summary>
        /// <param name="username">Username-ul de verificat.</param>
        /// <returns>True daca username-ul exista deja, altfel false.</returns>
        public bool UsernameExista(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            return GetByUsername(username) != null;
        }

        /// <summary>
        /// Verifica daca o adresa de email este deja folosita (case-insensitive).
        /// </summary>
        /// <param name="email">Email-ul de verificat.</param>
        /// <returns>True daca email-ul exista deja, altfel false.</returns>
        public bool EmailExista(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return GetByEmail(email) != null;
        }

        /// <summary>
        /// Actualizeaza soldul unui utilizator dupa ID.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <param name="soldNou">Noul sold de setat (trebuie sa fie >= 0).</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        public bool ActualizeazaSold(int utilizatorId, decimal soldNou)
        {
            if (soldNou < 0)
                return false;

            Utilizator utilizator = GetById(utilizatorId);

            if (utilizator == null)
                return false;

            utilizator.Sold = soldNou;
            return true;
        }

        #endregion
    }
}