using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kseo2.DataAccess;
using Kseo2.Model;

namespace Kseo2.Tests.UnitTests
{
   
    
    [TestClass]
    public class PersonRepositoryUnitTest
    {

        private KseoContext _ctx;

        [TestInitialize]
        public void TestInitialize()
        {
            _ctx = new KseoContext();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _ctx.Dispose();
        }

        [TestMethod]
        public void PersonRepository_can_select_all()
        {
            //given
            var pr = new PersonRepository(_ctx);    
            //when
            var l = pr.GetAll();
            //then
            Assert.IsNotNull(l);
            Assert.IsTrue(l.Count > 0);
        }
    }
}
