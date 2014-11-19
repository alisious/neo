using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kseo2.ViewModels;
using Kseo2.Service;
using Kseo2.DataAccess;

namespace Kseo2.Tests.UnitTests
{
    [TestClass]
    public class SearchPersonViewModelUnitTest
    {
        [TestMethod]
        public void Not_Show_Results_Over_Limit()
        {
            //given


            //when


            //then
        }

        [TestMethod]
        public void Show_Results_In_Limit()
        {
            //given
           
            
            //when
            
            
            //then
            throw new NotImplementedException();

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
