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
using JSON;

namespace Formatter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Formatter formatter = new Formatter();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_paste_Click(object sender, RoutedEventArgs e)
        {
            textBox.Focus();
            textBox.Paste();
        }

        private void bt_copy_Click(object sender, RoutedEventArgs e)
        {
            textBox.Focus();
            textBox.Copy();
        }

        private void bt_format_Click(object sender, RoutedEventArgs e)
        {
            textBox.Focus();
            textBox.Text = formatter.Format(textBox.Text);            
        }

        private void bt_remove_space_Click(object sender, RoutedEventArgs e)
        {
            textBox.Focus();
            textBox.Text = formatter.RemoveEmptyEntries(textBox.Text);
        }

        private void bt_clear_Click(object sender, RoutedEventArgs e)
        {
            textBox.Focus();
            textBox.Clear();
        }
    }
}
