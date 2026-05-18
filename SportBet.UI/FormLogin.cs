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
    public partial class FormLogin : Form
    {
        private readonly AuthService _authService;
        private readonly DataService _dataService;
        private readonly TichetService _tichetService;

        public FormLogin(AuthService authService, DataService dataService, TichetService tichetService)
        {
            InitializeComponent();
            _authService = authService;
            _dataService = dataService;
            _tichetService = tichetService;
        }

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

        private void buttonInregistrare_Click(object sender, EventArgs e)
        {
            var formRegister = new FormRegister(_authService, _dataService, _tichetService);
            formRegister.Show();
            this.Hide();
        }

        private void buttonIesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAjutor_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "SportBet.chm");
        }
    }
}
