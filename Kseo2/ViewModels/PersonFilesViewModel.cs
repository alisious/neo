﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms.VisualStyles;
using Caliburn.Micro;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels
{
    public sealed class PersonFilesViewModel :Conductor<IHasState>.Collection.AllActive, 
        IHasDisplayName,
        IHasState,
        IIsPersistent,
        IHandle<FilesTittleChangeEvent>,
        IHandle<ComponentStateChangeEvent>
    {
        private string _personFilesTittle;
        private readonly IEventAggregator _events = IoC.Get<IEventAggregator>();

        public PersonFilesViewModel(int personId,KseoContext kseoContext)
        {
            _events.Subscribe(this);
            KseoContext = kseoContext;
            var currentPerson = (personId == 0)
                ? new Person()
                : KseoContext.Persons
                .Include(p=>p.Addresses)
                .Include(p=>p.Workplaces)
                .Include(p=>p.Nationality)
                .Include(p=>p.Citizenships)
                .FirstOrDefault(p => p.Id.Equals(personId));
            DisplayName = "Teczka osoby.";
            
            Items.Add(new PersonViewModel(currentPerson,KseoContext));
            Items.Add(new PersonCollaborationsViewModel());
        }


        public PersonViewModel PersonData { get { return (PersonViewModel)Items[0]; } }
        public PersonCollaborationsViewModel CollaborationsData 
        { 
            get
                {
                return (PersonCollaborationsViewModel) Items[1];
            } 
        }

        public IHasState SelectedContent { get; set; }

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
            get
            {
                return Items.Aggregate(true, (current, item) => current && item.CanSave);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Save()
        {
            IsDirty = false;
        }

        public void Handle(FilesTittleChangeEvent message)
        {
            PersonFilesTittle = message.Tittle;
        }



        public void Handle(ComponentStateChangeEvent message)
        {
            _events.PublishOnUIThread(new FilesStateChangeEvent(CanSave,IsDirty));
        }


        public void Load(object selectedItem)
        {
          
            
        }


        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}
