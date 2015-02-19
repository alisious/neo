using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.Model;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels
{
    public class WorkplaceViewModel : ValidatingScreen<WorkplaceViewModel>, IHandle<CanSaveEvent>
    {
        
        public WorkplaceViewModel(Workplace workplace,IEventAggregator events)
        {
            events.Subscribe(this);
            DisplayName = (workplace.Id == 0) ? @"Nowe miejsce pracy." : workplace.Location.ToString();
            CurrentWorkplace = Mapper.Map<Workplace>(workplace);
            WorkplaceLocation = new LocationViewModel(CurrentWorkplace.Location, events);
           

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

       

        public bool CanSave
        {
            get { return !String.IsNullOrWhiteSpace(UnitName) && WorkplaceLocation.CanSave; }
        }

        public void Save()
        {
            
            TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }

        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
        }

        public void Handle(CanSaveEvent message)
        {
            NotifyOfPropertyChange(() => CanSave);
        }
       
    }
}
