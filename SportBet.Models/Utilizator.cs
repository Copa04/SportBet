// Autor: Copacinschi David-Ioan
// Functionalitate: Clasa model pentru un utilizator al aplicatiei de pariuri sportive.
//                  Contine datele de autentificare si informatiile contului.

using System;
using System.Collections.Generic;

namespace SportBet.Models
{
    /// <summary>
    /// Reprezinta un utilizator inregistrat in sistemul de pariuri sportive.
    /// </summary>
    public class Utilizator
    {
        #region Proprietati

        /// <summary>Identificatorul unic al utilizatorului.</summary>
        public int Id { get; set; }

        /// <summary>Numele de utilizator (username) folosit la autentificare.</summary>
        public string Username { get; set; }

        /// <summary>Parola criptata a utilizatorului.</summary>
        public string Parola { get; set; }

        /// <summary>Adresa de email a utilizatorului.</summary>
        public string Email { get; set; }

        /// <summary>Prenumele utilizatorului.</summary>
        public string Prenume { get; set; }

        /// <summary>Numele de familie al utilizatorului.</summary>
        public string Nume { get; set; }

        /// <summary>Soldul curent al contului, in lei (RON).</summary>
        public decimal Sold { get; set; }

        /// <summary>Data la care contul a fost creat.</summary>
        public DateTime DataInregistrare { get; set; }

        /// <summary>Indica daca contul utilizatorului este activ.</summary>
        public bool EsteActiv { get; set; }

        /// <summary>Lista de tichete plasate de catre utilizator.</summary>
        public List<Tichet> Tichete { get; set; }

        #endregion

        #region Constructori

        /// <summary>
        /// Constructor implicit. Initializeaza lista de tichete si seteaza valorile implicite.
        /// </summary>
        public Utilizator()
        {
            Tichete = new List<Tichet>();
            DataInregistrare = DateTime.Now;
            EsteActiv = true;
            Sold = 0m;
        }

        /// <summary>
        /// Constructor cu parametri pentru initializarea completa a unui utilizator.
        /// </summary>
        /// <param name="id">Identificatorul unic.</param>
        /// <param name="username">Numele de utilizator.</param>
        /// <param name="parola">Parola.</param>
        /// <param name="email">Adresa de email.</param>
        /// <param name="prenume">Prenumele utilizatorului.</param>
        /// <param name="nume">Numele de familie.</param>
        /// <param name="sold">Soldul initial al contului.</param>
        public Utilizator(int id, string username, string parola,
                          string email, string prenume, string nume, decimal sold)
        {
            Id = id;
            Username = username;
            Parola = parola;
            Email = email;
            Prenume = prenume;
            Nume = nume;
            Sold = sold;
            DataInregistrare = DateTime.Now;
            EsteActiv = true;
            Tichete = new List<Tichet>();
        }

        #endregion

        #region Metode

        /// <summary>
        /// Returneaza numele complet al utilizatorului (prenume + nume).
        /// </summary>
        /// <returns>String-ul cu numele complet.</returns>
        public string GetNumeComplet()
        {
            return string.Format("{0} {1}", Prenume, Nume).Trim();
        }

        /// <summary>
        /// Verifica daca utilizatorul are suficiente fonduri pentru o suma data.
        /// </summary>
        /// <param name="suma">Suma de verificat.</param>
        /// <returns>True daca soldul acopera suma, altfel false.</returns>
        public bool AreSuficienteFonduri(decimal suma)
        {
            return EsteActiv && suma > 0 && Sold >= suma;
        }

        /// <summary>
        /// Adauga o suma la soldul utilizatorului (depunere).
        /// </summary>
        /// <param name="suma">Suma de adaugat.</param>
        public void Depune(decimal suma)
        {
            if (!EsteActiv)
                throw new InvalidOperationException("Contul utilizatorului nu este activ.");

            if (suma <= 0)
                throw new ArgumentException("Suma depusa trebuie sa fie mai mare decat 0.");

            Sold += suma;
        }

        /// <summary>
        /// Scade o suma din soldul utilizatorului (retragere / plasare pariu).
        /// </summary>
        /// <param name="suma">Suma de scazut.</param>
        public void Retrage(decimal suma)
        {
            if (!EsteActiv)
                throw new InvalidOperationException("Contul utilizatorului nu este activ.");

            if (suma <= 0)
                throw new ArgumentException("Suma retrasa trebuie sa fie mai mare decat 0.");

            if (!AreSuficienteFonduri(suma))
                throw new InvalidOperationException("Fonduri insuficiente.");

            Sold -= suma;
        }

        /// <summary>
        /// Returneaza o reprezentare text a obiectului Utilizator.
        /// </summary>
        /// <returns>String cu informatiile principale ale utilizatorului.</returns>
        public override string ToString()
        {
            return string.Format("#{0} | {1} ({2}) | Email: {3} | Sold: {4:0.00} RON | Activ: {5}",
                            Id, GetNumeComplet(), Username, Email, Sold, EsteActiv ? "Da" : "Nu");
        }

        #endregion
    }
}
