using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.WindowFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Register_Page
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(0.5) // Продолжительность анимации в секундах
            };

            // Привязка анимации к свойству Opacity элемента (например, Grid или Window)
            MyGrid.BeginAnimation(Grid.OpacityProperty, fadeInAnimation);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = DBEntities.GetContext()
                    .User.FirstOrDefault(u => u.Login == LoginTb.Text);

                if (user == null)
                {
                    MBClass.ShowErrorPopup("Не верный логин!", Application.Current.MainWindow);
                    LoginTb.Focus();
                    return;
                }
                if (user.Password != PasswordTb.Password)
                {
                    MBClass.ShowErrorPopup("Не верный пароль!", Application.Current.MainWindow);
                    PasswordTb.Focus();
                    return;
                }
                else
                {
                    switch (user.RoleId)
                    {
                        case 1:
                            new BaseWindow().Show();
                            foreach (Window window in Application.Current.Windows)
                            {
                                if (window is Window && window.Title == "Autorisation")
                                {
                                    window.Close();
                                }
                            }
                            break;
                        case 2:
                            new MenagerBaseWindow().Show();
                            foreach (Window window in Application.Current.Windows)
                            {
                                if (window is Window && window.Title == "Autorisation")
                                {
                                    window.Close();
                                }
                            }
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }

        
    }
}
