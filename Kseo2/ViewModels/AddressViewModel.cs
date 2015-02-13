using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro.Validation;
using System.Runtime.CompilerServices;
using Kseo2.Model;

namespace Kseo2.ViewModels
{
    class AddressViewModel :ValidatingScreen<AddressViewModel>
    {
        private bool _isActiveAddress = true;
        private string _location;


        public AddressViewModel(Address address,List<AddressType> addressTypes )
        {
            CurrentAddress = address;
            DisplayName = (address.Id==0)? @"Nowy adres." : address.Location;
            CurrentAddressType = address.AddressType;
            IsActiveAddress = address.IsActive;
            Location = address.Location;
            AddressTypes = addressTypes;
        }


        public List<AddressType> AddressTypes { get; private set; }


        public AddressType CurrentAddressType { get; set; }

        public bool IsActiveAddress
        {
            get { return _isActiveAddress; }
            set
            {
                _isActiveAddress = value;
                OnPropertyChanged(value);
            }
        }


        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged(value);
            }
        }

        public bool CanSave
        {
            get
            {
                return CurrentAddressType != null
                       && !String.IsNullOrWhiteSpace(Location);
            } 
        }

        public void Save()
        {
            CurrentAddress.AddressType = CurrentAddressType;
            CurrentAddress.Location = Location;
            CurrentAddress.IsActive = IsActiveAddress;
            TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }


        public Address CurrentAddress { get; private set; }
        
        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
        }



        
    }
}
