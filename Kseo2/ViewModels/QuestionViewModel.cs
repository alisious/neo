using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.Model;

namespace Kseo2.ViewModels
{
    public class QuestionViewModel :Screen
    {
        private Question _question;
        
        
        public QuestionViewModel()
        {
            _question = new Question();
        }

        public QuestionViewModel(Question question)
        {
            _question = question;
        }

        public Question Question
        {
            get { return _question; }
            set
            {
                _question = value;
                NotifyOfPropertyChange(()=>Question);
            }

        }

    }
}
