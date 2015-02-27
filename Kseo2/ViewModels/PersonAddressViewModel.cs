using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using System.Runtime.CompilerServices;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.ViewModels.Common;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels
{
    public class PersonAddressViewModel :ComplexViewModel<PersonAddressViewModel,Address>
    {
        
        public PersonAddressViewModel(Address address,KseoContext kseoContext) :base(address,kseoContext)
        {
            DisplayName = address==null ? @"Nowy adres." : address.Location.ToString();
            CurrentAddress = address ?? new Address();
            Location = new LocationViewModel(CurrentAddress.Location);
            AddressTypes = KseoContext.AddressTypes.Where(x=>x.IsActive.Equals(true)).ToList();
        }


        public List<AddressType> AddressTypes { get; private set; }

        [Required]
        public AddressType CurrentAddressType
        {
            get { return CurrentAddress.AddressType; }
            set
            {
                CurrentAddress.AddressType = value;
                OnPropertyChanged(value);
            }
        }
        public LocationViewModel Location { get; set; }
        
        public override bool CanSave
        {
            get
            {
                return !HasErrors && Location.CanSave;
            } 
        }

        public void Save()
        {
           CurrentAddress.AddressType = CurrentAddressType;
           TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }


        public Address CurrentAddress { get; private set; }
        public Location CurrentLocation { get { return CurrentAddress.Location; } 
            set {
            CurrentAddress.Location = value;
            OnPropertyChanged(value);
        } 
        }


        
        

       
    }
}
