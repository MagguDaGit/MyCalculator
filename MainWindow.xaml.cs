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
using System.Text.RegularExpressions;
using System.Data;

namespace MyCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        // Regex implementering, blir ikke brukr foreløpig... 
        private static readonly Regex _regex = new Regex("[^0-9.-]+");

        public MainWindow()
        {
            InitializeComponent();
        }
         
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private static bool isValidInput(string input)
        {
            return !_regex.IsMatch(input);
        }

        private void InputPreview(object sender, TextCompositionEventArgs e)
        {
            string regexPattern = "[^0-9+*.-]"; 
            Regex regex = new Regex(regexPattern);
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Calculator_Input(object sender, RoutedEventArgs e)
        {
            Button _btn = (Button) sender;
            switch(_btn.CommandParameter.ToString())
            {
                case "DEL":
                    {
                        if (textfield.Text.Length < 1) return; 
                        textfield.Text = textfield.Text.Substring(0, textfield.Text.Length - 1);
                        return; 
                    }
                case "C":
                    {
                        textfield.Clear();
                        return;
                    }
                case "CE":
                    {
                        textfield.Clear();
                        return;
                    }
                case "=":
                    {
                        DataTable dt = new DataTable();
                        var result = dt.Compute(textfield.Text.ToString(), "");
                        textfield.Text = result.ToString();
                        return; 
                    }
                default:
                    {
                        textfield.AppendText(_btn.CommandParameter.ToString());
                        return; 
                    }
            }
            
        }
    }
}
