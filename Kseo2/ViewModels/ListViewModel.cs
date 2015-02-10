using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Kseo2.Model;
using Kseo2.DataAccess;
using System.Collections.ObjectModel;

namespace Kseo2.ViewModels
{
    public class ListViewModel<T> :Screen where T :Entity
    {
        #region Common private fields
            private readonly KseoContext _kseoContext;
            private int _resultsLimit = 20;
            private bool _canSearchAutomatically = true;
            private int _resultsCounter = 0;
            private int _filterTemplateLengthTrigger = 3;
            private ObservableCollection<T> _items;
            private T _selectedItem;
        #endregion

        #region Constructors
            public ListViewModel(KseoContext kseoContext)
            {
                _kseoContext = kseoContext;
                Items = new ObservableCollection<T>();
                ResultsCounter = Items.Count;
            }

        #endregion

        #region Public common properties

            public KseoContext Context { get { return _kseoContext; } }
    
            public ObservableCollection<T> Items
            {
                get { return _items; }
                set
                {
                    _items = value;
                    NotifyOfPropertyChange(() => Items);
                }
            }

            public T SelectedItem
            {
                get { return _selectedItem; }
                set
                {
                    _selectedItem = value;
                    NotifyOfPropertyChange(() => SelectedItem);
                    NotifyOfPropertyChange(() => CanEdit);
                    NotifyOfPropertyChange(() => CanRemove);
                }
            }

            //Guard properties
            public bool CanEdit
            {
                get { return SelectedItem != null; }
            }

            public bool CanRemove
            {
                get { return SelectedItem != null; }
            }

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
        
        #endregion

    }
}
