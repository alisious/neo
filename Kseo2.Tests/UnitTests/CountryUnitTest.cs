using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kseo2.Model;
using Kseo2.DataAccess;

namespace Kseo2.Tests.UnitTests
{
    [TestClass]
    public class CountryUnitTest
    {
        [TestMethod]
        public void mozna_dodac_nowy_element_do_slownika()
        {
            //given
            var ctx = new KseoContext();
            var c = new Country() { Name = "KONGO", LongName = "" };
            ctx.Countries.Add(c);
            ctx.SaveChanges();

            //when
            var c1 = ctx.Countries.Find(c.Id);
            //then
            Assert.IsNotNull(c1);
        }
    }
}
