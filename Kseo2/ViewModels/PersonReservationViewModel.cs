using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.ViewModels.Common;
using Kseo2.Model;

namespace Kseo2.ViewModels
{
    public class PersonReservationViewModel :BaseViewModel<PersonReservationViewModel,Reservation>
    {
        public PersonReservationViewModel(List<ReservationPurpose> purposesList,List<ReservationEndReason> endReasonsList,List<OrganizationalUnit> organizationalUnitsList, IEventAggregator events,Reservation reservation=null) : base(events,reservation)
        {
            DisplayName = (reservation == null) ? @"Nowe zabezpieczenie." : reservation.ToString(); 
            CurrentEntity = reservation ?? new Reservation();
            PurposesList = purposesList;
            EndReasonsList = endReasonsList;
            OrganizationalUnitsList = organizationalUnitsList;

        }

        public List<OrganizationalUnit> OrganizationalUnitsList { get; private set; }
        public List<ReservationEndReason> EndReasonsList { get; private set; }
        public List<ReservationPurpose> PurposesList { get; private set; }

        public String StartDate
        {
            get { return CurrentEntity.StartDate; }
            set
            {
                CurrentEntity.StartDate = value;
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

        public ReservationPurpose Purpose
        {
            get { return CurrentEntity.Purpose; }
            set
            {
                CurrentEntity.Purpose = value;
                OnPropertyChanged(value);
            }
        }

        public OrganizationalUnit ConductingUnit
        {
            get { return CurrentEntity.ConductingUnit; }
            set
            {
                CurrentEntity.ConductingUnit = value;
                OnPropertyChanged(value);
            }
        }

        public override bool CanSave
        {
            get { return !HasErrors; }
        }
    }
}
