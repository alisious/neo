using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro.Validation;
using Kseo2.Model;
using System.Runtime.CompilerServices;

namespace Kseo2.ViewModels
{
    public class ReservationViewModel :ValidatingScreen<ReservationViewModel>
    {
       
        public ReservationViewModel(List<OrganizationalUnit> organizationalUnits, 
            List<ReservationPurpose> reservationPurposes,
            List<ReservationEndReason> reservationEndReasons,
            Reservation reservation=null)
        {
            DisplayName = reservation==null ? @"Nowe zabezpieczenie." : reservation.StartDate;
            CurrentReservation = reservation ?? new Reservation();
            CurrentConductingUnit = CurrentReservation.ConductingUnit;
            OrganizationalUnits = organizationalUnits;
            ReservationEndReasons = reservationEndReasons;
            ReservationPurposes = reservationPurposes;

        }

        public Reservation CurrentReservation { get; private set; }
        public OrganizationalUnit CurrentConductingUnit { get; private set; }
        public List<ReservationEndReason> ReservationEndReasons { get; private set; }
        public List<ReservationPurpose> ReservationPurposes { get; private set; }
        public List<OrganizationalUnit> OrganizationalUnits { get; private set; }

        public bool CanSave
        {
            get { return true; }
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
    }
}
