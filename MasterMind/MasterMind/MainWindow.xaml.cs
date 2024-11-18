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
using System.Windows.Threading;

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
        private DispatcherTimer timer = new DispatcherTimer();
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

        private void color_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Name == "rood1")
            {
                one.Background = Brushes.Red;
            }
            else if (btn.Name == "geel1")
            {
                one.Background = Brushes.Yellow;
            }
            else if (btn.Name == "oranje1")
            {
                one.Background = Brushes.Orange;
            }
            else if (btn.Name == "wit1")
            {
                one.Background = Brushes.White;
            }
            else if (btn.Name == "groen1")
            {
                one.Background = Brushes.Green;
            }
            else if (btn.Name == "blauw1")
            {
                one.Background = Brushes.Blue;
            }


            if (btn.Name == "rood2")
            {
                two.Background = Brushes.Red;
            }
            else if (btn.Name == "geel2")
            {
                two.Background = Brushes.Yellow;
            }
            else if (btn.Name == "oranje2")
            {
                two.Background = Brushes.Orange;
            }
            else if (btn.Name == "wit2")
            {
                two.Background = Brushes.White;
            }
            else if (btn.Name == "groen2")
            {
                two.Background = Brushes.Green;
            }
            else if (btn.Name == "blauw2")
            {
                two.Background = Brushes.Blue;
            }

            if (btn.Name == "rood3")
            {
                three.Background = Brushes.Red;
            }
            else if (btn.Name == "geel3")
            {
                three.Background = Brushes.Yellow;
            }
            else if (btn.Name == "oranje3")
            {
                three.Background = Brushes.Orange;
            }
            else if (btn.Name == "wit3")
            {
                three.Background = Brushes.White;
            }
            else if (btn.Name == "groen3")
            {
                three.Background = Brushes.Green;
            }
            else if (btn.Name == "blauw3")
            {
                three.Background = Brushes.Blue;
            }


            if (btn.Name == "rood4")
            {
                four.Background = Brushes.Red;
            }
            else if (btn.Name == "geel4")
            {
                four.Background = Brushes.Yellow;
            }
            else if (btn.Name == "oranje4")
            {
                four.Background = Brushes.Orange;
            }
            else if (btn.Name == "wit4")
            {
                four.Background = Brushes.White;
            }
            else if (btn.Name == "groen4")
            {
                four.Background = Brushes.Green;
            }
            else if (btn.Name == "blauw4")
            {
                four.Background = Brushes.Blue;
            }

        }
        private void timerCountdown(object sender, EventArgs e)
        {
            timer.Tick += Timer_Tick;
            TimeSpan interval = new TimeSpan(0, 0, 1);
            Timer.start();
        }
    }
}

    