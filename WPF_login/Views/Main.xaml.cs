
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using uPLibrary.Networking.M2Mqtt;


namespace WPF_login.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
       
        public Main()
        {
            InitializeComponent();

            //client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            //id = "rinhtt";    // Client-Id mit Zuffalssstring
           
            //var payload = new ServerContext();
            //payload.ClientId = "rinhtt";
            //payload.Url = "manage/nodesum";
            ////payload.Token = System.Windows.Application.Current.Properties["Token"].ToString();
            //client.Publish("device", UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));
            //client.Subscribe(new[] { "alert" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            ////client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            //client.MqttMsgPublishReceived += mqtt_publish_received;
            ////    async (object sender, MqttMsgPublishEventArgs e) =>
            ////{
            ////    string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            ////    var msg = JsonConvert.DeserializeObject<ObjConvert>(ReceivedMessage);
            ////    var newValue = (NodeModel)msg.Value;
            ////    //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
            ////    await Application.Current.Dispatcher.InvokeAsync(() => {
            ////        MessageBoxResult result = MessageBox.Show("Cháy rồi");
            ////        this.DataContext = newValue;

            ////    });

            ////};
            //client.Connect(id);
            PagesNavigation.Navigate(new System.Uri("Views/Pages/Home.xaml", UriKind.RelativeOrAbsolute));

        }
        //public  void mqtt_publish_received(object sender, MqttMsgPublishEventArgs e)
        //{
        //    string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
        //    var msg = JsonConvert.DeserializeObject<ObjConvert>(ReceivedMessage);
        //    var newValue = (NodeModel)msg.Value;
        //    Dispatcher.Invoke(delegate {              // we need this construction because the receiving code in the library and the UI with textbox run on different threads
        //        MessageBoxResult result = MessageBox.Show("Cháy rồi");
        //    });
            
        //    //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
        //    //await Application.Current.Dispatcher.InvokeAsync(() => {
        //    //    MessageBoxResult result = MessageBox.Show("Cháy rồi");
        //    //    this.DataContext = newValue;

        //    //});
        //}
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            // PagesNavigation.Navigate(new HomePage());

            PagesNavigation.Navigate(new System.Uri("Views/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdSounds_Click(object sender, RoutedEventArgs e)
        {
             PagesNavigation.Navigate(new System.Uri("Views/Pages/SoundsPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdNotes_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Views/Pages/Notes.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdPayment_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Views/Pages/PaymentPage.xaml", UriKind.RelativeOrAbsolute));
        }
        
    }
}
