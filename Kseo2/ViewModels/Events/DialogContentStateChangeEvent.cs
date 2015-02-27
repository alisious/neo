﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.ViewModels.Events
{
    public class DialogContentStateChangeEvent
    {
        public DialogContentStateChangeEvent(bool canSave,bool isDirty = true)
        {
            CanSave = canSave;
            IsDirty = isDirty;
        }

        public bool IsDirty { get; private set; }

        public bool CanSave { get; private set; }
    }
}
