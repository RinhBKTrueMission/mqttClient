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
using System.Windows.Shapes;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using WPF_login.Models;

namespace WPF_login.Views.Floors
{
    /// <summary>
    /// Interaction logic for MainFloor.xaml
    /// </summary>
    public partial class MainFloor : Window
    {
        string floorId;
        public MainFloor()
        {
            InitializeComponent();
        }
        public MainFloor(string floorId)
        {
            InitializeComponent();
            DataContext = this;
            this.floorId = floorId;
            //PagesNavigation.Navigate(new System.Uri("Views/Floors/FloorData.xaml?floorId="+floorId, UriKind.RelativeOrAbsolute));
            PagesNavigation.Navigate(new FloorData(floorId));
        }
        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            // PagesNavigation.Navigate(new HomePage());

            PagesNavigation.Navigate(new FloorData(floorId));
        }

        private void rdPayment_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new FloorData(floorId));
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
    }
}
