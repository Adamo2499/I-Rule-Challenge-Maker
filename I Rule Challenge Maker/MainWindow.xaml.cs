using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows;

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
        int[] disposableCards = { 11, 22, 33 };
        int fallingResource = 0;
        int noHearts = 0;
        int noProps = 0;
        int noSpecialPoop = 0;
        int noSpots = 0;
        double gSpeedSmooth = 1;
        double gSpeed = 1;
        String levelName = "";
        String stageName = "blue room";
        int stageNumber = 1;
        String stageDifficulty = "normal";
        StringCollection lines = new StringCollection();



        public MainWindow()
        {
            InitializeComponent();
            challengeContent.Text += "global.noCoins = " + noCoins + "\r\n";
            challengeContent.Text += "global.noChampions = " + noChampions + "\r\n";
            challengeContent.Text += "global.fastStart = " + fastStart + "\r\n";
            challengeContent.Text += "global.noShovel = " + noShovel + "\r\n";
            challengeContent.Text += "global.noChargers = " + noChargers + "\r\n";
            challengeContent.Text += "global.onePerWave = " + onePerWave + "\r\n";
            challengeContent.Text += "global.disposableCards = ";
            for (int i = 0; i < disposableCards.Length; i++)
            {
                if (i != disposableCards.Length - 1)
                {
                    challengeContent.Text += disposableCards[i] + ", ";
                }
                else
                {
                    challengeContent.Text += disposableCards[i] + " ";
                }
            }
            challengeContent.Text += "\r\n";
            challengeContent.Text += "global.fallingresource = " + fallingResource + "\r\n";
            challengeContent.Text += "global.noHearts = " + noHearts + "\r\n";
            challengeContent.Text += "global.noProps = " + noProps + "\r\n";
            challengeContent.Text += "global.noSpecialPoop = " + noSpecialPoop + "\r\n";
            challengeContent.Text += "global.noSpots = " + noSpots + "\r\n";
            challengeContent.Text += "global.gSpeedSmooth = " + gSpeedSmooth + "\r\n";
            challengeContent.Text += "global.gSpeed = " + gSpeed + "\r\n";
            challengeContent.Text += "\r\n";
            challengeContent.Text += "Name: Level1 \r\n";
            challengeContent.Text += "\r\n";
            challengeContent.Text += "Stage: " + stageName + " " + stageNumber.ToString() + " " + stageDifficulty + "\r\n";
            challengeContent.Text += "\r\n";
            chapterNameCombobox.Items.Add("Blue Room");
            chapterNameCombobox.Items.Add("It's All Mine");
            chapterNameCombobox.Items.Add("The Ark");

            for (int line = 0; line < challengeContent.LineCount; line++)
            {
                lines.Add(challengeContent.GetLineText(line));
            }
        }
        private void levelNameTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            levelName = levelNameTextbox.Text.Equals("Level1") ? "Level1" : levelNameTextbox.Text;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(15), "Name: " + levelName + "\r\n");
        }
        private void noCoinsCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noCoins = noCoinsCheckbox.IsChecked == true ? 1 : 0;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(0), "global.noCoins = " + noCoins + "\r\n");
        }

        private void noChampionsCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noChampions = noChampionsCheckbox.IsChecked == true ? 1 : 0;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(1), "global.noChampions = " + noChampions + "\r\n");
        }

        private void fastStartCheckbox_Click(object sender, RoutedEventArgs e)
        {
            fastStart = fastStartCheckbox.IsChecked != true ? 0 : 1;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(2), "global.fastStart = " + fastStart + "\r\n");
        }

        private void noShovelCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noShovel = noShovelCheckbox.IsChecked == true ? 0 : 1;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(3), "global.noShovel = " + noShovel + "\r\n");
        }
        private void noChargersCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noChargers = noChargersCheckbox.IsChecked == true ? 1 : 0;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(4), "global.noChargers = " + noChargers + "\r\n");
        }
        private void onePerWaveCheckbox_Click(object sender, RoutedEventArgs e)
        {
            onePerWave = onePerWaveCheckbox.IsChecked == true ? 1 : 0;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(5), "global.onePerWave = " + onePerWave + "\r\n");
        }

        private void noHeartsCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noHearts = noHeartsCheckbox.IsChecked == true ? 1 : 0;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(8), "global.noHearts = " + noHearts + "\r\n");
        }

        private void noPropsCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noProps = noPropsCheckbox.IsChecked == true ? 1 : 0;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(9), "global.noProps = " + noProps + "\r\n");
        }

        private void noSpecialPoopCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noSpecialPoop = noSpecialPoopCheckbox.IsChecked == true ? 1 : 0;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(10), "global.noSpecialPoop = " + noSpecialPoop + "\r\n");
        }

        private void noSpotsCheckbox_Click(object sender, RoutedEventArgs e)
        {
            noSpots = noSpotsCheckbox.IsChecked == true ? 1 : 0;
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(11), "global.noSpots = " + noSpots + "\r\n");
        }

        private void levelNumberSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            stageNumber = (int)levelNumberSlider.Value;
        }

        private void hardMode_Click(object sender, RoutedEventArgs e)
        {
            stageDifficulty = hardMode.IsChecked == true ? "hard" : "normal";
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(17), "Stage: " + chapterNameCombobox.SelectedItem + " " + levelNumberSlider.Value + " " + stageDifficulty + "\r\n");
        }

        private void gSpeedSmoothTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(gSpeedSmoothTextbox.Text, out gSpeedSmooth))
            {
                gSpeedSmooth = 1.0;
            }
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(12), "global.gSpeedSmooth = " + gSpeedSmooth + "\r\n");
        }

        private void gSpeedTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Double.TryParse(gSpeedTextbox.Text, out gSpeed))
            {
                gSpeed = 1.0;
            }
            challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(13), "global.gSpeed = " + gSpeed + "\r\n");
        }
        private void SaveChallengeFileButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            saveFileDialog.FileName = levelName.Equals("") ? "Level1" : levelName;
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, challengeContent.Text);
            MessageBox.Show(this, "File saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Environment.Exit(0);

        }
    }
}
