using System;
using System.Windows;
using System.Windows.Media;

namespace ColorMaker.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Zichtbaarheids objecten aanmaken
        Visibility visible = Visibility.Visible;
        Visibility hidden = Visibility.Hidden;

        string nul = 0.ToString();

        //Aanmaken KLEUR
        Color kleur = new Color();

        public MainWindow()
        {
            InitializeComponent();
        }

        //SCHERM LADEN
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetToBlack();
            SetToNul();

            rbColorInput.IsChecked = true;

            string nul = 0.ToString();
        }




        //INPUT GEDEELTE
        private void rbColorInput_Checked(object sender, RoutedEventArgs e)
        {
            //Scherm RADIOBUTTON verwisselen
            rbColorRandom.IsChecked = false;

            //Zichtbaar maken van INPUT objecten
            InputVisibility(visible);

            //Onzichtbaar maken van Random objecten
            RandomVisibility(hidden);

            SetToBlack();
        }

        private void btnResetRodeButton_Click(object sender, RoutedEventArgs e)
        {
            txtRood.Text = nul;
        }

        private void btnResetGroeneButton_Click(object sender, RoutedEventArgs e)
        {
            txtGroen.Text = nul;
        }

        private void btnResetBlauweButton_Click(object sender, RoutedEventArgs e)
        {
            txtBlauw.Text = nul;
        }

        private void btnPassColorCode_Click(object sender, RoutedEventArgs e)
        {
            txtRood.Text = ColorSetter(int.Parse(txtRood.Text)).ToString();
            txtGroen.Text = ColorSetter(int.Parse(txtGroen.Text)).ToString();
            txtBlauw.Text = ColorSetter(int.Parse(txtBlauw.Text)).ToString();

            string kleurHex = HexMaker(txtRood.Text, txtGroen.Text, txtBlauw.Text);
            txtColorOutput.Text = kleurHex;

            kleur = ByteSwitcher(txtRood.Text, txtGroen.Text, txtBlauw.Text);
            lblColorLabel.Background = new SolidColorBrush(kleur);
        }


        //PLUS MIN knoppen
        private void btnMinRodeButton_Click(object sender, RoutedEventArgs e)
        {
            int rood = int.Parse(txtRood.Text);
            txtRood.Text = ColorSetter(ColorMin(rood)).ToString();

        }

        private void btnPlusRodeButton_Click(object sender, RoutedEventArgs e)
        {
            int rood = int.Parse(txtRood.Text);
            txtRood.Text = ColorSetter(ColorPlus(rood)).ToString();
        }

        private void btnMinGroeneButton_Click(object sender, RoutedEventArgs e)
        {
            int groen = int.Parse(txtGroen.Text);
            txtGroen.Text = ColorSetter(ColorMin(groen)).ToString();
        }

        private void btnPlusGroeneButton_Click(object sender, RoutedEventArgs e)
        {
            int groen = int.Parse(txtGroen.Text);
            txtGroen.Text = ColorSetter(ColorPlus(groen)).ToString();
        }

        private void btnMinBlauweButton_Click(object sender, RoutedEventArgs e)
        {
            int blauw = int.Parse(txtBlauw.Text);
            txtBlauw.Text = ColorSetter(ColorMin(blauw)).ToString();
        }

        private void btnPlusBlauweButton_Click(object sender, RoutedEventArgs e)
        {
            int blauw = int.Parse(txtBlauw.Text);
            txtBlauw.Text = ColorSetter(ColorPlus(blauw)).ToString();
        }



        //RANDOM GEDEELTE
        private void rbColorRandom_Checked(object sender, RoutedEventArgs e)
        {
            //Scherm RADIOBUTTON verwisselen
            rbColorInput.IsChecked = false;

            //Zichtbaar maken van RANDOM objecten
            RandomVisibility(visible);

            //Onzichtbaar maken van INPUT objecten
            InputVisibility(hidden);

            SetToBlack();
        }

        private void btnMakeRandomColor_Click(object sender, RoutedEventArgs e)
        {
            Random willekeurig = new Random();

            int rood = willekeurig.Next(0, 255);
            int groen = willekeurig.Next(0, 255);
            int blauw = willekeurig.Next(0, 255);

            txtRoodRandom.Text = rood.ToString();
            txtGroenRandom.Text = groen.ToString();
            txtBlauwRandom.Text = blauw.ToString();

            txtColorOutput.Text = HexMaker(rood.ToString(), groen.ToString(), blauw.ToString());

            kleur = ByteSwitcher(rood.ToString(), groen.ToString(), blauw.ToString());
            lblColorLabel.Background = new SolidColorBrush(kleur);
        }



        //RESET KLEURCODE
        private void btnResetColorCode_Click(object sender, RoutedEventArgs e)
        {
            txtColorOutput.Text = "#000000";

            SetToBlack();
        }



        //METHODES

        //KLEUR setter
        private int ColorSetter(int kleur)
        {
            if (kleur < 0)
            {
                kleur = 0;
                MessageBox.Show($"Waarde mag niet onder {kleur} komen!");
            }
            if (kleur > 255)
            {
                kleur = 255;
                MessageBox.Show($"Waarde mag niet boven {kleur} komen!");
            }

            return kleur;
        }

        //KLEUR changer plus
        private int ColorPlus(int panel)
        {
            panel += 1;
            return panel;
        }

        //KLEUR changer min
        private int ColorMin(int panel)
        {
            panel -= 1;
            return panel;
        }

        //HEX berekening
        private string HexMaker(string textR, string textG, string textB)
        {
            int rood = int.Parse(textR);
            int groen = int.Parse(textG);
            int blauw = int.Parse(textB);

            string hex = $"#{rood.ToString("X2")}{groen.ToString("X2")}{blauw.ToString("X2")}";

            return hex;
        }

        //BYTE bewerking
        private Color ByteSwitcher(string textR, string textG, string textB)
        {
            byte roodByte = byte.Parse(textR);
            byte groenByte = byte.Parse(textG);
            byte blauwByte = byte.Parse(textB);

            Color kleur = Color.FromRgb(roodByte, groenByte, blauwByte);

            return kleur;
        }

        //RESET scherm naar zwart
        private void SetToBlack()
        {
            Color klr = Color.FromRgb(0, 0, 0);
            lblColorLabel.Background = new SolidColorBrush(klr);
        }

        //Schermen op nul (0) zetten
        private void SetToNul()
        {
            txtBlauw.Text = nul;
            txtGroen.Text = nul;
            txtRood.Text = nul;
            txtBlauwRandom.Text = nul;
            txtGroenRandom.Text = nul;
            txtRoodRandom.Text = nul;
        }

        //Visibility INPUT (hidden / visible)
        private void InputVisibility(Visibility veld)
        {
            txtBlauw.Visibility = veld;
            txtGroen.Visibility = veld;
            txtRood.Visibility = veld;
            btnPassColorCode.Visibility = veld;
            btnResetBlauweButton.Visibility = veld;
            btnResetGroeneButton.Visibility = veld;
            btnResetRodeButton.Visibility = veld;
            lblBlauwInput.Visibility = veld;
            lblGroenInput.Visibility = veld;
            lblRoodInput.Visibility = veld;
            btnMinBlauweButton.Visibility = veld;
            btnMinGroeneButton.Visibility = veld;
            btnMinRodeButton.Visibility = veld;
            btnPlusBlauweButton.Visibility = veld;
            btnPlusGroeneButton.Visibility = veld;
            btnPlusRodeButton.Visibility = veld;

            SetToNul();
        }

        //Visibility RANDOM (hidden / visible)
        private void RandomVisibility(Visibility veld)
        {
            txtBlauwRandom.Visibility = veld;
            txtGroenRandom.Visibility = veld;
            txtRoodRandom.Visibility = veld;
            btnMakeRandomColor.Visibility = veld;
            lblBlauwRandom.Visibility = veld;
            lblGroenRandom.Visibility = veld;
            lblRoodRandom.Visibility = veld;

            SetToNul();
        }
    }
}
