using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.BusinessLayer;
using Kseo2.DataAccess;
using Kseo2.Model;
using Caliburn.Micro;

namespace Kseo2.ViewModels
{
    public class PersonReservationsViewModel :CompositionViewModel<Person,Reservation>
    {
        private ReservationService _reservationService;

        public PersonReservationsViewModel(Person rootEntity,IEventAggregator events,KseoContext kseoContext)
            : base(rootEntity, events,kseoContext)
        {
            _reservationService = new ReservationService(kseoContext);
            //LoadItems();
            //Items = new ObservableCollection<Reservation>(rootEntity.Reservations);
        }


        public void LoadItems()
        {
            Items = new ObservableCollection<Reservation>(_reservationService.GetReservationsByPerson(RootEntity));
        }

        public override void Add()
        {
            var windowManager = new WindowManager();
            var vm = new PersonReservationViewModel(KseoContext,new Reservation(RootEntity));
            
            if (windowManager.ShowDialog(vm) == true)
            {
                RootEntity.Reservations.Add(vm.CurrentEntity);
                //Items = new ObservableCollection<Reservation>(RootEntity.Reservations);
                LoadItems();
                base.Add();
            }
        }
    }
}
