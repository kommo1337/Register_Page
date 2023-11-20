using Register_Page.ClassFolder;
using Register_Page.DataFolder;
using Register_Page.PageFolder.AdminAddPageFolder;
using Register_Page.PageFolder.AdminEditPageFolder;
using Register_Page.WindowFolder;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Register_Page.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = DBEntities.GetContext().Worker.
                    ToList().OrderBy(u => u.WorkerId);
        }

        private void EditInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new EditWorkerPage(membersDataGrid.SelectedItem as Worker));

        }

        private void DeleteInGrid_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Worker auto = membersDataGrid.SelectedItem as Worker;

            DBEntities.GetContext().Worker
                        .Remove(membersDataGrid.SelectedItem as Worker);
            DBEntities.GetContext().SaveChanges();

            MBClass.ShowMesagePopup("Успешно", Application.Current.MainWindow);

            membersDataGrid.ItemsSource = DBEntities.GetContext()
                .Worker.ToList().OrderBy(u => u.WorkerId);
        }

        private void AddBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
            (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new WorkerAddPage());

        }

        private void CloseWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinimizeWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            membersDataGrid.ItemsSource = DBEntities.GetContext()
               .Worker.Where(u => u.Name
               .StartsWith(textBoxFilter.Text))
               .ToList().OrderBy(u => u.Name);
            if (membersDataGrid.Items.Count <= 0)
            {
                MBClass.ShowErrorPopup("Данные не найдены", Application.Current.MainWindow);
            }
        }

        private void membersDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new FullInfoWorker(membersDataGrid.SelectedItem as Worker).Show();
        }

        private void modifyIt_Click(object sender, RoutedEventArgs e)
        {
            new FullInfoWorker(membersDataGrid.SelectedItem as Worker).Show();
        }
    }
}
