using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
