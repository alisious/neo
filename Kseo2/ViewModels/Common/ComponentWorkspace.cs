using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels.Common
{
   
    public class ComponentWorkspace :Conductor<IComponentBase>.Collection.AllActive, IHandle<ComponentStateChangeEvent>
    {
        private readonly IEventAggregator _events;

        public ComponentWorkspace(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
        }

        public bool CanSave {
            get
            {
               return Items.Aggregate(true, (current, item) => current && item.CanSave);
            } 
        }

        public bool IsDirty {
            get
            {
               return Items.Aggregate(false, (current, item) => current || item.IsDirty);
            }
        }


        public void Handle(ComponentStateChangeEvent message)
        {
            _events.PublishOnUIThread(new ComponentWorkspaceStateChangeEvent(IsDirty,CanSave));
        }
    }
}
