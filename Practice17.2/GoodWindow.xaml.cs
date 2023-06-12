using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using System.Security.Policy;

namespace Practice17_2
{
    public partial class GoodWindow : Window
    {
        public Goods Good { get; private set; }
        public BindingList<Users> Users { get; private set; }
        int selectedIndex = -1;
        public GoodWindow(Goods good, BindingList<Users> users, int selectedIndex = -1)
        {
            InitializeComponent();
            Good = good;
            DataContext = Good;
            Users = users;
            cbEmails.ItemsSource = users;
            this.selectedIndex = selectedIndex;
            if (selectedIndex >= 0 && selectedIndex != cbEmails.SelectedIndex)
                cbEmails.SelectedIndex = selectedIndex;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cbEmails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cbEmails.SelectedItem as Users)!= null)
            {
                Good.email = (cbEmails.SelectedItem as Users).email;
            }
        }

    }
}
