using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.Validation;
using Kseo2.DataAccess;
using Kseo2.Model;
using System.Windows;
using System.Dynamic;
using Kseo2.Service;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Caliburn.Micro.Extras;

namespace Kseo2.ViewModels
{
    public class VerificationViewModel :ValidatingScreen<VerificationViewModel>
    {
        private readonly IKseoContext _context;
        private readonly User _user;
        private Verification _verification;
        private readonly List<QuestionReason> _questionReasons;
        private readonly List<Country> _countries;
        private QuestionViewModel _questionViewModel;
        
        private readonly VerificationService _verificationService;
        private readonly IWindowManager _windowManager;

        private bool _isNew; 
       

        public VerificationViewModel(IKseoContext context,Verification verification=null)
        {
            _isNew = verification == null;
            if (_isNew)
            {
                Verification = new Verification();
                DisplayName = @"Nowe sprawdzenie.";
            }
            else
            {
                DisplayName = String.Format("Sprawdzenie: {0} {1}", FirstName, LastName);
            }
            
            _context = context;
            _questionReasons = _context.QuestionReasons
                .Where(i => i.IsActive.Equals(true))
                .OrderBy(i => i.DisplayOrder)
                .ToList();
            _countries = _context.Countries
                .Where(i => i.IsActive.Equals(true))
                .OrderBy(i => i.DisplayOrder)
                .ToList();

            Verification = verification ?? new Verification();
            
            QuestionViewModel = new QuestionViewModel(_context,Verification.Question);
            _windowManager = new WindowManager();

        }

        public VerificationViewModel(UnitOfWork unitOfWork)
        {
            
           // _verificationService = new VerificationService(_unitOfWork.Context());
           // QuestionViewModel = new QuestionViewModel(_unitOfWork,null);
        }






        protected override void OnActivate()
        {
            base.OnActivate();
            ((Conductor<Screen>.Collection.OneActive)Parent).DisplayName = DisplayName;
            
        }

        public Verification Verification
        {
            get { return _verification; }
            protected set
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



        public List<QuestionReason> QuestionReasons
        {
            get { return _questionReasons; }
        }
        
        public QuestionReason SelectedQuestionReason
        {
            get { return Verification.QuestionReason; }
            set
            {
                Verification.QuestionReason = value;
                OnPropertyChanged(value);
            }
        }
        
        public List<Country> Countries
        {
            get { return _countries; }
        }

        public Country SelectedCountry
        {
            get { return Verification.Nationality; }
            set
            {
                Verification.Nationality = value;
                NotifyOfPropertyChange(()=>SelectedCountry);
            }
        }

        //[Required(ErrorMessage = @"Nazwisko jest wymagane!", AllowEmptyStrings = false)]
        public string LastName
        {
            get { return Verification.Pesel; }
            set
            {
                _verification.LastName = value;
                OnPropertyChanged(value);
            }
        }

        [Required(ErrorMessage = @"Imię jest wymagane!", AllowEmptyStrings = false)]
        public string FirstName
        {
            get { return _verification.FirstName; }
            set
            {
                _verification.FirstName = value;
                OnPropertyChanged(value);
            }
        }

        public void SelectPerson()
        {
            
          
            dynamic settings = new ExpandoObject();
            settings.WindowStyle = WindowStyle.ToolWindow;
            settings.Height = 600;
            settings.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            settings.ShowInTaskbar = false;
            settings.Title = "Wyszukiwanie osoby...";
            //var vm = new PersonSearchViewModel(_unitOfWork);
            var vm = new PersonSearchViewModel(_context);
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
           /*
            _verificationService.AddVerification(Verification);
            var q = Verification.Question;
            Verification = new Verification(_unitOfWork.ActiveUser, q);
            SelectPerson();
            */ 
        }

        public void AddNewQuestion()
        {
           /*
            _verificationService.AddVerification(Verification);
            Verification = new Verification(_unitOfWork.ActiveUser, new Question());
            SelectPerson();
            */ 
        }


        public bool CanSave
        {
            get { return !HasErrors; }
        }

        public IResult Save()
        {

            if (CanSave)
            {
                
                try
                {
                    if (_isNew)
                    {
                        Verification.CreationTime = DateTime.Now;
                        Verification.Author = _context.Users.FirstOrDefault(u => u.Login.Equals(Environment.UserName));
                        _context.Verifications.Add(Verification);
                    }
                    _context.SaveChanges();
                    return new MessengerResult("Zmiany zostały zapisane.")
                        .Caption("Informacja")
                        .Image(MessageImage.Information);
                }
                catch (Exception ex)
                {
                   return new MessengerResult(ex.Message)
                        .Caption("Błąd zapisu sprawdzenia w repozytorium!")
                        .Image(MessageImage.Error);
                }
            }
            else
            {
                return null;
            }

            //_verificationService.UpdateVerification(Verification);
        }

        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
        }

    }
}
