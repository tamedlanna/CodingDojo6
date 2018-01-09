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
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace CodingDojo6.ViewModel
{
    public class MessageBarVm : ViewModelBase, ImessageBar
    {
        private Messenger messenger = null;
        private string message;
        private BitmapImage image;
        private DispatcherTimer timer;
        private int DisplayTime = 2;
        private Visibility visible;


    }
}