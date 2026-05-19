// Autor: Maxim Cezar-Andrei
// Functionalitate: Teste unitare pentru clasele din SportBet.
//                  Acopera modelele Utilizator, Meci, Tichet, Pariu
//                  si repository-ul MeciRepository.


using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportBet.Models;
using SportBet.Repositories;

namespace SportBet.Tests
{
    #region Teste Utilizator

    /// <summary>
    /// Teste unitare pentru clasa Utilizator.
    /// </summary>
    [TestClass]
    public class SportBetTests
    {
        /// <summary>
        /// Depunerea unei sume valide trebuie sa creasca soldul cu suma respectiva.
        /// </summary>
        [TestMethod]
        public void Depune_SumaValida_CresteSoldul()
        {
            Utilizator u = new Utilizator();
            u.Sold = 100m;

            u.Depune(50m);

            Assert.AreEqual(150m, u.Sold);
        }

        /// <summary>
        /// Depunerea unei sume negative trebuie sa arunce ArgumentException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Depune_SumaNegativa()
        {
            Utilizator u = new Utilizator();
            u.Sold = 100m;

            u.Depune(-50m);
        }

        /// <summary>
        /// Retragerea unei sume valide trebuie sa scada soldul cu suma respectiva.
        /// </summary>
        [TestMethod]
        public void Retrage_SumaValida_ScadeSoldul()
        {
            Utilizator u = new Utilizator();
            u.Sold = 100m;

            u.Retrage(40m);

            Assert.AreEqual(60m, u.Sold);
        }

        /// <summary>
        /// Retragerea unei sume mai mari decat soldul trebuie sa arunce InvalidOperationException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Retrage_FonduriInsuficiente()
        {
            Utilizator u = new Utilizator();
            u.Sold = 50m;

            u.Retrage(100m);
        }

        /// <summary>
        /// AreSuficienteFonduri trebuie sa returneze true cand soldul acopera suma.
        /// </summary>
        [TestMethod]
        public void AreSuficienteFonduri_SoldSuficient()
        {
            Utilizator u = new Utilizator();
            u.Sold = 200m;

            bool rezultat = u.AreSuficienteFonduri(100m);

            Assert.IsTrue(rezultat);
        }

        /// <summary>
        /// AreSuficienteFonduri trebuie sa returneze false cand soldul nu acopera suma.
        /// </summary>
        [TestMethod]
        public void AreSuficienteFonduri_SoldInsuficient()
        {
            Utilizator u = new Utilizator();
            u.Sold = 50m;

            bool rezultat = u.AreSuficienteFonduri(100m);

            Assert.IsFalse(rezultat);
        }

        /// <summary>
        /// GetNumeComplet trebuie sa returneze prenumele si numele concatenate.
        /// </summary>
        [TestMethod]
        public void GetNumeComplet_PreNumeSiNume()
        {
            Utilizator u = new Utilizator();
            u.Prenume = "Ion";
            u.Nume = "Popescu";

            string rezultat = u.GetNumeComplet();

            Assert.AreEqual("Ion Popescu", rezultat);
        }
    }

    #endregion

    #region Teste Meci

    /// <summary>
    /// Teste unitare pentru clasa Meci.
    /// </summary>
    [TestClass]
    public class MeciTests
    {
        /// <summary>
        /// GetCotaForTip cu "1" trebuie sa returneze CotaGazda.
        /// </summary>
        [TestMethod]
        public void GetCotaForTip_Selectie1()
        {
            Meci m = new Meci();
            m.CotaGazda = 1.75;

            double rezultat = m.GetCotaForTip("1");

            Assert.AreEqual(1.75, rezultat);
        }

        /// <summary>
        /// GetCotaForTip cu "X" trebuie sa returneze CotaEgalitate.
        /// </summary>
        [TestMethod]
        public void GetCotaForTip_SelectieX()
        {
            Meci m = new Meci();
            m.CotaEgalitate = 3.20;

            double rezultat = m.GetCotaForTip("X");

            Assert.AreEqual(3.20, rezultat);
        }

        /// <summary>
        /// GetCotaForTip cu "2" trebuie sa returneze CotaOaspete.
        /// </summary>
        [TestMethod]
        public void GetCotaForTip_Selectie2()
        {
            Meci m = new Meci();
            m.CotaOaspete = 4.50;

            double rezultat = m.GetCotaForTip("2");

            Assert.AreEqual(4.50, rezultat);
        }

        /// <summary>
        /// GetCotaForTip cu string gol trebuie sa returneze 0.
        /// </summary>
        [TestMethod]
        public void GetCotaForTip_SelectieGoala()
        {
            Meci m = new Meci();

            double rezultat = m.GetCotaForTip("");

            Assert.AreEqual(0, rezultat);
        }

        /// <summary>
        /// EsteDisponibilPariere trebuie sa returneze true pentru meciuri programate.
        /// </summary>
        [TestMethod]
        public void EsteDisponibilPariere_MeciProgramat()
        {
            Meci m = new Meci();
            m.Status = StatusMeci.Programat;
            m.DataOra = DateTime.Now.AddDays(1);

            bool rezultat = m.EsteDisponibilPariere();

            Assert.IsTrue(rezultat);
        }

        /// <summary>
        /// EsteDisponibilPariere trebuie sa returneze false pentru meciuri finalizate.
        /// </summary>
        [TestMethod]
        public void EsteDisponibilPariere_MeciFinalizat()
        {
            Meci m = new Meci();
            m.Status = StatusMeci.Finalizat;
            m.DataOra = DateTime.Now.AddDays(-1);

            bool rezultat = m.EsteDisponibilPariere();

            Assert.IsFalse(rezultat);
        }
    }

    #endregion

    #region Teste Tichet

    /// <summary>
    /// Teste unitare pentru clasa Tichet.
    /// </summary>
    [TestClass]
    public class TichetTests
    {
        /// <summary>
        /// AdaugaPariu trebuie sa creasca numarul de pariuri din tichet.
        /// </summary>
        [TestMethod]
        public void AdaugaPariu_PariuValid_CresteNrPariuri()
        {
            Tichet t = new Tichet();
            Pariu p = new Pariu();

            t.AdaugaPariu(p);

            Assert.AreEqual(1, t.GetNrPariuri());
        }

        /// <summary>
        /// AdaugaPariu cu null trebuie sa arunce ArgumentNullException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AdaugaPariu_PariuNull()
        {
            Tichet t = new Tichet();

            t.AdaugaPariu(null);
        }

        /// <summary>
        /// RecalculeazaCotaTotala trebuie sa calculeze produsul cotelor.
        /// </summary>
        [TestMethod]
        public void RecalculeazaCotaTotala_DouaPariuri()
        {
            Tichet t = new Tichet();
            t.AdaugaPariu(new Pariu { Cota = 2.0 });
            t.AdaugaPariu(new Pariu { Cota = 3.0 });

            t.RecalculeazaCotaTotala();

            Assert.AreEqual(6.0, t.CotaTotala, 0.001);
        }

        /// <summary>
        /// CalculeazaCastigPotential trebuie sa returneze miza inmultita cu cota totala.
        /// </summary>
        [TestMethod]
        public void CalculeazaCastigPotential_MizaSiCota()
        {
            Tichet t = new Tichet(0, 1, 100m);
            t.AdaugaPariu(new Pariu { Cota = 2.0 });

            decimal castig = t.CalculeazaCastigPotential();

            Assert.AreEqual(200m, castig);
        }

        /// <summary>
        /// GetNrPariuri trebuie sa returneze numarul corect de pariuri.
        /// </summary>
        [TestMethod]
        public void GetNrPariuri_TreiPariuri()
        {
            Tichet t = new Tichet();
            t.AdaugaPariu(new Pariu { Cota = 1.5 });
            t.AdaugaPariu(new Pariu { Cota = 2.0 });
            t.AdaugaPariu(new Pariu { Cota = 3.0 });

            Assert.AreEqual(3, t.GetNrPariuri());
        }

        /// <summary>
        /// EsteGataDeDecontare trebuie sa returneze false daca meciurile nu sunt finalizate.
        /// </summary>
        [TestMethod]
        public void EsteGataDeDecontare_MeciuriNefinalizate()
        {
            Meci meci = new Meci();
            meci.Status = StatusMeci.Programat;

            Tichet t = new Tichet();
            t.AdaugaPariu(new Pariu { MeciAsociat = meci });

            bool rezultat = t.EsteGataDeDecontare();

            Assert.IsFalse(rezultat);
        }
    }

    #endregion

    #region Teste Pariu

    /// <summary>
    /// Teste unitare pentru clasa Pariu.
    /// </summary>
    [TestClass]
    public class PariuTests
    {
        /// <summary>
        /// GetDescriereSelectie cu "1" trebuie sa returneze "Victorie gazda".
        /// </summary>
        [TestMethod]
        public void GetDescriereSelectie_Selectie1()
        {
            Pariu p = new Pariu();
            p.TipSelectie = "1";

            string rezultat = p.GetDescriereSelectie();

            Assert.AreEqual("Victorie gazda", rezultat);
        }

        /// <summary>
        /// GetDescriereSelectie cu "X" trebuie sa returneze "Egal".
        /// </summary>
        [TestMethod]
        public void GetDescriereSelectie_SelectieX()
        {
            Pariu p = new Pariu();
            p.TipSelectie = "X";

            string rezultat = p.GetDescriereSelectie();

            Assert.AreEqual("Egal", rezultat);
        }

        /// <summary>
        /// GetDescriereSelectie cu "2" trebuie sa returneze "Victorie oaspete".
        /// </summary>
        [TestMethod]
        public void GetDescriereSelectie_Selectie2()
        {
            Pariu p = new Pariu();
            p.TipSelectie = "2";

            string rezultat = p.GetDescriereSelectie();

            Assert.AreEqual("Victorie oaspete", rezultat);
        }

        /// <summary>
        /// GetDescriereSelectie cu selectie invalida trebuie sa returneze "Selectie necunoscuta".
        /// </summary>
        [TestMethod]
        public void GetDescriereSelectie_SelectieInvalida()
        {
            Pariu p = new Pariu();
            p.TipSelectie = "3";

            string rezultat = p.GetDescriereSelectie();

            Assert.AreEqual("Selectie necunoscuta", rezultat);
        }
    }

    #endregion

    #region Teste UtilizatorRepository

    /// <summary>
    /// Teste unitare pentru clasa UtilizatorRepository.
    /// </summary>
    [TestClass]
    public class UtilizatorRepositoryTests
    {
        /// <summary>
        /// Add trebuie sa adauge utilizatorul in repository.
        /// </summary>
        [TestMethod]
        public void Add_UtilizatorValid()
        {
            UtilizatorRepository repo = new UtilizatorRepository();
            Utilizator u = new Utilizator { Id = 1, Username = "ionpop", Email = "ion@test.ro" };

            bool rezultat = repo.Add(u);

            Assert.IsTrue(rezultat);
            Assert.AreEqual(1, repo.GetAll().Count);
        }

        /// <summary>
        /// Add cu username duplicat trebuie sa returneze false.
        /// </summary>
        [TestMethod]
        public void Add_UsernameDuplicat()
        {
            UtilizatorRepository repo = new UtilizatorRepository();
            repo.Add(new Utilizator { Id = 1, Username = "ionpop", Email = "ion@test.ro" });

            bool rezultat = repo.Add(new Utilizator { Id = 2, Username = "ionpop", Email = "alt@test.ro" });

            Assert.IsFalse(rezultat);
        }

        /// <summary>
        /// GetById trebuie sa returneze utilizatorul cu ID-ul specificat.
        /// </summary>
        [TestMethod]
        public void GetById_IdExistent()
        {
            UtilizatorRepository repo = new UtilizatorRepository();
            repo.Add(new Utilizator { Id = 1, Username = "ionpop", Email = "ion@test.ro" });

            Utilizator rezultat = repo.GetById(1);

            Assert.IsNotNull(rezultat);
            Assert.AreEqual("ionpop", rezultat.Username);
        }

        /// <summary>
        /// GetById cu ID inexistent trebuie sa returneze null.
        /// </summary>
        [TestMethod]
        public void GetById_IdInexistent_ReturneazaNull()
        {
            UtilizatorRepository repo = new UtilizatorRepository();

            Utilizator rezultat = repo.GetById(999);

            Assert.IsNull(rezultat);
        }

        /// <summary>
        /// GetByUsername trebuie sa returneze utilizatorul cu username-ul specificat.
        /// </summary>
        [TestMethod]
        public void GetByUsername_UsernameExistent()
        {
            UtilizatorRepository repo = new UtilizatorRepository();
            repo.Add(new Utilizator { Id = 1, Username = "ionpop", Email = "ion@test.ro" });

            Utilizator rezultat = repo.GetByUsername("ionpop");

            Assert.IsNotNull(rezultat);
            Assert.AreEqual(1, rezultat.Id);
        }

        /// <summary>
        /// GetByUsername cu username inexistent trebuie sa returneze null.
        /// </summary>
        [TestMethod]
        public void GetByUsername_UsernameInexistent()
        {
            UtilizatorRepository repo = new UtilizatorRepository();

            Utilizator rezultat = repo.GetByUsername("inexistent");

            Assert.IsNull(rezultat);
        }

        /// <summary>
        /// ActualizeazaSold trebuie sa actualizeze soldul utilizatorului.
        /// </summary>
        [TestMethod]
        public void ActualizeazaSold_IdExistent()
        {
            UtilizatorRepository repo = new UtilizatorRepository();
            repo.Add(new Utilizator { Id = 1, Username = "ionpop", Email = "ion@test.ro", Sold = 100m });

            bool rezultat = repo.ActualizeazaSold(1, 250m);

            Assert.IsTrue(rezultat);
            Assert.AreEqual(250m, repo.GetById(1).Sold);
        }

        /// <summary>
        /// ActualizeazaSold cu ID inexistent trebuie sa returneze false.
        /// </summary>
        [TestMethod]
        public void ActualizeazaSold_IdInexistent()
        {
            UtilizatorRepository repo = new UtilizatorRepository();

            bool rezultat = repo.ActualizeazaSold(999, 100m);

            Assert.IsFalse(rezultat);
        }

        /// <summary>
        /// GetAll trebuie sa returneze toti utilizatorii din repository.
        /// </summary>
        [TestMethod]
        public void GetAll_TreiUtilizatori_ReturneazaTrei()
        {
            UtilizatorRepository repo = new UtilizatorRepository();
            repo.Add(new Utilizator { Id = 1, Username = "user1", Email = "u1@test.ro" });
            repo.Add(new Utilizator { Id = 2, Username = "user2", Email = "u2@test.ro" });
            repo.Add(new Utilizator { Id = 3, Username = "user3", Email = "u3@test.ro" });

            List<Utilizator> rezultat = repo.GetAll();

            Assert.AreEqual(3, rezultat.Count);
        }
    }

    #endregion


}
