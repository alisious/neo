using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.ViewModels.Common
{
    public interface ICompositionViewModel
    {
        bool IsDirty { get; set; }
        bool CanSave { get; set; }
    }
}
