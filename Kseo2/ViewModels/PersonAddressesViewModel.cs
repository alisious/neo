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
    public class PersonAddressesViewModel :AssociationListViewModel<Person,Address>
    {
        public PersonAddressesViewModel(Person currentPerson)
            : base(currentPerson)
        {
            Items = new ObservableCollection<Address>(RootEntity.Addresses);
        }

        
        public override void Add()
        {
           
        }
    }
}
