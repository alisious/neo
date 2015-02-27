using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.ViewModels.Events;
using Kseo2.DataAccess;

namespace Kseo2.ViewModels.Common
{
    public class ComplexViewModel<T,TEntity> :BaseViewModel<T,TEntity>, IHandle<ComponentStateChangeEvent> 
        where T :ValidatingScreen<T> 
        where TEntity : class
    {
        private IEventAggregator _events;

        public ComplexViewModel(TEntity currentEntity, KseoContext kseoContext) : base(currentEntity, kseoContext)
        {
            _events = IoC.Get<IEventAggregator>();
            _events.Subscribe(this);
        }
        

        public void Handle(ComponentStateChangeEvent message)
        {
           _events.PublishOnUIThread(new DialogContentStateChangeEvent(CanSave,IsDirty));
        }
    }
}
