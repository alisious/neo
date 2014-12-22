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
            bl.LoadDictionary<Country>();
            bl.LoadDictionary<Organization>();
            //then
            Assert.IsNotNull(bl.GetDictionary<Country>());
            Assert.IsTrue(bl.GetDictionary<Country>().Count > 0);
            Assert.IsNotNull(bl.GetDictionary<Organization>());
            Assert.IsTrue(bl.GetDictionary<Organization>().Count > 0);
        }

        [TestMethod]
        public void mozna_pobrac_element_slownika_po_nazwie()
        {
            //given
            var bl = new Kseo2.BusinessLayer.BusinessLayer();
            

            //when
            var c = bl.GetDictionaryItemByName<Country>("POLSKA");
            //then
            Assert.IsNotNull(c);
            Assert.AreEqual(c.Name,"POLSKA");
        }

        [TestMethod]
        public void mozna_zaladowac_jednostki_organizacyjne()
        {
            //given
            var bl = new Kseo2.BusinessLayer.BusinessLayer();
            var o = bl.GetDictionaryItemByName<Organization>("ŻANDARMERIA WOJSKOWA");

            //when
            var list = bl.GetOrganizationalUnits(o, true);
            //then
            Assert.IsNotNull(o);
            Assert.IsTrue(o.Name == "ŻANDARMERIA WOJSKOWA");
            Assert.IsTrue(list.Count>0);
            
        }
    }
}
