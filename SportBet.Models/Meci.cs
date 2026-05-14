// Autor: Echipa SportBet
// Functionalitate: Clasa model pentru un meci sportiv disponibil la pariere.
//                  Contine informatii despre echipe, cote si statusul meciului.

using System;
using System.Collections.Generic;

namespace SportBet.Models
{
    /// <summary>
    /// Enumereaza sporturile disponibile in aplicatie.
    /// </summary>
    public enum SportTip
    {
        Fotbal,
        Baschet,
        Tenis,
        Handbal,
        Volei
    }

    /// <summary>
    /// Enumereaza starile posibile ale unui meci.
    /// </summary>
    public enum StatusMeci
    {
        Programat,
        InDesfasurare,
        Finalizat,
        Anulat
    }

    /// <summary>
    /// Reprezinta un meci sportiv la care utilizatorii pot paria.
    /// </summary>
    public class Meci
    {
        #region Proprietati

        /// <summary>Identificatorul unic al meciului.</summary>
        public int Id { get; set; }

        /// <summary>Numele echipei gazda.</summary>
        public string EchipaGazda { get; set; }

        /// <summary>Numele echipei oaspete.</summary>
        public string EchipaOaspete { get; set; }

        /// <summary>Data si ora la care se disputa meciul.</summary>
        public DateTime DataOra { get; set; }

        /// <summary>Tipul de sport al meciului.</summary>
        public SportTip Sport { get; set; }

        /// <summary>Cota pentru victoria echipei gazda.</summary>
        public double CotaGazda { get; set; }

        /// <summary>Cota pentru egalitate (acolo unde este aplicabila).</summary>
        public double CotaEgalitate { get; set; }

        /// <summary>Cota pentru victoria echipei oaspete.</summary>
        public double CotaOaspete { get; set; }

        /// <summary>Statusul curent al meciului.</summary>
        public StatusMeci Status { get; set; }

        /// <summary>Scorul echipei gazda (disponibil dupa finalizare).</summary>
        public int? ScorGazda { get; set; }

        /// <summary>Scorul echipei oaspete (disponibil dupa finalizare).</summary>
        public int? ScorOaspete { get; set; }

        /// <summary>Campionatul sau liga in care se disputa meciul.</summary>
        public string Liga { get; set; }

        /// <summary>Lista de pariuri plasate pe acest meci.</summary>
        public List<Pariu> Pariuri { get; set; }

        #endregion

        #region Constructori

        /// <summary>
        /// Constructor implicit. Initializeaza lista de pariuri.
        /// </summary>
        public Meci()
        {
            Pariuri = new List<Pariu>();
            Status = StatusMeci.Programat;
        }

        /// <summary>
        /// Constructor cu parametri pentru initializarea unui meci.
        /// </summary>
        /// <param name="id">Identificatorul unic.</param>
        /// <param name="echipaGazda">Echipa de acasa.</param>
        /// <param name="echipaOaspete">Echipa oaspete.</param>
        /// <param name="dataOra">Data si ora meciului.</param>
        /// <param name="sport">Tipul de sport.</param>
        /// <param name="cotaGazda">Cota echipei gazda.</param>
        /// <param name="cotaEgalitate">Cota pentru egalitate.</param>
        /// <param name="cotaOaspete">Cota echipei oaspete.</param>
        /// <param name="liga">Liga/campionatul.</param>
        public Meci(int id, string echipaGazda, string echipaOaspete,
                    DateTime dataOra, SportTip sport,
                    double cotaGazda, double cotaEgalitate, double cotaOaspete,
                    string liga)
        {
            Id = id;
            EchipaGazda = echipaGazda;
            EchipaOaspete = echipaOaspete;
            DataOra = dataOra;
            Sport = sport;
            CotaGazda = cotaGazda;
            CotaEgalitate = cotaEgalitate;
            CotaOaspete = cotaOaspete;
            Liga = liga;
            Status = StatusMeci.Programat;
            Pariuri = new List<Pariu>();
        }

        #endregion

        #region Metode

        /// <summary>
        /// Returneaza denumirea completa a meciului in formatul "EchipaGazda vs EchipaOaspete".
        /// </summary>
        /// <returns>String cu denumirea meciului.</returns>
        public string GetDenumireMeci()
        {
            return string.Format("{0} vs {1}", EchipaGazda, EchipaOaspete);
        }

        /// <summary>
        /// Verifica daca meciul este inca disponibil pentru pariere.
        /// </summary>
        /// <returns>True daca se poate paria pe acest meci, altfel false.</returns>
        public bool EsteDisponibilPariere()
        {
            return Status == StatusMeci.Programat && DataOra > DateTime.Now;
        }

        /// <summary>
        /// Returneaza cota corespunzatoare unui tip de pariu dat.
        /// </summary>
        /// <param name="tipPariu">Tipul de pariu (ex. "1", "X", "2").</param>
        /// <returns>Valoarea cotei sau 0 daca tipul nu este valid.</returns>
        public double GetCotaForTip(string tipPariu)
        {
            if (string.IsNullOrWhiteSpace(tipPariu))
                return 0;

            switch (tipPariu.Trim().ToUpper())
            {
                case "1":
                    return CotaGazda;
                case "X":
                    return CotaEgalitate;
                case "2":
                    return CotaOaspete;
                default:
                    return 0;
            }
        }


        /// <summary>
        /// Seteaza scorul final al meciului si il marcheaza ca finalizat.
        /// </summary>
        /// <param name="scorGazda">Goluri/puncte echipa gazda.</param>
        /// <param name="scorOaspete">Goluri/puncte echipa oaspete.</param>
        public void SetScorFinal(int scorGazda, int scorOaspete)
        {
            if (scorGazda < 0 || scorOaspete < 0)
                throw new ArgumentException("Scorul nu poate fi negativ.");

            ScorGazda = scorGazda;
            ScorOaspete = scorOaspete;
            Status = StatusMeci.Finalizat;
        }

        /// <summary>
        /// Returneaza rezultatul meciului ca string ("1", "X" sau "2").
        /// </summary>
        /// <returns>Rezultatul meciului sau null daca nu este finalizat.</returns>
        public string GetRezultat()
        {
            if (Status != StatusMeci.Finalizat || !ScorGazda.HasValue || !ScorOaspete.HasValue)
                return null;

            if (ScorGazda.Value > ScorOaspete.Value)
                return "1";

            if (ScorGazda.Value == ScorOaspete.Value)
                return "X";

            return "2";
        }

        /// <summary>
        /// Returneaza o reprezentare text a obiectului Meci.
        /// </summary>
        /// <returns>String cu informatiile principale ale meciului.</returns>
        public override string ToString()
        {
            string scor = "-";

            if (ScorGazda.HasValue && ScorOaspete.HasValue)
                scor = string.Format("{0}-{1}", ScorGazda.Value, ScorOaspete.Value);

            return string.Format("#{0} | {1} | {2} | {3:dd.MM.yyyy HH:mm} | Cote: 1={4:0.00}, X={5:0.00}, 2={6:0.00} | Status: {7} | Scor: {8}",
                Id, GetDenumireMeci(), Liga, DataOra, CotaGazda, CotaEgalitate, CotaOaspete, Status, scor);
        }

        #endregion
    }

}
