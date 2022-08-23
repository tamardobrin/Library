
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using WpfLibrary.BL;
using WpfLibrary.Interfaces;
using WpfLibrary.Service;

namespace WpfLibrary.ViewModel
{

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<Logic>();
            SimpleIoc.Default.Register<TextBoxViewModel>();
            SimpleIoc.Default.Register<ButtonsViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<FilterViewModel>();
            SimpleIoc.Default.Register<RegisterAndLoginViewModel>();
            SimpleIoc.Default.Register<WorkersEnterViewModel>();
            SimpleIoc.Default.Register<ReturnesViewModel>();
            SimpleIoc.Default.Register<WorkerActionsViewModel>();
            SimpleIoc.Default.Register<ReportsProductionViewModel>();
            SimpleIoc.Default.Register<IChangeView, DataService>();
        }

        public TextBoxViewModel TBViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TextBoxViewModel>();
            }
        }
        public ButtonsViewModel BTNViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ButtonsViewModel>();
            }
        }
        public RegisterViewModel RegisterViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegisterViewModel>();
            }
        }
        public FilterViewModel filterViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FilterViewModel>();
            }
        }
        public RegisterAndLoginViewModel registerAndLogin
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegisterAndLoginViewModel>();
            }
        }
        public WorkersEnterViewModel WorkersEnter
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WorkersEnterViewModel>();
            }
        }
        public ReturnesViewModel Returnes
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReturnesViewModel>();
            }
        } 
        public WorkerActionsViewModel WorkerActions
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WorkerActionsViewModel>();
            }
        } 
        public ReportsProductionViewModel ReportsProduction
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReportsProductionViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}