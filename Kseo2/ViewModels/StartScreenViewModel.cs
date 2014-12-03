using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.ViewModels
{
    public class StartScreenViewModel :Screen
    {
        public StartScreenViewModel()
        {
            DisplayName = "Strona startowa...";
        }

        public void NewVerification()
        {
           ((Conductor<IScreen>.Collection.OneActive)this.Parent).ActivateItem(((Conductor<IScreen>.Collection.OneActive)this.Parent).Items[1]);
        }
    }
}
