// Autor: Postolache Matei
// Functionalitate: Serviciu pentru crearea, gestionarea si decontarea tichetelor de pariuri.
//                  Coordoneaza logica de business dintre repository-urile de tichete,
//                  meciuri si utilizatori.

using System;
using System.Collections.Generic;
using SportBet.Models;
using SportBet.Repositories;

namespace SportBet.Services
{
    /// <summary>
    /// Serviciu care expune operatiile de business pentru tichete si pariuri.
    /// Gestioneaza plasarea, vizualizarea si decontarea tichetelor.
    /// </summary>
    public class TichetService
    {
        #region Campuri private

        private readonly ITichetRepository _tichetRepo;
        private readonly IMeciRepository _meciRepo;
        private readonly IUtilizatorRepository _utilizatorRepo;

        #endregion

        #region Constructori

        /// <summary>
        /// Constructor implicit pentru instante temporare.
        /// </summary>
        public TichetService()
        {
        }

        /// <summary>
        /// Constructor cu injectia dependintelor (Dependency Injection).
        /// </summary>
        /// <param name="tichetRepo">Repository-ul de tichete.</param>
        /// <param name="meciRepo">Repository-ul de meciuri.</param>
        /// <param name="utilizatorRepo">Repository-ul de utilizatori.</param>
        public TichetService(ITichetRepository tichetRepo,
                              IMeciRepository meciRepo,
                              IUtilizatorRepository utilizatorRepo)
        {
            _tichetRepo = tichetRepo;
            _meciRepo = meciRepo;
            _utilizatorRepo = utilizatorRepo;
        }

        #endregion

        #region Metode publice – Gestionare tichete

        /// <summary>
        /// Plaseaza un tichet nou pentru utilizatorul dat.
        /// Verifica soldul disponibil, scade miza si salveaza tichetul.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului care plaseaza.</param>
        /// <param name="pariuri">Lista de pariuri de inclus in tichet.</param>
        /// <param name="miza">Suma mizata pe tichet.</param>
        /// <returns>Tichetul creat sau null in caz de eroare.</returns>
        public Tichet PlaseazaTichet(int utilizatorId, List<Pariu> pariuri, decimal miza)
        {
            if (!ValidareTichet(utilizatorId, pariuri, miza))
                return null;

            Utilizator utilizator = _utilizatorRepo.GetById(utilizatorId);

            utilizator.Retrage(miza);
            _utilizatorRepo.ActualizeazaSold(utilizatorId, utilizator.Sold);

            Tichet tichet = new Tichet(0, utilizatorId, miza);

            foreach (Pariu pariu in pariuri)
                tichet.AdaugaPariu(pariu);

            _tichetRepo.Add(tichet);
            return tichet;
        }

        /// <summary>
        /// Returneaza toate tichetele unui utilizator.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <returns>Lista cu tichetele utilizatorului.</returns>
        public List<Tichet> GetTicheteUtilizator(int utilizatorId)
        {
            return _tichetRepo.GetByUtilizatorId(utilizatorId);
        }

        /// <summary>
        /// Returneaza detaliile complete ale unui tichet dupa ID,
        /// cu meciurile asociate incarcate pe fiecare pariu.
        /// </summary>
        /// <param name="tichetId">ID-ul tichetului.</param>
        /// <returns>Obiectul Tichet cu pariurile si meciurile incarcate.</returns>
        public Tichet GetTichetById(int tichetId)
        {
            Tichet tichet = _tichetRepo.GetById(tichetId);

            if (tichet == null)
                return null;

            foreach (Pariu pariu in tichet.Pariuri)
            {
                if (pariu.MeciAsociat == null)
                    pariu.MeciAsociat = _meciRepo.GetById(pariu.MeciId);
            }

            return tichet;
        }

        /// <summary>
        /// Anuleaza un tichet si returneaza miza utilizatorului.
        /// Posibil doar daca toate meciurile sunt inca Programate si nu au inceput.
        /// </summary>
        /// <param name="tichetId">ID-ul tichetului de anulat.</param>
        /// <returns>True daca anularea a reusit, altfel false.</returns>
        public bool AnuleazaTichet(int tichetId)
        {
            Tichet tichet = _tichetRepo.GetById(tichetId);

            if (tichet == null)
                return false;

            if (tichet.Status != StatusTichet.InAsteptare)
                return false;

            foreach (Pariu pariu in tichet.Pariuri)
            {
                Meci meci = _meciRepo.GetById(pariu.MeciId);

                if (meci == null)
                    return false;

                if (meci.Status != StatusMeci.Programat || meci.DataOra <= DateTime.Now)
                    return false;
            }

            Utilizator utilizator = _utilizatorRepo.GetById(tichet.UtilizatorId);

            if (utilizator == null)
                return false;

            utilizator.Depune(tichet.MizaTotal);
            _utilizatorRepo.ActualizeazaSold(utilizator.Id, utilizator.Sold);

            tichet.Status = StatusTichet.Anulat;
            return _tichetRepo.Update(tichet);
        }

        #endregion

        #region Metode publice – Decontare

        /// <summary>
        /// Deconteaza toate tichetele gata de decontare (toate meciurile finalizate).
        /// Crediteaza utilizatorii castigatori.
        /// </summary>
        /// <returns>Numarul de tichete decontate.</returns>
        public int DeconteazaTichete()
        {
            List<Tichet> ticheteDeDecontat = _tichetRepo.GetTicheteDeDecontat();
            int nrDecontate = 0;

            foreach (Tichet tichet in ticheteDeDecontat)
            {
                if (DeconteazaTichet(tichet.Id))
                    nrDecontate++;
            }

            return nrDecontate;
        }

        /// <summary>
        /// Deconteaza un singur tichet dupa ID.
        /// Crediteaza utilizatorul daca tichetul este castigat.
        /// </summary>
        /// <param name="tichetId">ID-ul tichetului de decontat.</param>
        /// <returns>True daca decontarea a reusit, altfel false.</returns>
        public bool DeconteazaTichet(int tichetId)
        {
            Tichet tichet = GetTichetById(tichetId);

            if (tichet == null)
                return false;

            if (tichet.Status != StatusTichet.InAsteptare)
                return false;

            if (!tichet.EsteGataDeDecontare())
                return false;

            tichet.Deconteaza();

            if (tichet.CastigEfectiv > 0)
            {
                Utilizator utilizator = _utilizatorRepo.GetById(tichet.UtilizatorId);

                if (utilizator != null)
                {
                    utilizator.Depune(tichet.CastigEfectiv);
                    _utilizatorRepo.ActualizeazaSold(utilizator.Id, utilizator.Sold);
                }
            }

            return _tichetRepo.Update(tichet);
        }

        #endregion

        #region Metode publice – Statistici

        /// <summary>
        /// Calculeaza totalul mizat de un utilizator pe toate tichetele.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <returns>Suma totala mizata in RON.</returns>
        public decimal GetTotalMizat(int utilizatorId)
        {
            return _tichetRepo.GetTotalMizatDeUtilizator(utilizatorId);
        }

        /// <summary>
        /// Calculeaza totalul castigat de un utilizator din tichete decontate.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <returns>Suma totala castigata in RON.</returns>
        public decimal GetTotalCastigat(int utilizatorId)
        {
            return _tichetRepo.GetTotalCastigatDeUtilizator(utilizatorId);
        }

        /// <summary>
        /// Calculeaza rata de succes a unui utilizator
        /// (procent tichete castigate din totalul celor finalizate).
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <returns>Valoare intre 0 si 100 reprezentand procentul de succes.</returns>
        public double GetRataSucses(int utilizatorId)
        {
            List<Tichet> toateTichetele = _tichetRepo.GetByUtilizatorId(utilizatorId);

            int nrFinalizate = 0;
            int nrCastigate = 0;

            foreach (Tichet tichet in toateTichetele)
            {
                if (tichet.Status == StatusTichet.Castigat || tichet.Status == StatusTichet.Pierdut)
                {
                    nrFinalizate++;

                    if (tichet.Status == StatusTichet.Castigat)
                        nrCastigate++;
                }
            }

            if (nrFinalizate == 0)
                return 0.0;

            return Math.Round((double)nrCastigate / nrFinalizate * 100, 2);
        }

        #endregion

        #region Metode private helper

        /// <summary>
        /// Valideaza un tichet inainte de plasare:
        /// verifica miza pozitiva, cel putin un pariu, disponibilitatea meciurilor
        /// si soldul suficient al utilizatorului.
        /// </summary>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <param name="pariuri">Lista de pariuri de validat.</param>
        /// <param name="miza">Miza de validat.</param>
        /// <returns>True daca tichetul este valid, altfel false.</returns>
        private bool ValidareTichet(int utilizatorId, List<Pariu> pariuri, decimal miza)
        {
            if (miza <= 0)
                return false;

            if (pariuri == null || pariuri.Count == 0)
                return false;

            Utilizator utilizator = _utilizatorRepo.GetById(utilizatorId);

            if (utilizator == null || !utilizator.EsteActiv)
                return false;

            if (!utilizator.AreSuficienteFonduri(miza))
                return false;

            foreach (Pariu pariu in pariuri)
            {
                Meci meci = _meciRepo.GetById(pariu.MeciId);

                if (meci == null || !meci.EsteDisponibilPariere())
                    return false;

                if (meci.GetCotaForTip(pariu.TipSelectie) == 0)
                    return false;
            }

            return true;
        }

        #endregion
    }
}