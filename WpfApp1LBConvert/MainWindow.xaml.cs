using System.Linq;
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

namespace WpfApp1LBConvert
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum TimeUnit 
        {
            Millisecond,
            Second,
            Minute,
            Hour,
            Day
        }

        private static readonly Dictionary<TimeUnit, double> ToSeconds = new()
    {
        { TimeUnit.Millisecond, 1e-3 },
        { TimeUnit.Second,      1.0  },
        { TimeUnit.Minute,      60.0 },
        { TimeUnit.Hour,        3600.0 },
        { TimeUnit.Day,         86400.0 },
    };
        public MainWindow()
        {
            InitializeComponent();
            BoxTo.ItemsSource = new List<string> {TimeUnit.Millisecond.ToString(), TimeUnit.Second.ToString(), TimeUnit.Minute.ToString(), TimeUnit.Hour.ToString(), TimeUnit.Day.ToString() };
            BoxFrom.ItemsSource = new List<string> {TimeUnit.Millisecond.ToString(), TimeUnit.Second.ToString(), TimeUnit.Minute.ToString(), TimeUnit.Hour.ToString(), TimeUnit.Day.ToString() };
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (BoxTo.Text != "" & BoxFrom.Text != "" & TextTo.Text !="") 
            {
                TimeUnit unitTo = (TimeUnit)Enum.Parse(typeof(TimeUnit), BoxTo.Text);
                TimeUnit unitFrom = (TimeUnit)Enum.Parse(typeof(TimeUnit), BoxFrom.Text);
                double inSecond = Convert.ToDouble(TextTo.Text) * ToSeconds[unitTo];
                TextFrom.Text = Convert.ToString(inSecond / ToSeconds[unitFrom]);

            }

            
        }

        private void PreviewTextInputBOX(object sender, TextCompositionEventArgs e)
        {
            e.Handled =!IsNumber(e.Text);
        }

        private static bool IsNumber(string text) 
        {
            return Double.TryParse(text, out double value);
        }

        private void ButtonClean_Click(object sender, RoutedEventArgs e)
        {
            TextTo.Text = "";
            TextFrom.Text = "";
            BoxFrom.Text = "";
            BoxTo.Text = "";
            
        }
    }
    
}