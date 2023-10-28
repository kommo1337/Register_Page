using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Register_Page.PageFolder.AdminAddPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dateString = BTHDatePick.SelectedDate.ToString();
                string format = "dd.MM.yyyy";

                if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth))
                {
                    DBEntities.GetContext().Client.Add(new Client()
                    {
                        Name = NameTb.Text,
                        Surname = SurNameTb.Text,
                        Therdname = TherdNameTb.Text,
                        Birthday = dateOfBirth,
                        Email = EmailTb.Text,
                        Phone = PhoneTb.Text
                    });
                    DBEntities.GetContext().SaveChanges();
                    NavigationService.Navigate(new ClientPage());
                }
                else
                {

                    MBClass.ShowErrorPopup("Ошибка: Неверный формат даты.", Application.Current.MainWindow);

                }
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
                throw;
            }
        }
    }
}
