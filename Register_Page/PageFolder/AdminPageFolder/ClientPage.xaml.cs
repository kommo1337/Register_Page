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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = DBEntities.GetContext().Client.
                    ToList().OrderBy(u => u.ClientId);
        }

        private void AddBTN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new AddClientPage());
        }

        private void EditInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new EditClientPage(membersDataGrid.SelectedItem as Client));

        }

        private void DeleteInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Client auto = membersDataGrid.SelectedItem as Client;

            DBEntities.GetContext().Client
                        .Remove(membersDataGrid.SelectedItem as Client);
            DBEntities.GetContext().SaveChanges();

            MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);

            membersDataGrid.ItemsSource = DBEntities.GetContext()
                .Client.ToList().OrderBy(u => u.ClientId);
        }
    }
}
