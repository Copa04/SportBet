// Autor: Maxim-Cezar Andrei
// Functionalitate: Formular pentru plasarea unui pariu pe un meci selectat.
//                  Permite selectarea tipului de pariu (1/X/2), introducerea
//                  mizei si afisarea castigului potential inainte de confirmare.

using SportBet.Models;
using SportBet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportBet.UI
{
    public partial class FormPariu : Form
    {
        #region Campuri private

        /// <summary>Utilizatorul curent autentificat.</summary>
        private readonly Utilizator _utilizatorCurent;

        /// <summary>Meciul pe care se plaseaza pariul.</summary>
        private readonly Meci _meci;

        /// <summary>Serviciul central de date.</summary>
        private readonly DataService _dataService;

        /// <summary>Cota selectata curent (1, X sau 2).</summary>
        private double _cotaSelectata;

        /// <summary>Tipul selectiei curente ("1", "X" sau "2").</summary>
        private string _tipSelectie;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializeaza formularul cu utilizatorul curent, meciul selectat si serviciul de date.
        /// </summary>
        /// <param name="utilizator">Utilizatorul logat.</param>
        /// <param name="meci">Meciul pe care se plaseaza pariul.</param>
        /// <param name="dataService">Instanta DataService din Program.cs.</param>
        public FormPariu(Utilizator utilizator, Meci meci, DataService dataService)
        {
            InitializeComponent();
            _utilizatorCurent = utilizator;
            _meci = meci;
            _dataService = dataService;
        }

        #endregion

        #region Evenimente Form

        /// <summary>
        /// La incarcarea formularului: populeaza detaliile meciului si
        /// initializeaza controalele cu valorile implicite.
        /// </summary>
        private void FormPariu_Load(object sender, EventArgs e)
        {
            try
            {
                PopuleazaDetaliiMeci();
                InitializeazaControale();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la incarcarea formularului: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Metode private

        /// <summary>
        /// Populeaza label-urile cu informatiile meciului selectat.
        /// </summary>
        private void PopuleazaDetaliiMeci()
        {
            label1.Text = _meci.Liga;
            labelMeci.Text = $"{_meci.EchipaGazda} — {_meci.EchipaOaspete}";
            labelData.Text = _meci.DataOra.ToString("dd.MM.yyyy HH:mm");

            // Afiseaza cotele pe fiecare RadioButton
            radioButtonGazda.Text = $"1 — Gazda  ({_meci.CotaGazda:F2})";
            radioButtonEgal.Text = $"X — Egal  ({_meci.CotaEgalitate:F2})";
            radioButtonOaspete.Text = $"2 — Oaspete  ({_meci.CotaOaspete:F2})";
        }

        /// <summary>
        /// Seteaza valorile initiale ale controalelor:
        /// selectie implicita Gazda, miza minima 1 RON, sold disponibil.
        /// </summary>
        private void InitializeazaControale()
        {
            // Selectie implicita: Gazda
            radioButtonGazda.Checked = true;
            _cotaSelectata = _meci.CotaGazda;
            _tipSelectie = "1";

            // Configureaza NumericUpDown
            numericUpDownMiza.Minimum = 1;
            numericUpDownMiza.Maximum = (decimal)_utilizatorCurent.Sold;
            numericUpDownMiza.DecimalPlaces = 2;
            numericUpDownMiza.Value = 1;

            // Afiseaza soldul disponibil
            labelSoldDisponibil.Text = $"{_utilizatorCurent.Sold:F2} RON";

            // Actualizeaza castigul potential initial
            ActualizeazaCastigPotential();
        }

        /// <summary>
        /// Recalculeaza si afiseaza castigul potential pe baza mizei si cotei selectate.
        /// </summary>
        private void ActualizeazaCastigPotential()
        {
            decimal miza = numericUpDownMiza.Value;
            decimal castig = Math.Round(miza * (decimal)_cotaSelectata, 2);
            labelCastigPotential.Text = $"{castig:F2} RON";
            labelCotaSelectata.Text = $"Cota selectata: {_cotaSelectata:F2}";
        }

        #endregion

        #region Handlere RadioButton

        /// <summary>
        /// Selectie schimbata pe "1 — Gazda".
        /// </summary>
        private void radioButtonGazda_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGazda.Checked)
            {
                _cotaSelectata = _meci.CotaGazda;
                _tipSelectie = "1";
                ActualizeazaCastigPotential();
            }
        }

        /// <summary>
        /// Selectie schimbata pe "X — Egal".
        /// </summary>
        private void radioButtonEgal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEgal.Checked)
            {
                _cotaSelectata = _meci.CotaEgalitate;
                _tipSelectie = "X";
                ActualizeazaCastigPotential();
            }
        }

        /// <summary>
        /// Selectie schimbata pe "2 — Oaspete".
        /// </summary>
        private void radioButtonOaspete_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOaspete.Checked)
            {
                _cotaSelectata = _meci.CotaOaspete;
                _tipSelectie = "2";
                ActualizeazaCastigPotential();
            }
        }

        #endregion

        #region Handler NumericUpDown

        /// <summary>
        /// La schimbarea mizei, recalculeaza castigul potential.
        /// </summary>
        private void numericUpDownMiza_ValueChanged(object sender, EventArgs e)
        {
            ActualizeazaCastigPotential();
        }

        #endregion

        #region Handlere butoane

        /// <summary>
        /// Plaseaza pariul dupa confirmare:
        /// verifica selectia si soldul, creaza pariul si tichetul,
        /// scade miza din sold si salveaza in JSON.
        /// </summary>
        private void buttonPlaseazaPariul_Click(object sender, EventArgs e)
        {
            try
            {
                // Validare selectie
                if (string.IsNullOrEmpty(_tipSelectie))
                {
                    MessageBox.Show("Selectati tipul pariului (1, X sau 2).",
                        "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal miza = numericUpDownMiza.Value;

                // Validare sold suficient
                if (!_utilizatorCurent.AreSuficienteFonduri(miza))
                {
                    MessageBox.Show("Sold insuficient pentru aceasta miza.",
                        "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal castigPotential = Math.Round(miza * (decimal)_cotaSelectata, 2);

                // Confirmare plasare
                DialogResult confirmare = MessageBox.Show(
                    $"Confirmi plasarea pariului?\n\n" +
                    $"Meci: {_meci.EchipaGazda} — {_meci.EchipaOaspete}\n" +
                    $"Selectie: {_tipSelectie}  |  Cota: {_cotaSelectata:F2}\n" +
                    $"Miza: {miza:F2} RON\n" +
                    $"Castig potential: {castigPotential:F2} RON",
                    "Confirmare pariu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmare != DialogResult.Yes)
                    return;

                // Creaza pariul
                Pariu pariu = new Pariu(0, 0, _meci.Id, _tipSelectie, _cotaSelectata);
                pariu.MeciAsociat = _meci;

                // Creaza tichetul si adauga pariul
                Tichet tichet = new Tichet(0, _utilizatorCurent.Id, miza);
                tichet.AdaugaPariu(pariu);

                // Scade miza din soldul utilizatorului
                _utilizatorCurent.Retrage(miza);

                // Salveaza tichetul in repository si in JSON
                _dataService.TichetRepository.Add(tichet);
                _dataService.SalveazaTichete(_dataService.TichetRepository.GetAll());

                // Salveaza soldul actualizat al utilizatorului in JSON
                _dataService.UtilizatorRepository.ActualizeazaSold(
                    _utilizatorCurent.Id, _utilizatorCurent.Sold);
                _dataService.SalveazaUtilizatori(_dataService.UtilizatorRepository.GetAll());

                MessageBox.Show(
                    $"Pariul a fost plasat cu succes!\nSold ramas: {_utilizatorCurent.Sold:F2} RON",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la plasarea pariului: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inchide formularul fara a plasa pariul.
        /// </summary>
        private void buttonAnulare_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }

}
