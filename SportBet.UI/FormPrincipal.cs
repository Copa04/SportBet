// Autor: Echipa SportBet
// Functionalitate: Fereastra principala a aplicatiei SportBet.
//                  Afiseaza meciurile disponibile, permite construirea unui tichet
//                  prin adaugarea de pariuri si finalizarea acestuia.


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
        private readonly TichetService _tichetService;

        /// <summary>Lista pariurilor din tichetul in constructie.</summary>
        private List<Pariu> _pariuriCurente = new List<Pariu>();

        private decimal _mizaTichet = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializeaza FormPrincipal cu utilizatorul autentificat si serviciul de date.
        /// </summary>
        /// <param name="utilizator">Utilizatorul logat, pasat din FormLogin.</param>
        /// <param name="dataService">Instanta DataService creata in Program.cs.</param>
        public FormPrincipal(Utilizator utilizator, DataService dataService, AuthService authService, TichetService tichetService)
        {
            InitializeComponent();
            _utilizatorCurent = utilizator;
            _dataService = dataService;
            _authService = authService;
            _tichetService = tichetService;
        }

        #endregion

        #region Evenimente Form

        /// <summary>
        /// La incarcarea formularului: actualizeaza headerul, configureaza
        /// ListView-urile si incarca meciurile.
        /// </summary>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizeazaHeader();
                ConfigureazaListViewMeciuri();
                ConfigureazaListViewTichet();
                InitializeazaPanel();
                IncarcaMeciuri();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la incarcarea datelor: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Metode private — configurare

        /// <summary>
        /// Actualizeaza label-urile din ToolStrip cu numele si soldul utilizatorului curent.
        /// </summary>
        private void ActualizeazaHeader()
        {
            toolStripLabelProfil.Text = _utilizatorCurent.Username;
            toolStripLabelSold.Text = $"{_utilizatorCurent.Sold:F2} RON";
        }

        /// <summary>
        /// Configureaza coloanele si stilul ListView-ului pentru meciuri.
        /// </summary>
        private void ConfigureazaListViewMeciuri()
        {
            listViewMeciuri.View = View.Details;
            listViewMeciuri.FullRowSelect = true;
            listViewMeciuri.GridLines = true;
            listViewMeciuri.MultiSelect = false;

            listViewMeciuri.Columns.Clear();
            listViewMeciuri.Columns.Add("Liga", 130);
            listViewMeciuri.Columns.Add("Meci", 220);
            listViewMeciuri.Columns.Add("Data / Ora", 120);
            listViewMeciuri.Columns.Add("1", 55);
            listViewMeciuri.Columns.Add("X", 55);
            listViewMeciuri.Columns.Add("2", 55);
            listViewMeciuri.Columns.Add("Status", 80);
        }

        /// <summary>
        /// Configureaza coloanele ListView-ului pentru tichetul curent.
        /// Daca ai adaugat coloanele din Designer, sterge continutul acestei metode.
        /// </summary>
        private void ConfigureazaListViewTichet()
        {
            listViewTichetCurent.View = View.Details;
            listViewTichetCurent.FullRowSelect = true;
            listViewTichetCurent.GridLines = true;
            listViewTichetCurent.MultiSelect = false;

            listViewTichetCurent.Columns.Clear();
            listViewTichetCurent.Columns.Add("Meci", 120);
            listViewTichetCurent.Columns.Add("Sel.", 35);
            listViewTichetCurent.Columns.Add("Cota", 40);
        }

        /// <summary>
        /// Initializeaza controalele din panelul tichetului curent.
        /// </summary>
        private void InitializeazaPanel()
        {
            labelSoldDisponibil.Text = $"Sold: {_utilizatorCurent.Sold:F2} RON";
            buttonFinalizeazaTichet.Enabled = false;
            buttonStergePariu.Enabled = false;
            buttonStergeTot.Enabled = false;

            ActualizeazaPanelTichet();
        }

        #endregion

        #region Metode private — meciuri

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
                    item.Tag = meci;
                    listViewMeciuri.Items.Add(item);
                }

                labelMesaj.Text = $"{meciuriProgramate.Count} meciuri disponibile";
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
        private Meci GetMeciSelectat()
        {
            if (listViewMeciuri.SelectedItems.Count == 0)
                return null;

            return (Meci)listViewMeciuri.SelectedItems[0].Tag;
        }

        #endregion

        #region Metode private — panel tichet

        /// <summary>
        /// Adauga un pariu la tichetul curent.
        /// Verifica sa nu existe deja un pariu pe acelasi meci.
        /// </summary>
        /// <param name="pariu">Pariul de adaugat.</param>
        private void AdaugaPariu(Pariu pariu, decimal miza)
        {
            foreach (Pariu p in _pariuriCurente)
            {
                if (p.MeciId == pariu.MeciId)
                {
                    MessageBox.Show("Ai deja un pariu pe acest meci in tichetul curent.",
                        "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            _mizaTichet += miza;
            _pariuriCurente.Add(pariu);
            ActualizeazaPanelTichet();
        }

        /// <summary>
        /// Recalculeaza cota totala si castigul potential si
        /// actualizeaza toate controalele din panelul tichetului.
        /// </summary>
        private void ActualizeazaPanelTichet()
        {
            listViewTichetCurent.Items.Clear();

            double cotaTotala = 1.0;

            foreach (Pariu p in _pariuriCurente)
            {
                ListViewItem item = new ListViewItem(
                    $"{p.MeciAsociat.EchipaGazda} — {p.MeciAsociat.EchipaOaspete}");
                item.SubItems.Add(p.TipSelectie);
                item.SubItems.Add(p.Cota.ToString("F2"));
                item.Tag = p;
                listViewTichetCurent.Items.Add(item);
                cotaTotala *= p.Cota;
            }

            labelCotaTotala.Text = $"Cota totala: {cotaTotala:F2}";

            labelMizaTotala.Text = $"Miza totala: {_mizaTichet:F2} RON";

            decimal castig = Math.Round(_mizaTichet * (decimal)cotaTotala, 2);
            labelCastigPotential.Text = $"Castig potential: {castig:F2} RON";

            bool arePariuri = _pariuriCurente.Count > 0;
            buttonFinalizeazaTichet.Enabled = arePariuri;
            buttonStergeTot.Enabled = arePariuri;
            buttonStergePariu.Enabled = arePariuri;
        }

        /// <summary>
        /// Actualizeaza label-ul soldului din ToolStrip si din panel.
        /// Apelata dupa orice operatiune care modifica soldul.
        /// </summary>
        private void ActualizeazaSold()
        {
            toolStripLabelSold.Text = $"{_utilizatorCurent.Sold:F2} RON";
            labelSoldDisponibil.Text = $"Sold: {_utilizatorCurent.Sold:F2} RON";
        }

        /// <summary>
        /// Deschide FormPlasarePariu cu meciul selectat.
        /// Daca utilizatorul confirma, adauga pariul in tichetul curent.
        /// </summary>
        private void DeschideFormPlasarePariu()
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

                var formPariu = new FormPariu(_utilizatorCurent, meciSelectat, _dataService);
                if (formPariu.ShowDialog() == DialogResult.OK)
                {
                    AdaugaPariu(formPariu.PariulCreat, formPariu.MizaIntrodusa);
                }
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
        /// Click pe "Meciuri" — reincarca lista de meciuri.
        /// </summary>
        private void toolStripButtonMeciuri_Click(object sender, EventArgs e)
        {
            IncarcaMeciuri();
        }

        /// <summary>
        /// Click pe "Tichetele mele" — deschide FormTichete.
        /// </summary>
        private void toolStripButtonTicheteleMele_Click(object sender, EventArgs e)
        {
            try
            {
                var formTichete = new FormTichete(_utilizatorCurent, _dataService, _tichetService);
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
        /// Click pe "Depunere" — deschide FormDepunere.
        /// </summary>
        private void toolStripButtonDepunere_Click(object sender, EventArgs e)
        {
            try
            {
                var formDepunere = new FormDepunere(_utilizatorCurent, _dataService);
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
        /// Click pe "Iesire" — deconecteaza utilizatorul si revine la FormLogin.
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
                var formLogin = new FormLogin(_authService, _dataService, _tichetService);
                formLogin.Show();
                this.Close();
            }
        }

        #endregion

        #region Handlere ListView meciuri

        /// <summary>
        /// Dublu-click pe un meci — deschide FormPlasarePariu.
        /// </summary>
        private void listViewMeciuri_DoubleClick(object sender, EventArgs e)
        {
            DeschideFormPlasarePariu();
        }

        /// <summary>
        /// Click pe butonul "Plasează pariu" — deschide FormPlasarePariu.
        /// </summary>
        private void buttonPlaseazaPariu_Click(object sender, EventArgs e)
        {
            DeschideFormPlasarePariu();
        }

        #endregion

        #region Handlere panel tichet

        /// <summary>
        /// La schimbarea mizei, recalculeaza castigul potential.
        /// </summary>
        private void numericUpDownMiza_ValueChanged(object sender, EventArgs e)
        {
            ActualizeazaPanelTichet();
        }

        /// <summary>
        /// Sterge pariul selectat din tichetul curent.
        /// </summary>
        private void buttonStergePariu_Click(object sender, EventArgs e)
        {
            if (listViewTichetCurent.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selectati un pariu din lista.",
                    "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Pariu p = (Pariu)listViewTichetCurent.SelectedItems[0].Tag;
            _pariuriCurente.Remove(p);
            ActualizeazaPanelTichet();
        }

        /// <summary>
        /// Sterge toate pariurile din tichetul curent.
        /// </summary>
        private void buttonStergeTot_Click(object sender, EventArgs e)
        {
            _pariuriCurente.Clear();
            _mizaTichet = 0;
            ActualizeazaPanelTichet();
        }

        /// <summary>
        /// Finalizeaza tichetul curent: valideaza miza, plaseaza tichetul
        /// prin TichetService si salveaza in JSON.
        /// </summary>
        private void buttonFinalizeazaTichet_Click(object sender, EventArgs e)
        {
            try
            {
                if (_pariuriCurente.Count == 0)
                {
                    MessageBox.Show("Adaugati cel putin un pariu inainte de a finaliza.",
                        "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal miza = _mizaTichet;

                if (!_utilizatorCurent.AreSuficienteFonduri(miza))
                {
                    MessageBox.Show("Sold insuficient pentru aceasta miza.",
                        "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calculeaza cota totala pentru mesajul de confirmare
                double cotaTotala = 1.0;
                foreach (Pariu p in _pariuriCurente)
                    cotaTotala *= p.Cota;

                decimal castigPotential = Math.Round(miza * (decimal)cotaTotala, 2);

                DialogResult confirmare = MessageBox.Show(
                    $"Confirmi plasarea tichetului?\n\n" +
                    $"Pariuri: {_pariuriCurente.Count}\n" +
                    $"Cota totala: {cotaTotala:F2}\n" +
                    $"Miza: {miza:F2} RON\n" +
                    $"Castig potential: {castigPotential:F2} RON",
                    "Confirmare tichet",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmare != DialogResult.Yes)
                    return;

                // Plaseaza tichetul prin TichetService
                TichetService tichetService = new TichetService(
                    _dataService.TichetRepository,
                    _dataService.MeciRepository,
                    _dataService.UtilizatorRepository);

                Utilizator u = _dataService.UtilizatorRepository.GetById(_utilizatorCurent.Id);
                MessageBox.Show(
                    $"Utilizator gasit: {u != null}\n" +
                    $"EsteActiv: {u?.EsteActiv}\n" +
                    $"Sold utilizator in repo: {u?.Sold}\n" +
                    $"Miza: {miza}\n" +
                    $"AreSuficienteFonduri: {u?.AreSuficienteFonduri(miza)}\n" +
                    $"Nr pariuri: {_pariuriCurente.Count}\n" +
                    $"MeciId primul pariu: {_pariuriCurente[0].MeciId}\n" +
                    $"Meci gasit in repo: {_dataService.MeciRepository.GetById(_pariuriCurente[0].MeciId) != null}",
                    "Debug");


                Tichet tichet = tichetService.PlaseazaTichet(
                    _utilizatorCurent.Id, _pariuriCurente, miza);

                if (tichet == null)
                {
                    MessageBox.Show("Eroare la plasarea tichetului. Verificati datele.",
                        "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Salveaza in JSON
                _dataService.SalveazaTichete(_dataService.TichetRepository.GetAll());
                _dataService.SalveazaUtilizatori(_dataService.UtilizatorRepository.GetAll());

                MessageBox.Show(
                    $"Tichet plasat cu succes!\nSold ramas: {_utilizatorCurent.Sold:F2} RON",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reseteaza tichetul curent
                _pariuriCurente.Clear();
                ActualizeazaPanelTichet();
                ActualizeazaSold();
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
