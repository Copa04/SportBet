// Autor: Echipa SportBet
// Functionalitate: Interfata pentru repository-ul de utilizatori.
//                  Defineste contractul de acces la datele utilizatorilor
//                  conform Repository Pattern.

using System.Collections.Generic;
using SportBet.Models;

namespace SportBet.Repositories
{
    /// <summary>
    /// Defineste operatiile CRUD si de cautare pentru entitatea Utilizator.
    /// </summary>
    public interface IUtilizatorRepository
    {
        /// <summary>
        /// Returneaza toti utilizatorii din sursa de date.
        /// </summary>
        /// <returns>Lista cu toti utilizatorii.</returns>
        List<Utilizator> GetAll();

        /// <summary>
        /// Cauta si returneaza un utilizator dupa ID-ul sau unic.
        /// </summary>
        /// <param name="id">Identificatorul utilizatorului.</param>
        /// <returns>Obiectul Utilizator sau null daca nu exista.</returns>
        Utilizator GetById(int id);

        /// <summary>
        /// Cauta un utilizator dupa username.
        /// </summary>
        /// <param name="username">Numele de utilizator.</param>
        /// <returns>Obiectul Utilizator sau null daca nu exista.</returns>
        Utilizator GetByUsername(string username);

        /// <summary>
        /// Cauta un utilizator dupa adresa de email.
        /// </summary>
        /// <param name="email">Adresa de email.</param>
        /// <returns>Obiectul Utilizator sau null daca nu exista.</returns>
        Utilizator GetByEmail(string email);

        /// <summary>
        /// Adauga un utilizator nou in sursa de date.
        /// </summary>
        /// <param name="utilizator">Obiectul Utilizator de adaugat.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool Add(Utilizator utilizator);

        /// <summary>
        /// Actualizeaza datele unui utilizator existent.
        /// </summary>
        /// <param name="utilizator">Obiectul Utilizator cu datele actualizate.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool Update(Utilizator utilizator);

        /// <summary>
        /// Sterge un utilizator din sursa de date dupa ID.
        /// </summary>
        /// <param name="id">Identificatorul utilizatorului de sters.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool Delete(int id);

        /// <summary>
        /// Verifica daca un username este deja folosit.
        /// </summary>
        /// <param name="username">Username-ul de verificat.</param>
        /// <returns>True daca username-ul exista deja, altfel false.</returns>
        bool UsernameExista(string username);

        /// <summary>
        /// Verifica daca o adresa de email este deja folosita.
        /// </summary>
        /// <param name="email">Email-ul de verificat.</param>
        /// <returns>True daca email-ul exista deja, altfel false.</returns>
        bool EmailExista(string email);

        /// <summary>
        /// Actualizeaza soldul unui utilizator.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <param name="soldNou">Noul sold de setat.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool ActualizeazaSold(int utilizatorId, decimal soldNou);
    }
}
