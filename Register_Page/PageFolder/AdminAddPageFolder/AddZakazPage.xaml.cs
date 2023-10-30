using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminPageFolder;
using Register_Page.WindowFolder;
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


                DBEntities.GetContext().Order.Add(new Order()
                {
                    StartDate = DateTime.Parse(BthPick.Text),
                    ClientId = Int32.Parse(ClientCb.SelectedValue.ToString()),
                    AutoId = Int32.Parse(CarCb.SelectedValue.ToString()),
                    StatusId = Int32.Parse(StatusCb.SelectedValue.ToString()),
                    ServiceId = Int32.Parse(RabotaCb.SelectedValue.ToString()),
                    WorkerId = Int32.Parse(WorkerCb.SelectedValue.ToString()),
                    Price = 1

                }) ;
                    DBEntities.GetContext().SaveChanges();
                Window currentWindow = GetCurrentWindow() as Window;
                if (currentWindow is MenagerBaseWindow)
                {
                    ((MenagerBaseWindow)currentWindow).MainFrame.Navigate(new ZakazPage());
                    ((MenagerBaseWindow)currentWindow).MainFrame2.Content = null;
                }
                else
                {
                    (App.Current.Windows[0] as BaseWindow).MainFrame.Navigate(new ZakazPage());
                    (App.Current.Windows[0] as BaseWindow).MainFrame2.Content = null;
                }



            }
            catch (Exception ex)
            {
                MBClass.ShowErrorPopup(ex.Message, Application.Current.MainWindow);
                
            }

        }
    }
}
