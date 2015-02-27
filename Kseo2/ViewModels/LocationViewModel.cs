using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Kseo2.ViewModels.Common;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels
{

    

   
    public class LocationViewModel :BaseViewModel<LocationViewModel,Location>
    {
        public LocationViewModel(Location location) :base(location,null)
        {
            CurrentLocation = location;
            IsDirty = false;
        }

        public Location CurrentLocation { get; private set; }

        [Required(ErrorMessage = @"Nazwa miejscowości jest wymagana!",AllowEmptyStrings = false)]
        [MaxLength(100,ErrorMessage = @"Nazwa miejscowości <= 100 znaków!")]
        public string City
        {
            get
            {
                return CurrentLocation.City;
            }
            set
            {
                CurrentLocation.City = value;
                OnPropertyChanged(value);
            }
        }

        public string Street
        {
            get
            {
                return CurrentLocation.Street;
            }
            set
            {
                CurrentLocation.Street = value;
                OnPropertyChanged(value);
            }
        }

        public string StreetNo
        {
            get
            {
                return CurrentLocation.StreetNo;
            }
            set
            {
                CurrentLocation.StreetNo = value;
                OnPropertyChanged(value);
            }
        }
        public string PlaceNo
        {
            get
            {
                return CurrentLocation.PlaceNo;
            }
            set
            {
                CurrentLocation.PlaceNo = value;
                OnPropertyChanged(value);
            }
        }
        [MaxLength(6,ErrorMessage = @"Kod pocztowy w formacie 00-000.")]
        public string PostalCode
        {
            get
            {
                return CurrentLocation.PostalCode;
            }
            set
            {
                CurrentLocation.PostalCode = value;
                OnPropertyChanged(value);
            }
        }
        public string PostOffice
        {
            get
            {
                return CurrentLocation.PostOffice;
            }
            set
            {
                CurrentLocation.PostOffice = value;
                OnPropertyChanged(value);
            }
        }

        
    }
}
