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
    /// Interaction logic for NodeList.xaml
    /// </summary>
    public partial class NodeList : Page
    {
        MqttClient client;
        string id;
        public NodeList()
        {
            InitializeComponent();
        }
        public NodeList(string roomId)
        {
            InitializeComponent();
            InitializeComponent();
            client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            id = "rinhtt";    // Client-Id mit Zuffalssstring
            client.Connect(id);
            var payload = new ServerContext();
            payload.ClientId = "rinhtt";
            payload.Url = "manage/NodeListinRoom";
            payload.Value = roomId;
            //payload.Token = System.Windows.Application.Current.Properties["Token"].ToString();
            client.Publish("device", UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));
            client.Subscribe(new[] { "response/nodelstInRoom" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            //client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgPublishReceived += async (object sender, MqttMsgPublishEventArgs e) =>
            {
                string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
                var msg = JsonConvert.DeserializeObject<ObjConvert>(ReceivedMessage);
                var newValue = JsonConvert.DeserializeObject<List<NodeModel>>(msg.Value.ToString());
                //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
                await Application.Current.Dispatcher.InvokeAsync(() =>
                {

                    double kq = Convert.ToDouble(newValue.Count) / 5.0;
                    var a = 0;
                    if (kq <= 1)
                    {
                        RowDefinition rowDef1 = new RowDefinition();
                    }
                    else
                    {
                        for (int i = 0; i < kq + 1; i++)
                        {
                            RowDefinition rowDef = new RowDefinition();
                            a++;
                        }
                    }
                    var x = 0;
                    var y = 0;
                    foreach (var item in newValue)
                    {

                        Border border = new Border();
                        Label label = new Label();
                        label.VerticalContentAlignment = VerticalAlignment.Center;
                        label.HorizontalContentAlignment = HorizontalAlignment.Center;
                        label.FontSize = 25;
                        label.Content = "Node " + item.Id.Substring(1);
                        label.Foreground = Brushes.Wheat;
                        border.Background = Brushes.Green;
                        border.CornerRadius = new CornerRadius(5);
                        border.Child = label;
                        border.MouseLeftButtonDown += getFloor;
                        border.Margin = new Thickness(10);
                        border.Height = 100;
                        border.VerticalAlignment = VerticalAlignment.Top;
                        Roomlst.Children.Add(border);
                        Grid.SetRow(border, x);
                        Grid.SetColumn(border, y);

                        if (y < 4) y++;
                        if (x < a - 1) x++;

                    }

                });
            };
        }
        private void getFloor(object sender, MouseButtonEventArgs e)
        {
            string room = e.Source.ToString().Split(' ')[1].Replace("Room", "P");
            string sourceName = e.Source.ToString().Split(' ')[1];
            MessageBoxResult message = MessageBox.Show("Bạn muốn xem chi tiết " + sourceName);
            if (message.Equals(MessageBoxResult.OK))
            {
                //new Floors.MainFloor("1").Show();

            }
        }
    }
}
