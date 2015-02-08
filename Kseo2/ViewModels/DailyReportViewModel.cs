using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.Model;

namespace Kseo2.ViewModels
{
    public class DailyReportViewModel :Screen
    {
        private User _user;


        public DailyReportViewModel(User user)
        {
            VerificationsCounter = 0;
            ReservationsCounter = 0;
            CollaborationsCounter = 0;
            _user = user;
        }

        public String OperationDate
        {
            get { return DateTime.Today.ToShortDateString(); }
        }

        public int VerificationsCounter { get; private set; }

        public int CollaborationsCounter { get; private set; }

        public int ReservationsCounter { get; private set; }
        
        public void RefreshReport()
        {

        }
    }
}
