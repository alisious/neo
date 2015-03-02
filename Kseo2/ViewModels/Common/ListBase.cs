using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels.Common
{
    public class ListBase :Screen,IComponentBase
    {
        private bool _isDirty = false;
        
        private readonly IEventAggregator _events;

        [ImportingConstructor]
        public ListBase(IEventAggregator events)
        {
            _events = events;
            events.Subscribe(this);
        }
        
        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                OnPropertyChanged(value);
            }
        }

        public bool CanSave
        {
            get { return true; }
        }

        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
            IsDirty = true;
            _events.PublishOnUIThread(new ComponentStateChangeEvent(IsDirty, CanSave));

        }

        public void Handle(DialogSubmitedEvent message)
        {
            _isDirty = false;
        }

        
    }
}
