using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kseo2.ViewModels.Events
{
    public class ComponentWorkspaceStateChangeEvent :StateChangeEvent
    {
        public ComponentWorkspaceStateChangeEvent(bool isDirty, bool canSave) : base(isDirty, canSave)
        {
        }
    }
}
