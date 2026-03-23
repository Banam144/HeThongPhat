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
        private Storyboard sb;

        public TuKDCS()
        {
            InitializeComponent();

            // Ẩn nhịp tim
            nhipTimMau1.Opacity = 0; nhipTimMau2.Opacity = 0;
            nhipTimMau3.Opacity = 0; nhipTimMau4.Opacity = 0;
            nhipTimMau5.Opacity = 0; nhipTimMau6.Opacity = 0;

            // Ẩn lớp Text lúc ban đầu
            txt_diot.Opacity = 0; txt_194bb50.Opacity = 0; txt_denKlistron.Opacity = 0;
            txt_194bb05.Opacity = 0; txt_194bb08.Opacity = 0; txt_194bb72.Opacity = 0;
            txt_194tb02m.Opacity = 0; txt_hop.Opacity = 0; txt_194tb02.Opacity = 0;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var greenColor = System.Windows.Media.Color.FromRgb(40, 167, 69);
            txtTrangThai.Text = "ĐANG PHÁT";
            txtTrangThai.Foreground = new System.Windows.Media.SolidColorBrush(greenColor);
            glowTrangThai.Color = greenColor;

            if (sb != null)
            {
                sb.Resume(this);
                return;
            }

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

            void BatSangLopPhu(double startTime, UIElement lightLayer, UIElement textLayer)
            {
                DoubleAnimation bgAnim = new DoubleAnimation(0, 0.7, TimeSpan.FromSeconds(0.1)) { BeginTime = TimeSpan.FromSeconds(startTime) };
                Storyboard.SetTarget(bgAnim, lightLayer);
                Storyboard.SetTargetProperty(bgAnim, new PropertyPath("Opacity"));
                sb.Children.Add(bgAnim);

                DoubleAnimation txtAnim = new DoubleAnimation(0, 1.0, TimeSpan.FromSeconds(0.1)) { BeginTime = TimeSpan.FromSeconds(startTime) };
                Storyboard.SetTarget(txtAnim, textLayer);
                Storyboard.SetTargetProperty(txtAnim, new PropertyPath("Opacity"));
                sb.Children.Add(txtAnim);
            }

            // ==========================================================
            // KỊCH BẢN ĐÃ ĐƯỢC LÀM CHẬM LẠI MỘT NỬA (Nhân đôi thời gian)
            // ==========================================================

            // --- GIAI ĐOẠN 1: TỪ 0.0s ĐẾN 12.0s ---
            ChayNhipTim(0, nhipTimMau2, day1, 12.0); // Cũ là 6.0
            ChayNhipTim(0, nhipTimMau1, day2, 12.0);

            BatSangLopPhu(5.2, light_diot, txt_diot);       // Cũ là 2.6
            BatSangLopPhu(7.6, light_194bb50, txt_194bb50); // Cũ là 3.8
            BatSangLopPhu(12.0, light_denKlistron, txt_denKlistron); // Gặp nhau ở giây 12

            // --- GIAI ĐOẠN 2: TỪ 12.0s ĐẾN 18.0s ---
            ChayNhipTim(12.0, nhipTimMau3, day3, 6.0); // Cũ chạy từ 6.0 mất 3.0s

            BatSangLopPhu(14.0, light_194bb05, txt_194bb05); // Cũ là 7.0
            BatSangLopPhu(18.0, light_194bb08, txt_194bb08); // Cũ là 9.0

            // --- GIAI ĐOẠN CUỐI: TỪ 18.0s TRỞ ĐI ---
            ChayNhipTim(18.0, nhipTimMau4, day4, 8.0);  // Cũ chạy từ 9.0 mất 4.0s
            ChayNhipTim(18.0, nhipTimMau5, day5, 4.0);  // Cũ chạy từ 9.0 mất 2.0s
            ChayNhipTim(18.0, nhipTimMau6, day6, 14.0); // Cũ chạy từ 9.0 mất 7.0s

            BatSangLopPhu(22.0, light_194bb72, txt_194bb72);   // Cũ là 11.0
            BatSangLopPhu(22.4, light_194tb02m, txt_194tb02m); // Cũ là 11.2
            BatSangLopPhu(30.4, light_hop, txt_hop);           // Cũ là 15.2
            BatSangLopPhu(32.0, light_194tb02, txt_194tb02);   // Cũ là 16.0

            sb.Begin(this, true);
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            var orangeColor = System.Windows.Media.Color.FromRgb(253, 126, 20);
            txtTrangThai.Text = "TẠM DỪNG";
            txtTrangThai.Foreground = new System.Windows.Media.SolidColorBrush(orangeColor);
            glowTrangThai.Color = orangeColor;

            if (sb != null)
            {
                sb.Pause(this);
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }
    }
}