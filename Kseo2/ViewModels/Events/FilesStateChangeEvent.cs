using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kseo2.ViewModels.Events
{
    public class FilesStateChangeEvent :StateChangeEvent
    {
        public FilesStateChangeEvent(bool isDirty, bool canSave) : base(isDirty, canSave)
        {
        }
    }
}
