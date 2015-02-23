using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.Model;
using Caliburn.Micro;

namespace Kseo2.ViewModels
{
    public class PersonReservationsViewModel :CompositionViewModel<Person,Reservation>
    {
        public PersonReservationsViewModel(
            List<ReservationPurpose> purposesList, 
            List<ReservationEndReason> endReasonsList, 
            List<OrganizationalUnit> organizationalUnitsList, 
            Person rootEntity, 
            IEventAggregator events)
            : base(rootEntity, events)
        {
            Items = new ObservableCollection<Reservation>(rootEntity.Reservations);
            PurposesList = purposesList;
            EndReasonsList = endReasonsList;
            OrganizationalUnitsList = organizationalUnitsList;
        }

        public List<OrganizationalUnit> OrganizationalUnitsList { get; private set; }
        public List<ReservationEndReason> EndReasonsList { get; private set; }
        public List<ReservationPurpose> PurposesList { get; private set; }

        public override void Add()
        {
            var windowManager = new WindowManager();
            var vm = new PersonReservationViewModel(PurposesList,EndReasonsList,OrganizationalUnitsList,new EventAggregator());
            
            if (windowManager.ShowDialog(vm) == true)
            {
                RootEntity.Reservations.Add(vm.CurrentEntity);
                Items = new ObservableCollection<Reservation>(RootEntity.Reservations);
                base.Add();
            }
        }
    }
}
