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

using CodingDojo6.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using CodingDojo6.Interfaces;
using CodingDojo6.ViewModel;
namespace CodingDojo6.ViewModel
{
    public class MessageBarVm : ViewModelBase, IMessageBar
    {
        private Messenger messenger = null;
        private string message;
        private BitmapImage symbol;
        private DispatcherTimer timer;
        private int displayTime = 2;
        private Visibility visible;

        public String Message {
            get {
                return message;
            }
            set {
                message = value;
                RaisePropertyChanged();
            }
        }

        public BitmapImage Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
                RaisePropertyChanged();
            }
        }
      
       

        public Visibility Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
                RaisePropertyChanged();
            }
        }
        public MessageBarVm() {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, displayTime);
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Symbol = null;
            Message = "";
            timer.Stop();
            Visible = Visibility.Hidden;
        }

        public void SetDisplayTime(int time) {
            displayTime = time;
        }

        public void ShowInfo(Message msg)
        {
            Visible = Visibility.Visible;
            switch (msg.State)
            {
                case MessageState.Warning:
                    Symbol = new BitmapImage(new Uri("../Image/state_Warning.png", UriKind.Relative));
                    break;
                case MessageState.Error:
                    Symbol = new BitmapImage(new Uri("../Image/state_Error.png", UriKind.Relative));
                    break;
                case MessageState.Info:
                    Symbol = new BitmapImage(new Uri("Image/state_Info.png", UriKind.Relative));
                    break;
                case MessageState.Ok:
                    Symbol = new BitmapImage(new Uri("../Image/state_Ok.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
            Message = msg.Text;
            timer.Start();
        }


        public void RegisterOnMessage(Messenger messanger, string token)
        {
            this.messenger = messanger;
            messenger.Register<PropertyChangedMessage<Message>>(this, token, shwContent);
        }

        private void shwContent(PropertyChangedMessage<Message> obj)
        {
            ShowInfo(obj.NewValue);
        }

       
    }
}