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
using WPF_login.Models;

namespace WPF_login.Views.Support
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        public Dialog(NodeModel node)
        {
            InitializeComponent();
            Border border = new Border();
           
            ImageBrush image = new ImageBrush();
            image.ImageSource = new BitmapImage(new Uri( @"Image/bell1.jpg", UriKind.Relative));
            Image image1 = new Image();
            image1.Source = image.ImageSource;
            border.Child = image1;
            Grid.SetColumn(border, 0);
            Grid.SetRow(border, 0);
            Label label = new Label();
            if (node.status == 1)
            {
                label.Content = node.Id + " đang gặp sự cố";
            }
            if(node.status == 2)
            {
                /*
                 0 báo nhiệt
                 1 báo gas
                 2 báo khói
                 3 cảm biến độ ẩm
               */
                switch (node.function)
                {
                    case 0: label.Content = node.Id + " :Phát hiện nhiệt độ cao bất thường"; break;
                    case 1: label.Content = node.Id + " : Phát hiện nồng độ khí gas cao bất thường"; break;
                    case 2: label.Content = node.Id + " : Phát hiện nồng độ khói gas cao bất thường"; break;
                }
            }
            //B01F01P01
           
            Label label1 = new Label();
            label1.VerticalContentAlignment = VerticalAlignment.Center;
            label.VerticalContentAlignment = VerticalAlignment.Center;
            label1.Content = "Vị trí : " +" Phòng "+ int.Parse(node.location.Substring(7, 2)) +" Tầng "+ int.Parse(node.location.Substring(4, 2)) + " Tòa "+int.Parse(node.location.Substring(1, 2));
            Border border1 = new Border();
            Border border2 = new Border();
            border1.Child = label;
            border2.Child = label1;
            label.FontSize = 14;
            label.FontWeight= FontWeights.Bold;
            label1.FontWeight = FontWeights.Bold;

            label1.FontSize = 14;
            Grid.SetColumn(border1, 0);
            Grid.SetRow(border1, 1);
            Grid.SetColumn(border2, 0);
            Grid.SetRow(border2, 2);
            AlertList.Children.Add(border1);
            AlertList.Children.Add(border2);
            AlertList.Children.Add(border);
        }

       
    }
}
