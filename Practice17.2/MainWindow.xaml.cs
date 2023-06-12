using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice17_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            (DataContext as ViewModel).Users.ListChanged += Users_ListChanged;
        }

        private void Users_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            Debug.Print(e.ListChangedType.ToString());
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    Debug.Print(e.NewIndex.ToString());
                    dgUsers.SelectedIndex = e.NewIndex;
                    dgUsers.ScrollIntoView((DataContext as ViewModel).Users[e.NewIndex-1]);
                    break;
                case ListChangedType.ItemDeleted:
                    dgUsers.SelectedIndex = e.NewIndex - 1;
                    break;
            }
        }

        private void dgUsers_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    dgUsers.SelectedIndex = -1;
                    break;
            }
        }

        private void dgGoods_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    dgGoods.SelectedIndex = -1;
                    break;
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteUser.IsEnabled = btnEditUser.IsEnabled = dgUsers.SelectedIndex >= 0;
            (DataContext as ViewModel).SelectedUserIndex = dgUsers.SelectedIndex;
        }

        private void dgGoods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteGood.IsEnabled = btnEditGood.IsEnabled = dgGoods.SelectedIndex >= 0;
            (DataContext as ViewModel).SelectedGoodIndex = dgGoods.SelectedIndex;
        }

    }

}
