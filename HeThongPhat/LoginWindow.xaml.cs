using System.Windows;
using System.Windows.Input;

namespace HeThongPhat
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            // Đồng bộ mật khẩu lúc khởi động
            txtPassVisible.Text = txtPassHidden.Password;
        }

        // Chức năng: Kéo thả cửa sổ lơ lửng
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        // Chức năng: Bấm nút Đăng Nhập
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text == "viewer" && txtPassHidden.Password == "123456")
            {
                // Mở giao diện chính và đóng cửa sổ đăng nhập
                var main = new MainWindow();
                main.Show();

                // Nếu cửa sổ đăng nhập là cửa sổ chính của ứng dụng, đặt MainWindow mới
                if (Application.Current != null && Application.Current.MainWindow == this)
                {
                    Application.Current.MainWindow = main;
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Chức năng: Đóng mở bảng Cài đặt
        private void btnToggleSettings_Click(object sender, RoutedEventArgs e)
        {
            if (LoginPanel.Visibility == Visibility.Visible)
            {
                LoginPanel.Visibility = Visibility.Collapsed;
                SettingsPanel.Visibility = Visibility.Visible;
            }
            else
            {
                SettingsPanel.Visibility = Visibility.Collapsed;
                LoginPanel.Visibility = Visibility.Visible;
            }
        }

        // Chức năng: Bật/Tắt con mắt nhìn mật khẩu
        private void btnTogglePass_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassHidden.Visibility == Visibility.Visible)
            {
                // Mở mắt (Hiện Text, Ẩn Password)
                txtPassHidden.Visibility = Visibility.Collapsed;
                txtPassVisible.Visibility = Visibility.Visible;
                txtTogglePassGlyph.Text = "👁\u20E0"; // Ký hiệu mắt gạch chéo

                txtPassVisible.Text = txtPassHidden.Password;
                txtPassVisible.Focus();
                txtPassVisible.SelectionStart = txtPassVisible.Text.Length;
            }
            else
            {
                // Nhắm mắt (Hiện Password, Ẩn Text)
                txtPassHidden.Visibility = Visibility.Visible;
                txtPassVisible.Visibility = Visibility.Collapsed;
                txtTogglePassGlyph.Text = "👁"; // Ký hiệu mắt bình thường

                txtPassHidden.Password = txtPassVisible.Text;
                txtPassHidden.Focus();
            }
        }
    }
}