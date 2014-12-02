using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.Model;

namespace Kseo2.ViewModels
{
    public class VerificationViewModel :Conductor<IScreen>.Collection.OneActive
    {
        private Conductor<IScreen>.Collection.OneActive _parent;
        private Verification _verification;

        public VerificationViewModel()
        {
            _parent = this.Parent as Conductor<IScreen>.Collection.OneActive;
        }

        public Verification Verification
        {
            get { return _verification; }
            set
            {
                _verification = value;
                NotifyOfPropertyChange(()=>Verification);
            }
        }

        public void BackToStartScreen()
        {
            _parent.ActivateItem(_parent.Items[0]);
        }
    }
}
