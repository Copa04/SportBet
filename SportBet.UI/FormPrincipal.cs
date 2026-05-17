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
        private readonly Utilizator _utilizatorCurent;
        private readonly DataService _dataService;

        public FormPrincipal(Utilizator utilizator, DataService dataService)
        {
            InitializeComponent();
            _utilizatorCurent = utilizator;
            _dataService = dataService;
        }

        private void toolStripButtonIesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
