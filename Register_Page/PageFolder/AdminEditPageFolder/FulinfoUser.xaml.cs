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
    /// Логика взаимодействия для FulinfoUser.xaml
    /// </summary>
    public partial class FulinfoUser : Window
    {
        User worker = new User();
        public FulinfoUser(User worker)
        {
            InitializeComponent();

            DataContext = worker;

            this.worker.UserId = worker.UserId;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
