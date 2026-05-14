// Autor: Echipa SportBet
// Functionalitate: Serviciu central care incarca datele din fisiere JSON locale
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
    /// Serviciu central de date care citeste fisierele JSON si
    /// populeaza repository-urile la pornirea aplicatiei.
    /// </summary>
    public class DataService
    {
        #region Constante cai fisiere JSON

        /// <summary>Calea catre fisierul JSON cu utilizatorii.</summary>
        private const string FISIER_UTILIZATORI = "Data/utilizatori.json";

        /// <summary>Calea catre fisierul JSON cu meciurile.</summary>
        private const string FISIER_MECIURI = "Data/meciuri.json";

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

        #region Metode publice

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

            UtilizatorRepository = utilizatorRepo;
            MeciRepository = meciRepo;
            TichetRepository = tichetRepo;

            AuthService.Instanta.Initialize(UtilizatorRepository);
        }

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

        #endregion
    }
}