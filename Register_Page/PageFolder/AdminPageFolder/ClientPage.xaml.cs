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

        private void AddBTN_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new AddClientPage());
        }

        private void EditInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window currentWindow = GetCurrentWindow() as Window;
            if (currentWindow is MenagerBaseWindow)
            {
                ((MenagerBaseWindow)currentWindow).MainFrame2.Navigate(new EditClientPage(membersDataGrid.SelectedItem as Client));
                ((MenagerBaseWindow)currentWindow).MainFrame.Content = null;
            }
            else
            {
                (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new EditClientPage(membersDataGrid.SelectedItem as Client));
                (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            }

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

        private void CloseWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinimizeWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBTN2_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Windows[0] as MenagerBaseWindow).MainFrame2.Navigate(new AddClientPage());
            (App.Current.Windows[0] as MenagerBaseWindow).MainFrame.Content = null;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in App.Current.Windows)
            {
                if ((item as Window).Title == "MenagerWindow")
                {
                    AddBTN.Click -= AddBTN_Click;
                    AddBTN.Click += AddBTN2_Click;
                }

            }
        }
    }
}
