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
using Newtonsoft.Json;

namespace WPF_login.Views.Pages
{
    /// <summary>
    /// Interaction logic for SoundsPage.xaml
    /// </summary>
    public partial class SoundsPage : Page
    {
       
        public SoundsPage()
        {
            InitializeComponent();
            #region
            //client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            //id = "rinhtt";    // Client-Id mit Zuffalssstring
            //client.Connect(id);
            //var payload = new ServerContext();
            //payload.ClientId = "rinhtt";
            //payload.Url = "config/getbuild";
            ////payload.Token = System.Windows.Application.Current.Properties["Token"].ToString();
            //client.Publish("device", UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));
            //client.Subscribe(new[] { "response/default/rinhtt" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            ////client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            //client.MqttMsgPublishReceived += async (object sender, MqttMsgPublishEventArgs e) =>
            //{
            //    string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            //    var msg = JsonConvert.DeserializeObject<ObjConvert>(ReceivedMessage);
            //    var newValue = (Building)msg.Value;
            //    //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
            //    await Application.Current.Dispatcher.InvokeAsync(() =>
            //    {
            //        //ColumnDefinition colDef1 = new ColumnDefinition();
            //        //ColumnDefinition colDef2 = new ColumnDefinition();
            //        //ColumnDefinition colDef3 = new ColumnDefinition();
            //        //ColumnDefinition colDef4 = new ColumnDefinition();
            //        //ColumnDefinition colDef5 = new ColumnDefinition();
            //        //Roomlst.ColumnDefinitions.Add(colDef1);
            //        //Roomlst.ColumnDefinitions.Add(colDef2);
            //        //Roomlst.ColumnDefinitions.Add(colDef3);
            //        //Roomlst.ColumnDefinitions.Add(colDef4);
            //        //Roomlst.ColumnDefinitions.Add(colDef5);
            //        //double kq = Convert.ToDouble(newValue.floors.Count) / 5.0;
            //        //var a = 0;
            //        //if ( kq <= 1)
            //        //{
            //        //    RowDefinition rowDef1 = new RowDefinition();
            //        //}
            //        //else
            //        //{
            //        //   for(int i = 0; i < kq + 1; i++)
            //        //   {
            //        //     RowDefinition rowDef = new RowDefinition();
            //        //        a++;
            //        //   }
            //        //}

            //        //foreach(var item in newValue.floors)
            //        //{

            //        //}

            //    });
            //};
            #endregion

        }

        private void getFloor(object sender, MouseButtonEventArgs e)
        {


            MessageBoxResult message = MessageBox.Show("Bạn có chắc chắn chọn xem thông tin tầng này ?");
            if (message.Equals(MessageBoxResult.OK))
            {
                new Floors.MainFloor("F1").Show();

            }
        }
    }
}
