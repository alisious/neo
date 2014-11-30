using System;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kseo2.Tests.UnitTests
{
    [TestClass]
    public class UserServiceUnitTest
    {
        [TestMethod]
        public void mozna_dodac_nowego_uzytkownika()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_zmienic_dane_uzytkownika()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void login_musi_byc_unikalny_przy_dodawaniu()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void nie_mozna_zmienic_loginu_uzytkownika_na_juz_istniejacy()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void nie_mozna_usunac_uzytkownika_ktory_dzialal_w_systemie()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_usunac_uzytkownika_ktory_nie_dzialal_w_systemie()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_policzyc_ile_osob_sprawdzil_uzytkownik_w_danym_dniu()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_policzyc_ile_zapytan_zarejestrowal_uzytkownik_w_danym_dniu()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_pobrac_liste_wszystkich_uzytkownikow()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_pobrac_uzytkownika_po_id()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_pobrac_uzytkownika_po_loginie()
        {
            
            //given
            var login = "Jacek";
            var ctx = new KseoContext();
            ctx.Users.Add(new User() {Login = login, Name = "Jacek Korpusik"});
            ctx.SaveChanges();
            var us = new UserService(ctx);
            
            //when
            var au = us.GetSingle(login);
            //then
            Assert.IsNotNull(au);
            Assert.AreEqual(login,au.Login);
            
        }

        [TestMethod]
        public void nie_mozna_pobrac_uzytkownika_ktory_loguje_sie_1_raz()
        {
            //given
            var ctx = new KseoContext();
            var us = new UserService(ctx);
            var login = "NowyLogin";
            //when
            var au = us.GetSingle(login);
            //then
            Assert.IsNull(au);
        }
    }
}
