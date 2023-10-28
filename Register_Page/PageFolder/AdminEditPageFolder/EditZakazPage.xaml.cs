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
    /// Логика взаимодействия для EditZakazPage.xaml
    /// </summary>
    public partial class EditZakazPage : Page
    {
        Order order = new Order();
        public EditZakazPage()
        {
            InitializeComponent();

            DataContext = order;
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

            this.order.OrderId = order.OrderId;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                int index = ClientCb.SelectedIndex + 1;
                int index2 = CarCb.SelectedIndex + 1;
                int index3 = StatusCb.SelectedIndex + 1;
                int index4 = RabotaCb.SelectedIndex + 1;
                int index5 = WorkerCb.SelectedIndex + 1;
                order = DBEntities.GetContext().Order
                    .FirstOrDefault(u => u.OrderId == order.OrderId);
                order.StartDate = (DateTime)BthPick.SelectedDate;
                order.ClientId = index;
                order.AutoId = index2;
                order.StatusId = index3;
                order.ServiceId = index4;
                order.WorkerId = index5;
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
