using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.DataAccess;
using Kseo2.Model;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Kseo2.ViewModels.Events;
using Kseo2.ViewModels.Common;

namespace Kseo2.ViewModels
{
    public class PersonWorkplaceViewModel : ComplexViewModel<PersonWorkplaceViewModel,Workplace>
    {
        
     /// <summary>
     /// 
     /// </summary>
     /// <param name="workplace"></param>
     /// <param name="kseoContext"></param>
        public PersonWorkplaceViewModel(Workplace workplace,KseoContext kseoContext) :base(workplace,kseoContext)
        {
            
            DisplayName = workplace==null ? @"Nowe miejsce pracy." : workplace.UnitName; 
            CurrentWorkplace = workplace ?? new Workplace();
            WorkplaceLocation = new LocationViewModel(CurrentWorkplace.Location);
           

        }
        
        public LocationViewModel WorkplaceLocation { get; private set; }
        public Workplace CurrentWorkplace { get; private set; }
        


        [Required(AllowEmptyStrings = false, ErrorMessage = @"Nazwa miejsca pracy jest wymagana!")]
        [MaxLength(200, ErrorMessage = @"Nazwa miejsca pracy nie może być dłuższa niż 200 znaków!")]
        public string UnitName
        {
            get { return CurrentWorkplace.UnitName; }
            set
            {
                CurrentWorkplace.UnitName = value;
                OnPropertyChanged(value);
            }
        }
        public string UnitNumber
        {
            get { return CurrentWorkplace.UnitNumber; }
            set
            {
                CurrentWorkplace.UnitNumber = value;
                OnPropertyChanged(value);
            }
        }

       

        public override bool CanSave
        {
            get { return !HasErrors && WorkplaceLocation.CanSave; }
        }

        public void Save()
        {
            
            TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }

        

        
       
    }
}
