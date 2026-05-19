// Autor: Maxim Cezar-Andrei
// Functionalitate: Formular de inregistrare pentru crearea unui cont nou in aplicatia SportBet.
//                  Valideaza datele introduse, verifica unicitatea username-ului si salveaza contul.

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
        #region Campuri private

        private readonly AuthService _authService;
        private readonly DataService _dataService;
        private readonly TichetService _tichetService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializeaza FormRegister cu serviciile necesare inregistrarii unui cont nou.
        /// </summary>
        /// <param name="authService">Instanta AuthService creata in Program.cs.</param>
        /// <param name="dataService">Instanta DataService creata in Program.cs.</param>
        /// <param name="tichetService">Instanta TichetService creata in Program.cs.</param>
        public FormRegister(AuthService authService, DataService dataService, TichetService tichetService)
        {
            InitializeComponent();
            _authService = authService;
            _dataService = dataService;
            _tichetService = tichetService;
        }

        #endregion

        #region Handlere

        /// <summary>
        /// Valideaza campurile introduse, creeaza un cont nou si redirectioneaza catre login.
        /// </summary>
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

                MessageBox.Show("Cont creat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var formLogin = new FormLogin(_authService, _dataService, _tichetService);
                formLogin.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inchide formularul de inregistrare si revine la ecranul anterior.
        /// </summary>
        private void buttonInapoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}