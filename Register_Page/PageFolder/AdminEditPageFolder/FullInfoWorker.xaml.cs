using Register_Page.ClassFolder;
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
    /// Логика взаимодействия для FullInfoWorker.xaml
    /// </summary>
    public partial class FullInfoWorker : Window
    {
        Worker worker = new Worker();
        public FullInfoWorker(Worker worker)
        {
            InitializeComponent();

            DataContext = worker;

            try
            {
                this.worker.WorkerId = worker.WorkerId;
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
               
            }
            

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
