using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using System.Runtime.CompilerServices;
using Kseo2.Model;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels
{
    public class PersonAddressViewModel :ValidatingScreen<PersonAddressViewModel>,IHandle<CanSaveEvent>
    {
        
        public PersonAddressViewModel(List<AddressType> addressTypes,IEventAggregator events,Address address=null)
        {
            events.Subscribe(this);
            DisplayName = address==null ? @"Nowy adres." : address.Location.ToString();
            CurrentAddress = address ?? new Address();
            CurrentAddressType = CurrentAddress.AddressType;
            Location = new LocationViewModel(CurrentAddress.Location,events);
            AddressTypes = addressTypes;
        }


        public List<AddressType> AddressTypes { get; private set; }
        public AddressType CurrentAddressType { get; set; }
        public LocationViewModel Location { get; set; }
        
        public bool CanSave
        {
            get
            {
                return CurrentAddressType != null
                    && Location.CanSave;
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


        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
        }





        public void Handle(CanSaveEvent message)
        {
            NotifyOfPropertyChange(()=>CanSave);
        }
    }
}
