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
    /// Логика взаимодействия для EditAuto.xaml
    /// </summary>
    public partial class EditAuto : Page
    {
        Auto auto = new Auto();



        public EditAuto(Auto auto)
        {

            InitializeComponent();

            DataContext = auto;

            this.auto.AutoId = auto.AutoId;

            ClientCb.ItemsSource = DBEntities.GetContext()
                    .Client.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = ClientCb.SelectedIndex + 1;
                auto = DBEntities.GetContext().Auto
                    .FirstOrDefault(u => u.AutoId == auto.AutoId);
                auto.GosNomer = GosNomerTB.Text;
                auto.VIN = VINTB.Text;
                auto.Mileage = int.Parse(ProbegTB.Text);
                auto.ClientId = index;
                DBEntities.GetContext().SaveChanges();
                MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);
                (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
                (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new AvtoPage());
            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
            }
        }
    }
}
