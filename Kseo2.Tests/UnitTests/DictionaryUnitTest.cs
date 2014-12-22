using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kseo2.Model;
using Kseo2.DataAccess;
using Kseo2.BusinessLayer;

namespace Kseo2.Tests.PersonServiceUnitTest
{
    [TestClass]
    public class DictionaryUnitTest
    {
        [TestMethod]
        public void mozna_zaladowac_slownik_wg_typu()
        {
            //given
            var bl = new Kseo2.BusinessLayer.BusinessLayer();
            
            //when
            bl.ReloadDictionary(typeof(Country));
            //then
            Assert.IsNotNull(bl.DictionaryCountries);
            Assert.IsTrue(bl.DictionaryCountries.Count>0);
        }
    }
}
