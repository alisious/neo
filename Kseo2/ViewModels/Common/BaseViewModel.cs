using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.DataAccess;
using Kseo2.ViewModels.Events;
using System.Runtime.CompilerServices;
using Kseo2.Model;

namespace Kseo2.ViewModels.Common
{
    public class BaseViewModel<T,TEntity> :ValidatingScreen<T>, IBaseViewModel
        where T :ValidatingScreen<T> 
        where TEntity :class
    {
        private bool _isDirty;

        public BaseViewModel(TEntity currentEntity,KseoContext kseoContext)
        {
            
            CurrentEntity = currentEntity;
            KseoContext = kseoContext;
        }

        protected KseoContext KseoContext { get; private set; }

        public TEntity CurrentEntity { get; protected set; }

        public virtual bool IsDirty
        {
           
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                NotifyOfPropertyChange(() => IsDirty);
            }
        }

        public virtual bool CanSave
        {
            get { return !HasErrors; }
            
        }

        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            IsDirty = true;
            NotifyOfPropertyChange(() => CanSave);
            var events = IoC.Get<IEventAggregator>();
            events.PublishOnUIThread(new ComponentStateChangeEvent(CanSave,IsDirty));
            events.PublishOnUIThread(new DialogContentStateChangeEvent(CanSave,IsDirty));
        }
        
        
    }
}
