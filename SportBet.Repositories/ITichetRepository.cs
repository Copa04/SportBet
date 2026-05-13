// Autor: Echipa SportBet
// Functionalitate: Interfata pentru repository-ul de tichete.
//                  Defineste contractul de acces la datele tichetelor si pariurilor
//                  conform Repository Pattern.

using System.Collections.Generic;
using SportBet.Models;

namespace SportBet.Repositories
{
    /// <summary>
    /// Defineste operatiile CRUD si de filtrare pentru entitatea Tichet.
    /// </summary>
    public interface ITichetRepository
    {
        /// <summary>
        /// Returneaza toate tichetele din sursa de date.
        /// </summary>
        /// <returns>Lista cu toate tichetele.</returns>
        List<Tichet> GetAll();

        /// <summary>
        /// Cauta si returneaza un tichet dupa ID-ul sau unic.
        /// </summary>
        /// <param name="id">Identificatorul tichetului.</param>
        /// <returns>Obiectul Tichet sau null daca nu exista.</returns>
        Tichet GetById(int id);

        /// <summary>
        /// Returneaza toate tichetele unui utilizator dupa ID-ul acestuia.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <returns>Lista cu tichetele utilizatorului.</returns>
        List<Tichet> GetByUtilizatorId(int utilizatorId);

        /// <summary>
        /// Returneaza tichetele unui utilizator filtrate dupa status.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <param name="status">Statusul de filtrat.</param>
        /// <returns>Lista cu tichetele corespunzatoare.</returns>
        List<Tichet> GetByUtilizatorIdSiStatus(int utilizatorId, StatusTichet status);

        /// <summary>
        /// Returneaza tichetele care contin un pariu pe un meci dat.
        /// </summary>
        /// <param name="meciId">ID-ul meciului.</param>
        /// <returns>Lista cu tichetele care includ meciul specificat.</returns>
        List<Tichet> GetByMeciId(int meciId);

        /// <summary>
        /// Adauga un tichet nou in sursa de date.
        /// </summary>
        /// <param name="tichet">Obiectul Tichet de adaugat.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool Add(Tichet tichet);

        /// <summary>
        /// Actualizeaza datele unui tichet existent.
        /// </summary>
        /// <param name="tichet">Obiectul Tichet cu datele actualizate.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool Update(Tichet tichet);

        /// <summary>
        /// Sterge un tichet din sursa de date dupa ID.
        /// </summary>
        /// <param name="id">Identificatorul tichetului de sters.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool Delete(int id);

        /// <summary>
        /// Calculeaza suma totala mizata de un utilizator.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <returns>Suma totala a mizelor in RON.</returns>
        decimal GetTotalMizatDeUtilizator(int utilizatorId);

        /// <summary>
        /// Calculeaza suma totala castigata de un utilizator.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <returns>Suma totala castigata in RON.</returns>
        decimal GetTotalCastigatDeUtilizator(int utilizatorId);

        /// <summary>
        /// Returneaza tichetele gata de decontare (toate meciurile finalizate, status InAsteptare).
        /// </summary>
        /// <returns>Lista cu tichetele de decontat.</returns>
        List<Tichet> GetTicheteDeDecontat();
    }
}
