using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kseo2.ViewModels.Events
{
    public class ComponentStateChangeEvent :StateChangeEvent
    {
        public ComponentStateChangeEvent(bool canSave, bool isDirty) : base(canSave, isDirty)
        {
        }
    }
}
