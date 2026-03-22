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

namespace HeThongPhat
{
    /// <summary>
    /// Interaction logic for TunanDCA.xaml
    /// </summary>
    public partial class TunanDCA : UserControl
    {
        public event EventHandler EndButtonClicked;
        public TunanDCA()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            // Màu xanh lá
            var greenColor = System.Windows.Media.Color.FromRgb(40, 167, 69);

            txtTrangThai.Text = "ĐANG PHÁT";
            txtTrangThai.Foreground = new System.Windows.Media.SolidColorBrush(greenColor);
            glowTrangThai.Color = greenColor; // Đổi cả màu ánh sáng phát ra
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            // Màu vàng cam
            var orangeColor = System.Windows.Media.Color.FromRgb(253, 126, 20);

            txtTrangThai.Text = "TẠM DỪNG";
            txtTrangThai.Foreground = new System.Windows.Media.SolidColorBrush(orangeColor);
            glowTrangThai.Color = orangeColor;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            // Tìm cái Window đang chứa UserControl này
            Window parentWindow = Window.GetWindow(this);

            // Nếu tìm thấy, đóng nó lại
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
    }
}
