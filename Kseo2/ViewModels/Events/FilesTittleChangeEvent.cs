using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kseo2.ViewModels.Events
{
    public class FilesTittleChangeEvent
    {
        public FilesTittleChangeEvent(string tittle)
        {
            Tittle = tittle;
        }

        public string Tittle { get; private set; }
    }
}
