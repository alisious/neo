using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kseo2.Service;

namespace Kseo2.ViewModels
{
    public class StartScreenViewModel :Screen
    {
        private UnitOfWork _unitOfWork;
        public StartScreenViewModel(UnitOfWork unitOfWork)
        {
            DisplayName = "Strona startowa...";
            _unitOfWork = unitOfWork;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            ((Conductor<Screen>.Collection.OneActive)Parent).DisplayName=DisplayName;
        }

       

        public void NewVerification()
        {
            var parent = (Conductor<Screen>.Collection.OneActive) Parent;
            parent.ActivateItem(new VerificationViewModel(_unitOfWork));
            parent.DisplayName = "Nowe sprawdzenie...";
        }
    }
}
