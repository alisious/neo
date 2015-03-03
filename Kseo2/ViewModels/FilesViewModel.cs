using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Extras;

namespace Kseo2.ViewModels
{
    public sealed class FilesViewModel<T> :Conductor<IScreen>.Collection.OneActive
        where T :IHasDisplayName,IHasState,IIsPersistent
    {

        public FilesViewModel(T filesWorkspace)
        {
            FilesWorkspace = filesWorkspace;
            DisplayName = FilesWorkspace.DisplayName;
        }


        public T FilesWorkspace { get; private set; }

        public bool CanSave { get { return FilesWorkspace.CanSave; } }
        
        public void Save()
        {
            FilesWorkspace.Save();
        }

        public void Close()
        {
            if (!FilesWorkspace.IsDirty)
            {
                TryClose(true);
                return;
            }
            
            var ms = IoC.Get<IMessageService>();
            if (ms.Show("Zamknięcie okna spowoduje, że wprowadzone zmiany nie zostaną zapisane.", "Uwaga!",
                MessageButton.OKCancel, MessageImage.Warning) == MessageResult.OK) 
               TryClose(false);
        }

        public void Cancel()
        {
            TryClose(false);
        }


    }
}
