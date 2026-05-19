// Autor: Maxim Cezar-Andrei
// Functionalitate: Formular pentru depunerea de fonduri in contul utilizatorului curent.
//                  Permite introducerea unei sume intre 1 si 10000 RON si actualizeaza soldul.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SportBet.Models;
using SportBet.Services;

namespace SportBet.UI
{
    public partial class FormDepunere : Form
    {
        #region Campuri private

        private readonly Utilizator _utilizatorCurent;
        private readonly DataService _dataService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializeaza FormDepunere cu utilizatorul curent si serviciul de date.
        /// </summary>
        /// <param name="utilizator">Utilizatorul logat, pasat din FormPrincipal.</param>
        /// <param name="dataService">Instanta DataService creata in Program.cs.</param>
        public FormDepunere(Utilizator utilizator, DataService dataService)
        {
            InitializeComponent();
            _utilizatorCurent = utilizator;
            _dataService = dataService;
        }

        #endregion

        #region Evenimente Form

        /// <summary>
        /// La incarcarea formularului: configureaza controalele si afiseaza soldul curent.
        /// </summary>
        private void FormDepunere_Load(object sender, EventArgs e)
        {
            try
            {
                numericUpDownSuma.Minimum = 1;
                numericUpDownSuma.Maximum = 10000;
                numericUpDownSuma.DecimalPlaces = 2;
                numericUpDownSuma.Value = 1;

                ActualizeazaLabels();
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
        /// Actualizeaza label-urile cu soldul curent si soldul dupa depunere.
        /// </summary>
        private void ActualizeazaLabels()
        {
            labelSoldCurent.Text = $"{_utilizatorCurent.Sold:F2} RON";
            decimal soldDupa = _utilizatorCurent.Sold + numericUpDownSuma.Value;
            labelSoldDupa.Text = $"{soldDupa:F2} RON";
        }

        #endregion

        #region Handlere

        /// <summary>
        /// La schimbarea sumei, actualizeaza soldul dupa depunere.
        /// </summary>
        private void numericUpDownSuma_ValueChanged(object sender, EventArgs e)
        {
            ActualizeazaLabels();
        }

        /// <summary>
        /// Depune suma introdusa in contul utilizatorului si salveaza in JSON.
        /// </summary>
        private void buttonDepunere_Click(object sender, EventArgs e)
        {
            try
            {
                decimal suma = numericUpDownSuma.Value;

                DialogResult confirmare = MessageBox.Show(
                    $"Confirmi depunerea sumei de {suma:F2} RON?",
                    "Confirmare depunere",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmare != DialogResult.Yes)
                    return;

                _utilizatorCurent.Depune(suma);

                _dataService.UtilizatorRepository.ActualizeazaSold(
                    _utilizatorCurent.Id, _utilizatorCurent.Sold);
                _dataService.SalveazaUtilizatori(
                    _dataService.UtilizatorRepository.GetAll());

                MessageBox.Show(
                    $"Depunere efectuata cu succes!\nSold nou: {_utilizatorCurent.Sold:F2} RON",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la depunere: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inchide formularul fara a efectua depunerea.
        /// </summary>
        private void buttonAnulare_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }

}
