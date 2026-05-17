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
    public partial class FormPrincipal : Form
    {
        #region Campuri private

        /// <summary>Lista tuturor meciurilor incarcate din fisierul JSON.</summary>
        private List<Meci> _meciuri;

        /// <summary>Utilizatorul curent autentificat, pasat din FormLogin.</summary>
        private readonly Utilizator _utilizatorCurent;

        /// <summary>Serviciul central de date, instantiat in Program.cs si pasat aici.</summary>
        private readonly DataService _dataService;
        private readonly AuthService _authService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializeaza FormPrincipal cu utilizatorul autentificat si serviciul de date.
        /// </summary>
        /// <param name="utilizator">Utilizatorul logat, pasat din FormLogin.</param>
        /// <param name="dataService">Instanta DataService creata in Program.cs.</param>
        public FormPrincipal(Utilizator utilizator, DataService dataService)
        {
            InitializeComponent();
            _utilizatorCurent = utilizator;
            _dataService = dataService;
        }

        #endregion

        #region Evenimente Form

        /// <summary>
        /// La incarcarea formularului: actualizeaza headerul si incarca meciurile.
        /// </summary>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizeazaHeader();
                ConfigureazaListView();
                IncarcaMeciuri();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la incarcarea datelor: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Metode private

        /// <summary>
        /// Actualizeaza label-urile din ToolStrip cu numele si soldul utilizatorului curent.
        /// </summary>
        private void ActualizeazaHeader()
        {
            // tslblProfil = ToolStripLabel cu numele utilizatorului
            // tslblSold   = ToolStripLabel cu soldul
            toolStripLabelProfil.Text = _utilizatorCurent.Username;
            toolStripLabelSold.Text = $"{_utilizatorCurent.Sold:F2} RON";
        }

        /// <summary>
        /// Configureaza coloanele si stilul ListView-ului pentru afisarea meciurilor.
        /// </summary>
        private void ConfigureazaListView()
        {
            listViewMeciuri.View = View.Details;
            listViewMeciuri.FullRowSelect = true;
            listViewMeciuri.GridLines = true;
            listViewMeciuri.MultiSelect = false;

            listViewMeciuri.Columns.Clear();
            listViewMeciuri.Columns.Add("Liga", 140);
            listViewMeciuri.Columns.Add("Meci", 230);
            listViewMeciuri.Columns.Add("Data / Ora", 120);
            listViewMeciuri.Columns.Add("1", 60);
            listViewMeciuri.Columns.Add("X", 60);
            listViewMeciuri.Columns.Add("2", 60);
            listViewMeciuri.Columns.Add("Status", 90);
        }

        /// <summary>
        /// Incarca meciurile din fisierul JSON prin DataService si le afiseaza in ListView.
        /// Afiseaza doar meciurile cu statusul Programat, ordonate dupa data.
        /// </summary>
        private void IncarcaMeciuri()
        {
            try
            {
                _meciuri = _dataService.IncarcaMeciuri();

                listViewMeciuri.Items.Clear();

                List<Meci> meciuriProgramate = _meciuri
                    .Where(m => m.Status == StatusMeci.Programat)
                    .OrderBy(m => m.DataOra)
                    .ToList();

                foreach (Meci meci in meciuriProgramate)
                {
                    ListViewItem item = new ListViewItem(meci.Liga);
                    item.SubItems.Add($"{meci.EchipaGazda} — {meci.EchipaOaspete}");
                    item.SubItems.Add(meci.DataOra.ToString("dd.MM.yyyy HH:mm"));
                    item.SubItems.Add(meci.CotaGazda.ToString("F2"));
                    item.SubItems.Add(meci.CotaEgalitate.ToString("F2"));
                    item.SubItems.Add(meci.CotaOaspete.ToString("F2"));
                    item.SubItems.Add(meci.Status.ToString());
                    item.Tag = meci; // stocam obiectul Meci pe item pentru acces ulterior
                    listViewMeciuri.Items.Add(item);
                }

                // Actualizeaza StatusStrip-ul cu numarul de meciuri afisate
                //tsslMesaj.Text = $"{meciuriProgramate.Count} meciuri disponibile";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la incarcarea meciurilor: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Returneaza meciul selectat din ListView, sau null daca nu e selectat niciunul.
        /// </summary>
        /// <returns>Obiectul Meci selectat sau null.</returns>
        private Meci GetMeciSelectat()
        {
            if (listViewMeciuri.SelectedItems.Count == 0)
                return null;

            return (Meci)listViewMeciuri.SelectedItems[0].Tag;
        }

        /// <summary>
        /// Actualizeaza label-ul soldului din ToolStrip.
        /// Apelata dupa orice operatiune care modifica soldul utilizatorului.
        /// </summary>
        private void ActualizeazaSold()
        {
            toolStripLabelSold.Text = $"{_utilizatorCurent.Sold:F2} RON";
        }

        /// <summary>
        /// Deschide FormPlasarePariu cu meciul selectat.
        /// Valideaza ca un meci e selectat si ca are statusul Programat.
        /// </summary>
        private void DeschideFormPariu()
        {
            try
            {
                Meci meciSelectat = GetMeciSelectat();

                if (meciSelectat == null)
                {
                    MessageBox.Show("Selectati un meci din lista pentru a plasa un pariu.",
                        "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (meciSelectat.Status != StatusMeci.Programat)
                {
                    MessageBox.Show("Pariurile pot fi plasate doar pe meciuri programate.",
                        "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var formPariu = new FormPariu();
                formPariu.ShowDialog();

                // Dupa inchiderea formularului, actualizam soldul afisat
                ActualizeazaSold();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Handlere ToolStrip

        /// <summary>
        /// Click pe butonul "Meciuri" din ToolStrip — reincarca lista de meciuri.
        /// </summary>
        private void toolStripButtonMeciuri_Click(object sender, EventArgs e)
        {
            try
            {
                IncarcaMeciuri();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Click pe butonul "Tichetele mele" din ToolStrip — deschide FormTichete.
        /// </summary>
        private void toolStripButtonTicheteleMele_Click(object sender, EventArgs e)
        {
            try
            {
                var formTichete = new FormTichete();
                formTichete.ShowDialog();
                ActualizeazaSold();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Click pe butonul "Depunere" din ToolStrip — deschide FormDepunere.
        /// </summary>
        private void toolStripButtonDepunere_Click(object sender, EventArgs e)
        {
            try
            {
                var formDepunere = new FormDepunere();
                formDepunere.ShowDialog();
                ActualizeazaSold();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Click pe butonul "Iesire" din ToolStrip — deconecteaza utilizatorul.
        /// </summary>
        private void toolStripButtonIesire_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show(
                "Ești sigur că vrei să te deconectezi?",
                "Deconectare",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rezultat == DialogResult.Yes)
            {
                var formLogin = new FormLogin(_authService, _dataService);
                formLogin.Show();
                this.Close();
            }
        }

        #endregion

        #region Handlere ListView si butoane

        /// <summary>
        /// Dublu-click pe un meci din lista — deschide direct FormPlasarePariu.
        /// </summary>
        private void listViewMeciuri_DoubleClick(object sender, EventArgs e)
        {
            DeschideFormPariu();
        }

        /// <summary>
        /// Click pe butonul "Plaseaza Pariu" — deschide FormPlasarePariu.
        /// </summary>
        private void buttonPlaseazaPariu_Click(object sender, EventArgs e)
        {
            DeschideFormPariu();
        }

        /// <summary>
        /// Click pe butonul "Reincarcare" — reimprospateza lista de meciuri din JSON.
        /// </summary>
        private void buttonReincarca_Click(object sender, EventArgs e)
        {
            try
            {
                IncarcaMeciuri();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }

}
