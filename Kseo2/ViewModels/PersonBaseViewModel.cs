using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.ViewModels.Common;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels
{
    public class PersonBaseViewModel :ComponentWorkspace
    {
        public PersonBaseViewModel(IEventAggregator events) : base(events)
        {

        }
    }

}
