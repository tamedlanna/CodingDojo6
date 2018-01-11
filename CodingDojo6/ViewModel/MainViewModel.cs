using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using CodingDojo6.ViewModel;
using CodingDojo6.Interfaces;


namespace CodingDojo6.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentView;
        private NavigationService nav= SimpleIoc.Default.GetInstance<NavigationService>();

    public ViewModelBase CurrentView {
            get {
                return currentView;
            }
            set {
                currentView = value;
                RaisePropertyChanged();
            }

        }

        public RelayCommand OverviewBtnClicked { get; set; }
        public RelayCommand MyToysBtnClicked { get; set; }

        public MainViewModel() {
            OverviewBtnClicked = new RelayCommand(() => { currentView = nav.NavigateTo("Overview"); });
            MyToysBtnClicked = new RelayCommand(() => { currentView = nav.NavigateTo("MyToys"); });

            currentView = nav.NavigateTo("Overview");

            (App.Current.Resources["Locator"] as ViewModelLocator).MessageBar.RegisterOnMessenger(SimpleIoc.Default.GetInstance<Messenger>(), "@Message");
        }
    }
}