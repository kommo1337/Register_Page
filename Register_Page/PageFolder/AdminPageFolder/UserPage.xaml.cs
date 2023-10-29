using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminAddPageFolder;
using Register_Page.PageFolder.AdminEditPageFolder;
using Register_Page.WindowFolder;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = DBEntities.GetContext().User.
                    ToList().OrderBy(u => u.UserId);
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new AddUserPage());
        }

        private void EditInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new EditUserPage(membersDataGrid.SelectedItem as User));
        }

        private void DeleteInGrid_Click(object sender, RoutedEventArgs e)
        {
            User auto = membersDataGrid.SelectedItem as User;

            DBEntities.GetContext().User
                        .Remove(membersDataGrid.SelectedItem as User);
            DBEntities.GetContext().SaveChanges();

            MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);

            membersDataGrid.ItemsSource = DBEntities.GetContext()
                .Client.ToList().OrderBy(u => u.ClientId);
        }

        private void CloseWindowBTN_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void MinimizeWindowBTN_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
