﻿using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfLibrary.Interfaces;
using WpfLibrary.Service;
using WpfLibrary.UIelements;

namespace WpfLibrary.ViewModel
{
    public class FilterViewModel : ViewModelBase
    {
        string a = "";
        private IChangeView changeView;
        private RegisterViewModel rvm;

        private readonly ItemCollection itemCollection;
        public ObservableCollection<AbstractItem> ItemsList { get; set; }
        public ObservableCollection<AbstractItem> _itemcollection { get; set; } = new ObservableCollection<AbstractItem>();
        public ObservableCollection<AbstractItem> filteredList { get; set; } = new ObservableCollection<AbstractItem>();
        public ObservableCollection<AbstractItem> ShoppingChart { get; set; } = new ObservableCollection<AbstractItem>();
        public ObservableCollection<AbstractItem> CurrentList { get { return _currentList; } set { Set(ref _currentList, value); } } 
        public double TotalPrice { get => _totalPrice; set => Set(ref _totalPrice, value); }
        public RelayCommand EndShopCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        public List<string> AutorsList { get; set; } = new List<string>();

        private Categories _selectedCategory;
        private string _selectedAutor;
        private AbstractItem _selectedItem;
        private string _priceCmbSelection;
        private int _selectedIndexCategory;
        private int _selectedIndexAutor;
        private int _selectedIndexPrice;
        private int _indexToDelete;
        private double _totalPrice;
        private ObservableCollection<AbstractItem> _currentList= new ObservableCollection<AbstractItem>();


        public List<string> ListAutors()
        {
            foreach (var item in _itemcollection)
            {
                a = item.Author;
                AutorsList.Add(a);
            }
            return AutorsList;

        }
        public Categories SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                FilterByJaner(SelectedCategory);
            }
        }
        public int IndexToDelete
        {
            get { return _indexToDelete; }
            set
            {
                _indexToDelete = value;
                if (value != -1)
                {
                    ShoppingChart.RemoveAt(_indexToDelete);
                    IndexToDelete = -1;

                }
            }
        }
        public int SelectedIndexCategory
        {
            get { return _selectedIndexCategory; }
            set
            {
                Set(ref _selectedIndexCategory, value);
            }
        }
        public int SelectedIndexAutor
        {
            get { return _selectedIndexAutor; }
            set
            {
                Set(ref _selectedIndexAutor, value);
            }
        }
        public int SelectedIndexPrice
        {
            get { return _selectedIndexPrice; }
            set
            {
                Set(ref _selectedIndexPrice, value);
            }
        }
        public string SelectedAutor
        {
            get { return _selectedAutor; }
            set
            {
                _selectedAutor = value;
                FilterByAutor();
            }
        }
        public AbstractItem SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != null)
                {
                    _selectedItem = value;
                    ShoppingChart.Add(_selectedItem);
                }
            }
        }
        
        public string PriceCmbSelection
        {
            get { return _priceCmbSelection; }
            set
            {
                _priceCmbSelection = value;
                SortPrices();
            }
        }
        public void SortPrices()
        {
            List<AbstractItem> tmpList = _currentList.OrderBy(o => o.Price).ToList();
            _currentList.Clear();
            tmpList.ForEach(item => _currentList.Add(item));
        }
        public FilterViewModel(IChangeView changeView, RegisterViewModel rvm, ItemCollection itemCollection)
        {
            this.itemCollection = itemCollection;
            ItemsList = new ObservableCollection<AbstractItem>(itemCollection.itemsList);
            this.rvm = rvm;
            Insert(itemCollection.itemsList);
            EndShopCommand = new RelayCommand(EndShop);
            ShowAllCommand = new RelayCommand(ShowAll);
            this.changeView = changeView;
            //CurrentList = itemcollection;
            InserToC();
            SelectedIndexCategory = -1;
            SelectedIndexAutor = -1;
            SelectedIndexPrice = -1;
            IndexToDelete = -1;
            ListAutors();
        }
        public void InserToC()
        {
            foreach (var item in itemCollection.itemsList)
            {
                CurrentList.Add(item);
            }
        }
        
      
        private void ShowAll()
        {
            SelectedIndexCategory = -1;
            SelectedIndexAutor = -1;
            SelectedIndexPrice = -1;
            InserToC();
            //CurrentList = _itemcollection;
        }
        private void EndShop()
        {
            if (rvm.CustomerPermisions==true)
            {
                CalCulate();
                foreach (var item in ShoppingChart)
                {
                    rvm.custList.Find(cust => cust.Name == rvm.Name).BorrowedItemslist.Add(item);
                }
                changeView.action.Invoke(4);
            }
            else
            {
               string q="Sorry. only registered customers can buy here, \n would you like to register?";
                System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(q, "Error", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    changeView.action.Invoke(0);
                }
                if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show("ok. have a plesent time :)");
                    changeView.action.Invoke(6);
                }
            }
           
        }

        public void CalCulate()
        {
            TotalPrice = 0;
            foreach (var item in ShoppingChart)
            {
                if (itemCollection[item.Name] != default)
                {
                    item.Discount= itemCollection[item.Name].Discount;
                }
            }
            foreach (var item in ShoppingChart)
            {
                TotalPrice += item.Price-item.Discount;
               
            }
           
        }
        public void Insert(List<AbstractItem> itemsList)
        {
            foreach (var item in _itemcollection)
            {
                _itemcollection.Remove(item);
            }
            itemsList.ForEach(_itemcollection.Add);
        }
        public void FilterByJaner(Categories SelectedCategory)
        {
            foreach (var item in _itemcollection)
            {
                if (item.Categories == SelectedCategory)
                    filteredList.Add(item);
                else
                    filteredList.Remove(item);
            }
            CurrentList = filteredList;
        }
        public void FilterByAutor()
        {
            ObservableCollection<AbstractItem> tmpList = new ObservableCollection<AbstractItem>();
            int i = 0;
            while(i<_itemcollection.Count)
            {
                if (_itemcollection[i].Author == SelectedAutor)
                {
                    tmpList.Add(_itemcollection[i]);
                }
                i++;
            }
            CurrentList = tmpList ;
        }
    }
}
