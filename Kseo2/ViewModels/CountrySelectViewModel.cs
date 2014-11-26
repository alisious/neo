using Caliburn.Micro;
using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.ViewModels
{
    public class CountrySelectViewModel :Screen
    {

        private ObservableCollection<CheckedListItem<Country>> _allCountries = new ObservableCollection<CheckedListItem<Country>>(); 

        public CountrySelectViewModel(List<Country> countries)
        {
            this.DisplayName = "Wybierz kraj ...";
            foreach (Country c in countries)
            {
                _allCountries.Add(new CheckedListItem<Country>() { IsChecked = false, Item = c });
            }
        }

        public ObservableCollection<CheckedListItem<Country>> AllCountries
        {
            get { return _allCountries; }
            set
            {
                _allCountries = value;
                NotifyOfPropertyChange(() => AllCountries);
            }
        }

        #region Metody publiczne

        public ICollection<Country> GetSelectedCountries()
        {
            var _selectedCountries = new HashSet<Country>();
            foreach (CheckedListItem<Country> i in AllCountries)
                if (i.IsChecked)
                    _selectedCountries.Add(i.Item);
            return _selectedCountries;
        }

        public void SetSelectedCountries(ICollection<Country> countries = null)
        {
            foreach (Country c in countries)
                AllCountries.FirstOrDefault(x => x.Item.Name == c.Name).IsChecked = true;
        }

        public void Select()
        {
            TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }
        
        #endregion
    }


    public class CheckedListItem<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isChecked;
        private T item;

        public CheckedListItem()
        { }

        public CheckedListItem(T item, bool isChecked = false)
        {
            this.item = item;
            this.isChecked = isChecked;
        }

        public T Item
        {
            get { return item; }
            set
            {
                item = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Item"));
            }
        }


        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
    }
}
