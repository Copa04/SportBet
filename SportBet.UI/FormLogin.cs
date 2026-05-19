// Autor: Maxim Cezar-Andrei
// Functionalitate: Formular de autentificare pentru utilizatorii aplicatiei SportBet.
//                  Permite introducerea credentialelor si redirectionarea catre formularul principal.

using SportBet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportBet.UI
{
    public partial class FormLogin : Form
    {
        #region Campuri private

        private readonly AuthService _authService;
        private readonly DataService _dataService;
        private readonly TichetService _tichetService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializeaza FormLogin cu serviciile necesare autentificarii.
        /// </summary>
        /// <param name="authService">Instanta AuthService creata in Program.cs.</param>
        /// <param name="dataService">Instanta DataService creata in Program.cs.</param>
        /// <param name="tichetService">Instanta TichetService creata in Program.cs.</param>
        public FormLogin(AuthService authService, DataService dataService, TichetService tichetService)
        {
            InitializeComponent();
            _authService = authService;
            _dataService = dataService;
            _tichetService = tichetService;
        }

        #endregion

        #region Handlere

        /// <summary>
        /// Autentifica utilizatorul pe baza credentialelor introduse si deschide formularul principal.
        /// </summary>
        private void buttonAutentificare_Click(object sender, EventArgs e)
        {
            try
            {
                labelStatus.Text = "";

                if (string.IsNullOrWhiteSpace(textBoxUtilizator.Text) ||
                    string.IsNullOrWhiteSpace(textBoxParola.Text))
                {
                    labelStatus.Text = "Completează toate câmpurile!";
                    return;
                }

                bool ok = _authService.Autentifica(
                    textBoxUtilizator.Text.Trim(),
                    textBoxParola.Text);

                if (!ok)
                {
                    labelStatus.Text = "Nume utilizator sau parolă incorectă!";
                    textBoxParola.Clear();
                    return;
                }

                var formPrincipal = new FormPrincipal(
                    _authService.UtilizatorCurent, _dataService, _authService, _tichetService);
                formPrincipal.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Deschide formularul de inregistrare si ascunde formularul de login.
        /// </summary>
        private void buttonInregistrare_Click(object sender, EventArgs e)
        {
            var formRegister = new FormRegister(_authService, _dataService, _tichetService);
            formRegister.Show();
            this.Hide();
        }

        /// <summary>
        /// Inchide aplicatia.
        /// </summary>
        private void buttonIesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Deschide fisierul de ajutor al aplicatiei.
        /// </summary>
        private void buttonAjutor_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Application.StartupPath, "Help", "SportBet.chm");
            Help.ShowHelp(this, path);
        }

        #endregion
    }
}