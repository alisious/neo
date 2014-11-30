using System;
using System.Linq;
using Kseo2.DataAccess;
using Kseo2.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kseo2.Service;

namespace Kseo2.Tests.UnitTests
{
    [TestClass]
    public class VerificationServiceUnitTest
    {
        [TestMethod]
        public void mozna_dodac_nowe_sprawdzenie()
        {
            //given
            var uow = new UnitOfWork();
            var org = uow.Organizations.FirstOrDefault();
            var qf = uow.QuestionForms.FirstOrDefault();
            var qr = uow.QuestionReasons.FirstOrDefault();
            var q = new Question()
            {
                Asker = "KORPUSIK",
                AskerOrganization = org,
                AskerOrganizationalUnit = null,
                AskerRank = null,
                Classification = "Z",
                QuestionForm = qf,
                RegDate = DateTime.Today,
                RegNumber = "1",
                Signer = "KORPUSIK",
                SignerPosition = "SZEF WYDZIAŁU"
            };
            var vs = new VerificationService(uow.Context());
            var v = new Verification(uow.ActiveUser, q) {Answer = "", QuestionReason = qr};
            //when
            vs.AddVerification(v);
            uow.SaveChanges();
            var v1 = uow.Context().Verifications.Find(v.Id);
            //then
            Assert.IsNotNull(v1);
            
        }

        [TestMethod]
        public void mozna_zapisac_zmiany_sprawdzenia()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_dodac_kilka_sprawdzen_do_tego_samego_zapytania()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_usunac_sprawdzenie()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_wyszukac_sprawdzenia_po_numerze_zapytania()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_wyszukac_sprawdzenia_po_danych_osobowych()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }

        [TestMethod]
        public void mozna_pobrac_sprawdzenie_po_Id()
        {
            //given

            //when

            //then

            throw new NotImplementedException();
        }
    }
}
