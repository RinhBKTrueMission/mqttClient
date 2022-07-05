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
using MaterialDesignThemes.Wpf;
using WPF_login.Models;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Newtonsoft.Json;

namespace WPF_login.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MqttClient client;
        string id;
        public Login()
        {
            InitializeComponent();
            DataContext = this;

             client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
             id = "rinhtt";    // Client-Id mit Zuffalssstring
            client.Connect(id);
         
            //var payload = new ServerContext();
            //payload.ClientId = "rinhtt";
            //payload.Url = "account/login";

           
            client.Subscribe(new[] { "response/account/rinhtt" }, new[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            //client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgPublishReceived += async (object sender, MqttMsgPublishEventArgs e) =>
            {
                string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
                var msg = JsonConvert.DeserializeObject<ObjLog>(ReceivedMessage);
                var newValue = msg.Value.Token;
                if (newValue.ToString() != "-1")
                {
                    await Application.Current.Dispatcher.InvokeAsync(() => {
                        Console.WriteLine(dUsername + " " + dPassword + newValue);
                        System.Windows.Application.Current.Properties["Token"] = newValue;
                        var MainForm = new Main();
                        MainForm.Show();
                        this.Close();
                    });

                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Sai tài khoản hoặc mật khẩu ");
                }
                //Application.Current.Dispatcher.InvokeAsync(() => { senserInfolst = JsonConvert.DeserializeObject<List<senser>>(ReceivedMessage); });
                await Application.Current.Dispatcher.InvokeAsync(() => { this.DataContext = newValue; });

            };
        }

        //Theme Code ========================>
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        //===================================>

        public string dUsername { get; set; }
        protected string dPassword { private get; set; }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).dPassword = ((PasswordBox)sender).Password; }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void toggleTheme(object sender, RoutedEventArgs e)
        {
            //Theme Code ========================>
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }

            paletteHelper.SetTheme(theme);
            //===================================>
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void doLogin(object sender, RoutedEventArgs e)
        {
            var acc = new LoginModel();
            acc.username = dUsername;
            acc.password = dPassword;
            var payload = new ServerContext();
            payload.Value = acc;
            payload.Url = "User/login";
            client.Publish("account", UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));

            
            
        }
        private void doSignUp(object sender, RoutedEventArgs e)
        {
           
            if (dUsername == "admin")
            {
                Console.WriteLine(dUsername + " " + dPassword);
                var MainForm = new Main();
                MainForm.Show();
                this.Close();
            }
            var acc = new LoginModel();
            acc.username= dUsername;
            acc.password = dPassword;
            var payload = new ServerContext();
            payload.Value = acc;
            payload.Url = "User/CreateAccount";
            var client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            string id = "rinhtt";    // Client-Id mit Zuffalssstring
            client.Connect(id);
            client.Publish("account", UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload)));

        }
    }
}
