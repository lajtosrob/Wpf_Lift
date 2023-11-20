using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using Wpf_Lift.DataSource;

namespace Wpf_Lift
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    /// </summary>
        static List<Lift> liftek = new List<Lift>();
        int kartyaSzama;
        int celSzintSzama;

        public MainWindow()
        {
            InitializeComponent();

            // 2. feladat

            StreamReader sr = new StreamReader(".\\DataSource\\lift.txt");

            while(!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(" ");

                Lift adatsor = new Lift(
                    DateOnly.Parse(line[0]),
                    int.Parse(line[1]),
                    int.Parse(line[2]),
                    int.Parse(line[3])
                    );

                liftek.Add(adatsor);
            }

            sr.Close();

            // 3. feladat

            lblFeladat3.Content = "3. feladat: Összes lifthasználat: " + liftek.Count();

            // 4. feladat

            lblFeladat4.Content = $"4. feladat: Időszak: {liftek.Min(x => x.HasznalatIdopontja)} - {liftek.Max(x => x.HasznalatIdopontja)}";

            // 5. feladat

            lblFeladat5.Content = $"5. feladat: Célszint max:  {liftek.Max(x => x.CelSzint)}";

            // 8. feladat

            Dictionary<DateOnly, int> napiStatisztika = liftek.GroupBy(x => x.HasznalatIdopontja).ToDictionary(g => g.Key, g => g.Count());

            dataGrid.ItemsSource = napiStatisztika;

        }

        // 6. feladat

        private void txtFeladat6Kartyaszam_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                
                try
                {
                    kartyaSzama = int.Parse(txtFeladat6Kartyaszam.Text);
                    MessageBox.Show("A kártyaszám sikersen rögzítve lett.");
                    txtFeladat6Celszintszam.Focus();


                }
                catch (Exception)
                {
                    kartyaSzama = 5;
                    txtFeladat6Kartyaszam.Text = "5";
                    MessageBox.Show("Az 5-ös kártyaszám rögzítve lett.");
                    txtFeladat6Celszintszam.Focus();

                }

            }
        }

        private void txtFeladat6Celszintszam_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {

                try
                {
                    celSzintSzama = int.Parse(txtFeladat6Celszintszam.Text);
                    MessageBox.Show("A célszintszám sikeresen rögzítve lett.");


                }
                catch (Exception)
                {
                    celSzintSzama = 5;
                    txtFeladat6Celszintszam.Text = "5";
                    MessageBox.Show("Az 5-ös célszintszám rögzítve lett.");

                }
            }
        }

        private void btnFeladat7_Click(object sender, RoutedEventArgs e)
        {
            if (liftek.Any(x => x.KartyaSorszama == kartyaSzama && x.CelSzint == celSzintSzama))
            {
                lblFeladat7.Content = $"7. feladat: A(z) {kartyaSzama} kártyával utaztak a {celSzintSzama}. emeletre!";
            }
            else
            {
                lblFeladat7.Content = $"7. feladat: A(z) {kartyaSzama} kártyával nem utaztak a {celSzintSzama}. emeletre!";
            }
        }
    }
}
