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
    public class WorkersEnterViewModel : ViewModelBase
    {
        private readonly Logic logic;
        private string name;
        private int id;
        public int ID { get => id; set => Set(ref id, value); }
        public string Name { get => name; set => Set(ref name, value); }
        public RelayCommand EnterWorkerCommand { get; set; }
        public WorkersEnterViewModel(Logic logic)
        {
            this.logic = logic;
            EnterWorkerCommand = new RelayCommand(WorkEnter);
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
        private void WorkEnter()
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
            if (logic.Workers.Exists(worker => worker.Name == name && worker.ID == id))
            {
                MessageBox.Show($"welcome {name}");
                //CustomerPermisions = false;
                //workerPermisions = true;
                //changeView.action.Invoke(1);
            }
            else MessageBox.Show("Sorry you have no permmisions here");

        }
    }
}
