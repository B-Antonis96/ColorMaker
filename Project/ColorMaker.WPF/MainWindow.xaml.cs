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
using System.Drawing;

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
            if (string.IsNullOrWhiteSpace(txtRood.Text))
            {
                MessageBox.Show("ROOD moet een invoer hebben", "ERROR");
                txtRood.Text = nul;
            }
            if (string.IsNullOrWhiteSpace(txtGroen.Text))
            {
                MessageBox.Show("GROEN moet een invoer hebben", "ERROR");
                txtGroen.Text = nul;
            }
            if (string.IsNullOrWhiteSpace(txtBlauw.Text))
            {
                MessageBox.Show("BLAUW moet een invoer hebben", "ERROR");
                txtBlauw.Text = nul;
            }
            else
            {
                string kleurHex = HexMaker(txtRood.Text, txtGroen.Text, txtBlauw.Text);
                txtColorOutput.Text = kleurHex;

                kleur = ByteSwitcher(txtRood.Text, txtGroen.Text, txtBlauw.Text);
                lblColorLabel.Background = new SolidColorBrush(kleur);
            }
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

            txtColorOutput.Text = HexMaker(txtRoodRandom.Text, txtGroenRandom.Text, txtBlauwRandom.Text);

            kleur = ByteSwitcher(txtRoodRandom.Text, txtGroenRandom.Text, txtBlauwRandom.Text);
            lblColorLabel.Background = new SolidColorBrush(kleur);

        }



        //RESET KLEURCODE
        private void btnResetColorCode_Click(object sender, RoutedEventArgs e)
        {
            txtColorOutput.Text = "#000000";

            SetToBlack();
        }



        //METHODES


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
