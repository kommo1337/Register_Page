using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using Register_Page.WindowFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Register_Page.PageFolder.AdminAddPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddAutoPage.xaml
    /// </summary>
    public partial class AddAutoPage : Page
    {
        public AddAutoPage()
        {
            InitializeComponent();
            ClientCb.ItemsSource = DBEntities.GetContext()
               .Client.ToList();
        }



            

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBEntities.GetContext().Auto.Add(new Auto()
                {
                    GosNomer = GosNomerTB.Text,
                    VIN = VINTB.Text,
                    ClientId = Int32.Parse(ClientCb.SelectedValue.ToString()),
                    Mileage = Int32.Parse(ProbegTB.Text),
                    Age = Int32.Parse(GODVIPUSKATB.Text),

                });
                DBEntities.GetContext().SaveChanges();
                (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
                (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new AvtoPage());
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
                throw;
            }
        
    }
    }
}
