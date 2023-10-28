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
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        Client client = new Client();
        public EditClientPage()
        {
            InitializeComponent();
            DataContext = client;

            this.client.ClientId = client.ClientId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                client = DBEntities.GetContext().Client
                    .FirstOrDefault(u => u.ClientId == client.ClientId);
                client.Name = NameTb.Text;
                client.Surname = SurNameTb.Text;
                client.Therdname = TherdNameTb.Text;
                client.Phone = PhoneTb.Text;
                client.Email = EmailTb.Text;
                client.Birthday = (DateTime)BTHDatePick.SelectedDate;

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
