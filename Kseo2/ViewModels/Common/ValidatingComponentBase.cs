using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro.Validation;

namespace Kseo2.ViewModels.Common
{
    public class ValidatingComponentBase<TViewModel> :ValidatingScreen<TViewModel>
        where TViewModel :ValidatingScreen<TViewModel>
    {

    }
}
