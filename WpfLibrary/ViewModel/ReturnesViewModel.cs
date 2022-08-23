using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfLibrary.BL;

namespace WpfLibrary.ViewModel
{
    public class ReturnesViewModel : ViewModelBase
    {
        private readonly ItemCollection itemCollection;
        private readonly Logic logic;
        private RegisterAndLoginViewModel registerAndLoginVM;
        private string name;
        private long iSBN;
        public string Name { get => name; set => Set(ref name, value); }
        public long ISBN { get => iSBN; set => Set(ref iSBN, value); }
        public RelayCommand ReturnCommand { get; set; }
        public ReturnesViewModel(ItemCollection itemCollection, Logic logic, RegisterAndLoginViewModel registerAndLoginVM)
        {
            this.registerAndLoginVM = registerAndLoginVM;
            this.logic = logic;
            this.itemCollection = itemCollection;
            ReturnCommand = new RelayCommand(Return);
        }
        private void Return()
        {
            if (IfExist())
            {
                MessageBox.Show("Thank You!");
            }

            else
                MessageBox.Show("This Item does Not exist in you borrowing history, sorry");
        }
        public bool IfExist()
        {
            foreach (var item in logic.Customers.Find(cust => cust.Name == registerAndLoginVM.Name).BorrowedItemslist)
            {
                if (item.Name == name)
                {
                    logic.Customers.Find(cust => cust.Name == registerAndLoginVM.Name).BorrowedItemslist.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}
