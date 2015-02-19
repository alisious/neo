using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.ViewModels.Events
{
    public class IsDirtyEvent
    {
        public IsDirtyEvent(bool isDirty)
        {
            IsDirty = isDirty;
        }

        public bool IsDirty { get; private set; }
    }
}
