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
    public partial class FormRegister : Form
    {
        private readonly AuthService _authService;
        private readonly DataService _dataService;
        //private readonly TichetService _tichetService;

        public FormRegister(AuthService authService, DataService dataService)
        {
            InitializeComponent();
            _authService = authService;
            _dataService = dataService;
        }

        private void buttonInregistrare_Click(object sender, EventArgs e)
        {
            try
            {
                labelStatus.Text = "";

                if (string.IsNullOrWhiteSpace(textBoxUtilizator.Text) ||
                    string.IsNullOrWhiteSpace(textBoxParola.Text) ||
                    string.IsNullOrWhiteSpace(textBoxConfirmaParola.Text))
                {
                    labelStatus.Text = "Completează toate câmpurile!";
                    return;
                }

                if (textBoxParola.Text != textBoxConfirmaParola.Text)
                {
                    labelStatus.Text = "Parolele nu coincid!";
                    return;
                }

                var utilizator = new Utilizator
                {
                    Username = textBoxUtilizator.Text.Trim(),
                    Parola = textBoxParola.Text,
                    Sold = (decimal)numericUpDownSold.Value,
                    EsteActiv = true
                };

                bool adaugat = _dataService.UtilizatorRepository.Add(utilizator);

                if (!adaugat)
                {
                    labelStatus.Text = "Numele de utilizator există deja!";
                    return;
                }

                bool salvat = _dataService.SalveazaUtilizatori(
                    _dataService.UtilizatorRepository.GetAll());

                if (!salvat)
                {
                    labelStatus.Text = "Eroare la salvarea datelor!";
                    return;
                }

                MessageBox.Show("Cont creat cu succes!", "Succes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var formLogin = new FormLogin(_authService, _dataService);
                formLogin.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
