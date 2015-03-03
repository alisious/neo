using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.DataAccess;

namespace Kseo2.ViewModels
{
    public class CollaborationsViewModel :Screen
    {
        public void Add()
        {
            var vm = new FilesViewModel<PersonFilesViewModel>(new PersonFilesViewModel(0,new KseoContext()));
            var wm = IoC.Get<IWindowManager>();
            wm.ShowDialog(vm);

        }
    }
}
