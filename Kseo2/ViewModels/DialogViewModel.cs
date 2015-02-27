using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.Model;
using Kseo2.ViewModels.Common;
using Kseo2.ViewModels.Events;


namespace Kseo2.ViewModels
{
    public class DialogViewModel<T> : Screen, IHandle<DialogContentStateChangeEvent>
        where T :IBaseViewModel
    {
        public bool CanSubmit { get; protected set; }
        public T ContentViewModel { get; set; }
        

        public DialogViewModel(T contentViewModel)
        {
            var events = IoC.Get<IEventAggregator>();
            events.Subscribe(this);
            ContentViewModel = contentViewModel;
        }


        public void Handle(DialogContentStateChangeEvent message)
        {
            CanSubmit = ContentViewModel.CanSave && message.CanSave;
            NotifyOfPropertyChange(()=>CanSubmit);
        }

        public void Submit()
        {
            TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }
    }
}
