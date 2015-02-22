using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.ViewModels.Common;

namespace Kseo2.ViewModels
{
    public class PersonBaseViewModel :BaseViewModel<PersonBaseViewModel>
    {
        public PersonBaseViewModel(IEventAggregator events) : base(events)
        {

        }

    }
}
