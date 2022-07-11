using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;

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
            payload.ClientId = "rinhtt5";
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

                    foreach (var node in newValue)
                    {
                        Border border = new Border();
                        border.Height = 100;
                        StackPanel stack = new StackPanel();
                        //stack.Children.Add();
                        border.Child = stack;
                        Border border1 = new Border();
                        Label label = new Label();
                        label = new Label();
                        label.Content = "ID : " + node.Id;
                        border1.Child = label;

                        Grid grid = new Grid();
                        RowDefinition rowf1 = new RowDefinition();
                        RowDefinition rowf2 = new RowDefinition();
                        RowDefinition rowf3 = new RowDefinition();
                        rowf1.Height = new GridLength(30);
                        rowf2.Height = new GridLength(60);
                        ColumnDefinition columnf1 = new ColumnDefinition();
                        ColumnDefinition columnf2 = new ColumnDefinition();
                        ColumnDefinition columnf3 = new ColumnDefinition();
                        ColumnDefinition columnf4 = new ColumnDefinition();
                        grid.ColumnDefinitions.Add(columnf1);
                        grid.ColumnDefinitions.Add(columnf2);
                        grid.ColumnDefinitions.Add(columnf3);
                        grid.ColumnDefinitions.Add(columnf4);
                        grid.RowDefinitions.Add(rowf1);
                        grid.RowDefinitions.Add(rowf2);
                        grid.RowDefinitions.Add(rowf3);


                        Label label1 = new Label();
                        label1.Content = "Chức năng";
                        label1.Height = 100;
                        grid.Children.Add(label1);
                        Grid.SetRow(label1, 0);
                        Grid.SetColumn(label1, 0);

                        Label label2 = new Label();
                        label2.Content = "Ví trí";
                        label2.Height = 100;
                        grid.Children.Add(label2);
                        Grid.SetRow(label2, 0);
                        Grid.SetColumn(label2, 1);

                        Label label3 = new Label();
                        label3.Content = "Giá trị gần đây";
                        label3.Height = 100;
                        grid.Children.Add(label3);
                        Grid.SetRow(label3, 0);
                        Grid.SetColumn(label3, 2);

                        Label label4 = new Label();
                        label4.Content = "Trạng thái";
                        label4.Height = 100;
                        grid.Children.Add(label4);
                        Grid.SetRow(label4, 0);
                        Grid.SetColumn(label4, 3);

                        Label label5 = new Label();
                        /*
                           0 báo nhiệt
                           1 báo gas
                           2 báo khói
                           3 cảm biến độ ẩm
                        */
                        if (node.function == 0)
                        {
                            label5.Content = "Báo nhiệt";
                        }
                        else if (node.function == 1)
                        {
                            label5.Content = "Báo khí gas";
                        }
                        else if (node.function == 2)
                        {
                            label5.Content = "Báo khói";
                        }
                        else if (node.function == 3)
                        {
                            label5.Content = "Báo độ ẩm";
                        }
                        label5.Height = 100;
                        grid.Children.Add(label5);
                        Grid.SetRow(label5, 1);
                        Grid.SetColumn(label5, 0);

                        Label label6 = new Label();
                        label6.Height = 100;
                        //"B01F01P01"
                        var build = int.Parse(node.location.Substring(1, 2));
                        var floor = int.Parse(node.location.Substring(4, 2));
                        var room = int.Parse(node.location.Substring(7, 2));
                        label6.Content = "Phòng " + room + " Tầng " + floor + " Tòa " + build;
                        grid.Children.Add(label6);
                        Grid.SetRow(label6, 1);
                        Grid.SetColumn(label6, 1);

                        Label label7 = new Label();
                        label7.Height = 100;
                        label7.Content =ConvertValue(node.listData.ToArray().Last<setData>().value,node.function);
                        grid.Children.Add(label7);
                        Grid.SetRow(label7, 1);
                        Grid.SetColumn(label7, 2);

                        Label label8 = new Label();
                        label8.Height = 100;
                        grid.Children.Add(label8);
                        Grid.SetRow(label8, 1);
                        Grid.SetColumn(label8, 3);
                        Border border2 = new Border();
                        border2.Child = grid;
                        grid.Height = 200;
                        border2.Height = 200;
                        border1.Margin = new Thickness(0, 10, 0, 0);
                        if (node.status == 0)
                        {
                            label8.Content = "Bình thường";
                            border1.Background = Brushes.SteelBlue;
                            border2.Background = Brushes.PowderBlue;
                        }
                        else if (node.status == 1)
                        {
                            label8.Content = "Sự cố";
                            border1.Background = Brushes.PaleGoldenrod;
                            border2.Background = Brushes.FloralWhite;
                        }
                        else
                        {
                            label8.Content = "Bình thường";
                            border1.Background = Brushes.Firebrick;
                            border2.Background = Brushes.Salmon;
                        }
                        stack.Children.Insert(0, border1);
                        stack.Children.Insert(1, border2);


                        Nodelst.Children.Add(border);




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
        /*
                           0 báo nhiệt
                           1 báo gas
                           2 báo khói
                           3 cảm biến độ ẩm
                        */
        private static string ConvertValue(double value,int style)
        {
            if (style == 0)
            {
                return value + " °C";
            }
            else if(style==1 || style == 2)
            {
                return value + " ppm";
            }
            else
            {
                return value + " %";
            }
        }
    }
}
