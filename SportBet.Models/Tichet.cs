// Autor: Echipa SportBet
// Functionalitate: Clasa model pentru un tichet de pariere.
//                  Un tichet grupeaza mai multe pariuri individuale si calculeaza
//                  cota totala si castigul potential.

using System;
using System.Collections.Generic;

namespace SportBet.Models
{
    /// <summary>
    /// Enumereaza statusurile posibile ale unui tichet.
    /// </summary>
    public enum StatusTichet
    {
        InAsteptare,
        Castigat,
        Pierdut,
        Anulat
    }

    /// <summary>
    /// Reprezinta un tichet de pariere care contine unul sau mai multe pariuri.
    /// </summary>
    public class Tichet
    {
        #region Proprietati

        /// <summary>Identificatorul unic al tichetului.</summary>
        public int Id { get; set; }

        /// <summary>Identificatorul utilizatorului care a plasat tichetul.</summary>
        public int UtilizatorId { get; set; }

        /// <summary>Suma mizata pe tichet, in lei (RON).</summary>
        public decimal MizaTotal { get; set; }

        /// <summary>Cota totala calculata (produsul cotelor individuale).</summary>
        public double CotaTotala { get; set; }

        /// <summary>Castigul potential (miza * cota totala).</summary>
        public decimal CastigPotential { get; set; }

        /// <summary>Castigul efectiv obtinut (setat dupa decontare).</summary>
        public decimal CastigEfectiv { get; set; }

        /// <summary>Statusul curent al tichetului.</summary>
        public StatusTichet Status { get; set; }

        /// <summary>Data si ora la care a fost plasat tichetul.</summary>
        public DateTime DataPlasare { get; set; }

        /// <summary>Data la care a fost decontat tichetul.</summary>
        public DateTime? DataDecontare { get; set; }

        /// <summary>Lista pariurilor individuale din acest tichet.</summary>
        public List<Pariu> Pariuri { get; set; }

        #endregion

        #region Constructori

        /// <summary>
        /// Constructor implicit. Initializeaza lista de pariuri si seteaza valorile implicite.
        /// </summary>
        public Tichet()
        {
            Pariuri = new List<Pariu>();
            Status = StatusTichet.InAsteptare;
            DataPlasare = DateTime.Now;
            CotaTotala = 1.0;
        }

        /// <summary>
        /// Constructor cu parametri pentru crearea unui tichet.
        /// </summary>
        /// <param name="id">Identificatorul unic.</param>
        /// <param name="utilizatorId">ID-ul utilizatorului.</param>
        /// <param name="mizaTotal">Suma mizata.</param>
        public Tichet(int id, int utilizatorId, decimal mizaTotal)
        {
            Id = id;
            UtilizatorId = utilizatorId;
            MizaTotal = mizaTotal;
            Pariuri = new List<Pariu>();
            Status = StatusTichet.InAsteptare;
            DataPlasare = DateTime.Now;
            CotaTotala = 1.0;
        }

        #endregion

        #region Metode

        /// <summary>
        /// Adauga un pariu la tichet si recalculeaza cota totala.
        /// </summary>
        /// <param name="pariu">Pariurile de adaugat.</param>
        public void AdaugaPariu(Pariu pariu)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Elimina un pariu din tichet dupa ID-ul sau si recalculeaza cota totala.
        /// </summary>
        /// <param name="pariuId">ID-ul pariurilor de eliminat.</param>
        public void EliminaPariu(int pariuId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculeaza si actualizeaza cota totala a tichetului
        /// ca produs al cotelor tuturor pariurilor individuale.
        /// </summary>
        public void RecalculeazaCotaTotala()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculeaza castigul potential al tichetului (miza * cota totala).
        /// </summary>
        /// <returns>Valoarea castigului potential in RON.</returns>
        public decimal CalculeazaCastigPotential()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deconteaza tichetul: verifica fiecare pariu si seteaza statusul final.
        /// </summary>
        public void Deconteaza()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica daca toate pariurile din tichet au meciul finalizat.
        /// </summary>
        /// <returns>True daca tichetul poate fi decontat, altfel false.</returns>
        public bool EsteGataDeDecontare()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returneaza numarul de pariuri din tichet.
        /// </summary>
        /// <returns>Numarul de pariuri.</returns>
        public int GetNrPariuri()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returneaza o reprezentare text a obiectului Tichet.
        /// </summary>
        /// <returns>String cu informatiile principale ale tichetului.</returns>
        public override string ToString()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
