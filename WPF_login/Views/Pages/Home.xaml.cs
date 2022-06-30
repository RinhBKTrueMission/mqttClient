using Newtonsoft.Json;
using Syncfusion.UI.Xaml.Gauges;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            DataContext = this;



            var client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            string id = "rinhtt";    // Client-Id mit Zuffalssstring
            client.Connect(id);
            var payload = new ServerContext();
            payload.ClientId = "rinhtt";
            payload.Url = "manage/nodesum";

            client.Publish("device", UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));
            client.Subscribe(new[] { "response/tong" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            //client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgPublishReceived += async (object sender, MqttMsgPublishEventArgs e) =>
            {
                string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
                var msg = JsonConvert.DeserializeObject<ObjSum>(ReceivedMessage);
                var newValue = msg.Value;
                //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
                await Application.Current.Dispatcher.InvokeAsync(() => { this.DataContext = newValue; });

            };
            //var nodelst = new nodeSumlstString();
            //nodelst.nhiet_do = new List<setDataString>()
            //{
            //    new setDataString("11:06 PM",new Random().Next(10, 99)),
            //     new setDataString("10:06 PM",new Random().Next(10, 99)),
            //      new setDataString("9:06 PM",new Random().Next(10, 99)),
            //       new setDataString("8:06 PM",new Random().Next(10, 99)),
            //        new setDataString("7:06 PM",new Random().Next(10, 99)),
            //         new setDataString("6:06 PM",new Random().Next(10, 99)),
            //          new setDataString("5:06 PM",new Random().Next(10, 99)),

            //};
            //nodelst.gas = new List<setDataString>()
            //{
            //    new setDataString("11:06 PM",new Random().Next(10, 99)),
            //     new setDataString("10:06 PM",new Random().Next(10, 99)),
            //      new setDataString("9:06 PM",new Random().Next(10, 99)),
            //       new setDataString("8:06 PM",new Random().Next(10, 99)),
            //        new setDataString("7:06 PM",new Random().Next(10, 99)),
            //         new setDataString("6:06 PM",new Random().Next(10, 99)),
            //          new setDataString("5:06 PM",new Random().Next(10, 99)),

            //};
            //nodelst.khoi = new List<setDataString>()
            //{
            //    new setDataString("11:06 PM",new Random().Next(10, 99)),
            //     new setDataString("10:06 PM",new Random().Next(10, 99)),
            //      new setDataString("9:06 PM",new Random().Next(10, 99)),
            //       new setDataString("8:06 PM",new Random().Next(10, 99)),
            //        new setDataString("7:06 PM",new Random().Next(10, 99)),
            //         new setDataString("6:06 PM",new Random().Next(10, 99)),
            //          new setDataString("5:06 PM",new Random().Next(10, 99)),

            //};
            //nodelst.do_am = new List<setDataString>()
            //{
            //    new setDataString("11:06 PM",new Random().Next(10, 99)),
            //     new setDataString("10:06 PM",new Random().Next(10, 99)),
            //      new setDataString("9:06 PM",new Random().Next(10, 99)),
            //       new setDataString("8:06 PM",new Random().Next(10, 99)),
            //        new setDataString("7:06 PM",new Random().Next(10, 99)),
            //         new setDataString("6:06 PM",new Random().Next(10, 99)),
            //          new setDataString("5:06 PM",new Random().Next(10, 99)),

            //};
            //nodelst.sum = new nodeSum();
            //nodelst.sum.nhiet_do = nodelst.sum.gas = nodelst.sum.khoi = nodelst.sum.do_am=60;
            //this.DataContext = nodelst;


        }
       
    }
}
