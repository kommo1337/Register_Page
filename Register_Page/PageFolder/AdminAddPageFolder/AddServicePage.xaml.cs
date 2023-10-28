using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Register_Page.PageFolder.AdminAddPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        public AddServicePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().Service.Add(new Service()
                {
                    ServiceName = NameServiceTb.Text,
                    ServicePrice = Int32.Parse(PriceTb.Text),

                });
                DBEntities.GetContext().SaveChanges();
                NavigationService.Navigate(new ZakazPage());
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
                throw;
            }
        }
    }
}
