// Autor: Maxim Cezar-Andrei
// Functionalitate: Formular pentru vizualizarea tichetelor plasate de utilizatorul curent.
//                  Afiseaza lista tichetelor si detaliile fiecaruia, inclusiv pariurile componente.

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
    public partial class FormTichete : Form
    {
        #region Campuri private

        private readonly Utilizator _utilizatorCurent;
        private readonly DataService _dataService;
        private readonly TichetService _tichetService;
        private List<Tichet> _tichete;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializeaza formularul cu utilizatorul curent si serviciul de date.
        /// </summary>
        /// <param name="utilizator">Utilizatorul logat.</param>
        /// <param name="dataService">Instanta DataService din Program.cs.</param>
        public FormTichete(Utilizator utilizator, DataService dataService, TichetService tichetService)
        {
            InitializeComponent();
            _utilizatorCurent = utilizator;
            _dataService = dataService;
            _tichetService = tichetService;
        }

        #endregion

        #region Evenimente Form

        /// <summary>
        /// La incarcarea formularului: configureaza ListView-urile si incarca tichetele.
        /// </summary>
        private void FormTichete_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigureazaListViewTichete();
                ConfigureazaListViewPariuri();
                CurataDetalii();
                IncarcaTichete();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la incarcarea formularului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Metode private — configurare

        /// <summary>
        /// Configureaza coloanele ListView-ului cu lista de tichete.
        /// </summary>
        private void ConfigureazaListViewTichete()
        {
            listViewTichete.View = View.Details;
            listViewTichete.FullRowSelect = true;
            listViewTichete.GridLines = true;
            listViewTichete.MultiSelect = false;

            listViewTichete.Columns.Clear();
            listViewTichete.Columns.Add("#", 35);
            listViewTichete.Columns.Add("Data plasare", 120);
            listViewTichete.Columns.Add("Status", 80);
        }

        /// <summary>
        /// Configureaza coloanele ListView-ului cu pariurile unui tichet.
        /// </summary>
        private void ConfigureazaListViewPariuri()
        {
            listViewPariuri.View = View.Details;
            listViewPariuri.FullRowSelect = true;
            listViewPariuri.GridLines = true;
            listViewPariuri.MultiSelect = false;

            listViewPariuri.Columns.Clear();
            listViewPariuri.Columns.Add("Meci", 200);
            listViewPariuri.Columns.Add("Selectie", 65);
            listViewPariuri.Columns.Add("Cota", 55);
            listViewPariuri.Columns.Add("Status", 80);
        }

        /// <summary>
        /// Goleste label-urile de detalii si ListView-ul de pariuri.
        /// Apelata la incarcare si cand nu e selectat niciun tichet.
        /// </summary>
        private void CurataDetalii()
        {
            labelDataPlasare.Text = "-";
            labelStatus.Text = "-";
            labelMiza.Text = "-";
            labelCotaTotala.Text = "-";
            labelCastigPotential.Text = "-";
            listViewPariuri.Items.Clear();
        }

        #endregion

        #region Metode private — date

        /// <summary>
        /// Incarca tichetele utilizatorului curent din repository si le afiseaza in ListView.
        /// </summary>
        private void IncarcaTichete()
        {
            listViewTichete.Items.Clear();

            _tichete = _tichetService.GetTicheteUtilizator(_utilizatorCurent.Id);

            if (_tichete == null || _tichete.Count == 0)
            {
                labelMesaj.Text = "Nu ai niciun tichet plasat.";
                return;
            }

            foreach (Tichet tichet in _tichete)
            {
                ListViewItem item = new ListViewItem(tichet.Id.ToString());
                item.SubItems.Add(tichet.DataPlasare.ToString("dd.MM.yyyy HH:mm"));
                item.SubItems.Add(tichet.Status.ToString());
                item.Tag = tichet;

                switch (tichet.Status)
                {
                    case StatusTichet.Castigat:
                        item.ForeColor = Color.Green;
                        break;
                    case StatusTichet.Pierdut:
                        item.ForeColor = Color.Red;
                        break;
                    case StatusTichet.Anulat:
                        item.ForeColor = Color.Gray;
                        break;
                    default:
                        item.ForeColor = Color.Black;
                        break;
                }

                listViewTichete.Items.Add(item);
            }

            labelMesaj.Text = $"{_tichete.Count} tichete gasite";
        }

        /// <summary>
        /// Afiseaza detaliile tichetului selectat: informatii generale si lista de pariuri.
        /// </summary>
        /// <param name="tichet">Tichetul de afisat.</param>
        private void AfiseazaDetaliiTichet(Tichet tichet)
        {
            labelDataPlasare.Text = tichet.DataPlasare.ToString("dd.MM.yyyy HH:mm");
            labelStatus.Text = tichet.Status.ToString();
            labelMiza.Text = $"{tichet.MizaTotal:F2} RON";
            labelCotaTotala.Text = tichet.CotaTotala.ToString("F2");
            labelCastigPotential.Text = $"{tichet.CastigPotential:F2} RON";

            listViewPariuri.Items.Clear();

            if (tichet.Pariuri == null || tichet.Pariuri.Count == 0)
            {
                labelMesaj.Text = "Tichetul nu contine pariuri.";
                return;
            }

            foreach (Pariu pariu in tichet.Pariuri)
            {
                if (pariu.MeciAsociat == null)
                {
                    Tichet tichetComplet = _tichetService.GetTichetById(tichet.Id);
                    pariu.MeciAsociat = tichetComplet?.Pariuri.Find(p => p.Id == pariu.Id)?.MeciAsociat;
                }
                    
                string numeMeci = pariu.MeciAsociat != null
                    ? $"{pariu.MeciAsociat.EchipaGazda} — {pariu.MeciAsociat.EchipaOaspete}"
                    : $"Meci #{pariu.MeciId}";

                ListViewItem item = new ListViewItem(numeMeci);
                item.SubItems.Add(pariu.TipSelectie);
                item.SubItems.Add(pariu.Cota.ToString("F2"));
                item.SubItems.Add(pariu.Status.ToString());
                item.Tag = pariu;

                listViewPariuri.Items.Add(item);
            }
        }

        #endregion

        #region Handlere

        /// <summary>
        /// La selectarea unui tichet din lista, afiseaza detaliile acestuia.
        /// </summary>
        private void listViewTichete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTichete.SelectedItems.Count == 0)
            {
                CurataDetalii();
                return;
            }

            Tichet tichetSelectat = (Tichet)listViewTichete.SelectedItems[0].Tag;
            AfiseazaDetaliiTichet(tichetSelectat);
        }

        /// <summary>
        /// Inchide formularul.
        /// </summary>
        private void buttonInchide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }

}
