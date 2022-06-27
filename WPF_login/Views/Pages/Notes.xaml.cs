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
using System.Windows.Navigation;
using System.Windows.Shapes;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using WPF_login.Models;

namespace WPF_login.Views.Pages
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Page
    {
        public  Notes()
        {
            InitializeComponent();
            DataContext = this;
            var client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            string id = "rinhtt";    // Client-Id mit Zuffalssstring
            client.Connect(id);
            var payload = new ServerContext();
            payload.ClientId = "rinhtt";
            payload.Url = "manage/devicelist";
           
            client.Publish("device", UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));
            client.Subscribe(new[] { "response/default/rinhtt" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            //client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgPublishReceived += async (object sender, MqttMsgPublishEventArgs e) => {
                string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
                var msg = JsonConvert.DeserializeObject<Obj>(ReceivedMessage);
                var newValue = msg.Value;
                //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
              await Application.Current.Dispatcher.InvokeAsync(() => { dataGrid.ItemsSource = newValue; });

            };
        
                
            
        }
        //public static List<senser> senserInfolst { get; set; }
        //public static string txtTopic { get; set; }
        //static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        //{
        //    string ReceivedMessage = Encoding.UTF8.GetString(e.Message);

        //    //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
        //    Application.Current.Dispatcher.InvokeAsync(() => {  dataGrid.ItemsSource = ReceivedMessage; });

        //}
    }
}
