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
    /// Interaction logic for TuKDSB.xaml
    /// </summary>
    public partial class TuKDSB : UserControl
    {
        public event EventHandler EndButtonClicked;
        public TuKDSB()
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
            var blueColor = Color.FromRgb(0, 191, 255);
            txtTrangThai.Text = "READY";
            txtTrangThai.Foreground = new SolidColorBrush(blueColor);
            glowTrangThai.Color = blueColor;

            // 2. BẮN PHÁO SÁNG: Báo cho Form1 xử lý việc ẩn sơ đồ
            EndButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
