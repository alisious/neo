using System.Linq;
using System.Runtime.Serialization;
using Caliburn.Micro;
using Kseo2.DataAccess;
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
        private KseoContext _kseoContext;
        private User _activeUser;

         





        public ShellViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
            _kseoContext = new KseoContext();
            DisplayName = "Komputerowy System Ewidencji Operacyjnej 2.0";
            DailyReport = new DailyReportViewModel(ActiveUser);
            Verifications = new VerificationsViewModel();
            Reservations = new ReservationsViewModel();
            Collaborations = new CollaborationsViewModel();
            Procedures = new ProceduresViewModel();
            Persons = new PersonsViewModel();
        }
        

        public DailyReportViewModel DailyReport { get; private set; }
        public VerificationsViewModel Verifications { get; private set; }
        public ReservationsViewModel Reservations { get; private set; }
        public CollaborationsViewModel Collaborations { get; private set; }
        public ProceduresViewModel Procedures {get; private set; }
        public PersonsViewModel Persons { get; private set; }

        public User ActiveUser
        {
            get { return _activeUser; }
            set
            {
                _activeUser = value;
                NotifyOfPropertyChange(()=>ActiveUser);
            }

        }

       
        //TODO: Usunąć poniższe

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
