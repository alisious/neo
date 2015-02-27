using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Caliburn.Micro;
using Kseo2.DataAccess;
using Kseo2.Model;
using Kseo2.ViewModels.Events;

namespace Kseo2.ViewModels.Common
{
    public class BaseListViewModel<T> :Screen where T : Entity
{
    private readonly IEventAggregator _events = IoC.Get<IEventAggregator>();
    private T _selectedItem;
    private bool _isDirty = false;
    private BindableCollection<T> _items;


    public BaseListViewModel(List<T> items,KseoContext kseoContext)
    {
        Items = new BindableCollection<T>();
        KseoContext = kseoContext;
    }

        public KseoContext KseoContext { get; private set; }

        public BindableCollection<T> Items { get { return _items; }
            protected set
            {
                _items = value;
                NotifyOfPropertyChange(()=>Items);
            } }

        public T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyOfPropertyChange(() => SelectedItem);
                NotifyOfPropertyChange(()=>CanEdit);
                NotifyOfPropertyChange(()=>CanRemove);
            }
        }

        public virtual void LoadItems()
        {
            Items = new BindableCollection<T>();
        }

        public bool CanEdit
        {
            get { return SelectedItem != null; }
        }

        public bool CanRemove
        {
            get { return SelectedItem != null; }
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
                NotifyOfPropertyChange(()=>IsDirty);
                _events.PublishOnUIThread(new ListStateChangeEvent(true,IsDirty));
            }
        }

        public virtual void Add()
        {
            IsDirty = true;
        }

        public virtual void Edit()
        {
            IsDirty = false;
        }

        public virtual void Remove()
        {
            IsDirty = true;
        }





}

}

