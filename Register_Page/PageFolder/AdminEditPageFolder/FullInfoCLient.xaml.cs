using Register_Page.DataFolder;
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
using System.Windows.Shapes;

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
