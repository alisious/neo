using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.Model;
using Kseo2.DataAccess;
using System.Collections.ObjectModel;

namespace Kseo2.ViewModels.Common
{
    public class SearchableListViewModel<TEntity> :ListViewModel<TEntity>
        where TEntity :Entity
    {
        #region Common private fields
            private int _resultsLimit = 20;
            private bool _canSearchAutomatically = true;
            private int _resultsCounter = 0;
            private int _filterTemplateLengthTrigger = 3;
        #endregion

        #region Constructors
            public SearchableListViewModel(List<TEntity> items,KseoContext kseoContext) :base(items,kseoContext)
            {
                ResultsCounter = Items.Count;
            }

        #endregion

        #region Public common properties

            
    
        //Powinno być nadpisane w każdej pochodnej klasie.
            public virtual bool CanSearch
            {
                get { return true; }
            }

            public bool CanSearchAutomatically
            {
                get { return _canSearchAutomatically; }
                set
                {
                    _canSearchAutomatically = value;
                    NotifyOfPropertyChange(() => CanSearchAutomatically);
                }
            }

            public int ResultsLimit
            {
                get { return _resultsLimit; }
                set
                {
                    _resultsLimit = value;
                    NotifyOfPropertyChange(() => ResultsLimit);
                }
            }

           
            //Results properties
            public int ResultsCounter
            {
                get { return _resultsCounter; }
                set
                {
                    _resultsCounter = value;
                    NotifyOfPropertyChange(() => ResultsCounter);
                }
            }

            public int FilterTemplateLengthTrigger
            {
                get { return _filterTemplateLengthTrigger; }
                set
                {
                    _filterTemplateLengthTrigger = value;
                    NotifyOfPropertyChange(()=>FilterTemplateLengthTrigger);
                    NotifyOfPropertyChange(() => CanSearch);
                }
            }

        #endregion

        #region Protected methods
           
            protected virtual void SearchAutomatically()
            {
                if (CanSearchAutomatically && CanSearch)
                    Search();
            }
        #endregion


        #region Public methods
            
            public virtual void Search() {}

        public virtual void ListRowDoubleClick()
        {
            if (CanEdit) Edit();
        }

        #endregion

    }
}
