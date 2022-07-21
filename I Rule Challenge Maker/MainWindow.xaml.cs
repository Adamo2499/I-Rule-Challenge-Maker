using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows;
using System.Windows.Data;

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
        int[] disposableCards = { 0, 0, 0, 0 };
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
        List<Baby> babiesList = new List<Baby>();
        public BindingListCollectionView View1 { get; set; }
        public BindingListCollectionView View2 { get; set; }
        public BindingListCollectionView View3 { get; set; }
        public BindingListCollectionView View4 { get; set; }




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
            numberOfBabiesComboBox.Items.Add(1);
            numberOfBabiesComboBox.Items.Add(2);
            numberOfBabiesComboBox.Items.Add(3);
            numberOfBabiesComboBox.Items.Add(4);

            babiesList = LoadCollectionData();

            for (int i = 0; i < babiesList.Count; i++)
            {
                firstBabyComboBox.Items.Add(babiesList[i].Name);
                secondBabyComboBox.Items.Add(babiesList[i].Name);
                thirdBabyComboBox.Items.Add(babiesList[i].Name);
                fourthBabyComboBox.Items.Add(babiesList[i].Name);
            }
            for (int line = 0; line < challengeContent.LineCount; line++)
            {
                lines.Add(challengeContent.GetLineText(line));
            }
            numberOfBabiesComboBox.SelectedIndex = 0;
            babiesList = LoadCollectionData();


        }
        private string _selected1;
        public string Selected1
        {
            get { return _selected1; }
            set
            {
                _selected1 = value;
                this.UpdateFilter();
            }
        }
        private string GetFilter(string selected2, string selected3, string selected4)
        {
            var filter = "";

            if (!string.IsNullOrWhiteSpace(selected2))
                filter = "Name <> '" + selected2 + "' and ";

            if (!string.IsNullOrWhiteSpace(selected3))
                filter += "Name <> '" + selected3 + "' and ";

            if (!string.IsNullOrWhiteSpace(selected4))
                filter += "Name <> '" + selected4 + "' and ";

            if (!string.IsNullOrWhiteSpace(filter))
                filter = filter.Substring(0, filter.Length - 4);

            return filter;
        }
        private void UpdateFilter()
        {
            this.View1.CustomFilter = GetFilter(this.Selected2, this.Selected3, this.Selected4);
            this.View2.CustomFilter = GetFilter(this.Selected1, this.Selected3, this.Selected4);
            this.View3.CustomFilter = GetFilter(this.Selected1, this.Selected2, this.Selected4);
            this.View4.CustomFilter = GetFilter(this.Selected1, this.Selected2, this.Selected3);
        }

        private string _selected2;
        public string Selected2
        {
            get { return _selected2; }
            set
            {
                _selected2 = value;
                this.UpdateFilter();
            }
        }

        private string _selected3;
        public string Selected3
        {
            get { return _selected3; }
            set
            {
                _selected3 = value;
                this.UpdateFilter();
            }

        }
        private string _selected4;
        public string Selected4
        {
            get { return _selected4; }
            set
            {
                _selected4 = value;
                this.UpdateFilter();
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

        private void numberOfBabiesComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int numberOfBabies = int.Parse(numberOfBabiesComboBox.SelectedItem.ToString());
            switch (numberOfBabies)
            {
                case 1:
                    firstBabyComboBox.IsEnabled = true;
                    secondBabyComboBox.IsEnabled = false;
                    secondBabyComboBox.SelectedIndex = -1;
                    thirdBabyComboBox.IsEnabled = false;
                    thirdBabyComboBox.SelectedIndex = -1;
                    fourthBabyComboBox.IsEnabled = false;
                    fourthBabyComboBox.SelectedIndex = -1;
                    break;
                case 2:
                    firstBabyComboBox.IsEnabled = true;
                    secondBabyComboBox.IsEnabled = true;
                    thirdBabyComboBox.IsEnabled = false;
                    thirdBabyComboBox.SelectedIndex = -1;
                    fourthBabyComboBox.IsEnabled = false;
                    fourthBabyComboBox.SelectedIndex = -1;
                    break;
                case 3:
                    firstBabyComboBox.IsEnabled = true;
                    secondBabyComboBox.IsEnabled = true;
                    thirdBabyComboBox.IsEnabled = true;
                    fourthBabyComboBox.IsEnabled = false;
                    fourthBabyComboBox.SelectedIndex = -1;
                    break;
                case 4:
                    firstBabyComboBox.IsEnabled = true;
                    secondBabyComboBox.IsEnabled = true;
                    thirdBabyComboBox.IsEnabled = true;
                    fourthBabyComboBox.IsEnabled = true;
                    break;
            }
        }
        private void firstBabyComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            foreach (Baby baby in babiesList)
            {

                if (baby.Name == firstBabyComboBox.SelectedItem)
                {
                    disposableCards[0] = baby.ID;
                }
            }
            if (firstBabyComboBox.SelectedItem != null)
            {
                challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(6), "global.disposableCards =  " + disposableCards[0] + ", " + disposableCards[1] + ", " + disposableCards[2] + ", " + disposableCards[3] + ", " + "\r\n");

            }

        }

        private void secondComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            foreach (Baby baby in babiesList)
            {

                if (baby.Name == secondBabyComboBox.SelectedItem)
                {
                    disposableCards[1] = baby.ID;
                }
            }
            if (secondBabyComboBox.SelectedItem != null)
            {
                challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(6), "global.disposableCards =  " + disposableCards[0] + ", " + disposableCards[1] + ", " + disposableCards[2] + ", " + disposableCards[3] + ", " + "\r\n");

            }
        }
        private void thirdComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            foreach (Baby baby in babiesList)
            {

                if (baby.Name == thirdBabyComboBox.SelectedItem)
                {
                    disposableCards[2] = baby.ID;
                }
            }
            if (thirdBabyComboBox.SelectedItem != null)
            {
                challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(6), "global.disposableCards =  " + disposableCards[0] + ", " + disposableCards[1] + ", " + disposableCards[2] + ", " + disposableCards[3] + ", " + "\r\n");

            }
        }
        private void fourthComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            foreach (Baby baby in babiesList)
            {

                if (baby.Name == fourthBabyComboBox.SelectedItem)
                {
                    disposableCards[3] = baby.ID;
                }
            }
            if (fourthBabyComboBox.SelectedItem != null)
            {
                challengeContent.Text = challengeContent.Text.Replace(challengeContent.GetLineText(6), "global.disposableCards =  " + disposableCards[0] + ", " + disposableCards[1] + ", " + disposableCards[2] + ", " + disposableCards[3] + ", " + "\r\n");
            }
        }
        private List<Baby> LoadCollectionData()
        {
            List<Baby> Babies = new List<Baby>();
            Babies.Add(new Baby()
            {
                ID = 2,
                Name = "Brother Bobby",
            });
            Babies.Add(new Baby()
            {
                ID = 3,
                Name = "Little C.H.A.D.",
            });
            Babies.Add(new Baby()
            {
                ID = 4,
                Name = "Cube of Meat",
            });
            Babies.Add(new Baby()
            {
                ID = 6,
                Name = "Lil Loki",
            });
            Babies.Add(new Baby()
            {
                ID = 7,
                Name = "Harlequin Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 8,
                Name = "Wiz Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 9,
                Name = "Freezer Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 10,
                Name = "Hallowed Ground",
            });
            Babies.Add(new Baby()
            {
                ID = 11,
                Name = "BBF",
            });
            Babies.Add(new Baby()
            {
                ID = 12,
                Name = "Farting Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 13,
                Name = "Mongo Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 14,
                Name = "Little Steven",
            });
            Babies.Add(new Baby()
            {
                ID = 15,
                Name = "Multidimensional Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 16,
                Name = "Spider Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 17,
                Name = "Rainbow Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 18,
                Name = "Rubber Soul",
            });
            Babies.Add(new Baby()
            {
                ID = 19,
                Name = "Ghost Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 20,
                Name = "Spike Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 21,
                Name = "Mystery Egg",
            });
            Babies.Add(new Baby()
            {
                ID = 22,
                Name = "Demon Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 23,
                Name = "Tooth & Nail",
            });
            Babies.Add(new Baby()
            {
                ID = 24,
                Name = "Acid Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 25,
                Name = "Abel",
            });
            Babies.Add(new Baby()
            {
                ID = 26,
                Name = "Dry Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 27,
                Name = "Revenant",
            });
            Babies.Add(new Baby()
            {
                ID = 28,
                Name = "Crispy Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 29,
                Name = "Paschal Candle",
            });
            Babies.Add(new Baby()
            {
                ID = 30,
                Name = "Pegasus",
            });
            Babies.Add(new Baby()
            {
                ID = 31,
                Name = "Snowball",
            });
            Babies.Add(new Baby()
            {
                ID = 33,
                Name = "Double Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 34,
                Name = "Fistuloid",
            });
            Babies.Add(new Baby()
            {
                ID = 35,
                Name = "Juicy Sack",
            });
            Babies.Add(new Baby()
            {
                ID = 36,
                Name = "Psychic Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 37,
                Name = "Peeping",
            });
            Babies.Add(new Baby()
            {
                ID = 39,
                Name = "Fiend Baby",
            });
            Babies.Add(new Baby()
            {
                ID = 40,
                Name = "Parasitoid",
            });
            Babies.Add(new Baby()
            {
                ID = 41,
                Name = "Brain Worm",
            });
            Babies.Add(new Baby()
            {
                ID = 42,
                Name = "Ball of Bandages",
            });
            Babies.Add(new Baby()
            {
                ID = 43,
                Name = "Baby Pluto",
            });
            Babies.Add(new Baby()
            {
                ID = 44,
                Name = "Lil Keeper",
            });
            Babies.Add(new Baby()
            {
                ID = 45,
                Name = "Red Maw",
            });
            Babies.Add(new Baby()
            {
                ID = 46,
                Name = "Cursed Baby",
            });

            return Babies;
        }
        public void DeselectAllBabies()
        {
            firstBabyComboBox.SelectedIndex = -1;
            secondBabyComboBox.SelectedIndex = -1;
            thirdBabyComboBox.SelectedIndex = -1;
            fourthBabyComboBox.SelectedIndex = -1;
        }

    }
}
