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
        
        private readonly UnitOfWork _uow = new UnitOfWork();

        [TestInitialize]
        public void Initialize()
        {
            
        }


        private Verification CreateTestVerification()
        {
            var org = _uow.Organizations.FirstOrDefault();
            var qf = _uow.QuestionForms.FirstOrDefault();
            var qr = _uow.QuestionReasons.FirstOrDefault();
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
            var v = new Verification(_uow.ActiveUser, q) { Answer = "", QuestionReason = qr };
            return v;
        }


        [TestMethod]
        public void mozna_dodac_nowe_sprawdzenie()
        {
            //given
            var vs = new VerificationService(_uow.Context());
            var v = CreateTestVerification();
            //when
            vs.AddVerification(v);

            var uow = new UnitOfWork();
            var vs1 = new VerificationService(uow.Context());
            var v1 = vs1.GetSingle(v.Id);

            
            //then
            Assert.IsNotNull(v1);
            Assert.IsNotNull(v1.Question);
            Assert.AreEqual("KORPUSIK",v1.Question.Asker);
            
        }

        [TestMethod]
        public void mozna_zapisac_zmiany_sprawdzenia()
        {

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
            var vs = new VerificationService(_uow.Context());
            var v = CreateTestVerification();
            vs.AddVerification(v);


            var uow = new UnitOfWork();
            var vs1 = new VerificationService(uow.Context());
            var v1 = vs1.GetSingle(v.Id);
            var i = v1.Id;
            vs1.RemoveVerification(v1);

            v = vs.GetSingle(i);

            //then
            Assert.IsNull(v);
            

           
        }

        [TestMethod]
        public void mozna_usunac_zapytanie()
        {
            //given
            var vs = new VerificationService(_uow.Context());
            var v = CreateTestVerification();
            vs.AddVerification(v);
            
            var uow = new UnitOfWork();
            var vs1 = new VerificationService(uow.Context());
            var v1 = vs1.GetSingle(v.Id);
            var q = v1.Question;
            var i = v1.Id;
            vs1.RemoveVerification(v1);

            v = vs.GetSingle(i);

            //then
            Assert.IsNull(v);



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
