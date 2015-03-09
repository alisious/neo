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
    public class PersonReservationsViewModel :CompositionViewModel<Person,Reservation>,IHasState
    {
        private ReservationService _reservationService;

        public PersonReservationsViewModel(Person rootEntity,KseoContext kseoContext)
            : base(rootEntity, kseoContext)
        {
            _reservationService = new ReservationService(kseoContext);
            //LoadItems();
            //Items = new ObservableCollection<Reservation>(rootEntity.Reservations);
        }


        public void LoadItems()
        {
            Items = new ObservableCollection<Reservation>(RootEntity.Reservations);
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

        public override void Edit()
        {
            var windowManager = new WindowManager();
            var vm = new PersonReservationViewModel(KseoContext, SelectedItem);

            if (windowManager.ShowDialog(vm) == true)
            {
                //RootEntity.Reservations.Add(vm.CurrentEntity);
                //Items = new ObservableCollection<Reservation>(RootEntity.Reservations);
                LoadItems();
                base.Edit();
            }
        }


        public bool CanSave
        {
            get { return true; }
        }
    }
}
