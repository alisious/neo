using System;
using System.Linq;
using Kseo2.DataAccess;
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
            Assert.IsNotNull(vm.QuestionViewModel.Organizations);
            Assert.AreNotEqual(0, vm.QuestionViewModel.Organizations.Count);
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
            vm.QuestionViewModel.AskerOrganization = zw;

            //then
            Assert.IsNotNull(vm.QuestionViewModel.OrganizationalUnits);
            Assert.AreNotEqual(0, vm.QuestionViewModel.OrganizationalUnits.Count);
            Assert.AreEqual(true, vm.QuestionViewModel.IsEnabledAskerOrganizationalUnit);
        }

        [TestMethod]
        public void nie_mozna_wyswietlic_listy_jedostek_jezeli_nie_wybrano_instytucji_pytajacej()
        {
            //given
            var ctx = new TestKseoContext();
            var vm = new VerificationViewModel(ctx);
            //when
            vm.QuestionViewModel.AskerOrganization = null;

            //then
            Assert.IsNotNull(vm.QuestionViewModel.OrganizationalUnits);
            Assert.AreEqual(0,vm.QuestionViewModel.OrganizationalUnits.Count);
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
        public void mozna_zapisac_nowe_sprawdzenie()
        {
            //given
            //when
            //then
            throw new NotImplementedException();
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
        public void mozna_wyszukac_osobe()
        {
            //given
            //when
            //then
            throw new NotImplementedException();
        }
    }
}
