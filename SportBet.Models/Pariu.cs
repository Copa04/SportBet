// Autor: Echipa SportBet
// Functionalitate: Clasa model pentru un pariu individual plasat pe un meci.
//                  Un pariu face parte dintr-un tichet si are asociat o cota si un tip de selectie.

using System;

namespace SportBet.Models
{
    /// <summary>
    /// Enumereaza statusurile posibile ale unui pariu.
    /// </summary>
    public enum StatusPariu
    {
        InAsteptare,
        Castigat,
        Pierdut,
        Anulat,
        Returnat
    }

    /// <summary>
    /// Reprezinta un pariu individual plasat pe un meci sportiv.
    /// </summary>
    public class Pariu
    {
        #region Proprietati

        /// <summary>Identificatorul unic al pariului.</summary>
        public int Id { get; set; }

        /// <summary>Identificatorul tichetului din care face parte pariurile.</summary>
        public int TichetId { get; set; }

        /// <summary>Identificatorul meciului pe care s-a plasat pariurile.</summary>
        public int MeciId { get; set; }

        /// <summary>Referinta la meciul asociat acestui pariu.</summary>
        public Meci MeciAsociat { get; set; }

        /// <summary>
        /// Tipul de selectie al pariurilor.
        /// Valori posibile: "1" (gazda), "X" (egal), "2" (oaspete).
        /// </summary>
        public string TipSelectie { get; set; }

        /// <summary>Cota la care a fost plasat pariuri (snapshot la momentul plasarii).</summary>
        public double Cota { get; set; }

        /// <summary>Statusul curent al pariurilor.</summary>
        public StatusPariu Status { get; set; }

        /// <summary>Data si ora la care a fost plasat pariuri.</summary>
        public DateTime DataPlasare { get; set; }

        #endregion

        #region Constructori

        /// <summary>
        /// Constructor implicit. Seteaza statusul initial si data plasarii.
        /// </summary>
        public Pariu()
        {
            Status = StatusPariu.InAsteptare;
            DataPlasare = DateTime.Now;
        }

        /// <summary>
        /// Constructor cu parametri pentru crearea unui pariu complet.
        /// </summary>
        /// <param name="id">Identificatorul unic.</param>
        /// <param name="tichetId">ID-ul tichetului parinte.</param>
        /// <param name="meciId">ID-ul meciului pariat.</param>
        /// <param name="tipSelectie">Selectia aleasa ("1", "X" sau "2").</param>
        /// <param name="cota">Cota la momentul plasarii.</param>
        public Pariu(int id, int tichetId, int meciId, string tipSelectie, double cota)
        {
            Id = id;
            TichetId = tichetId;
            MeciId = meciId;
            TipSelectie = tipSelectie;
            Cota = cota;
            Status = StatusPariu.InAsteptare;
            DataPlasare = DateTime.Now;
        }

        #endregion

        #region Metode

        /// <summary>
        /// Verifica daca pariuri a fost castigat in baza rezultatului meciului.
        /// </summary>
        /// <returns>True daca selectia corespunde rezultatului, altfel false.</returns>
        public bool VerificaCastig()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actualizeaza statusul pariurilor pe baza rezultatului meciului asociat.
        /// </summary>
        public void ActualizeazaStatus()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returneaza denumirea selectiei intr-un format lizibil (ex. "Victorie Gazda").
        /// </summary>
        /// <returns>String cu descrierea selectiei.</returns>
        public string GetDescriereSelectie()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returneaza o reprezentare text a obiectului Pariu.
        /// </summary>
        /// <returns>String cu informatiile principale ale pariurilor.</returns>
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
