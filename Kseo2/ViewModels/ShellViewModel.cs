using Caliburn.Micro;
using Kseo2.Model;
using Kseo2.Service;

namespace Kseo2.ViewModels
{
    public class ShellViewModel :Conductor<Screen>,IShell
    {
        private UnitOfWork _uow;
        
        public ShellViewModel()
        {   
            _uow = new UnitOfWork();
            _uow.LoadDictionary(typeof(Country));
            ShowScreenOne();
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
            ActivateItem(new PersonSearchViewModel());
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
