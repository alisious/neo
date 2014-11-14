using Caliburn.Micro;

namespace Kseo2.ViewModels
{
    public class ShellViewModel :Conductor<Screen>,IShell
    {
        public ShellViewModel()
        {
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
            ActivateItem(new PersonEditViewModel());
        }
    }
}
