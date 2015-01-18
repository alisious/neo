using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.Service;
using Caliburn.Micro.Validation;
using System.Runtime.CompilerServices;

namespace Kseo2.ViewModels
{
    public class QuestionViewModel : ValidatingScreen<QuestionViewModel>
    {

        #region Private fields
        private readonly IKseoContext _context;
        private Question _currentQuestion;
        private readonly List<Organization> _askerOrganizations;
        private List<OrganizationalUnit> _askerOrganizationalUnits;
        private readonly List<QuestionForm> _questionForms; 
        #endregion
        
        #region Constructors

        public QuestionViewModel(IKseoContext context, Question currentQuestion)
        {

            _context = context;
            CurrentQuestion = currentQuestion;
            _askerOrganizations = context.Organizations
                .Where(o => o.IsActive.Equals(true))
                .OrderBy(o => o.DisplayOrder)
                .ToList();
            _questionForms = context.QuestionForms
                .Where(o => o.IsActive.Equals(true))
                .OrderBy(o => o.DisplayOrder)
                .ToList();

        }

        
        #endregion

        #region Public properties

        public Question CurrentQuestion
        {
            get { return _currentQuestion; }
            set
            {
                _currentQuestion = value;
                NotifyOfPropertyChange(() => CurrentQuestion);
            }
        }
        
        public List<Organization> AskerOrganizations
        {
            get { return _askerOrganizations; }
        }

        [Required(ErrorMessage = @"Nazwa instytucji pytającej jest obowiązkowa!")]
        public Organization SelectedAskerOrganization
        {
            get { return CurrentQuestion.AskerOrganization; }
            set
            {
                CurrentQuestion.AskerOrganization = value;
                AskerOrganizationalUnits = (value == null)
                    ? new List<OrganizationalUnit>()
                    : _context.OrganizationalUnits
                        .Include(ou => ou.Organization)
                        .Where(ou => ou.IsActive.Equals(true) && ou.Organization.Id == value.Id)
                        .OrderBy(ou => ou.DisplayOrder)
                        .ToList();
                OnPropertyChanged(value);
             }
        }
        
        public OrganizationalUnit SelectedAskerOrganizationalUnit
        {
            get { return CurrentQuestion.AskerOrganizationalUnit; }
            set
            {
                CurrentQuestion.AskerOrganizationalUnit = value;
                OnPropertyChanged(value);
            }
        }
        

        public List<OrganizationalUnit> AskerOrganizationalUnits
        {
            get { return _askerOrganizationalUnits; }
            set
            {
                _askerOrganizationalUnits = value;
                NotifyOfPropertyChange(() => AskerOrganizationalUnits);
                NotifyOfPropertyChange(() => IsEnabledAskerOrganizationalUnit);
            }
        }

        public bool IsEnabledAskerOrganizationalUnit
        {
            get { return AskerOrganizationalUnits.Count > 0; }
        }

        public QuestionForm SelectedQuestionForm
        {
            get { return CurrentQuestion.QuestionForm; }
            set
            {
                CurrentQuestion.QuestionForm = value;
                OnPropertyChanged(value);
            }
        }

        public List<QuestionForm> QuestionForms
        {
            get { return _questionForms; }
        }

        public bool CanSave
        {
            get { return !HasErrors; }
        } 
        #endregion
        
        #region Public methods
        
        #endregion


        #region Helpers and validators
        protected void OnPropertyChanged(object value, [CallerMemberName] string propertyName = "")
        {
            NotifyOfPropertyChange(propertyName);
            NotifyOfPropertyChange(() => CanSave);
        } 
        #endregion
}
}
