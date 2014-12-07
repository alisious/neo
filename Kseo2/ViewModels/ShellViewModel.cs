using System.Linq;
using System.Runtime.Serialization;
using Caliburn.Micro;
using Kseo2.Model;
using Kseo2.Service;
using System;

using System.Windows.Controls.Primitives;

namespace Kseo2.ViewModels
{
   
    public class ShellViewModel :Conductor<Screen>.Collection.OneActive,IShell
    {
        private readonly IWindowManager _windowManager;
        private UnitOfWork _uow;
        private User _activeUser;





        public ShellViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
            DisplayName = "KSEO 2.0";
            _uow = new UnitOfWork();
            Items.Add(new StartScreenViewModel(_uow));
            Items.Add(new PersonSearchViewModel(_uow));
            ActiveUser = _uow.ActiveUser;
            ActivateItem(Items[0]);

        }

        public ShellViewModel()
        {
            _uow = new UnitOfWork();
            Items.Add(new StartScreenViewModel(_uow));
            
            
            _uow.LoadDictionary(typeof(Country));
            _uow.LoadDictionary(typeof(QuestionForm));
            _uow.LoadDictionary(typeof(QuestionReason));
            _uow.LoadDictionary(typeof(Organization));
            _uow.LoadDictionary(typeof(Rank));
            ActiveUser = _uow.ActiveUser;
            //TODO: Dorobić obsługę pierwszego logowania.
            this.DisplayName = "KSEO 1.0";
            ShowScreenOne();
        }

       
        public User ActiveUser
        {
            get { return _activeUser; }
            set
            {
                _activeUser = value;
                NotifyOfPropertyChange(()=>ActiveUser);
            }

        }

        public string ActiveDate
        {
            get { return DateTime.Today.ToShortDateString(); }
        }

        public void ShowScreenOne()
        {
            ActivateItem(new ScreenOneViewModel());
        }

        public void ShowScreenTwo()
        {
            ActivateItem(new ScreenTwoViewModel());
        }

        public void ShowSearchPersonScreen()
        {
            ActivateItem(new PersonSearchViewModel(_uow));
        }

        public void ShowEditPersonScreen()
        {
            ActivateItem(new PersonEditViewModel(_uow));
        }

        public void ShowDetailsPersonScreen()
        {
            ActivateItem(new PersonDetailsViewModel(new Person()));
        }
    }
}
