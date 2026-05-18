// Autor: Echipa SportBet
// Functionalitate: Serviciu central care incarca si salveaza datele din/in fisiere JSON locale
//                  si initializeaza repository-urile la pornirea aplicatiei.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using SportBet.Models;
using SportBet.Repositories;

namespace SportBet.Services
{
    /// <summary>
    /// Serviciu central de date care citeste si scrie fisierele JSON si
    /// populeaza repository-urile la pornirea aplicatiei.
    /// </summary>
    public class DataService
    {
        #region Constante cai fisiere JSON

        /// <summary>Calea catre fisierul JSON cu utilizatorii.</summary>
        private const string FISIER_UTILIZATORI = "Data\\utilizatori.json";

        /// <summary>Calea catre fisierul JSON cu meciurile.</summary>
        private const string FISIER_MECIURI = "Data\\meciuri.json";

        /// <summary>Calea catre fisierul JSON cu tichetele.</summary>
        private const string FISIER_TICHETE = "Data\\tichete.json";

        #endregion

        #region Proprietati – Repository-uri

        /// <summary>Repository-ul pentru operatii cu utilizatori.</summary>
        public IUtilizatorRepository UtilizatorRepository { get; private set; }

        /// <summary>Repository-ul pentru operatii cu meciuri.</summary>
        public IMeciRepository MeciRepository { get; private set; }

        /// <summary>Repository-ul pentru operatii cu tichete.</summary>
        public ITichetRepository TichetRepository { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor implicit.
        /// </summary>
        public DataService()
        {
        }

        #endregion

        #region Metode publice – Initializare

        /// <summary>
        /// Initializeaza serviciul: citeste JSON-urile si populeaza repository-urile.
        /// </summary>
        public void Initializeaza()
        {
            UtilizatorRepository utilizatorRepo = new UtilizatorRepository();
            MeciRepository meciRepo = new MeciRepository();
            TichetRepository tichetRepo = new TichetRepository();

            foreach (Utilizator u in IncarcaUtilizatori())
                utilizatorRepo.Add(u);

            foreach (Meci m in IncarcaMeciuri())
                meciRepo.Add(m);

            foreach (Tichet t in IncarcaTichete())
                tichetRepo.Add(t);

            UtilizatorRepository = utilizatorRepo;
            MeciRepository = meciRepo;
            TichetRepository = tichetRepo;
        }

        #endregion

        #region Metode publice – Citire JSON

        /// <summary>
        /// Incarca lista de utilizatori din fisierul JSON local.
        /// </summary>
        /// <returns>Lista cu utilizatorii sau lista goala la eroare.</returns>
        public List<Utilizator> IncarcaUtilizatori()
        {
            try
            {
                string json = File.ReadAllText(FISIER_UTILIZATORI, Encoding.UTF8);
                return JsonConvert.DeserializeObject<List<Utilizator>>(json);
            }
            catch (Exception)
            {
                return new List<Utilizator>();
            }
        }

        /// <summary>
        /// Incarca lista de meciuri din fisierul JSON local.
        /// </summary>
        /// <returns>Lista cu meciurile sau lista goala la eroare.</returns>
        public List<Meci> IncarcaMeciuri()
        {
            try
            {
                string json = File.ReadAllText(FISIER_MECIURI, Encoding.UTF8);
                return JsonConvert.DeserializeObject<List<Meci>>(json);
            }
            catch (Exception)
            {
                return new List<Meci>();
            }
        }

        /// <summary>
        /// Incarca lista de tichete din fisierul JSON local.
        /// </summary>
        /// <returns>Lista cu tichetele sau lista goala daca fisierul nu exista.</returns>
        public List<Tichet> IncarcaTichete()
        {
            try
            {
                if (!File.Exists(FISIER_TICHETE))
                    return new List<Tichet>();

                string json = File.ReadAllText(FISIER_TICHETE, Encoding.UTF8);
                return JsonConvert.DeserializeObject<List<Tichet>>(json);
            }
            catch (Exception)
            {
                return new List<Tichet>();
            }
        }

        #endregion

        #region Metode publice – Salvare JSON

        /// <summary>
        /// Salveaza lista de utilizatori in fisierul JSON local.
        /// </summary>
        /// <param name="utilizatori">Lista de utilizatori de serializat.</param>
        /// <returns>True daca salvarea a reusit, altfel false.</returns>
        public bool SalveazaUtilizatori(List<Utilizator> utilizatori)
        {
            try
            {
                string json = JsonConvert.SerializeObject(utilizatori, Formatting.Indented);
                File.WriteAllText(FISIER_UTILIZATORI, json, Encoding.UTF8);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Salveaza lista de meciuri in fisierul JSON local.
        /// </summary>
        /// <param name="meciuri">Lista de meciuri de serializat.</param>
        /// <returns>True daca salvarea a reusit, altfel false.</returns>
        public bool SalveazaMeciuri(List<Meci> meciuri)
        {
            try
            {
                string json = JsonConvert.SerializeObject(meciuri, Formatting.Indented);
                File.WriteAllText(FISIER_MECIURI, json, Encoding.UTF8);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Salveaza lista de tichete in fisierul JSON local.
        /// </summary>
        /// <param name="tichete">Lista de tichete de serializat.</param>
        /// <returns>True daca salvarea a reusit, altfel false.</returns>
        public bool SalveazaTichete(List<Tichet> tichete)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tichete, Formatting.Indented);
                File.WriteAllText(FISIER_TICHETE, json, Encoding.UTF8);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Salveaza toate datele (utilizatori, meciuri, tichete) in fisierele JSON.
        /// Apelat la inchiderea aplicatiei pentru a persista modificarile.
        /// </summary>
        /// <returns>True daca toate salvarile au reusit, altfel false.</returns>
        public bool SalveazaToateDatale()
        {
            bool ok = true;

            ok &= SalveazaUtilizatori(UtilizatorRepository.GetAll());
            ok &= SalveazaMeciuri(MeciRepository.GetAll());
            ok &= SalveazaTichete(TichetRepository.GetAll());

            return ok;
        }

        #endregion
    }
}