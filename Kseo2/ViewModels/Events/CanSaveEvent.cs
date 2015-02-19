using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.ViewModels.Events
{
    public class CanSaveEvent
    {
        public CanSaveEvent(bool canSave)
        {
            CanSave = canSave;
        }

        public bool CanSave { get; private set; }
    }
}
