using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.ViewModels.Common;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels
{
    public class PersonBaseViewModel :Conductor<IScreen>.Collection.AllActive,IHandle<CompositionStateChangeEvent>,ICompositionViewModel
    {
        private readonly IEventAggregator _events = IoC.Get<IEventAggregator>();

        public PersonBaseViewModel()
        {
            _events.Subscribe(this);
            Items.Add(PersonalitiesViewModel);
            Items.Add(PersonAddressesViewModel);
            Items.Add(PersonWorkplacesViewModel);
        }
        
        public bool IsDirty
        {
            get
            {
                
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool CanSave
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Handle(CompositionStateChangeEvent message)
        {
            throw new NotImplementedException();
        }
    }

    
}
