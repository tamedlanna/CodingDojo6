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
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;

namespace CodingDojo6.ViewModel
{
    public class MyToysVm : ViewModelBase
    {

        private Messenger messenger = new SimpleIoc.Default.GetInstance<Messenger>();
        public ObservableCollection<ItemVm> MyToys { get; set; }

        public MyToysVm(){
            MyToys = new ObservableCollection<ItemVm>();
            messenger.Register<PropertyChangedMessage<ItemVm>>(this, "write", update);
}

        private void update(PropertyChangedMessage<ItemVm> obj) {
            MyToys.Add(obj.NewValue);
        }
    }
}