﻿using Register_Page.ClassFolder;
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
    /// Логика взаимодействия для AvtoPage.xaml
    /// </summary>
    public partial class AvtoPage : Page
    {
        public AvtoPage()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = DBEntities.GetContext().Auto.
                    ToList().OrderBy(u => u.AutoId);
        }

        private void EditInGridBTN_Click(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedItem == null)
            {
                MBClass.ShowErrorPopup("Выбиерите заказ", Application.Current.MainWindow);

            }
            else
            {
                (App.Current.Windows[0] as BaseWindow).MainFrame.Content = null;
                (App.Current.Windows[0] as BaseWindow).MainFrame2.Navigate(new EditAuto(membersDataGrid.SelectedItem as Auto));
            }  
        }

        private void DeleteInGridBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinimizeWindowBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
