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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_paste_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            richTextBox.Paste();
        }

        private void bt_copy_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            richTextBox.Copy();
        }

        private void bt_format_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            string oldStr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document = Formatter.Format(oldStr);
        }

        private void bt_remove_space_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            string oldStr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            richTextBox.Document.Blocks.Clear();
            richTextBox.AppendText(Formatter.RemoveEmptyEntries(oldStr));
        }

        private void bt_clear_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            richTextBox.Document.Blocks.Clear();
        }
    }
}
