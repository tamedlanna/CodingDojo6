using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
namespace CodingDojo6.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ItemVm currentItem;
        public ObservableCollection<ItemVm> Items { get; set; }
        public ObservableCollection<ItemVm> Cart { get; set; }

        private RelayCommand<ItemVm> buyBtnClicked;


        public ItemVm CurrentItem
        {
            get
            {
                return currentItem;
            }

            set
            {
                currentItem = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<ItemVm> BuyBtnClicked
        {
            get
            {
                return buyBtnClicked;
            }

            set
            {
                buyBtnClicked = value;
                RaisePropertyChanged();
            }
        }
        public MainViewModel()
        {
            Cart = new ObservableCollection<ItemVm>();
            BuyBtnClicked = new RelayCommand<ItemVm>((p) =>
            {
                Cart.Add(p);
            }, (p) => { return true; }
           );
            Items = new ObservableCollection<ItemVm>();
            GenerateDemoData();



        }

        private void GenerateDemoData()
        {
            Items.Add(new ItemVm("MY Lego", new BitmapImage(new Uri("Image/lego1.jpg", UriKind.Relative)), "-"));
            Items.Add(new ItemVm("MY Playmobil", new BitmapImage(new Uri("Image/playmobil1.jpg", UriKind.Relative)), "-"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 2", new BitmapImage(new Uri("Image/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", new BitmapImage(new Uri("Image/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVm("Playmobil 2", new BitmapImage(new Uri("Image/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", new BitmapImage(new Uri("Image/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVm("Playmobil 2", new BitmapImage(new Uri("Image/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", new BitmapImage(new Uri("Image/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVm("Playmobil 2", new BitmapImage(new Uri("Image/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", new BitmapImage(new Uri("Image/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVm("Playmobil 2", new BitmapImage(new Uri("Image/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVm("Playmobil 3", new BitmapImage(new Uri("Image/playmobil3.jpg", UriKind.Relative)), "10+"));

        }
    }
}