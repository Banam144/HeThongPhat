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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeThongPhat
{
    public partial class TuKDCS : UserControl
    {
        public event EventHandler EndButtonClicked;
        private Storyboard sb; // Biến điều khiển hoạt ảnh

        public TuKDCS()
        {
            InitializeComponent();

            // =======================================================
            // KHỞI TẠO: Tàng hình dây và nhịp tim ngay khi mở UserControl
            // =======================================================
            day1.Fill = Brushes.Transparent; day1.Stroke = Brushes.Transparent;
            day2.Fill = Brushes.Transparent; day2.Stroke = Brushes.Transparent;
            day3.Fill = Brushes.Transparent; day3.Stroke = Brushes.Transparent;
            day4.Fill = Brushes.Transparent; day4.Stroke = Brushes.Transparent;
            day5.Fill = Brushes.Transparent; day5.Stroke = Brushes.Transparent;
            day6.Fill = Brushes.Transparent; day6.Stroke = Brushes.Transparent;

            nhipTimMau1.Opacity = 0; nhipTimMau2.Opacity = 0;
            nhipTimMau3.Opacity = 0; nhipTimMau4.Opacity = 0;
            nhipTimMau5.Opacity = 0; nhipTimMau6.Opacity = 0;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            // === 1. CHỨC NĂNG CŨ (Đổi màu UI) ===
            var greenColor = System.Windows.Media.Color.FromRgb(40, 167, 69);
            txtTrangThai.Text = "ĐANG PHÁT";
            txtTrangThai.Foreground = new System.Windows.Media.SolidColorBrush(greenColor);
            glowTrangThai.Color = greenColor;

            // === 2. ĐIỀU KHIỂN HOẠT ẢNH MÔ PHỎNG ===
            if (sb != null)
            {
                // Nếu đã khởi tạo rồi (đang bị Pause), thì Resume chạy tiếp
                sb.Resume(this);
                return;
            }

            // Nếu chạy lần đầu, xây dựng kịch bản
            sb = new Storyboard();

            void ChayNhipTim(double startTime, Path pulse, Path linePath, double duration)
            {
                PathGeometry route = PathGeometry.CreateFromGeometry(linePath.Data);

                DoubleAnimation opacIn = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.01)) { BeginTime = TimeSpan.FromSeconds(startTime) };
                Storyboard.SetTarget(opacIn, pulse);
                Storyboard.SetTargetProperty(opacIn, new PropertyPath("Opacity"));
                sb.Children.Add(opacIn);

                DoubleAnimationUsingPath animX = new DoubleAnimationUsingPath { PathGeometry = route, Source = PathAnimationSource.X, Duration = TimeSpan.FromSeconds(duration), BeginTime = TimeSpan.FromSeconds(startTime) };
                Storyboard.SetTarget(animX, pulse);
                Storyboard.SetTargetProperty(animX, new PropertyPath(System.Windows.Controls.Canvas.LeftProperty));
                sb.Children.Add(animX);

                DoubleAnimationUsingPath animY = new DoubleAnimationUsingPath { PathGeometry = route, Source = PathAnimationSource.Y, Duration = TimeSpan.FromSeconds(duration), BeginTime = TimeSpan.FromSeconds(startTime) };
                Storyboard.SetTarget(animY, pulse);
                Storyboard.SetTargetProperty(animY, new PropertyPath(System.Windows.Controls.Canvas.TopProperty));
                sb.Children.Add(animY);

                DoubleAnimation opacOut = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.01)) { BeginTime = TimeSpan.FromSeconds(startTime + duration) };
                Storyboard.SetTarget(opacOut, pulse);
                Storyboard.SetTargetProperty(opacOut, new PropertyPath("Opacity"));
                sb.Children.Add(opacOut);
            }

            void BatSangLopPhu(double startTime, System.Windows.Shapes.Rectangle lightLayer)
            {
                DoubleAnimation bgAnim = new DoubleAnimation(0, 0.7, TimeSpan.FromSeconds(0.1)) { BeginTime = TimeSpan.FromSeconds(startTime) };
                Storyboard.SetTarget(bgAnim, lightLayer);
                Storyboard.SetTargetProperty(bgAnim, new PropertyPath("Opacity"));
                sb.Children.Add(bgAnim);
            }

            // Kịch bản thời gian chậm gấp đôi
            ChayNhipTim(0, nhipTimMau2, day1, 6.0);
            ChayNhipTim(0, nhipTimMau1, day2, 6.0);

            BatSangLopPhu(2.6, light_diot);
            BatSangLopPhu(3.8, light_194BB50);
            BatSangLopPhu(6.0, light_denKlistron);

            ChayNhipTim(6.0, nhipTimMau3, day3, 3.0);

            BatSangLopPhu(7.0, light_1944BB05);
            BatSangLopPhu(9.0, light_1944BB08);

            ChayNhipTim(9.0, nhipTimMau4, day4, 4.0);
            ChayNhipTim(9.0, nhipTimMau5, day5, 2.0);
            ChayNhipTim(9.0, nhipTimMau6, day6, 7.0);

            BatSangLopPhu(11.0, light_194BB72);
            BatSangLopPhu(11.2, light_194TB02M);
            BatSangLopPhu(15.2, light_Hop);
            BatSangLopPhu(16.0, light_194TB02);

            sb.Begin(this, true); // True = Cho phép tạm dừng
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            // === 1. CHỨC NĂNG CŨ (Đổi màu UI) ===
            var orangeColor = System.Windows.Media.Color.FromRgb(253, 126, 20);
            txtTrangThai.Text = "TẠM DỪNG";
            txtTrangThai.Foreground = new System.Windows.Media.SolidColorBrush(orangeColor);
            glowTrangThai.Color = orangeColor;

            // === 2. DỪNG HOẠT ẢNH ===
            if (sb != null)
            {
                sb.Pause(this);
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            // Tìm cái Window đang chứa UserControl này và đóng nó
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
    }
}