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

namespace CA3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> allPlayers = new List<Player>();
        List<Player> selectedPlayers = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Sorting by first name then second name.
            allPlayersLB.ItemsSource = allPlayers.OrderBy(s => s.Name).ThenBy(s => s.Surname);

            // Creating the randomNames
            string[] firstNames = { "Adam", "Amelia", "Ava", "Chloe", "Conor", "Daniel", "Emily", "Emma", "Grace", "Hannah", "Harry", "Jack", "James", "Lucy", "Luke", "Mia", "Michael", "Noah", "Sean", "Sophie" };
            string[] lastNames = { "Brennan", "Byrne", "Daly", "Doyle", "Dunne", "Fitzgerald", "Kavanagh", "Kelly", "Lynch", "McCarthy", "McDonagh", "Murphy", "Nolan", "O'Brien", "O'Connor", "O'Neill", "O'Reilly", "O'Sullivan", "Ryan", "Walsh" };

            Random rng = new Random();

            for (int i = 0; i < 20; i++)
            {
                int number = rng.Next(0, 20);
                string Name = firstNames[number];
                number = rng.Next(0, 20);
                string Surname = lastNames[number];
            }

            // Setting up the contents of the ComboBox
            formationsCbx.ItemsSource = new string[] { "4-4-2", "4-3-3", "4-5-1" };
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Figure out which player is selected on screen //
            Player selectedPlayer = allPlayersLB.SelectedItem as Player;

            //Null Checker
            if (selectedPlayer != null)
            {

                //Move the item which is clicked from the left listbox to the right listbox
                allPlayers.Remove(selectedPlayer);
                selectedPlayers.Add(selectedPlayer);
            }
        }

        private void RefreshingScreen()
        {
            allPlayersLB.ItemsSource = null;
            allPlayersLB.ItemsSource = allPlayers;

            selectedPlayersLB.ItemsSource = null;
            selectedPlayersLB.ItemsSource = selectedPlayers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Figure out which player is selected on screen //
            Player selectedPlayers = allPlayersLB.SelectedItem as Player;

            //Null Checker
            if (selectedPlayers != null)
            {
                //Move the item which is clicked from the left listbox to the right listbox
                allPlayers.Add(selectedPlayers);
                allPlayers.Remove(selectedPlayers);
            }
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Player selected = allPlayersLB.SelectedItem as Player;
            if (selected != null)
            {
                spacesBx.Text = selected.Spaces;
            }
        }

        private void allPlayersLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
