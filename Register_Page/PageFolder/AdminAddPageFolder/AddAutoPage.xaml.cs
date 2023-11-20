using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using Register_Page.WindowFolder;
using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminAddPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddAutoPage.xaml
    /// </summary>
    public partial class AddAutoPage : Page
    {
        private DBEntities context;

        public AddAutoPage()
        {
            InitializeComponent();
            context = DBEntities.GetContext();
            ClientCb.ItemsSource = DBEntities.GetContext()
               .Client.ToList();
            AutoCb.ItemsSource = DBEntities.GetContext()
                .FullAuto.ToList();
        }


        public Window GetCurrentWindow()
        {
            foreach (var window in App.Current.Windows)
            {
                if (window is Window currentWindow)
                {
                    if (currentWindow.Title == "MenagerWindow")
                    {
                        return currentWindow;
                    }
                    else if (currentWindow.Title == "BaseWindow")
                    {
                        return currentWindow;
                    }
                }
            }

            return null;
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
                    FullAutoId = Int32.Parse(AutoCb.SelectedValue.ToString()),


                });
                DBEntities.GetContext().SaveChanges();

                Window currentWindow = GetCurrentWindow() as Window;
                if (currentWindow is MenagerBaseWindow)
                {
                    ((MenagerBaseWindow)currentWindow).MainFrame.Navigate(new AvtoPage());
                    ((MenagerBaseWindow)currentWindow).MainFrame2.Content = null;
                }
                else
                {
                    (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new AvtoPage());
                    (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
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
