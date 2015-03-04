using Caliburn.Micro;
using Kseo2.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.ViewModels
{
    public sealed class ReservationFilesViewModel :Conductor<IHasState>.Collection.AllActive, 
        IHasDisplayName,
        IHasState,
        IIsPersistent,
        IHandle<FilesTittleChangeEvent>,
        IHandle<ComponentStateChangeEvent>
    {
        private string _filesTittle;


        public ReservationFilesViewModel()
        {
            DisplayName = @"Akta zabezpieczenia operacyjnego osoby.";
        }

        public string FilesTittle
        {
            get { return _filesTittle; }
            set
            {
                _filesTittle = value;
                NotifyOfPropertyChange(() => FilesTittle);
            }
        }
        
        public bool IsDirty { get; set; }
        public bool CanSave { get; private set; }
        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Handle(FilesTittleChangeEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handle(ComponentStateChangeEvent message)
        {
            throw new NotImplementedException();
        }

        
        
    }
}
