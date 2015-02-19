using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caliburn.Micro;
using Kseo2.Model;

namespace Kseo2.ViewModels
{
    public class PersonAddressesViewModel :CompositionViewModel<Person,Address>
    {
        public PersonAddressesViewModel(Person currentPerson,IEventAggregator events)
            : base(currentPerson,events)
        {
            Items = new ObservableCollection<Address>(RootEntity.Addresses);
        }


      
    }
}
