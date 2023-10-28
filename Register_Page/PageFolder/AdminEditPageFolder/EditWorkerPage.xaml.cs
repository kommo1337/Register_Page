using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminEditPageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditWorkerPage.xaml
    /// </summary>
    public partial class EditWorkerPage : Page
    {
        Worker worker = new Worker();
        public EditWorkerPage()
        {
            InitializeComponent();

            DataContext = worker;

            this.worker.WorkerId = worker.WorkerId;

            PostCb.ItemsSource = DBEntities.GetContext()
               .Post.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = PostCb.SelectedIndex + 1;
                worker = DBEntities.GetContext().Worker
                    .FirstOrDefault(u => u.WorkerId == worker.WorkerId);
                worker.Name = NameTb.Text;
                worker.Surname = SurNameTb.Text;
                worker.Therdname = TherdNameTb.Text;
                worker.Phone = PhoneTb.Text;
                worker.Pasport = PasportTb.Text;
                worker.PostId = index;

                DBEntities.GetContext().SaveChanges();
                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
                NavigationService.Navigate(new AvtoPage());
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }
    }
}
