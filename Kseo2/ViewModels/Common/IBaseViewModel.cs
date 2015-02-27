using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.ViewModels.Common
{
    public interface IBaseViewModel
    {
        bool CanSave { get; }
        bool IsDirty { get; set; }
        string DisplayName { get; set; }
    }
}
