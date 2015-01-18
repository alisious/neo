using System;
using System.Linq;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kseo2.Tests.ViewModelTests
{
    [TestClass]
    public class VerificationViewModelTest
    {
        [TestMethod]
        public void mozna_wyswietlic_liste_organizacji()
        {
            //given
            var ctx = new TestKseoContext();
            //when
            var vm = new VerificationViewModel(ctx);
            //then
            Assert.IsNotNull(vm.QuestionViewModel);
            Assert.IsNotNull(vm.QuestionViewModel.AskerOrganizations);
            Assert.AreNotEqual(0, vm.QuestionViewModel.AskerOrganizations.Count);
        }

        [TestMethod]
        public void mozna_wyswietlic_liste_powodow_sprawdzenia()
        {
            //given
            var ctx = new TestKseoContext();
            //when
            var vm = new VerificationViewModel(ctx);
            //then
            Assert.IsNotNull(vm.QuestionReasons);
            Assert.AreNotEqual(0, vm.QuestionReasons.Count);
        }

        [TestMethod]
        public void mozna_wyswietlic_liste_jedostek_jezeli_instytucja_pytajaca_to_ZW()
        {
            //given
            var ctx = new TestKseoContext();
            var zw = ctx.Organizations.FirstOrDefault(o => o.Name.Equals("ŻANDARMERIA WOJSKOWA"));
            var vm = new VerificationViewModel(ctx);
            //when
            vm.QuestionViewModel.SelectedAskerOrganization = zw;

            //then
            Assert.IsNotNull(vm.QuestionViewModel.AskerOrganizationalUnits);
            Assert.AreNotEqual(0, vm.QuestionViewModel.AskerOrganizationalUnits.Count);
            Assert.AreEqual(true, vm.QuestionViewModel.IsEnabledAskerOrganizationalUnit);
        }

        [TestMethod]
        public void nie_mozna_wyswietlic_listy_jedostek_jezeli_nie_wybrano_instytucji_pytajacej()
        {
            //given
            var ctx = new TestKseoContext();
            var vm = new VerificationViewModel(ctx);
            //when
            vm.QuestionViewModel.SelectedAskerOrganization = null;

            //then
            Assert.IsNotNull(vm.QuestionViewModel.AskerOrganizationalUnits);
            Assert.AreEqual(0,vm.QuestionViewModel.AskerOrganizationalUnits.Count);
            Assert.AreEqual(false, vm.QuestionViewModel.IsEnabledAskerOrganizationalUnit);
        }

        [TestMethod]
        public void mozna_wyswietlic_liste_krajow()
        {
            //given
            var ctx = new TestKseoContext();
            //when
            var vm = new VerificationViewModel(ctx);
            //then
            Assert.IsNotNull(vm.Countries);
            Assert.AreNotEqual(0, vm.Countries.Count);
        }

        

        [TestMethod]
        public void nie_mozna_zapisac_sprawdzenia_bez_nazwiska_osoby_sprawdzanej()
        {
            //given
            var ctx = new TestKseoContext();
            var vm = new VerificationViewModel(ctx);
            
            //when
            vm.LastName = "";
           
            //then
            Assert.IsFalse(vm.CanSave);
            
        }

        [TestMethod]
        public void nie_mozna_zapisac_sprawdzenia_bez_imienia_osoby_sprawdzanej()
        {
            //given
            var ctx = new TestKseoContext();
            var vm = new VerificationViewModel(ctx);

            //when
            vm.LastName = "KORPUSIK";
            vm.FirstName = "";

            //then
            Assert.IsFalse(vm.CanSave);

        }

        [TestMethod]
        public void nie_mozna_zapisac_sprawdzenia_bez_podania_powodu_sprawdzenia_osoby()
        {
            //given
            var ctx = new TestKseoContext();
            var vm = new VerificationViewModel(ctx);

            //when
            vm.LastName = "KORPUSIK";
            vm.FirstName = "JACEK";
            vm.SelectedQuestionReason = null;

            //then
            Assert.IsFalse(vm.CanSave);

        }


        [TestMethod]
        public void mozna_zapisac_zmiany_sprawdzenia()
        {
            //given
            var ctx = new TestKseoContext();
            var u = ctx.Users.FirstOrDefault();
            var v = new Verification(u);
            //when
            ctx.Verifications.Add(v);
            ctx.SaveChanges();
            //then
            Assert.AreEqual(1, ctx.Verifications.Count());
            Assert.AreEqual(1, ctx.SaveChangesCount);
        }

        [TestMethod]
        public void mozna_zapisac_nowe_sprawdzenie()
        {
            //given
            var ctx = new TestKseoContext();
            var vm = new VerificationViewModel(ctx);
            vm.FirstName = "JACEK";
            vm.LastName = "KORPUSIK";
            vm.SelectedQuestionReason = ctx.QuestionReasons.FirstOrDefault();
            //when
            vm.Save();
            //then
            Assert.AreEqual(1, ctx.Verifications.Count());
            Assert.AreEqual(1, ctx.SaveChangesCount);
        }

        
    }
}
