using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.DataAccess;
using Kseo2.ViewModels.Common;
using Kseo2.Model;
using Caliburn.Micro.Validation;
using Kseo2.ViewModels.Events;
using System.Runtime.CompilerServices;

namespace Kseo2.ViewModels
{
    public class PersonReservationViewModel : ValidatingScreen<PersonReservationViewModel>
    {
        private EventAggregator _events;
        public PersonReservationViewModel(KseoContext kseoContext,Reservation reservation)
        {
            DisplayName = (reservation.Id.Equals(0)) ? @"Nowe zabezpieczenie." : reservation.ToString(); 
            
            KseoContext = kseoContext;
            CurrentEntity = reservation;
            _events = new EventAggregator();
            _events.Subscribe(this);

            
            
            PurposesList = KseoContext.ReservationPurposes.Where(c => c.IsActive.Equals(true)).ToList();
            EndReasonsList = KseoContext.ReservationEndReasons.Where(c => c.IsActive.Equals(true)).ToList();
            OrganizationalUnitsList = KseoContext.OrganizationalUnits.Where(c => c.IsActive.Equals(true)).ToList();

        }

        protected KseoContext KseoContext { get; private set; }
        public Reservation CurrentEntity { get; private set; }

        public List<OrganizationalUnit> OrganizationalUnitsList { get; private set; }
        public List<ReservationEndReason> EndReasonsList { get; private set; }
        public List<ReservationPurpose> PurposesList { get; private set; }

        [Required]
        [MaxLength(10)]
        public String StartDate
        {
            get { return CurrentEntity.StartDate; }
            set
            {
                CurrentEntity.StartDate = value;
                OnPropertyChanged(value);
            }
        }

        [Required]
        public ReservationPurpose Purpose
        {
            get { return CurrentEntity.Purpose; }
            set
            {
                CurrentEntity.Purpose = value;
                OnPropertyChanged(value);
            }
        }

        [Required]
        public OrganizationalUnit ConductingUnit
        {
            get { return CurrentEntity.ConductingUnit; }
            set
            {
                CurrentEntity.ConductingUnit = value;
                OnPropertyChanged(value);
            }
        }

        public String EndDate
        {
            get { return CurrentEntity.EndDate; }
            set
            {
                CurrentEntity.EndDate = value;
                OnPropertyChanged(value);
            }
        }
        
        public ReservationEndReason EndReason
        {
            get { return CurrentEntity.EndReason; }
            set
            {
                CurrentEntity.EndReason = value;
                OnPropertyChanged(value);
            }
        }
        
        public bool CanSave
        {
            get { return !HasErrors; }
        }

        public void Submit()
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
        
    }
}
