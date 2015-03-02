using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels.Common
{
    public interface IComponentBase :IHandle<DialogSubmitedEvent>
    {     
        bool IsDirty { get; set; }
        bool CanSave { get; }
        
    }
}
