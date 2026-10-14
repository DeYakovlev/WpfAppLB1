using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppLB1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double x = 0.0;
        char oper = ' ';
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNumber_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text == "0")
                textBox.Text = (sender as Button)?.Content.ToString();
            else
                if (textBox.Text.Length < 25)  
                    textBox.Text += (sender as Button)?.Content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.IndexOf(",") < 0)
                textBox.Text += ",";

        }

        private void ButtonOper_Click(object sender, RoutedEventArgs e)
        {
            x = Convert.ToDouble(textBox.Text);
            oper = (sender as Button).Content.ToString()[0];
            textBox.Text = "0";
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            double y = Convert.ToDouble(textBox.Text);
            double result = 0;
            switch(oper) 
            {
                case '+': result = x + y; break;
                case '-': result = x - y; break;
                case '*': result = x * y; break;
                case '/': result = x / y; break;
            }
            textBox.Text = result.ToString();
        }

        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length > 1)
                textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
            else
                textBox.Text = "0";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.Text = "0";
            x = 0.0;
            oper = ' ';
        }
    }
}