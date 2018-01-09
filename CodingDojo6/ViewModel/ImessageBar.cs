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

using GalaSoft.MvvmLight.Messaging;

namespace CodingDojo6.ViewModel
{
    public interface ImessageBar
    {
        void RegisterOnMessage(Messenger messanger, string token);
        void SetDisplayTime(int time);
        void ShowInfo(Message msg);
    }
}