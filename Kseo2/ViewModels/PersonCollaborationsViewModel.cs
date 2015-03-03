using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels
{
    public class PersonCollaborationsViewModel :IHasState
    {
    
        
        
        public bool IsDirty
{
	  get { return false; }
	  set 
	{ 
		throw new NotImplementedException(); 
	}
}

public bool CanSave
{
	get { return true; }
}




public void Load()
{
    throw new NotImplementedException();
}
    }
}
