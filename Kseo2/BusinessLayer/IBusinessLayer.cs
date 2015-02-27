using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.Model;

namespace Kseo2.BusinessLayer
{
    public interface IBusinessLayer
    {


        #region Dictionary routines

        void LoadDictionary<T>() where T : DictionaryItem<T>;
        IList<T> GetDictionary<T>() where T : DictionaryItem<T>;
        T GetDictionaryItemByName<T>(string name) where T : DictionaryItem<T>;
        IList<T> GetDictionaryItems<T>(bool activeOnly = true,T group = null) where T : DictionaryItem<T>;
        IList<T> GetAllDictionaryItems<T>(bool activeOnly = true) where T : DictionaryItem<T>; 
           
        #endregion

        #region OrganizationalUnit routines
        
        IList<OrganizationalUnit> GetOrganizationalUnits(Organization organization, bool activeOnly = true);
        OrganizationalUnit GetSingle(int id);
        
        #endregion

        #region Person routines

        IList<Person> GetAllPersons();
        
        Person GetPersonByPesel(string pesel);
        void AddPerson(params Person[] persons);
        void UpdatePerson(params Person[] persons);
        void RemovePerson(params Person[] persons); 
        
        #endregion
        
        #region Verification routines

        
        Verification GetVerificationById(int id);
        void AddVerification(params Verification[] verifications);
        void UpdateVerification(params Verification[] verifications);
        void RemoveVerification(params Verification[] verifications);

        #endregion
        
     
        #region Reservations routines

        Reservation GetReservationById(int id);
        IList<Reservation> GetReservationsByPerson(Person person); 
        //void AddReservation(params Reservation[] reservations);
        //void UpdateReservation(params Reservation[] reservations);
        //void RemoveReservation(params Reservation[] reservations);

        #endregion
        
    }
}
