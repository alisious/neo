using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.Model;
using System.Windows;
using System.Dynamic;
using Kseo2.Service;

namespace Kseo2.ViewModels
{
    public class VerificationViewModel :Screen
    {
        private readonly VerificationService _verificationService;
        private readonly IWindowManager _windowManager;
        private Verification _verification;
        private UnitOfWork _unitOfWork;
        private QuestionViewModel _questionViewModel;


        public VerificationViewModel(UnitOfWork unitOfWork)
        {
            _windowManager = new WindowManager();
            DisplayName = "Nowe sprawdzenie ...";
            _unitOfWork = unitOfWork;
            _verificationService = new VerificationService(_unitOfWork.Context());
            QuestionViewModel = new QuestionViewModel(_unitOfWork,null);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            ((Conductor<Screen>.Collection.OneActive)Parent).DisplayName = DisplayName;
            if (Verification == null)
            {
                Verification = new Verification(_unitOfWork.ActiveUser, new Question());
                SelectPerson();
            }
        }

        public Verification Verification
        {
            get { return _verification; }
            set
            {
                _verification = value;
                NotifyOfPropertyChange(()=>Verification);
            }
        }

        public QuestionViewModel QuestionViewModel
        {
            get { return _questionViewModel; }
            set
            {
                _questionViewModel = value;
                NotifyOfPropertyChange(()=>QuestionViewModel);
            }
        }


        public void SelectPerson()
        {
            
            dynamic settings = new ExpandoObject();
            settings.WindowStyle = WindowStyle.ToolWindow;
            settings.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settings.ShowInTaskbar = false;
            settings.Title = "Wyszukiwanie osoby...";
            var vm = new PersonSearchViewModel(_unitOfWork);
            if (_windowManager.ShowDialog(vm, null, settings) == true)
            {
                if (vm.SelectedResult != null)
                {
                    Verification.FoundedPerson = vm.SelectedResult;
                    Verification.Pesel = Verification.FoundedPerson.Pesel;
                    Verification.LastName = Verification.FoundedPerson.LastName;
                    Verification.FirstName = Verification.FoundedPerson.FirstName;
                    Verification.FatherName = Verification.FoundedPerson.FatherName;
                    Verification.BirthDate = Verification.FoundedPerson.BirthDate;
                    Verification.Nationality = Verification.FoundedPerson.Nationality;
                    Verification.Citizenships = Verification.FoundedPerson.Citizenships;
                }
                else
                {
                    //TODO: przepisać dane osoby z formularza wyszukiwania
                    Verification.Pesel = vm.Pesel;
                    Verification.LastName = vm.LastName;
                    Verification.FirstName = vm.FirstName;
                    Verification.FatherName = vm.FatherName;
                    Verification.BirthDate = vm.BirthDate;
                }

            }


        }


        public void Close()
        {
            var parent = (Conductor<Screen>.Collection.OneActive) Parent;
            parent.ActivateItem(parent.Items[0]);
            
        }

        public void AddNewVerification()
        {
            _verificationService.AddVerification(Verification);
            var q = Verification.Question;
            Verification = new Verification(_unitOfWork.ActiveUser, q);
            SelectPerson();
        }

        public void AddNewQuestion()
        {
            _verificationService.AddVerification(Verification);
            Verification = new Verification(_unitOfWork.ActiveUser, new Question());
            SelectPerson();
        }

        public void Save()
        {
            _verificationService.UpdateVerification(Verification);
        }

    }
}
