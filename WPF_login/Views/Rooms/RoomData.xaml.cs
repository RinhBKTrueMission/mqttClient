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

namespace WPF_login.Views.Rooms
{
    /// <summary>
    /// Interaction logic for RoomData.xaml
    /// </summary>
    public partial class RoomData : Page
    {
        public RoomData()
        {
            InitializeComponent();
        }
       
        MqttClient client;
        string id;
        public RoomData(string roomId)
        {
            InitializeComponent();
            client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            id = "rinhtt";    // Client-Id mit Zuffalssstring

            var payload = new ServerContext();
            payload.ClientId = "rinhtt";
            payload.Url = "manage/NodeSumRoom";
            payload.Value = roomId;
            //payload.Token = System.Windows.Application.Current.Properties["Token"].ToString();
            client.Publish("device", UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));
            client.Subscribe(new[] { "response/tong/" + roomId }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            //client.Subscribe(new[] { "alert" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            //client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgPublishReceived += async (object sender, MqttMsgPublishEventArgs e) =>
            {

                string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
                var msg = JsonConvert.DeserializeObject<ObjSum>(ReceivedMessage);
                //if (msg.Action.Equals("manage_Alert"))
                //{
                //    //await Application.Current.Dispatcher.InvokeAsync(() => {
                //    MessageBoxResult result = MessageBox.Show("Cháy rồi");
                //    //});

                //    return;
                //}
                var newValue = msg.Value;
                //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
                await Application.Current.Dispatcher.InvokeAsync(() => { this.DataContext = newValue; });

            };
            client.Connect(id);
            //DataContext = this;
        }
    }
}
