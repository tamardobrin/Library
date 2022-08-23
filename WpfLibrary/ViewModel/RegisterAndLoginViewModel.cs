using BookLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using WpfLibrary.BL;

namespace WpfLibrary.ViewModel
{
    public class RegisterAndLoginViewModel : ViewModelBase
    {
        private readonly Logic logic;
        private string name;
        private int id;
        public int ID { get => id; set => Set(ref id, value); }
        public string Name { get => name; set => Set(ref name, value); }

        public List<Customer> Customers { get; set; }
        public RelayCommand LogInCommand { get; set; }
        public RelayCommand RegisterCommand { get; set; }
        public RegisterAndLoginViewModel(Logic logic)
        {
            LogInCommand = new RelayCommand(LogIn);
            RegisterCommand = new RelayCommand(Register);
            this.logic = logic;
            Customers = new List<Customer>(logic.Customers);
        }
        public void RegexValidationForNameId(string nameToCheck, string idToChek)
        {
            if (!Regex.IsMatch(idToChek, @"^\d{9}$"))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (!Regex.IsMatch(nameToCheck, "[a-zA-Z]+"))
            {
                throw new ArgumentException();
            }

        }
        public void LogIn()
        {
            try
            {
                RegexValidationForNameId(name, id.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Not a valid ID \n please enter a 9 digit number");
                return;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Not a valid Name");
                return;
            }
            if (logic.Customers.Exists(customer => customer.Name == name && customer.ID == id))
            {
                //changeView.action.Invoke(3);
            }
            else
            {
                string messageBoxText = " this is your first time here. \n would you like to sing in?";
                System.Windows.Forms.DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(messageBoxText, "Welcome", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    Register();
                }
                if (dialogResult == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show("Good Bye");
                    Application.Current.Shutdown();
                }

            }
            //CustomerPermisions = true;
            //workerPermisions = false;
        }

        private void Register()
        {
            try
            {
                RegexValidationForNameId(name, id.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Not a valid ID \n please enter a 9 digit number");
                return;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Not a valid Name");
                return;
            }
            Customer cust = new Customer { Name = name, ID = id };
            if (logic.Customers.Exists(customer => customer.Name == cust.Name && customer.ID == cust.ID))
            {
                MessageBox.Show("you alredy exist in our system. Welcome");
                LogIn();
            }
            else
            {
                logic.AddCustomer(new Customer { Name = name, ID = id});
                MessageBox.Show("welcome!");
            }
            //CustomerPermisions = true;
            //workerPermisions = false;
            //changeView.action.Invoke(3);
        }
    }
}
