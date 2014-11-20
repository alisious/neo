using Caliburn.Micro;
using Caliburn.Micro.Extras;
using Caliburn.Micro.Validation;
using Kseo2.Model;
using Kseo2.Service;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Kseo2.ViewModels
{
    public class PersonEditViewModel : ValidatingScreen<PersonEditViewModel>
    {
        private readonly IPersonService _personService;
        
        private string _Pesel;
        private string _LastName;
        private string _FirstName;
        private string _FatherName;
        private string _BirthDate;
        private bool _HasPesel = true;
        private string _MiddleName;
        private string _MotherName;
        private string _BirthPlace;
        private string _MotherMaidenName;


        #region Public properties

        public Person Person { get; set; }

        public string RequiredFontWeight
        {
            get
            {
                if (HasPesel)
                {
                    return "Normal";
                }
                else
                {
                    return "Bold";
                }
            }
        }

        public bool HasPesel
        {
            get { return _HasPesel; }
            set
            {
                _HasPesel = value;
                if (value == false) Pesel = string.Empty;
                NotifyOfPropertyChange(() => HasPesel);
                NotifyOfPropertyChange(()=>PeselVisibility);
                NotifyOfPropertyChange(() => RequiredFontWeight);
            }
        }

        public string PeselVisibility
        {
            get
            {
                if (HasPesel)
                {
                    return "Visible";
                }
                return "Collapsed";
            }
        }

        [RequiredEx(ErrorMessage=@"PESEL jest wymagany!",GuardProperty = "HasPesel",ValidateWhileDisabled = false)]
        //[StringLength(11,ErrorMessage=@"PESEL musi składać się z 11 znaków!")]
        public string Pesel
        {
            get { return Person.Pesel; }
            set
            {
                Person.Pesel = value;
                OnPropertyChanged(value);

            }
        }


       
        public string LastName
        {
            get { return Person.LastName; }
            set
            {
                Person.LastName = value;
                NotifyOfPropertyChange(() => LastName);

            }
        }

        
        public string FirstName
        {
            get { return Person.FirstName; }
            set
            {
                Person.FirstName = value;
                OnPropertyChanged(value);
            }
        }

        public string MiddleName
        {
            get { return _MiddleName; }
            set
            {
                _MiddleName = value;
                NotifyOfPropertyChange(() => MiddleName);

            }
        }

        
        public bool HasNoPesel { get { return !HasPesel; } }

        [RequiredEx(ErrorMessage = @"Imię ojca jest wymagane w przypadku braku PESEL!",GuardProperty = "HasNoPesel")]
        public string FatherName
        {
            get { return _FatherName; }
            set
            {
                _FatherName = value;
                OnPropertyChanged(value);

            }
        }

        public string MotherName
        {
            get { return _MotherName; }
            set
            {
                _MotherName = value;
                NotifyOfPropertyChange(() => MotherName);

            }
        }

        public string MotherMaidenName
        {
            get { return _MotherMaidenName; }
            set
            {
                _MotherMaidenName = value;
                NotifyOfPropertyChange(() => MotherMaidenName);

            }
        }

        public string BirthDate
        {
            get { return _BirthDate; }
            set
            {
                _BirthDate = value;
                NotifyOfPropertyChange(() => BirthDate);

            }
        }

        public string BirthPlace
        {
            get { return _BirthPlace; }
            set
            {
                _BirthPlace = value;
                NotifyOfPropertyChange(() => BirthPlace);

            }
        }

        public bool Guard { get; set; }

        #endregion


        public PersonEditViewModel()
        {
            _personService = new PersonService();
            Person = new Person();
        }
               

        public IResult Save()
        {


            if (CanSave == true)
            {
                try
                {
                    _personService.AddPerson(Person);
                    _personService.SaveChanges();
                    return new MessengerResult("Zmiany zostały zapisane.")
                        .Caption("Informacja")
                        .Image(MessageImage.Information);
                }
                catch (Exception e)
                {
                    return new MessengerResult(e.Message)
                        .Caption("Błąd!")
                        .Image(MessageImage.Error);
                }
            }
            else
            {
                return null;
            }

        }

        public void Cancel()
        {
            this.TryClose(false);
        }

        public bool CanSave
        {
            get { return !HasErrorsByGroup();  }
        }

        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
        }


       
    }
}
