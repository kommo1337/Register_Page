using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using Register_Page.WindowFolder;
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
        public EditWorkerPage(Worker worker)
        {
            InitializeComponent();

            DataContext = worker;

            this.worker.WorkerId = worker.WorkerId;

            PostCb.ItemsSource = DBEntities.GetContext()
               .Post.ToList();
            GenderCb.ItemsSource = DBEntities.GetContext()
              .Gender.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = PostCb.SelectedIndex + 1;
                int index2 = GenderCb.SelectedIndex + 1;
                worker = DBEntities.GetContext().Worker
                    .FirstOrDefault(u => u.WorkerId == worker.WorkerId);
                worker.Name = NameTB.Text;
                worker.Surname = SurnameTb.Text;
                worker.Therdname = TherdNameTb.Text;
                worker.Phone = PhoneTb.Text;
                worker.Pasport = PasportTB.Text;
                worker.PostId = index;
                worker.GenderId = index2;
                worker.Email = EmailTb.Text;
                worker.Adress = AdressTb.Text;
                DBEntities.GetContext().SaveChanges();
                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
                (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
                (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new WorkerPage());

            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }
    }
}
