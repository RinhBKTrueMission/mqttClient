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
using uPLibrary.Networking.M2Mqtt.Messages;

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
            //var client = new MqttClient("localhost", 1883, false, null, null, MqttSslProtocols.None);
            //string id = "rinhtt";    // Client-Id mit Zuffalssstring
            //client.Connect(id);
          
        }
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
