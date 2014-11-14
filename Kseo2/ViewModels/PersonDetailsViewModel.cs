using Caliburn.Micro;
using Kseo2.Model;


namespace Kseo2.ViewModels
{
    class PersonDetailsViewModel :Screen
    {
    
        private readonly Person _person;

        public Person Person 
        {
            get { return _person; }
        }


        public PersonDetailsViewModel(Person person)
        {
            this._person = person;
        }


    }
}
