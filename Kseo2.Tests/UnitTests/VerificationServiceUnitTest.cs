using System;
using System.Linq;
using Kseo2.DataAccess;
using Kseo2.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kseo2.Service;
using Moq;

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


        [TestMethod]
        public void mozna_pobrac_sprawdzenie_wg_id()
        {
            var mock = new Mock<VerificationRepository>();
            mock.Setup(m => m.GetSingle(v=>v.Id==5))
            .Returns(new Verification{ Id = 5 });
            IVerificationRepository verificationRepository = mock.Object;
            var verification = verificationRepository.GetSingle(x=>x.Id==5);
            Assert.IsTrue(verification.Id == 5);
            


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
            //given
            var vs = new VerificationService(_uow.Context());
            var v1 = CreateTestVerification();
            const string pesel = "73020916558";
            const string lastName = "KORPUSIK";
            v1.Pesel = pesel;
            v1.LastName = lastName;
            v1.FirstName = "JACEK";
            vs.AddVerification(v1);

            v1.Question.RegNumber = "222/14";
            v1.LastName = "NOWAK";
            vs.UpdateVerification(v1);
            
            var uow = new UnitOfWork();
            var vs1 = new VerificationService(uow.Context());
            //when
            var sr = vs1.Search("222/14","", "", "NOWAK");
            //then
            Assert.IsNotNull(sr);
            Assert.AreEqual(1, sr.ResultsCounter);
        }

        [TestMethod]
        public void mozna_dodac_kilka_sprawdzen_do_tego_samego_zapytania()
        {
            //given
            var vs = new VerificationService(_uow.Context());
            var v1 = CreateTestVerification();
            var q = v1.Question;
            q.RegNumber = "200/14";
            vs.AddVerification(v1);
            var v2 = CreateTestVerification();
            v2.Question = q;
            vs.AddVerification(v2);

            var uow = new UnitOfWork();
            var vs1 = new VerificationService(uow.Context());
            //when
            var sr = vs1.Search("200/14", "", "","");
            //then
            Assert.IsNotNull(sr);
            Assert.AreEqual(2, sr.ResultsCounter);
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
            var vs = new VerificationService(_uow.Context());
            var v = CreateTestVerification();
            var regNum = "220/14";
            v.Question.RegNumber = regNum;
            vs.AddVerification(v);
            var uow = new UnitOfWork();
            var vs1 = new VerificationService(uow.Context());
            //when
            var sr = vs1.Search(regNum, "", "", "");
            //then
            Assert.IsNotNull(sr);
            Assert.AreEqual(1,sr.ResultsCounter);
        }

        [TestMethod]
        public void mozna_wyszukac_sprawdzenia_po_danych_osobowych()
        {
            //given
            var vs = new VerificationService(_uow.Context());
            var v1 = CreateTestVerification();
            const string pesel = "73020916558";
            const string lastName = "KORPUSIK";
            v1.Pesel = pesel;
            v1.LastName = lastName;
            v1.FirstName = "JACEK";
            vs.AddVerification(v1);
            var v2 = CreateTestVerification();
            v2.Pesel = "73021022987";
            v2.LastName = "KORPUSIK";
            v2.FirstName = "ADAM";
            vs.AddVerification(v2);
            
            var uow = new UnitOfWork();
            var vs1 = new VerificationService(uow.Context());
            //when
            var sr = vs1.Search("", "7302", "", lastName);
            //then
            Assert.IsNotNull(sr);
            Assert.AreEqual(2, sr.ResultsCounter);
        }

        [TestMethod]
        public void mozna_pobrac_sprawdzenie_po_Id()
        {
            //given
            var vs = new VerificationService(_uow.Context());
            var v = CreateTestVerification();
            vs.AddVerification(v);
            var uow = new UnitOfWork();
            var vs1 = new VerificationService(uow.Context());
            //when
            var v1 = vs1.GetSingle(v.Id);
            //then
            Assert.IsNotNull(v1);
        }

        [TestMethod]
        public void mozna_dodac_narodowosc()
        {
            //given
            var vs = new VerificationService(_uow.Context());
            var v = CreateTestVerification();
            v.Nationality = _uow.Countries.FirstOrDefault();
            vs.AddVerification(v);
            var uow = new UnitOfWork();
            var vs1 = new VerificationService(uow.Context());
            //when
            var v1 = vs1.GetSingle(v.Id);
            //then
            Assert.IsNotNull(v1);
            Assert.IsNotNull(v1.Nationality);
        }
    }
}
