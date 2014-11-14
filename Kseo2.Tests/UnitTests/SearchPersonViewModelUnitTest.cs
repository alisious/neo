using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kseo2.ViewModels;
using Kseo2.Service;
using Kseo2.DataAccess;

namespace Kseo2.Tests
{
    [TestClass]
    public class SearchPersonViewModelUnitTest
    {
        [TestMethod]
        public void Can_Not_Get_Persons_Over_Limit()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Can_Count_Search_Persons_Results()
        {
            //given
            KseoContext ctx = new KseoContext();
            PersonService ps = new PersonService(ctx);
            PersonSearchViewModel vm = new PersonSearchViewModel(ps);
            vm.Pesel = "000";
            
            //when
            
            
            //then
            Assert.AreEqual(5, vm.CounterResults);

        }

        [TestMethod]
        public void Can_Setup_SelectedResult_When_One_Person_Found()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Can_Not_Search_When_Pesel_Length_Under_Limit()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Can_Not_Search_When_LastName_Length_Under_Limit()
        {
            throw new NotImplementedException();
        }
    }
}
