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
        public PersonReservationsViewModel(Person rootEntity, IEventAggregator events)
            : base(rootEntity, events)
        {
            Items = new ObservableCollection<Reservation>(rootEntity.Reservations);
        }
    }
}
