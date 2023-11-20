using Register_Page.DataFolder;
using System.Windows;

namespace Register_Page.PageFolder.AdminEditPageFolder
{
    /// <summary>
    /// Логика взаимодействия для FullInfoCLient.xaml
    /// </summary>
    public partial class FullInfoCLient : Window
    {
        Client worker = new Client();
        public FullInfoCLient(Client worker)
        {
            InitializeComponent();

            DataContext = worker;

            this.worker.ClientId = worker.ClientId;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
