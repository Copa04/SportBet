// Autor: Echipa SportBet
// Functionalitate: Serviciu pentru autentificarea si gestionarea sesiunii utilizatorului.
//                  Implementeaza pattern-ul Singleton pentru sesiunea activa.

using System;
using System.Text.RegularExpressions;
using SportBet.Models;
using SportBet.Repositories;

namespace SportBet.Services
{
    /// <summary>
    /// Serviciu care gestioneaza autentificarea, inregistrarea si sesiunea utilizatorului curent.
    /// Utilizeaza Singleton Pattern pentru a mentine o singura sesiune activa.
    /// </summary>
    public class AuthService
    {
        #region Singleton

        private static AuthService _instanta;
        private static readonly object _lock = new object();

        /// <summary>
        /// Returneaza instanta unica a serviciului de autentificare (Singleton).
        /// </summary>
        public static AuthService Instanta
        {
            get
            {
                lock (_lock)
                {
                    if (_instanta == null)
                        _instanta = new AuthService();
                    return _instanta;
                }
            }
        }

        #endregion

        #region Proprietati

        /// <summary>Utilizatorul autentificat in sesiunea curenta. Null daca nu e logat nimeni.</summary>
        public Utilizator UtilizatorCurent { get; private set; }

        /// <summary>Indica daca exista un utilizator autentificat in sesiunea curenta.</summary>
        public bool EsteAutentificat => UtilizatorCurent != null;

        private IUtilizatorRepository _utilizatorRepo;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor privat (impus de Singleton).
        /// </summary>
        private AuthService()
        {
            _utilizatorRepo = null;
        }

        #endregion

        #region Metode publice

        /// <summary>
        /// Initializeaza serviciul cu repository-ul necesar.
        /// Trebuie apelat o singura data, la pornirea aplicatiei.
        /// </summary>
        /// <param name="utilizatorRepository">Implementarea repository-ului de utilizatori.</param>
        public void Initialize(IUtilizatorRepository utilizatorRepository)
        {
            if (utilizatorRepository == null)
                throw new ArgumentNullException("utilizatorRepository");

            _utilizatorRepo = utilizatorRepository;
        }

        /// <summary>
        /// Autentifica un utilizator pe baza username-ului si parolei.
        /// Seteaza UtilizatorCurent daca autentificarea reuseste.
        /// </summary>
        /// <param name="username">Username-ul introdus.</param>
        /// <param name="parola">Parola in text clar.</param>
        /// <returns>True daca autentificarea a reusit, altfel false.</returns>
        public bool Autentifica(string username, string parola)
        {
            if (_utilizatorRepo == null)
                throw new InvalidOperationException("AuthService nu a fost initializat.");

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(parola))
                return false;

            Utilizator utilizator = _utilizatorRepo.GetByUsername(username);

            if (utilizator == null)
                return false;

            if (!utilizator.EsteActiv)
                return false;

            if (utilizator.ParolaCriptata != parola)
                return false;

            UtilizatorCurent = utilizator;
            return true;
        }

        /// <summary>
        /// Inregistreaza un utilizator nou in sistem.
        /// </summary>
        /// <param name="username">Username-ul ales.</param>
        /// <param name="parola">Parola in text clar.</param>
        /// <param name="email">Adresa de email.</param>
        /// <param name="prenume">Prenumele utilizatorului.</param>
        /// <param name="nume">Numele de familie.</param>
        /// <returns>True daca inregistrarea a reusit, altfel false.</returns>
        public bool Inregistreaza(string username, string parola,
                                   string email, string prenume, string nume)
        {
            if (_utilizatorRepo == null)
                throw new InvalidOperationException("AuthService nu a fost initializat.");

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(parola))
                return false;

            if (string.IsNullOrWhiteSpace(prenume) || string.IsNullOrWhiteSpace(nume))
                return false;

            if (!ValidareEmail(email))
                return false;

            if (parola.Length < 6)
                return false;

            if (_utilizatorRepo.UsernameExista(username))
                return false;

            if (_utilizatorRepo.EmailExista(email))
                return false;

            Utilizator utilizatorNou = new Utilizator(0, username, parola, email, prenume, nume, 0m);

            return _utilizatorRepo.Add(utilizatorNou);
        }

        /// <summary>
        /// Deconecteaza utilizatorul curent si reseteaza sesiunea.
        /// </summary>
        public void Deconecteaza()
        {
            UtilizatorCurent = null;
        }

        /// <summary>
        /// Schimba parola utilizatorului autentificat.
        /// </summary>
        /// <param name="parolaVeche">Parola actuala.</param>
        /// <param name="parolaNoua">Noua parola.</param>
        /// <returns>True daca schimbarea a reusit, altfel false.</returns>
        public bool SchimbaParola(string parolaVeche, string parolaNoua)
        {
            if (!EsteAutentificat)
                return false;

            if (string.IsNullOrWhiteSpace(parolaVeche) || string.IsNullOrWhiteSpace(parolaNoua))
                return false;

            if (UtilizatorCurent.ParolaCriptata != parolaVeche)
                return false;

            if (parolaNoua.Length < 6)
                return false;

            UtilizatorCurent.ParolaCriptata = parolaNoua;
            return _utilizatorRepo.Update(UtilizatorCurent);
        }

        /// <summary>
        /// Actualizeaza informatiile de profil ale utilizatorului curent.
        /// </summary>
        /// <param name="email">Noul email.</param>
        /// <param name="prenume">Noul prenume.</param>
        /// <param name="nume">Noul nume de familie.</param>
        /// <returns>True daca actualizarea a reusit, altfel false.</returns>
        public bool ActualizeazaProfil(string email, string prenume, string nume)
        {
            if (!EsteAutentificat)
                return false;

            if (!ValidareEmail(email))
                return false;

            if (string.IsNullOrWhiteSpace(prenume) || string.IsNullOrWhiteSpace(nume))
                return false;

            // Daca emailul s-a schimbat, verificam sa nu fie folosit de altcineva
            if (!string.Equals(email, UtilizatorCurent.Email, StringComparison.OrdinalIgnoreCase))
            {
                if (_utilizatorRepo.EmailExista(email))
                    return false;
            }

            UtilizatorCurent.Email = email;
            UtilizatorCurent.Prenume = prenume;
            UtilizatorCurent.Nume = nume;

            return _utilizatorRepo.Update(UtilizatorCurent);
        }

        #endregion

        #region Metode private helper

        /// <summary>
        /// Valideaza formatul unui email folosind o expresie regulata simpla.
        /// </summary>
        /// <param name="email">Email-ul de validat.</param>
        /// <returns>True daca formatul este valid, altfel false.</returns>
        private bool ValidareEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        #endregion
    }
}