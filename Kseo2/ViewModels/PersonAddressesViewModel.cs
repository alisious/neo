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
using Kseo2.ViewModels.Common;

namespace Kseo2.ViewModels
{
    public class PersonAddressesViewModel :ListViewModel<Address>
    {
        
        
        public PersonAddressesViewModel(Person rootEntity,KseoContext kseoContext) :base(new List<Address>(rootEntity.Addresses),kseoContext)
        {
            RootEntity = rootEntity;
        }


        public override void LoadItems()
        {
            Items = new BindableCollection<Address>(RootEntity.Addresses);
        }

        public override void Add()
        {
            var windowManager = new WindowManager();
            var vm = new DialogViewModel<PersonAddressViewModel>(new PersonAddressViewModel(null, KseoContext));
            if (windowManager.ShowDialog(vm) == true)
            {
                RootEntity.Addresses.Add(vm.ContentViewModel.CurrentAddress);
                LoadItems();
                base.Add();
            }
        }

        public Person RootEntity { get; private set; }

        public override void Edit()
        {
            var windowManager = new WindowManager();
            var vm = new DialogViewModel<PersonAddressViewModel>(new PersonAddressViewModel(SelectedItem,KseoContext));
            if (windowManager.ShowDialog(vm) == true)
            {
                RootEntity.Addresses.Remove(SelectedItem);
                RootEntity.Addresses.Add(vm.ContentViewModel.CurrentAddress);
                LoadItems();
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
                LoadItems();
                base.Remove();
            }
        }
        
    }
}
