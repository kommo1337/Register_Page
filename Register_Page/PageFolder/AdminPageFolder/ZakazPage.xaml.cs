using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminAddPageFolder;
using Register_Page.WindowFolder;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ZakazPage.xaml
    /// </summary>
    public partial class ZakazPage : Page
    {
        public ZakazPage()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = DBEntities.GetContext().Order.
                ToList().OrderBy(u => u.OrderId);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new AddZakazPage());
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
        }
    }
}
