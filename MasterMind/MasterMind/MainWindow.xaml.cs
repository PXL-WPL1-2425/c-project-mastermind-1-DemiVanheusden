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

namespace MasterMind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        SolidColorBrush[] colorSelection = [Brushes.Red, Brushes.Blue, Brushes.Green, Brushes.White, Brushes.Yellow, Brushes.Orange];
        string[] colorSelectionString = ["Red", "Blue", "Green", "White", "Yellow", "Orange"];
        int[] colorsRandom = new int[4];

        public MainWindow()
        {
            InitializeComponent();
            pickColors();
        }

        private void pickColors()
        {
            for (int i = 0; i < colorsRandom.Length; i++)
            {
                colorsRandom[i] = rnd.Next(1, 6);
            }

            this.Title = $"Mastermind ({colorSelectionString[colorsRandom[0]]}, {colorSelectionString[colorsRandom[1]]}, {colorSelectionString[colorsRandom[2]]}, {colorSelectionString[colorsRandom[3]]})";
        }

        private void checkcode_Click(object sender, RoutedEventArgs e)
        {

        }
    }

        
           
}
    