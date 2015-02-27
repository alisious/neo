using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Caliburn.Micro;
using Caliburn.Micro.Extras;
using Kseo2.DataAccess;
using Kseo2.Model;
using AutoMapper;
using Kseo2.ViewModels.Common;

namespace Kseo2.ViewModels
{
    public class WorkplacesViewModel :BaseListViewModel<Workplace>
    {
        public WorkplacesViewModel(Person person, KseoContext kseoContext) : base(new List<Workplace>(person.Workplaces), kseoContext)
        {
            RootEntity = person;
        }

        public override void LoadItems()
        {
            Items = new BindableCollection<Workplace>(RootEntity.Workplaces);
        }


        public override void Add()
        {
            var windowManager = new WindowManager();
            var vm = new DialogViewModel<WorkplaceViewModel>(new WorkplaceViewModel(null,KseoContext));
            if (windowManager.ShowDialog(vm) == true)
            {
                RootEntity.Workplaces.Add(vm.ContentViewModel.CurrentWorkplace);
                LoadItems();
                base.Add();
            }
        }

        public override void Edit()
        {
            var windowManager = new WindowManager();
            var vm = new DialogViewModel<WorkplaceViewModel>(new WorkplaceViewModel(SelectedItem,KseoContext));
            if (windowManager.ShowDialog(vm) == true)
            {
                RootEntity.Workplaces.Remove(SelectedItem);
                RootEntity.Workplaces.Add(vm.ContentViewModel.CurrentWorkplace);
                LoadItems();
                base.Edit();
            }
        }

        public override void Remove()
        {
            var ms = new MessageService();
            if (
                ms.Show(@"Wybrane miejsce pracy zostanie usunięte!", "Uwaga!", MessageButton.OKCancel,
                    MessageImage.Warning) == MessageResult.OK)
            {
               RootEntity.Workplaces.Remove(SelectedItem);
               LoadItems();
               base.Remove();
            }
        }

        public Person RootEntity { get; private set; }
    }
}
