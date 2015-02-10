using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro.Validation;
using Kseo2.DataAccess;
using Kseo2.Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Kseo2.Helpers;

namespace Kseo2.ViewModels
{
    public class PersonViewModel :ValidatingScreen<PersonViewModel>
    {
        private readonly KseoContext _context;
        private Person _currentPerson;
        

        public PersonViewModel(KseoContext context)
        {
            DisplayName = "Edycja danych osoby.";
            _context = context;
            CurrentPerson = new Person();
        }

        public Person CurrentPerson
        {
            get { return _currentPerson; }
            set
            {
                _currentPerson = value;
                NotifyOfPropertyChange(()=>CurrentPerson);
            }
        }

        public string FullName
        {
            get { return CurrentPerson.FullName; }
        }

        [Required(ErrorMessage = @"Nazwisko jest wymagane!", AllowEmptyStrings = false)]
        public string LastName
        {
            get { return CurrentPerson.LastName; }
            set
            {
                CurrentPerson.LastName = value;
                NotifyOfPropertyChange(()=>LastName);
                NotifyOfPropertyChange(()=>FullName);
            }
        }

        [Required(ErrorMessage = @"Imię jest wymagane!", AllowEmptyStrings = false)]
        public string FirstName
        {
            get { return CurrentPerson.FirstName; }
            set
            {
                CurrentPerson.FirstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        #region PESEL properties

        [RequiredEx(ErrorMessage = @"PESEL jest wymagany!", GuardProperty = "HasPesel")]
        [RegularExpression("[0-9]{11}", ErrorMessage = @"PESEL powinien składać się z 11 cyfr!")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasPeselGroup")]
        public string Pesel
        {
            get { return CurrentPerson.Pesel; }
            set
            {
                CurrentPerson.Pesel = value;
                if (value.Length >= 6 && String.IsNullOrEmpty(BirthDate))
                {
                    var d = PeselValidator.GetBirthDateFromPESEL(value);
                    if (d.HasValue)
                        BirthDate = d.Value.ToString("yyyy-MM-dd");
                }
                if (value.Length >= 9 && String.IsNullOrEmpty(Sex))
                {
                    Sex = PeselValidator.GetSexFromPESEL(value);
                }

                OnPropertyChanged(value);
            }
        }

        public string BoldWhenHasNoPesel
        {
            get { return HasPesel ? "Normal" : "Bold"; }
        }

        public string BoldWhenHasPesel
        {
            get { return HasPesel ? "Bold" : "Normal"; }
        }

        public bool HasPesel
        {
            get { return CurrentPerson.HasPESEL; }
            set
            {
                CurrentPerson.HasPESEL = value;
                if (value == false) Pesel = string.Empty;
                NotifyOfPropertyChange(() => PeselVisibility);
                NotifyOfPropertyChange(() => BoldWhenHasNoPesel);
                NotifyOfPropertyChange(() => BoldWhenHasPesel);
                NotifyOfPropertyChange(() => Pesel);
                NotifyOfPropertyChange(() => FatherName);
                NotifyOfPropertyChange(() => BirthDate);
                OnPropertyChanged(value);
            }
        }

        public bool HasNoPesel { get { return !HasPesel; } }

        public string PeselVisibility
        {
            get { return HasPesel ? "Visible" : "Hidden"; }
        } 
        #endregion

        #region Sex properties




        [Required(ErrorMessage = @"Płeć jest wymagana!")]
        public string Sex
        {
            get { return CurrentPerson.Sex; }
            set
            {
                CurrentPerson.Sex = value;
                NotifyOfPropertyChange(() => IsMale);
                NotifyOfPropertyChange(() => IsFemale);
                OnPropertyChanged(value);
            }
        }

        public bool IsMale
        {
            get { return Sex == "M"; }
            set
            {
                Sex = value ? "M" : "K";
                NotifyOfPropertyChange(() => IsMale);
            }
        }

        public bool IsFemale
        {
            get { return Sex == "K"; }
            set
            {
                Sex = value ? "K" : "M";
                NotifyOfPropertyChange(() => IsFemale);
            }
        }

        #endregion

        [RequiredEx(ErrorMessage = @"Data urodzenia jest wymagana w przypadku braku PESEL!", AllowEmptyStrings = false, GuardProperty = "HasNoPesel")]
        [RegularExpression(@"((?:19|20)\d\d)([-](0[1-9]|1[012]))?([-](0[1-9]|[12][0-9]|3[01]))?", ErrorMessage = @"Rok, Rok-Miesiąc lub data urodzenia.")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasNoPeselGroup")]
        public string BirthDate
        {
            get { return CurrentPerson.BirthDate; }
            set
            {
                CurrentPerson.BirthDate = value;
                OnPropertyChanged(value);

            }
        }

        public string BirthPlace
        {
            get { return CurrentPerson.BirthPlace; }
            set
            {
                CurrentPerson.BirthPlace = value;
                NotifyOfPropertyChange(() => BirthPlace);

            }
        }

        [RequiredEx(ErrorMessage = @"Imię ojca jest wymagane w przypadku braku PESEL!", AllowEmptyStrings = false, GuardProperty = "HasNoPesel")]
        [ValidationGroup(IncludeInErrorsValidation = false, GroupName = "HasNoPeselGroup")]
        public string FatherName
        {
            get { return CurrentPerson.FatherName; }
            set
            {
                CurrentPerson.FatherName = value;
                OnPropertyChanged(value);

            }
        }

        public string MotherName
        {
            get { return CurrentPerson.MotherName; }
            set
            {
                CurrentPerson.MotherName = value;
                NotifyOfPropertyChange(() => MotherName);

            }
        }

        public string MotherMaidenName
        {
            get { return CurrentPerson.MotherMaidenName; }
            set
            {
                CurrentPerson.MotherMaidenName = value;
                NotifyOfPropertyChange(() => MotherMaidenName);

            }
        }

        public void Cancel()
        {
            TryClose(false);
        }

        public bool CanSave
        {
            get
            {
                var r = HasErrorsByGroup();
                if (HasPesel)
                    return !r && !HasErrorsByGroup("HasPeselGroup");
                else
                    return !r && !HasErrorsByGroup("HasNoPeselGroup");
            }
        }

        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
        }


    }
}
