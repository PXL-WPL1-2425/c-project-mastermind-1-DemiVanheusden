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
        MessageBox.Show("Wil je opnieuw spelen? (ja/nee)");
            

            if (herstart == "nee")
            {
                wilSpelen = false;  // Stop het spel
private void hint_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

MessageBox.Show("Bedankt voor het spelen!");


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
        MessageBox.Show($"Je hebt nog {pogingen} pogingen over. Voer de geheime kleurencombinatie in (bijv. 'rood blauw groen geel paars wit'):");
        string invoer = MessageBox.Show;

        // Split de invoer op spaties en converteer naar een array van kleuren
        string[] ingevoerdeCombinatie = invoer.Split(' ');

        // Controleer of de invoer correct is
        if (ingevoerdeCombinatie.Length == geheimeCombinatie.Length)
        {
            // Bereken de score
            int[] score = BerekenScore(ingevoerdeCombinatie, geheimeCombinatie);

            // Toon de score
            MessageBox.Show("Score: ");
            for (int i = 0; i < score.Length; i++)
            {
                MessageBox.Show($"Positie {i + 1}: {score[i]} strafpunt(en)");
            }

            // Controleer of de speler de juiste combinatie heeft geraden
            if (score[0] == 0 && score[1] == 0 && score[2] == 0 && score[3] == 0 && score[4] == 0 && score[5] == 0)
            {
                MessageBox.Show("Gefeliciteerd! Je hebt de kleurencombinatie gekraakt.");
                codeGekraakt = true;
            }
        }
        else
        {
            MessageBox.Show("De invoer heeft niet het juiste aantal kleuren. Zorg ervoor dat je 6 kleuren invoert.");
        }

        // Verlaag het aantal pogingen
        pogingen--;
    }

    // Als de speler geen pogingen meer heeft, toon de geheime code
    if (!codeGekraakt)
    {
        MessageBox.Show("Je hebt al je pogingen gebruikt. De combinatie was:");
        MessageBox.Show(string.Join(" ", geheimeCombinatie));
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
static int[] BerekenScore (string[] ingevoerdeCombinatie, string[] geheimeCombinatie)
{
    int[] score = new int[ingevoerdeCombinatie.Length];
    bool[] gebruiktePosities = new bool[geheimeCombinatie.Length];

    // Eerst controleren op exacte overeenkomsten
    for (int i = 0; i < ingevoerdeCombinatie.Length; i++)
    {
        if (ingevoerdeCombinatie[i] == geheimeCombinatie[i])
        {
            score[i] = 0;
            gebruiktePosities[i] = true;
        }
    }

    // de kleur ergens anders in de code voorkomt
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
            MessageBox.Show("Wil je opnieuw spelen? (ja/nee)");
            MessageBoxResult result = MessageBox.Show("Wil je opnieuw spelen?", "Herstart", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                wilSpelen = false;  // Stop het spel
            }

        }

        MessageBox.Show("Bedankt voor het spelen!");
    }

    static void StartGame()
    {
        // Genereer een nieuwe geheime combinatie
        string[] geheimeCombinatie = GenereerNieuweCombinatie();

        // Naam van speler vragen
        MessageBox.Show("Naam speler:");
        string naamspeler = Console.ReadLine();

        // Aantal pogingen
        int pogingen = 20;
        bool codeGekraakt = false;

        while (pogingen > 0 && !codeGekraakt)
        {
            // Vraagt de speler om de kleurencombinatie in te voeren
            MessageBox.Show($"Je hebt nog {pogingen} pogingen over. Voer de geheime kleurencombinatie in (bijv. 'rood blauw groen geel paars wit'):");
            string invoer = Console.ReadLine();

            // Check of de speler probeert af te breken
            if (invoer.ToLower() == "stop")
            {
                // Vraag of de speler zeker weet dat hij het spel wil stoppen
                MessageBox.Show("Weet je zeker dat je het spel wilt stoppen? (ja/nee)");
                string stopBevestigen = Console.ReadLine().ToLower();

                if (stopBevestigen == "ja")
                {
                    MessageBox.Show("Het spel wordt nu afgesloten.");
                    Environment.Exit(0);  // Beëindig de applicatie
                }
                else
                {
                    MessageBox.Show("Je kunt gewoon verder spelen.");
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
                MessageBox.Show("Score: ");
                for (int i = 0; i < score.Length; i++)
                {
                    MessageBox.Show($"Positie {i + 1}: {score[i]} strafpunt(en)");
                }

                // Controleer of de speler de juiste combinatie heeft geraden
                if (score[0] == 0 && score[1] == 0 && score[2] == 0 && score[3] == 0 && score[4] == 0 && score[5] == 0)
                {
                    MessageBox.Show("Gefeliciteerd! Je hebt de kleurencombinatie gekraakt.");
                    codeGekraakt = true;
                }
            }
            else
            {
                MessageBox.Show("De invoer heeft niet het juiste aantal kleuren. Zorg ervoor dat je 6 kleuren invoert.");
            }

            // Verlaag aantal pogingen
            pogingen--;
        }

        // Als de speler geen pogingen meer heeft, toon de geheime code
        if (!codeGekraakt)
        {
            MessageBox.Show("Je hebt al je pogingen gebruikt. De combinatie was:");
            MessageBox.Show(string.Join(" ", geheimeCombinatie));
        }

        if (eindklassement)
            { 
            (codeGekraakt(MessageBox.Show($"Code is gekraakt in {pogingen} (oké).")));
            codeGekraakt = false;
            }
        else
        {
            (!codeGekraakt(MessageBox.Show($"You failed! De correcte code was {geheimeCombinatie}(oké).")));
            codeGekraakt = true;
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

                // Als de kleur niet in de code zit
                if (score[i] != 1)
                {
                    score[i] = 2;
                }
            }
        }

        return score;

        string[] highscores = { "naam speler, X pogingen, score/100" };

        StartGame();
        {
            // Maak een nieuwe lijst voor de namen van de spelers
            List<string> spelers = new List<string>();

            bool nogEenSpeler = true;
            while (nogEenSpeler)
            {
                // Vraag om de naam van de speler
                string spelerNaam = Microsoft.VisualBasic.Interaction.InputBox("Voer de naam van de speler in:", "Spelernaam");

                // Voeg de naam toe aan de lijst
                if (!string.IsNullOrEmpty(spelerNaam))
                {
                    spelers.Add(spelerNaam);
                }

                // Vraag of er nog een speler toegevoegd moet worden
                string antwoord = Microsoft.VisualBasic.Interaction.InputBox("Wilt u nog een speler toevoegen? (Ja/Nee)", "Nieuwe Speler", "Ja");

                // Als het antwoord "Nee" is, stoppen we met het toevoegen van spelers
                if (antwoord.Equals("Nee", StringComparison.OrdinalIgnoreCase))
                {
                    nogEenSpeler = false;
                }
            }

            // Optioneel: geef een melding met de namen van de spelers
            string spelerNamen = string.Join(", ", spelers);
            MessageBox.Show($"Spelers: {spelerNamen}", "Spelerslijst");
        }

        Private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }
    }

    private void KoopHint()
    {
        
        string bericht = $"Je hebt {strafpunten} strafpunten.\n" +
                         "Kies een hint:\n" +
                         "1. Juiste kleur (15 strafpunten)\n" +
                         "2. Juiste kleur op de juiste plaats (25 strafpunten)";

        MessageBoxResult keuze = MessageBox.Show(bericht, "Kies een hint", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);


        if (keuze == MessageBoxResult.Yes)
        {
            if (strafpunten >= 15)
            {
                strafpunten -= 15;
                MessageBox.Show("Je hebt 15 strafpunten betaald voor een juiste kleur hint.", "Hint gekocht", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg strafpunten om deze hint te kopen.", "Niet genoeg strafpunten", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        else if (keuze == MessageBoxResult.No)
        {
            if (strafpunten >= 25)
            {
                strafpunten -= 25;
                MessageBox.Show("Je hebt 25 strafpunten betaald voor een juiste kleur op de juiste plaats hint.", "Hint gekocht", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Je hebt niet genoeg strafpunten om deze hint te kopen.", "Niet genoeg strafpunten", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

    private void BeoordeelGok(string spelerGok, string juisteKleur, string juistePositie)

    {
        GokTextBox.BorderBrush = Brushes.Transparent;
        GokTextBox.ToolTip = "Foute kleur";

        if (spelerGok == juisteKleur)
        {
            if (spelerGok == juistePositie) // Juiste kleur, juiste positie
            {
                GokTextBox.BorderBrush = Brushes.Red;
                GokTextBox.ToolTip = "Juiste kleur, juiste positie";
            }
            else // Juiste kleur, foute positie
            {
                GokTextBox.BorderBrush = Brushes.White;
                GokTextBox.ToolTip = "Juiste kleur, foute positie";
            }
        }
        // Als het geen juiste kleur is, geef geen randkleur
        else
        {
            GokTextBox.BorderBrush = Brushes.Transparent;
            GokTextBox.ToolTip = "Foute kleur";
        }
    }

   
    private void BtnBeoordeelGok_Click(object sender, RoutedEventArgs e)
    {

        string spelerGok = GokTextBox.Text; 
        string juisteKleur = "Rood"; 
        string juistePositie = "Rood"; 

        BeoordeelGok(spelerGok, juisteKleur, juistePositie);
    }
}

    