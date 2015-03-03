using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kseo2.ViewModels
{
    public class PersonFilesTittleChangeEvent
    {
        public PersonFilesTittleChangeEvent(string tittle)
        {
            Tittle = tittle;
        }

        public string Tittle { get; private set; }
    }
}
