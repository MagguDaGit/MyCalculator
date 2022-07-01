using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Data;


namespace MyCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
          
            InitializeComponent();
        }
         
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private bool NotValidInput(string input)
        {
            string regexPattern = "[^0-9+*.-]";
            Regex regex = new Regex(regexPattern);
            return regex.IsMatch(input);

        }

        
        private void InputPreview(object sender, TextCompositionEventArgs e)
        {
            e.Handled = NotValidInput(e.Text.ToString());
        }


        private void Calculate(string? text)
        {
            if (text == null) return; 
            bool notValid= NotValidInput(textfield.Text.ToString());
            if (notValid)
            {
                textfield.Clear();
                textfield.Text = "0";
                return;
            }

            switch (text)
            {
                case "DEL":
                    {
                        if (textfield.Text.Length == 0) return;
                        textfield.Text = textfield.Text.Substring(0, textfield.Text.Length - 1);
                        return;
                    }
                case "C":
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
                        textfield.AppendText(text);
                        return;
                    }
            }

        }

        private void Calculator_Input(object sender, RoutedEventArgs e)
        {
            bool invalid = NotValidInput(textfield.Text.ToString());
            Button _btn = (Button) sender;

            if(invalid)
            { 
                textfield.Clear();
                textfield.Text = "0"; 
                return; 
            }

            Calculate(_btn.CommandParameter.ToString());    
        }
    }
}
