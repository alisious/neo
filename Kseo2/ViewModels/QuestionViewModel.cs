using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.Model;
using Kseo2.Service;

namespace Kseo2.ViewModels
{
    public class QuestionViewModel :Screen
    {
        private readonly OrganizationalUnitService _organizationalUnitService;
        private Question _question;
        private List<OrganizationalUnit> _organizationalUnits;
        private OrganizationalUnit _MPHQ;
        private UnitOfWork _uow;
        private bool _isEnabledAskerOrganizationalUnit;

        public QuestionViewModel(UnitOfWork uow)
        {
            _question = new Question();
            UnitOfWork = uow;
           
        }

        public QuestionViewModel(UnitOfWork uow=null,Question question=null)
        {
            Question = question ?? new Question();
            UnitOfWork = uow ?? new UnitOfWork();
            _organizationalUnitService = new OrganizationalUnitService(UnitOfWork.Context());
            MPHQ = _organizationalUnitService.GetSingle("KG ŻW");
            IsEnabledAskerOrganizationalUnit = false;

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
                NotifyOfPropertyChange(()=>AskerOrganization);
                IsEnabledAskerOrganizationalUnit = (Question.AskerOrganization != null)
                                                   && (Question.AskerOrganization.Name == "ŻANDARMERIA WOJSKOWA");
                
            }
        }

        public UnitOfWork UnitOfWork
        {
            get
            {
                return _uow;
            }
            set
            {
                _uow = value;
                NotifyOfPropertyChange(()=>UnitOfWork);
            } 
        }

        public  OrganizationalUnit MPHQ
        {
            get
            {
                return _MPHQ;
            }
            set
            {
                _MPHQ = value;
                NotifyOfPropertyChange(() => MPHQ);
            }
        }

        public bool IsEnabledAskerOrganizationalUnit
        {
            get { return _isEnabledAskerOrganizationalUnit; }
            set
            {
                _isEnabledAskerOrganizationalUnit = value;
                if (!_isEnabledAskerOrganizationalUnit) Question.AskerOrganizationalUnit = null;
                NotifyOfPropertyChange(()=>IsEnabledAskerOrganizationalUnit);
                NotifyOfPropertyChange(()=>Question);
            }

        }


    }
}
