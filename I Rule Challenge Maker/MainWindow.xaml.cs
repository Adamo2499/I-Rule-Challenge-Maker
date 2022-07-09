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

namespace I_Rule_Challenge_Maker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int noCoins = 1;
        int noChampions = 1;
        int fastStart = 0;
        int noShovel = 0;
        int noChargers = 1;
        int onePerWave = 1;
        int[] disposableCards = { 1 };
        int fallingResource = 0;
        int noHearts = 0;
        int noProps = 0;
        int noSpecialPoop = 0;
        int noSpots = 0;
        int gSpeedSmooth = 0;
        int gSpeed = 0;
        String name = "";
        String stageName = "";
        int stageNumber = 1;
        String stageDifficulty = "normal";
        String stageFullName = "";



        public MainWindow()
        {
            InitializeComponent();
            challengeContent.Text += "global.noCoins = " + noCoins + "\r\n";
            challengeContent.Text += "global.noChampions = " + noChampions + "\r\n";
            challengeContent.Text += "global.fastStart = " + fastStart + "\r\n";
            challengeContent.Text += "global.noShovel = " + noShovel + "\r\n";
        }


        private void noCoinsCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noCoins = noCoinsCheckbox.IsChecked == true ? 0 : 1;
            if (noCoins == 0)
            {
                challengeContent.Text = challengeContent.Text.Replace("global.noCoins = 0\r\n", "global.noCoins = 1\r\n");

            }
            else
            {
                challengeContent.Text = challengeContent.Text.Replace("global.noCoins = 1\r\n", "global.noCoins = 0\r\n");
            }
        }

        private void SaveChallengeFileButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "File saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Environment.Exit(0);
        }

        private void noChampionsCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noChampions = noChampionsCheckbox.IsChecked == true ? 0 : 1;
            if (noChampions == 0)
            {
                challengeContent.Text = challengeContent.Text.Replace("global.noChampions = 0\r\n", "global.noChampions = 1\r\n");

            }
            else
            {
                challengeContent.Text = challengeContent.Text.Replace("global.noChampions = 1\r\n", "global.noChampions = 0\r\n");
            }
        }

        private void fastStartCheckbox_Click(object sender, RoutedEventArgs e)
        {
            fastStart = fastStartCheckbox.IsChecked != true ? 0 : 1;
            if (fastStart == 0)
            {
                challengeContent.Text = challengeContent.Text.Replace("global.fastStart = 0\r\n", "global.fastStart = 1\r\n");

            }
            else
            {
                challengeContent.Text = challengeContent.Text.Replace("global.fastStart = 1\r\n", "global.fastStart = 0\r\n");
            }
        }

        private void noShovelCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noShovel = noShovelCheckbox.IsChecked == true ? 0 : 1;
            if (noShovel == 0)
            {
                challengeContent.Text = challengeContent.Text.Replace("global.noShovel = 0\r\n", "global.noShovel = 1\r\n");

            }
            else
            {
                challengeContent.Text = challengeContent.Text.Replace("global.noShovel = 1\r\n", "global.noShovel = 0\r\n");
            }
        }
    }
}
