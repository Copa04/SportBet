// Autor: Hothazie Mircea
// Functionalitate: Interfata pentru repository-ul de meciuri.
//                  Defineste contractul de acces la datele meciurilor sportive
//                  conform Repository Pattern.

using System;
using System.Collections.Generic;
using SportBet.Models;

namespace SportBet.Repositories
{
    /// <summary>
    /// Defineste operatiile CRUD si de filtrare pentru entitatea Meci.
    /// </summary>
    public interface IMeciRepository
    {
        /// <summary>
        /// Returneaza toate meciurile din sursa de date.
        /// </summary>
        /// <returns>Lista cu toate meciurile.</returns>
        List<Meci> GetAll();

        /// <summary>
        /// Cauta si returneaza un meci dupa ID-ul sau unic.
        /// </summary>
        /// <param name="id">Identificatorul meciului.</param>
        /// <returns>Obiectul Meci sau null daca nu exista.</returns>
        Meci GetById(int id);

        /// <summary>
        /// Returneaza meciurile disponibile pentru pariere (status Programat, data in viitor).
        /// </summary>
        /// <returns>Lista cu meciurile disponibile.</returns>
        List<Meci> GetMeciuriDisponibile();

        /// <summary>
        /// Returneaza meciurile filtrate dupa tipul de sport.
        /// </summary>
        /// <param name="sport">Tipul de sport pentru filtrare.</param>
        /// <returns>Lista cu meciurile de tipul specificat.</returns>
        List<Meci> GetBySport(SportTip sport);

        /// <summary>
        /// Returneaza meciurile filtrate dupa liga/campionat.
        /// </summary>
        /// <param name="liga">Numele ligii.</param>
        /// <returns>Lista cu meciurile din liga specificata.</returns>
        List<Meci> GetByLiga(string liga);

        /// <summary>
        /// Returneaza meciurile programate intr-un interval de date.
        /// </summary>
        /// <param name="dataInceput">Data de start a intervalului.</param>
        /// <param name="dataSfarsit">Data de sfarsit a intervalului.</param>
        /// <returns>Lista cu meciurile din intervalul specificat.</returns>
        List<Meci> GetByInterval(DateTime dataInceput, DateTime dataSfarsit);

        /// <summary>
        /// Returneaza meciurile cu un anumit status.
        /// </summary>
        /// <param name="status">Statusul de filtrat.</param>
        /// <returns>Lista cu meciurile avand statusul specificat.</returns>
        List<Meci> GetByStatus(StatusMeci status);

        /// <summary>
        /// Adauga un meci nou in sursa de date.
        /// </summary>
        /// <param name="meci">Obiectul Meci de adaugat.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool Add(Meci meci);

        /// <summary>
        /// Actualizeaza datele unui meci existent.
        /// </summary>
        /// <param name="meci">Obiectul Meci cu datele actualizate.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool Update(Meci meci);

        /// <summary>
        /// Sterge un meci din sursa de date dupa ID.
        /// </summary>
        /// <param name="id">Identificatorul meciului de sters.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool Delete(int id);

        /// <summary>
        /// Seteaza scorul final al unui meci si il marcheaza ca Finalizat.
        /// </summary>
        /// <param name="meciId">ID-ul meciului.</param>
        /// <param name="scorGazda">Scorul echipei gazda.</param>
        /// <param name="scorOaspete">Scorul echipei oaspete.</param>
        /// <returns>True daca operatia a reusit, altfel false.</returns>
        bool SetScorFinal(int meciId, int scorGazda, int scorOaspete);
    }
}
