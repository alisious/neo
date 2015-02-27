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

namespace Kseo2.ViewModels
{
    public class WorkplacesViewModel :CompositionViewModel<Person,Workplace>
    {
        public WorkplacesViewModel(Person rootEntity,IEventAggregator events,KseoContext kseoContext) : base(rootEntity,events,kseoContext)
        {
            Items = new ObservableCollection<Workplace>(RootEntity.Workplaces);
        }

        public override void Add()
        {
            var windowManager = new WindowManager();
            var vm = new WorkplaceViewModel(null,KseoContext);
            if (windowManager.ShowDialog(vm) == true)
            {
                RootEntity.Workplaces.Add(vm.CurrentWorkplace);
                Items = new ObservableCollection<Workplace>(RootEntity.Workplaces);
                base.Add();
            }
        }

        public override void Edit()
        {
            var windowManager = new WindowManager();
            var vm = new WorkplaceViewModel(SelectedItem,KseoContext);
            if (windowManager.ShowDialog(vm) == true)
            {
                RootEntity.Workplaces.Remove(SelectedItem);
                RootEntity.Workplaces.Add(vm.CurrentWorkplace);
                Items = new ObservableCollection<Workplace>(RootEntity.Workplaces);
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
               Items = new ObservableCollection<Workplace>(RootEntity.Workplaces);
               base.Remove();
            }
        }
    }
}
