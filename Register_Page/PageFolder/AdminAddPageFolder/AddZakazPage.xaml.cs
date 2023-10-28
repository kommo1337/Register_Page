using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Register_Page.PageFolder.AdminAddPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddZakazPage.xaml
    /// </summary>
    public partial class AddZakazPage : Page
    {
        public AddZakazPage()
        {
            InitializeComponent();
            ClientCb.ItemsSource = DBEntities.GetContext()
                .Client.ToList();
            CarCb.ItemsSource = DBEntities.GetContext()
                .Auto.ToList();
            StatusCb.ItemsSource = DBEntities.GetContext()
                .Status.ToList();
            RabotaCb.ItemsSource = DBEntities.GetContext()
                .Service.ToList();
            WorkerCb.ItemsSource = DBEntities.GetContext()
                .Worker.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                string dateString = BthPick.SelectedDate.ToString();
                string format = "dd.MM.yyyy";

                if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth))
                {
                    DBEntities.GetContext().Order.Add(new Order()
                    {
                        StartDate = dateOfBirth,
                        ClientId = Int32.Parse(ClientCb.SelectedValue.ToString()),
                        AutoId = Int32.Parse(CarCb.SelectedValue.ToString()),
                        StatusId = Int32.Parse(StatusCb.SelectedValue.ToString()),
                        ServiceId = Int32.Parse(RabotaCb.SelectedValue.ToString()),
                        WorkerId = Int32.Parse(WorkerCb.SelectedValue.ToString())

                    });
                    DBEntities.GetContext().SaveChanges();
                    NavigationService.Navigate(new AvtoPage());
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
