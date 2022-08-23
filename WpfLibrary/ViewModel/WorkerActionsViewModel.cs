using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary.ViewModel
{
    public class WorkerActionsViewModel : ViewModelBase
    {
        public RelayCommand AddItemChoose { get; set; }
        public RelayCommand DeleteItemChoose { get; set; }
        public RelayCommand ReportChoose { get; set; }
        public WorkerActionsViewModel()
        {
            AddItemChoose = new RelayCommand(AddItem);
            DeleteItemChoose = new RelayCommand(DeleteItem);
            ReportChoose = new RelayCommand(ReportProduction);
        }
        private void AddItem()
        {
            //if (rvm.workerPermisions == false)
            //{
            //    MessageBox.Show("you have no permisions here");
            //    changeView.action.Invoke(0);

            //}
            //else
            //{
            //    changeView.action.Invoke(2);

            //}
        }
        private void DeleteItem()
        {
            //if (rvm.workerPermisions == false)
            //{
            //    MessageBox.Show("you have no permisions here");
            //    changeView.action.Invoke(0);

            //}
            //else
            //{
            //    changeView.action.Invoke(2);
            //}
        }
        private void ReportProduction()
        {
            //if (rvm.workerPermisions == false)
            //{
            //    MessageBox.Show("you have no permisions here");
            //    changeView.action.Invoke(0);

            //}
            //else
            //{
            //    changeView.action.Invoke(5);
            //}
        }

    }
}
