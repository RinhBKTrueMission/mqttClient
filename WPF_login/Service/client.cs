using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using WPF_login.Models;

namespace WPF_login.Service
{
   
    public class clientService
    {

        public clientService() { }
        static MqttClient client;
        static string id;

        public async static Task Start()
        {
            client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            id = "rinhtt";    // Client-Id mit Zuffalssstring



            client.Subscribe(new[] { "alert" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            client.MqttMsgPublishReceived += async (object sender, MqttMsgPublishEventArgs e) =>
            {
                string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
                var msg = JsonConvert.DeserializeObject<ObjConvert>(ReceivedMessage);
                var newValue = (NodeModel)msg.Value;
                //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    MessageBoxResult result = MessageBox.Show("Cháy rồi");


                });

            };
            client.Connect(id);
        }
    }
}
