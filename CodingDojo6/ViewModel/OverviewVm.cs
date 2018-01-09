/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:CodingDojo6"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using CodingDojo6.ViewModel;
using CodingDojo6.Model;

namespace CodingDojo6.ViewModel
{
    public class OverviewVm:ViewModelBase
    {
        private Messenger messenger = SimpleIoc.Default.GetInstance<Messenger>();
        private ItemVm currentItem;

        public ObservableCollection<ItemVm> Items { get; set; }
        public RelayCommand<ItemVm> buyBtnClicked;

        public ItemVm CurrentItem {
            get {
                return currentItem;
            }
            set {
                currentItem = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<ItemVm> BuyBtnClicked {
            get
            {
                return BuyBtnClicked;
            }
            set
            {
                BuyBtnClicked = value;
                RaisePropertyChanged();
            }
        }

        public OverviewVm() {
            BuyBtnClicked = new RelayCommand<ItemVm>((p) =>
            {
                messenger.Send<PropertyChangedMessage<ItemVm>>(new PropertyChangedMessage<ItemVm>(null, p, "AddNew"), "Write");
                messenger.Send<PropertyChangedMessage<Message>>(new PropertyChangedMessage<ItemVm>(null, new Message("New Entry Added",MessageState.Info), ""), "@Message");
            });

            Items = new ObservableCollection<ItemVm>();
            GenerateDemoData();
        }

        private void GenerateDemoData()
        {

            Items.Add(new ItemVm("Lego", new BitmapImage(new Uri("../Images/lego1.jpg", UriKind.Relative)), "-"));
            Items.Add(new ItemVm("Playmobil", new BitmapImage(new Uri("../Images/playmobil1.jpg", UriKind.Relative)), "-"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 2", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVm("Playmobil 2", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVm("Playmobil 2", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVm("Playmobil 2", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVm("Playmobil 2", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative)), "10+"));
        }
    }
}