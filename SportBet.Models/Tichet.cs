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
            if (pariu == null)
                throw new ArgumentNullException("pariu");

            Pariuri.Add(pariu);
            RecalculeazaCotaTotala();
        }

        /// <summary>
        /// Elimina un pariu din tichet dupa ID-ul sau si recalculeaza cota totala.
        /// </summary>
        /// <param name="pariuId">ID-ul pariurilor de eliminat.</param>
        public void EliminaPariu(int pariuId)
        {
            Pariu pariuDeEliminat = null;

            foreach (Pariu pariu in Pariuri)
            {
                if (pariu.Id == pariuId)
                {
                    pariuDeEliminat = pariu;
                    break;
                }
            }

            if (pariuDeEliminat != null)
                Pariuri.Remove(pariuDeEliminat);

            RecalculeazaCotaTotala();
        }

        /// <summary>
        /// Calculeaza si actualizeaza cota totala a tichetului
        /// ca produs al cotelor tuturor pariurilor individuale.
        /// </summary>
        public void RecalculeazaCotaTotala()
        {
            if (Pariuri == null || Pariuri.Count == 0)
            {
                CotaTotala = 1.0;
                CastigPotential = 0m;
                return;
            }

            double produs = 1.0;

            foreach (Pariu pariu in Pariuri)
            {
                produs *= pariu.Cota;
            }

            CotaTotala = produs;
            CastigPotential = CalculeazaCastigPotential();
        }

        /// <summary>
        /// Calculeaza castigul potential al tichetului (miza * cota totala).
        /// </summary>
        /// <returns>Valoarea castigului potential in RON.</returns>
        public decimal CalculeazaCastigPotential()
        {
            if (MizaTotal <= 0 || Pariuri == null || Pariuri.Count == 0)
                return 0m;

            return Math.Round(MizaTotal * (decimal)CotaTotala, 2);
        }

        /// <summary>
        /// Deconteaza tichetul: verifica fiecare pariu si seteaza statusul final.
        /// </summary>
        public void Deconteaza()
        {
            if (Status == StatusTichet.Anulat)
                return;

            if (!EsteGataDeDecontare())
                throw new InvalidOperationException("Tichetul nu poate fi decontat deoarece nu toate meciurile sunt finalizate sau anulate.");

            bool arePariuPierdut = false;
            bool toateReturnate = true;

            foreach (Pariu pariu in Pariuri)
            {
                pariu.ActualizeazaStatus();

                if (pariu.Status == StatusPariu.Pierdut)
                    arePariuPierdut = true;

                if (pariu.Status != StatusPariu.Returnat && pariu.Status != StatusPariu.Anulat)
                    toateReturnate = false;
            }

            if (arePariuPierdut)
            {
                Status = StatusTichet.Pierdut;
                CastigEfectiv = 0m;
            }
            else if (toateReturnate)
            {
                Status = StatusTichet.Anulat;
                CastigEfectiv = MizaTotal;
            }
            else
            {
                Status = StatusTichet.Castigat;
                CastigEfectiv = CalculeazaCastigPotential();
            }

            DataDecontare = DateTime.Now;
        }

        /// <summary>
        /// Verifica daca toate pariurile din tichet au meciul finalizat.
        /// </summary>
        /// <returns>True daca tichetul poate fi decontat, altfel false.</returns>
        public bool EsteGataDeDecontare()
        {
            if (Pariuri == null || Pariuri.Count == 0)
                return false;

            foreach (Pariu pariu in Pariuri)
            {
                if (pariu.MeciAsociat == null)
                    return false;

                if (pariu.MeciAsociat.Status != StatusMeci.Finalizat &&
                    pariu.MeciAsociat.Status != StatusMeci.Anulat)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Returneaza numarul de pariuri din tichet.
        /// </summary>
        /// <returns>Numarul de pariuri.</returns>
        public int GetNrPariuri()
        {
            return Pariuri == null ? 0 : Pariuri.Count;
        }

        /// <summary>
        /// Returneaza o reprezentare text a obiectului Tichet.
        /// </summary>
        /// <returns>String cu informatiile principale ale tichetului.</returns>
        public override string ToString()
        {
            return string.Format("Tichet #{0} | Utilizator: {1} | Miza: {2:0.00} RON | Pariuri: {3} | Cota totala: {4:0.00} | Castig potential: {5:0.00} RON | Status: {6}",
                            Id, UtilizatorId, MizaTotal, GetNrPariuri(), CotaTotala, CastigPotential, Status);
        }

        #endregion
    }
}
