using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.Model;

namespace Kseo2.ViewModels
{
    public class ReservationsViewModel :Screen
    {
        public Verification SelectedItem { get; set; }

        public bool CanEdit
        {
            get { return SelectedItem != null; }
        }
        public bool CanRemove { get { return SelectedItem != null; } }

        public void Add()
        {
            var vm = new FilesViewModel<ReservationFilesViewModel>(new ReservationFilesViewModel());
            var wm = IoC.Get<IWindowManager>();
            wm.ShowDialog(vm);
        }
    }
}
