using SportBet.Repositories;
using SportBet.Services;
using SportBet.UI;
using System;
using System.Windows.Forms;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var dataService = new DataService();
        dataService.Initializeaza();
        var authService = new AuthService(dataService.UtilizatorRepository);

        var tichetService = new TichetService(dataService.TichetRepository, dataService.MeciRepository, dataService.UtilizatorRepository);

        Application.Run(new FormLogin(authService, dataService, tichetService));
    }
}
