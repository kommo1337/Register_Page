using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using Register_Page.WindowFolder;
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

namespace Register_Page.PageFolder.AdminAddPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
            ClientCb.ItemsSource = DBEntities.GetContext()
                     .Role.ToList();
            GenderCb.ItemsSource = DBEntities.GetContext()
                     .Gender.ToList();
        }

        public Window GetCurrentWindow()
        {
            foreach (var window in App.Current.Windows)
            {
                if (window is Window currentWindow)
                {
                    if (currentWindow.Title == "MenagerWindow")
                    {
                        return currentWindow;
                    }
                    else if (currentWindow.Title == "BaseWindow")
                    {
                        return currentWindow;
                    }
                }
            }

            return null;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().User.Add(new User()
                {
                    Login = LoginTB.Text,
                    Password = PasswordTB.Text,
                    RoleId = Int32.Parse(ClientCb.SelectedValue.ToString()),
                    Adress = AdressTb.Text,
                    Name = NameTB.Text,
                    Surname = SurnameTb.Text,
                    Therdname = TherdNameTb.Text,
                    UserEmail = EmailTb.Text,
                    GenderId = Int32.Parse(GenderCb.SelectedValue.ToString()),
                    Phone = PhoneTb.Text,
                    Birthday = DateTime.Parse(BTHDatePick.Text)

                });
                DBEntities.GetContext().SaveChanges();
                Window currentWindow = GetCurrentWindow() as Window;
                if (currentWindow is MenagerBaseWindow)
                {
                    ((MenagerBaseWindow)currentWindow).MainFrame.Navigate(new UserPage());
                    ((MenagerBaseWindow)currentWindow).MainFrame2.Content = null;
                }
                else
                {
                    (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new UserPage());
                    (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
                }
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
                
            }
        }
    }
}
