using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;

namespace HeThongPhat
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // --- HÀM HELPER: CHUYÊN ĐỂ SẢN XUẤT RA 1 CÁI CARD WPF SIÊU ĐẸP ---
        // Bo góc (`CornerRadius`) và Bóng đổ (`DropShadowEffect`) là mặc định, cực sắc nét.
        // Đã thêm tham số 'windowTag' để gắn thông tin cửa sổ vào thẻ
        private Border CreateModernDataCard(string title, string subtitle, Color themeColor, string iconEmoji, string windowTag)
        {
            // 1. Chỉ giữ lại Kích thước, Margin và Tag (Vì mỗi thẻ giống nhau cái này)
            var cardFrame = new Border
            {
                Width = 230,
                Height = 190,
                Margin = new Thickness(0, 0, 25, 25),
                Tag = windowTag // Gắn tên cửa sổ vào đây để code biết cửa sổ nào cần mở
            };

            // 2. BÍ THUẬT: Gọi Style có chứa hiệu ứng Hover từ file XAML đắp vào đây
            cardFrame.Style = (Style)FindResource("RadarCardStyle");

            // ĐÃ XÓA ĐOẠN cardFrame.Effect VÌ TRONG STYLE ĐÃ CÓ SẴN BÓNG ĐỔ RỒI NHÉ NAM!

            // 3. Phần ruột bên trong (Icon, Chữ) giữ nguyên y hệt
            var cardContent = new StackPanel { VerticalAlignment = VerticalAlignment.Center };
            cardFrame.Child = cardContent;

            var iconCircle = new Border
            {
                Width = 60,
                Height = 60,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 15),
                CornerRadius = new CornerRadius(30),
                Background = new SolidColorBrush(Color.FromArgb(50, themeColor.R, themeColor.G, themeColor.B))
            };

            iconCircle.Child = new TextBlock
            {
                Text = iconEmoji,
                FontSize = 26,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            cardContent.Children.Add(iconCircle);

            cardContent.Children.Add(new TextBlock
            {
                Text = title,
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Black,
                HorizontalAlignment = HorizontalAlignment.Center
            });

            cardContent.Children.Add(new TextBlock
            {
                Text = subtitle,
                FontSize = 10,
                Foreground = Brushes.Gray,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0)
            });

            return cardFrame;
        }
        // ==========================================
        // SỰ KIỆN BẤM VÀO "Giáo trình " TRÊN SIDEBAR
        // ==========================================
        private void MenuGiaoTrinh_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // 1. Đổi dòng tiêu đề
            txtMainTitle.Text = "📚 GIÁO TRÌNH HỆ THỐNG RADAR";
            
            // 2. Xóa sạch các thẻ cũ trên màn hình
            wrpCards.Children.Clear();

            // 3. Khai báo kèm tên cửa sổ
            

            // 4. Vòng lặp vẽ 5 cái Thẻ (Card) mới tinh lên màn hình            
        }
        // ==========================================
        // SỰ KIỆN BẤM VÀO "Bài Giảng " TRÊN SIDEBAR
        // ==========================================
        private void MenuBaiGiang_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // 1. Đổi dòng tiêu đề
            txtMainTitle.Text = "📂 BÀI GIẢNG HỆ THỐNG RADAR";
            
            // 2. Xóa sạch các thẻ cũ trên màn hình
            wrpCards.Children.Clear();

            // 3. Khai báo kèm tên cửa sổ


            // 4. Vòng lặp vẽ 5 cái Thẻ (Card) mới tinh lên màn hình            
        }
        // ==========================================
        // SỰ KIỆN BẤM VÀO "DỮ LIỆU MÔ PHỎNG" TRÊN SIDEBAR
        // ==========================================
        private void MenuDuLieuMoPhong_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // 1. Đổi dòng tiêu đề
            txtMainTitle.Text = "📝 DỮ LIỆU MÔ PHỎNG HỆ THỐNG RADAR";
            
            // 2. Xóa sạch các thẻ cũ trên màn hình
            wrpCards.Children.Clear();

            // 3. Khai báo 5 khối dữ liệu mới lấy từ sơ đồ Nam gửi, kèm tên cửa sổ
            var radarModules = new[]
            {
                new { Title = "Tạo tín hiệu phát", Sub = "KHỐI CHỨC NĂNG", Color = Color.FromRgb(76, 175, 80), Emoji = "📡", Window = "TuTTH" },
                new { Title = "Khuếch đại sơ bộ", Sub = "KHỐI CHỨC NĂNG", Color = Color.FromRgb(33, 150, 243), Emoji = "📻", Window = "TuKDSB" },
                new { Title = "Khuếch đại công suất", Sub = "KHỐI CHỨC NĂNG", Color = Color.FromRgb(244, 67, 54), Emoji = "🔋", Window = "TuKDCS" },
                new { Title = "Tủ điều chế", Sub = "KHỐI CHỨC NĂNG", Color = Color.FromRgb(255, 87, 34), Emoji = "🎛️", Window = "TuDC" },
                new { Title = "Nắn dòng cao áp", Sub = "KHỐI CHỨC NĂNG", Color = Color.FromRgb(233, 30, 99), Emoji = "⚡", Window = "TunanDCA" }
            };

            // 4. Vòng lặp vẽ 5 cái Thẻ (Card) mới tinh lên màn hình
            foreach (var module in radarModules)
            {
                // Truyền module.Window vào làm windowTag
                var card = CreateModernDataCard(module.Title, module.Sub, module.Color, module.Emoji, module.Window);

                // Gắn sự kiện click cho thẻ để mở cửa sổ
                card.MouseLeftButtonDown += Card_MouseLeftButtonDown;

                wrpCards.Children.Add(card);
            }
        }
        // ==========================================
        // SỰ KIỆN BẤM VÀO "Thi TN"TRÊN SIDEBAR
        // ==========================================
        private void MenuTN_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // 1. Đổi dòng tiêu đề
            txtMainTitle.Text = "📝 CÁC CÂU HỎI TRẮC NGHIỆM VỀ HỆ THỐNG";
            
            // 2. Xóa sạch các thẻ cũ trên màn hình
            wrpCards.Children.Clear();

            // 3. Khai báo kèm tên cửa sổ


            // 4. Vòng lặp vẽ 5 cái Thẻ (Card) mới tinh lên màn hình            
        }
        // ==========================================
        // SỰ KIỆN BẤM VÀO "Video " TRÊN SIDEBAR
        // ==========================================
        private void MenuVideo_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // 1. Đổi dòng tiêu đề
            txtMainTitle.Text = "🎬 VIDEO DEMO";
            
            // 2. Xóa sạch các thẻ cũ trên màn hình
            wrpCards.Children.Clear();

            // 3. Khai báo kèm tên cửa sổ


            // 4. Vòng lặp vẽ 5 cái Thẻ (Card) mới tinh lên màn hình            
        }
        // ==========================================
        // SỰ KIỆN BẤM VÀO THẺ DỮ LIỆU TRÊN MÀN HÌNH CHÍNH
        // ==========================================
        private void Card_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Lấy Border được click
            Border clickedCard = sender as Border;
            if (clickedCard == null || clickedCard.Tag == null) return;

            string controlName = clickedCard.Tag.ToString();

            // Khai báo một UserControl thay vì Window
            UserControl targetControl = null;
            string windowTitle = "Chi tiết sơ đồ";

            // Tạo UserControl tương ứng dựa trên Tag Nam đã đặt
            switch (controlName)
            {
                case "TuDC":
                    targetControl = new TuDC();
                    windowTitle = "Sơ đồ Tủ điều chế";
                    break;
                case "TunanDCA":
                    targetControl = new TunanDCA();
                    windowTitle = "Sơ đồ Nắn dòng cao áp";
                    break;
                case "TuKDSB":
                    targetControl = new TuKDSB();
                    windowTitle = "Sơ đồ Khuếch đại sơ bộ";
                    break;
                case "TuKDCS":
                    targetControl = new TuKDCS();
                    windowTitle = "Sơ đồ Khuếch đại công suất";
                    break;
                case "TuTTH":
                    targetControl = new TuTTH();
                    windowTitle = "Sơ đồ Tạo tín hiệu thăm dò";
                    break;
            }

            if (targetControl != null)
            {
                // BÍ THUẬT: Tạo một cái Window "vỏ bọc" và nhét UserControl của Nam vào
                Window popupWindow = new Window
                {
                    Title = windowTitle,
                    Content = targetControl, // Nhét bức tranh (UserControl) vào khung (Window)
                    WindowStyle = WindowStyle.None,        // Xóa thanh tiêu đề (mất nút X, thu bé)
                    WindowState = WindowState.Maximized,   // Phóng to tràn toàn bộ màn hình
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    Owner = this,
                    // WindowStyle = WindowStyle.ToolWindow // Bỏ comment dòng này nếu muốn cửa sổ popup trông giống thanh công cụ nhỏ
                };

                popupWindow.Show(); // Hiển thị cửa sổ chứa UserControl lên
            }
        }

        // ==========================================
        // SỰ KIỆN BẤM NÚT THOÁT TRÊN SIDEBAR
        // ==========================================
        private void BtnThoat_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}