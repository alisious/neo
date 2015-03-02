using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.ViewModels.Events;
using System.Runtime.CompilerServices;
using System.ComponentModel.Composition;


namespace Kseo2.ViewModels.Common
{
   
    public class ComponentBase<TViewModel> : ValidatingScreen<TViewModel>,IComponentBase
        where TViewModel :ValidatingScreen<TViewModel>
    {
        private bool _isDirty = false;
        
        private readonly IEventAggregator _events;

        [ImportingConstructor]
        public ComponentBase(IEventAggregator events)
        {
            _events = events;
            events.Subscribe(this);
        }


        public virtual bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                OnPropertyChanged(value);
            }
        }

        public virtual bool CanSave
        {
            get { return !HasErrors; }
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
