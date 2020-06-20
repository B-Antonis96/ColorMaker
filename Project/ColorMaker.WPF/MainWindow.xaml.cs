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

namespace ColorMaker.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Visibility visible = Visibility.Visible;
        Visibility hidden = Visibility.Collapsed;

        public MainWindow()
        {
            InitializeComponent();
        }

        //SCHERM LADEN
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rbColorInput.IsChecked = true;

        }




        //INVOER GEDEELTE
        private void rbColorInput_Checked(object sender, RoutedEventArgs e)
        {
            //Scherm RADIOBUTTON verwisselen
            rbColorRandom.IsChecked = false;

            //Zichtbaar maken van DEEL objecten
            txtBlauw.Visibility = visible;
            txtGroen.Visibility = visible;
            txtRood.Visibility = visible;
            btnPassColorCode.Visibility = visible;
            btnResetBlauweButton.Visibility = visible;
            btnResetGroeneButton.Visibility = visible;
            btnResetRodeButton.Visibility = visible;
            lblBlauwInput.Visibility = visible;
            lblGroenInput.Visibility = visible;
            lblRoodInput.Visibility = visible;

            //Onzichtbaar maken van andere DEEL objecten
            txtBlauwRandom.Visibility = hidden;
            txtGroenRandom.Visibility = hidden;
            txtRoodRandom.Visibility = hidden;
            btnPassColorCodeRandom.Visibility = hidden;
            lblBlauwRandom.Visibility = hidden;
            lblGroenRandom.Visibility = hidden;
            lblRoodRandom.Visibility = hidden;



        }

        private void btnResetRodeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnResetGroeneButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnResetBlauweButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPassColorCode_Click(object sender, RoutedEventArgs e)
        {

        }



        //RANDOM GEDEELTE
        private void rbColorRandom_Checked(object sender, RoutedEventArgs e)
        {
            //Scherm RADIOBUTTON verwisselen
            rbColorInput.IsChecked = false;

            //Zichtbaar maken van DEEL objecten
            txtBlauwRandom.Visibility = visible;
            txtGroenRandom.Visibility = visible;
            txtRoodRandom.Visibility = visible;
            btnPassColorCodeRandom.Visibility = visible;
            lblBlauwRandom.Visibility = visible;
            lblGroenRandom.Visibility = visible;
            lblRoodRandom.Visibility = visible;

            //Onzichtbaar maken van andere DEEL objecten
            txtBlauw.Visibility = hidden;
            txtGroen.Visibility = hidden;
            txtRood.Visibility = hidden;
            btnPassColorCode.Visibility = hidden;
            btnResetBlauweButton.Visibility = hidden;
            btnResetGroeneButton.Visibility = hidden;
            btnResetRodeButton.Visibility = hidden;
            lblBlauwInput.Visibility = hidden;
            lblGroenInput.Visibility = hidden;
            lblRoodInput.Visibility = hidden;
        }

        private void btnMakeRandomColor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPassColorCodeRandom_Click(object sender, RoutedEventArgs e)
        {

        }



        //RESET KLEURCODE
        private void btnResetColorCode_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
