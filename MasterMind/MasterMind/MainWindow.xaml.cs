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
        DispatcherTimer timer = new DispatcherTimer();
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

            // De geheime kleurencombinatie (je kunt dit aanpassen)
            string[] geheimeCombinatie = { "rood", "geel", "oranje", "wit", "groen", "blauw" };

            // Aantal pogingen
            int pogingen = 10;

            // Loop die maximaal 10 pogingen toestaat
            while (pogingen > 0)
            {
                // Vraagt de speler om de kleurencombinatie in te voeren
                Console.WriteLine($"Je hebt nog {pogingen} pogingen over. Voer de geheime kleurencombinatie in (bijv. 'rood blauw groen geel oranje wit'):");
                string invoer = Console.ReadLine();

                // Split de invoer op spaties en converteer naar een array van kleuren
                string[] ingevoerdeCombinatie = invoer.Split(' ');

                // Controleer of de ingevoerde combinatie gelijk is aan de geheime combinatie
                if (ingevoerdeCombinatie.Length == geheimeCombinatie.Length &&
                    juisteCombinatie(ingevoerdeCombinatie, geheimeCombinatie))
                {
                    Console.WriteLine("Gefeliciteerd! Je hebt de kleurencombinatie gekraakt.");
                    break; // Breekt de loop als de combinatie juist is
                }
                else
                {
                    Console.WriteLine("De kleurencombinatie is onjuist. Probeer het opnieuw.");
                }

                // Verlaag het aantal pogingen
                pogingen--;
            }

            // Als de speler geen pogingen meer heeft
            if (pogingen == 0)
            {
                Console.WriteLine("Je hebt al je pogingen gebruikt. De combinatie was:");
                Console.WriteLine(string.Join(" ", geheimeCombinatie));
            }
        }
        // Methode om te controleren of de twee combinaties gelijk zijn
        static bool juisteCombinatie(string[] ingevoerdeCombinatie, string[] geheimeCombinatie)
        {
            for (int i = 0; i < ingevoerdeCombinatie.Length; i++)
            {
                if (ingevoerdeCombinatie[i] != geheimeCombinatie[i])
                {
                    return false;
                }
            }
            return true;
        }
        bool wilSpelen = true;


        // Start het spel
        StartGame();

        // Vraag of de speler opnieuw wil spelen
        Console.WriteLine("Wil je opnieuw spelen? (ja/nee)");
            string herstart = Console.ReadLine().ToLower();

            if (herstart == "nee")
            {
                wilSpelen = false;  // Stop het spel
            }
    // Anders wordt wilSpelen weer 'true' en begint het spel opnieuw.
}

Console.WriteLine("Bedankt voor het spelen!");


static void StartGame()
{
    // Genereer een nieuwe geheime combinatie
    string[] geheimeCombinatie = GenereerNieuweCombinatie();

    // Aantal pogingen
    int pogingen = 10;
    bool codeGekraakt = false;

    while (pogingen > 0 && !codeGekraakt)
    {
        // Vraagt de speler om de kleurencombinatie in te voeren
        Console.WriteLine($"Je hebt nog {pogingen} pogingen over. Voer de geheime kleurencombinatie in (bijv. 'rood blauw groen geel paars wit'):");
        string invoer = Console.ReadLine();

        // Split de invoer op spaties en converteer naar een array van kleuren
        string[] ingevoerdeCombinatie = invoer.Split(' ');

        // Controleer of de invoer correct is
        if (ingevoerdeCombinatie.Length == geheimeCombinatie.Length)
        {
            // Bereken de score
            int[] score = BerekenScore(ingevoerdeCombinatie, geheimeCombinatie);

            // Toon de score
            Console.WriteLine("Score: ");
            for (int i = 0; i < score.Length; i++)
            {
                Console.WriteLine($"Positie {i + 1}: {score[i]} strafpunt(en)");
            }

            // Controleer of de speler de juiste combinatie heeft geraden
            if (score[0] == 0 && score[1] == 0 && score[2] == 0 && score[3] == 0 && score[4] == 0 && score[5] == 0)
            {
                Console.WriteLine("Gefeliciteerd! Je hebt de kleurencombinatie gekraakt.");
                codeGekraakt = true;
            }
        }
        else
        {
            Console.WriteLine("De invoer heeft niet het juiste aantal kleuren. Zorg ervoor dat je 6 kleuren invoert.");
        }

        // Verlaag het aantal pogingen
        pogingen--;
    }

    // Als de speler geen pogingen meer heeft, toon de geheime code
    if (!codeGekraakt)
    {
        Console.WriteLine("Je hebt al je pogingen gebruikt. De combinatie was:");
        Console.WriteLine(string.Join(" ", geheimeCombinatie));
    }
}

// Methode om de geheime combinatie te genereren
static string[] GenereerNieuweCombinatie()
{
    string[] kleuren = { "rood", "blauw", "groen", "geel", "paars", "wit", "zwart", "bruin", "oranje", "grijs" };
    Random random = new Random();
    string[] geheimeCombinatie = new string[6];

    for (int i = 0; i < geheimeCombinatie.Length; i++)
    {
        geheimeCombinatie[i] = kleuren[random.Next(kleuren.Length)];
    }

    return geheimeCombinatie;
}

// Methode om de score te berekenen
static int[] BerekenScore(string[] ingevoerdeCombinatie, string[] geheimeCombinatie)
{
    int[] score = new int[ingevoerdeCombinatie.Length];
    bool[] gebruiktePosities = new bool[geheimeCombinatie.Length]; // Track of de posities al zijn gecontroleerd

    // Eerst controleren op exacte overeenkomsten (0 strafpunten)
    for (int i = 0; i < ingevoerdeCombinatie.Length; i++)
    {
        if (ingevoerdeCombinatie[i] == geheimeCombinatie[i])
        {
            score[i] = 0;
            gebruiktePosities[i] = true;
        }
    }

    // de kleur ergens anders in de code voorkomt (1 strafpunt)
    for (int i = 0; i < ingevoerdeCombinatie.Length; i++)
    {
        if (score[i] != 0)
        {
            for (int j = 0; j < geheimeCombinatie.Length; j++)
            {
                if (!gebruiktePosities[j] && ingevoerdeCombinatie[i] == geheimeCombinatie[j])
                {
                    score[i] = 1; // 1 strafpunt voor kleur die wel voorkomt maar op een andere plek
                    gebruiktePosities[j] = true;
                    break;
                }
            }

            if (score[i] != 1)
            {
                score[i] = 2;
            }
        }
        bool wilSpelen = true;

        while (wilSpelen)
        {
            // Start het spel
            StartGame();

            // Vraag of de speler opnieuw wil spelen
            Console.WriteLine("Wil je opnieuw spelen? (ja/nee)");
            string herstart = Console.ReadLine().ToLower();

            if (herstart == "nee")
            {
                wilSpelen = false;
            }
        }

        Console.WriteLine("Bedankt voor het spelen!");
    }

    static void StartGame()
    {
        // Genereer een nieuwe geheime combinatie
        string[] geheimeCombinatie = GenereerNieuweCombinatie();

        // Naam van speler
        Console.WriteLine("Naam speler:");
        string naamspeler = Console.ReadLine();

        // Aantal pogingen
        int pogingen = 10;
        bool codeGekraakt = false;

        while (pogingen > 0 && !codeGekraakt)
        {
            // Vraagt de speler om de kleurencombinatie in te voeren
            Console.WriteLine($"Je hebt nog {pogingen} pogingen over. Voer de geheime kleurencombinatie in (bijv. 'rood blauw groen geel paars wit'):");
            string invoer = Console.ReadLine();

            // Check of de speler probeert af te breken (afsluiten van het spel)
            if (invoer.ToLower() == "stop")
            {
                // Vraag of de speler zeker weet dat hij het spel wil stoppen
                Console.WriteLine("Weet je zeker dat je het spel wilt stoppen? (ja/nee)");
                string stopBevestigen = Console.ReadLine().ToLower();

                if (stopBevestigen == "ja")
                {
                    Console.WriteLine("Het spel wordt nu afgesloten.");
                    Environment.Exit(0);  // Beëindig de applicatie
                }
                else
                {
                    Console.WriteLine("Je kunt gewoon verder spelen.");
                    continue;  // Laat de speler verder spelen
                }
            }

            // Split de invoer op spaties en converteer naar een array van kleuren
            string[] ingevoerdeCombinatie = invoer.Split(' ');

            // Controleer of de invoer correct is
            if (ingevoerdeCombinatie.Length == geheimeCombinatie.Length)
            {
                // Bereken de score
                int[] score = BerekenScore(ingevoerdeCombinatie, geheimeCombinatie);

                // Toon de score
                Console.WriteLine("Score: ");
                for (int i = 0; i < score.Length; i++)
                {
                    Console.WriteLine($"Positie {i + 1}: {score[i]} strafpunt(en)");
                }

                // Controleer of de speler de juiste combinatie heeft geraden
                if (score[0] == 0 && score[1] == 0 && score[2] == 0 && score[3] == 0 && score[4] == 0 && score[5] == 0)
                {
                    Console.WriteLine("Gefeliciteerd! Je hebt de kleurencombinatie gekraakt.");
                    codeGekraakt = true;
                }
            }
            else
            {
                Console.WriteLine("De invoer heeft niet het juiste aantal kleuren. Zorg ervoor dat je 6 kleuren invoert.");
            }

            // Verlaag het aantal pogingen
            pogingen--;
        }

        // Als de speler geen pogingen meer heeft, toon de geheime code
        if (!codeGekraakt)
        {
            Console.WriteLine("Je hebt al je pogingen gebruikt. De combinatie was:");
            Console.WriteLine(string.Join(" ", geheimeCombinatie));
        }
    }

    // Methode om de geheime combinatie te genereren
    static string[] GenereerNieuweCombinatie()
    {
        string[] kleuren = { "rood", "blauw", "groen", "geel", "paars", "wit", "zwart", "bruin", "oranje", "grijs" };
        Random random = new Random();
        string[] geheimeCombinatie = new string[6];

        for (int i = 0; i < geheimeCombinatie.Length; i++)
        {
            geheimeCombinatie[i] = kleuren[random.Next(kleuren.Length)];
        }

        return geheimeCombinatie;
    }

    // Methode om de score te berekenen
    static int[] BerekenScore(string[] ingevoerdeCombinatie, string[] geheimeCombinatie)
    {
        int[] score = new int[ingevoerdeCombinatie.Length];
        bool[] gebruiktePosities = new bool[geheimeCombinatie.Length]; // Track of de posities al zijn gecontroleerd

        // Eerst controleren op exacte overeenkomsten (0 strafpunten)
        for (int i = 0; i < ingevoerdeCombinatie.Length; i++)
        {
            if (ingevoerdeCombinatie[i] == geheimeCombinatie[i])
            {
                score[i] = 0;
                gebruiktePosities[i] = true; // Deze positie is correct, markeer als gebruikt
            }
        }

        for (int i = 0; i < ingevoerdeCombinatie.Length; i++)
        {
            if (score[i] != 0) 
            {
                for (int j = 0; j < geheimeCombinatie.Length; j++)
                {
                    if (!gebruiktePosities[j] && ingevoerdeCombinatie[i] == geheimeCombinatie[j])
                    {
                        score[i] = 1;
                        gebruiktePosities[j] = true; 
                        break;
                    }
                }

                // Als de kleur niet in de code zit (2 strafpunten)
                if (score[i] != 1)
                {
                    score[i] = 2;
                }
            }
        }

        return score;
    }
}