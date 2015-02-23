using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.ViewModels.Events;
using System.Runtime.CompilerServices;
using Kseo2.Model;

namespace Kseo2.ViewModels.Common
{
    public class BaseViewModel<T,TEntity> :ValidatingScreen<T>, IHandle<IsDirtyEvent>,IHandle<CanSaveEvent> 
        where T :ValidatingScreen<T> 
        where TEntity :Entity
    {
        private bool _isDirty;
        
        public BaseViewModel(IEventAggregator events,TEntity currentEntity)
        {
            Events = events;
            CurrentEntity = currentEntity;
        }

        public TEntity CurrentEntity { get; protected set; }

        public IEventAggregator Events { get; private set; }

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                NotifyOfPropertyChange(() => IsDirty);
                if (_isDirty) Events.PublishOnUIThread(new IsDirtyEvent(true));
            }
        }

        public virtual bool CanSave
        {
            get { return true; }
        }

        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
            Events.PublishOnUIThread(new CanSaveEvent(CanSave));
            IsDirty = true;
        }
        
        public void Handle(IsDirtyEvent message)
        {
            IsDirty = IsDirty || message.IsDirty;
        }

        public void Handle(CanSaveEvent message)
        {
           NotifyOfPropertyChange(()=>CanSave);
        }
    }
}
