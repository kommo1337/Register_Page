using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using Register_Page.WindowFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminAddPageFolder
{
    /// <summary>
    /// Логика взаимодействия для WorkerAddPage.xaml
    /// </summary>
    public partial class WorkerAddPage : Page
    {
        public WorkerAddPage()
        {
            InitializeComponent();
            PostCb.ItemsSource = DBEntities.GetContext()
                 .Post.ToList();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {

                DBEntities.GetContext().Worker.Add(new Worker()
                {
                    Name = NameTb.Text,
                    Surname = SurNameTb.Text,
                    Therdname = TherdNameTb.Text,
                    PostId = Int32.Parse(PostCb.SelectedValue.ToString()),
                    Pasport = PasportTb.Text,
                    Phone = PhoneTb.Text
                });
                DBEntities.GetContext().SaveChanges();
                (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
                (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new WorkerPage());


            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
                throw;
            }
        }
    }
}
