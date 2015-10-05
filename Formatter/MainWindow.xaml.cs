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

namespace JSON_Formatter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isHighlighted = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btPaste_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            richTextBox.Paste();
        }

        private void btCopy_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            richTextBox.Copy();
        }

        private void btFormat_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            string oldStr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document = new FlowDocument(new Paragraph(new Run(Formatter.Format(oldStr))));
            Highlight();
        }

        private void btRemoveWhiteSpace_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            string oldStr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            richTextBox.Document.Blocks.Clear();
            richTextBox.AppendText(Formatter.RemoveEmptyEntries(oldStr));
            Highlight();
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            richTextBox.Document.Blocks.Clear();
        }

        private void btSelectAll_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Focus();
            richTextBox.Selection.Select(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        }

        private void btHighlight_Click(object sender, RoutedEventArgs e)
        {
            if (isHighlighted == true)
            {
                isHighlighted = false;
                btHighlight.Content = "Highlight";
            }
            else
            {
                isHighlighted = true;
                btHighlight.Content = "Unhighlight";
            }
            Highlight();
        }

        private void Highlight()
        {
            richTextBox.Focus();
            string oldStr = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            richTextBox.Document.Blocks.Clear();
            if (isHighlighted == false)
                richTextBox.Document = new FlowDocument(new Paragraph(new Run(oldStr)));
            else 
                richTextBox.Document = Colorizer.Colorize(oldStr);
        }

        private void btViewJson_Click(object sender, RoutedEventArgs e)
        {
            treeJsonView.Focus();
            treeJsonView.Items.Clear();
            try
            {
                treeJsonView.Items.Add(Viewer.BuildTree(new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text));
            }
            catch
            {
                MessageBox.Show("JSON input is not correct, so tree cannot be built. Please, check the input string.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
