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

namespace WPF_login.Views.Rooms
{
    /// <summary>
    /// Interaction logic for MainRoom.xaml
    /// </summary>
    public partial class MainRoom : Window
    {
        string roomId;
        public MainRoom()
        {
            InitializeComponent();
        }
        public MainRoom(string roomId)
        {
            InitializeComponent();
            DataContext = this;
            this.roomId = roomId;
            //PagesNavigation.Navigate(new System.Uri("Views/Floors/FloorData.xaml?floorId="+floorId, UriKind.RelativeOrAbsolute));
            PagesNavigation.Navigate(new RoomData(roomId));
        }
        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            // PagesNavigation.Navigate(new HomePage());

            PagesNavigation.Navigate(new RoomData(roomId));
        }

        private void rdPayment_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new NodeList(roomId));
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
