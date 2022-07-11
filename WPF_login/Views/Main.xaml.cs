
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using WPF_login.Models;

namespace WPF_login.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
         MqttClient client;
         string id;
        public Main()
        {
            InitializeComponent();
            PagesNavigation.Navigate(new System.Uri("Views/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
            Thread thread = new Thread(() =>{
                client = new MqttClient("localhost");
                id = "bich";

                client.Subscribe(new[] { "alert" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

                client.MqttMsgPublishReceived += async (object sender, MqttMsgPublishEventArgs e) =>
                {
                    string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
                    var msg = JsonConvert.DeserializeObject<ObjConvert>(ReceivedMessage);
                    var newValue = JsonConvert.DeserializeObject<NodeModel>(msg.Value.ToString());
                    //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        new WPF_login.Views.Support.Dialog(newValue).Show();


                    });
                   
                };

              

                client.Connect(id);
            });
            thread.Start();
            //Task.Run(()=>{
            //    client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            //    id = "rinhtt";    // Client-Id mit Zuffalssstring

            //    client.MqttMsgPublishReceived += async (object sender, MqttMsgPublishEventArgs e) =>
            //    {
            //        string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            //        var msg = JsonConvert.DeserializeObject<ObjConvert>(ReceivedMessage);
            //        var newValue = (NodeModel)msg.Value;
            //        //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
            //        await Application.Current.Dispatcher.InvokeAsync(() =>
            //        {
            //            MessageBoxResult result = MessageBox.Show("Cháy rồi");


            //        });

            //    };

            //    client.Subscribe(new[] { "alert" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });

            //    client.Connect(id);

            //});

            
           

      
           

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
