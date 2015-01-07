using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.Service;

namespace Kseo2.ViewModels
{
    public class QuestionViewModel :Screen
    {
        private readonly IKseoContext _context;
        private Question _question;
        
        private readonly List<Organization> _organizations; 
        private List<OrganizationalUnit> _organizationalUnits;
        private readonly List<QuestionForm> _questionForms; 
        
        public QuestionViewModel(IKseoContext context,Question question)
        {
        
            _context = context;
            Question = question;
            _organizations = context.Organizations
                .Where(o => o.IsActive.Equals(true))
                .OrderBy(o => o.DisplayOrder)
                .ToList();
            _questionForms = context.QuestionForms
                .Where(o => o.IsActive.Equals(true))
                .OrderBy(o => o.DisplayOrder)
                .ToList();
            
        }

        public QuestionViewModel(UnitOfWork uow)
        {
            _question = new Question();
            
        }

        public QuestionViewModel(UnitOfWork uow=null,Question question=null)
        {
            Question = question ?? new Question();
            
        }

        public Question Question
        {
            get { return _question; }
            set
            {
                _question = value;
                NotifyOfPropertyChange(() => Question);
                
                }

        }

        public Organization AskerOrganization
        {
            get { return Question.AskerOrganization; }
            set
            {
                Question.AskerOrganization = value;
                OrganizationalUnits = (value==null) 
                    ? new List<OrganizationalUnit>() 
                    : _context.OrganizationalUnits
                        .Include(ou=>ou.Organization)
                        .Where(ou => ou.IsActive.Equals(true) && ou.Organization.Id == value.Id)
                        .OrderBy(ou=>ou.DisplayOrder)
                        .ToList();
                NotifyOfPropertyChange(()=>AskerOrganization);
            }
        }

        public bool IsEnabledAskerOrganizationalUnit
        {
            get { return OrganizationalUnits.Count > 0; }
        }

        public List<OrganizationalUnit> OrganizationalUnits
        {
            get { return _organizationalUnits; }
            set
            {
                _organizationalUnits = value;
                NotifyOfPropertyChange(()=>OrganizationalUnits);
                NotifyOfPropertyChange(()=>IsEnabledAskerOrganizationalUnit);
            }
        }

        public List<Organization> Organizations
        {
            get { return _organizations; }
        }

        public List<QuestionForm> QuestionForms
        {
            get { return _questionForms; }
        }
    }
}
