using System;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kseo2.Tests.ViewModelTests
{
    [TestClass]
    public class QuestionViewModelUnitTest
    {
        [TestMethod]
        public void nie_mozna_zapisac_bez_instytucji_pytajacej()
        {
            //given
            var vm = new QuestionViewModel(new TestKseoContext(), new Question());
            //when
            vm.SelectedAskerOrganization = null;
            vm.CurrentQuestion.RegDate = new DateTime();
            
            //then
            Assert.IsFalse(vm.CanSave);
        }

        [TestMethod]
        public void nie_mozna_zapisac_bez_formy_zapytania()
        {
            //given

            //when

            //then
            throw new NotImplementedException();
        }

        [TestMethod]
        public void nie_mozna_zapisac_bez_daty_zapytania()
        {
            //given
            
            //when
            
            //then
            throw new NotImplementedException();
        }
    }
}
