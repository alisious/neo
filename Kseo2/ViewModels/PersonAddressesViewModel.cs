using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caliburn.Micro;
using Kseo2.DataAccess;
using Kseo2.Model;
using Caliburn.Micro.Extras;

namespace Kseo2.ViewModels
{
    public class PersonAddressesViewModel :CompositionViewModel<Person,Address>
    {
        
        
        public PersonAddressesViewModel(Person rootEntity,List<AddressType> addressTypes, IEventAggregator events,KseoContext kseoContext)
            : base(rootEntity,events,kseoContext)
        {
            Items = new ObservableCollection<Address>(RootEntity.Addresses);
            AddressTypes = addressTypes;
        }


        public List<AddressType> AddressTypes { get; private set; } 

        public override void Add()
        {
            var windowManager = new WindowManager();
            var vm = new DialogViewModel<PersonAddressViewModel>(new PersonAddressViewModel(null, KseoContext));
            if (windowManager.ShowDialog(vm) == true)
            {
                RootEntity.Addresses.Add(vm.ContentViewModel.CurrentAddress);
                Items = new ObservableCollection<Address>(RootEntity.Addresses);
                base.Add();
            }
        }

        public override void Edit()
        {
            var windowManager = new WindowManager();
            var vm = new PersonAddressViewModel(SelectedItem,KseoContext);
            if (windowManager.ShowDialog(vm) == true)
            {
                RootEntity.Addresses.Remove(SelectedItem);
                RootEntity.Addresses.Add(vm.CurrentAddress);
                Items = new ObservableCollection<Address>(RootEntity.Addresses);
                base.Edit();
            }
        }

        public override void Remove()
        {
            var ms = new MessageService();
            if (
                ms.Show(@"Wybrany adres zostanie usunięty!", "Uwaga!", MessageButton.OKCancel,
                    MessageImage.Warning) == MessageResult.OK)
            {
                RootEntity.Addresses.Remove(SelectedItem);
                Items = new ObservableCollection<Address>(RootEntity.Addresses);
                base.Remove();
            }
        }

       
    }
}
