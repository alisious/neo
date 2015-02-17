using System.Collections.ObjectModel;
using Caliburn.Micro;
using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRoot">Typ agregatu.</typeparam>
    /// <typeparam name="T">Typ elementu kompozycji.</typeparam>
    public class CompositionViewModel<TRoot,T> :Screen where TRoot :Entity
    {
        private bool _isDirty = false;
        private TRoot _rootEntity;
        private ObservableCollection<T> _items;
        private T _selectedItem;

        public CompositionViewModel(TRoot rootEntity)
        {
            Items = new ObservableCollection<T>();
            RootEntity = rootEntity;
        }


        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                NotifyOfPropertyChange(()=>IsDirty);
            }
        }

        public ObservableCollection<T> Items
        {
            get { return _items; }
            protected set
            {
                _items = value;
                NotifyOfPropertyChange(()=>Items);
            }
        }

        public T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyOfPropertyChange(()=>SelectedItem);
            }
        }

        public TRoot RootEntity
        {
            get { return _rootEntity; }
            protected set
            {
                _rootEntity = value;
                NotifyOfPropertyChange(()=>RootEntity);
            }
        }

        public virtual void Add()
        {
            IsDirty = true;
        }

        public virtual void Remove()
        {
            IsDirty = true;
        }

        public virtual void Edit()
        {
            IsDirty = true;
        }

    }
}
