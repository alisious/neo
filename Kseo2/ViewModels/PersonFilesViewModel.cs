using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using Caliburn.Micro;
using Kseo2.BusinessLayer;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels
{
    public sealed class PersonFilesViewModel :Conductor<IHasState>.Collection.AllActive, 
        IHasDisplayName,
        IHasState,
        IIsPersistent,
        IHandle<PersonFilesTittleChangeEvent>,
        IHandle<ComponentStateChangeEvent>
    {
        private string _personFilesTittle;
        private readonly IEventAggregator _events = IoC.Get<IEventAggregator>();
        private readonly PersonService _personService;

        public PersonFilesViewModel(int personId,KseoContext kseoContext)
        {
            _events.Subscribe(this);
            KseoContext = kseoContext;
            _personService = new PersonService(KseoContext);
            var currentPerson = (personId == 0)
                ? new Person()
                : _personService.GetPersonFiles(personId);
            DisplayName = "Teczka osoby.";
            
            Items.Add(new PersonViewModel(currentPerson,KseoContext));
            Items.Add(new PersonReservationsViewModel(currentPerson,KseoContext));
        }


        public PersonViewModel PersonData { get { return (PersonViewModel)Items[0]; } }
        public PersonReservationsViewModel PersonReservations { get { return (PersonReservationsViewModel)Items[1]; } } 

        public string PersonFilesTittle
        {
            get { return _personFilesTittle; }
            set
            {
                _personFilesTittle = value;
                NotifyOfPropertyChange(()=>PersonFilesTittle);
            }
        }

        public KseoContext KseoContext { get; private set; }

        public bool IsDirty
        {
            get
            {
                return Items.Aggregate(false, (current, item) => current || item.IsDirty);
            }

            set 
            {
                foreach (var item in Items)
                {
                    item.IsDirty = value;
                }
            }
        }

        public bool CanSave
        {
            get { return Items.Aggregate(true, (current, item) => current && item.CanSave); }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Handle(PersonFilesTittleChangeEvent message)
        {
            PersonFilesTittle = message.Tittle;
        }



        public void Handle(ComponentStateChangeEvent message)
        {
            _events.PublishOnUIThread(new FilesStateChangeEvent(IsDirty,CanSave));
        }
    }
}
