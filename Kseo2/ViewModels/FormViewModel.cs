using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Caliburn.Micro;
using Kseo2.ViewModels.Common;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels
{
    public class FormViewModel<T> :Screen, IHandle<ComponentStateChangeEvent>,IHandle<ListStateChangeEvent>
        where T :IBaseViewModel
    {


        public virtual bool CanSave { get; set; }
        public virtual bool IsDirty { get; set; }
        public override void CanClose(Action<bool> callback)
        {
            callback(!IsDirty);
        }

        public virtual void Submit()
        {
        }

        public virtual void Cancel()
        {
        }

        public virtual void Close()
        {

        }


        public void Handle(ComponentStateChangeEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handle(ListStateChangeEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
