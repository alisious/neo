using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.ViewModels.Events
{
    public class StateChangeEvent
    {
        public StateChangeEvent(bool canSave, bool isDirty)
        {
            CanSave = canSave;
            IsDirty = isDirty;
        }

        public bool IsDirty { get; private set; }

        public bool CanSave { get; private set; }
    }
}
