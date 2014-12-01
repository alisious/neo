using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Kseo2.ViewModels
{
    public class VerificationViewModel :Conductor<IScreen>.Collection.OneActive
    {
        private Conductor<IScreen>.Collection.OneActive _parent;

        public VerificationViewModel()
        {
            _parent = this.Parent as Conductor<IScreen>.Collection.OneActive;
        }

        public void BackToStartScreen()
        {
            _parent.ActivateItem(_parent.Items[0]);
        }
    }
}
