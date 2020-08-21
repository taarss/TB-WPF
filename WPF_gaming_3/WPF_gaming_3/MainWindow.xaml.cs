using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;
using WPF_gaming_3.CharCreation;
using WPF_gaming_3.backend;


namespace WPF_gaming_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        business businessClass = new business();
        
        private int skill1 = 0;
        private int skill2 = 0;
        private int skill3 = 0;
        private int skillPoints = 10;
        private SoundPlayer mainBg = new SoundPlayer("C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/mainBgMusic.wav");
        public MainWindow()
        {
            InitializeComponent();
                 mainBg.LoadCompleted += delegate (object sender, AsyncCompletedEventArgs e) {
                 mainBg.PlayLooping();
                 };
                 mainBg.LoadAsync();

        }
           
        private void myGif_MediaEnded(object sender, RoutedEventArgs e)
        {

            myGif.Position = new TimeSpan(0, 0, 1);
            myGif.Play();
        }





        //============================================== main menu buttons ===================================================
        private void menuStart_Click(object sender, RoutedEventArgs e)
        {
            mainMenuCanvas.Visibility = Visibility.Hidden;
            charCreationMenu.Visibility = Visibility.Visible;
        }

        private void exitMainBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }







        //=================================== ADD SKILL BUTTONS ==================================================

        private void sAdd_Click(object sender, RoutedEventArgs e)
        {
            if (skillPoints > 0 && skill1 < 10)
            {
                skill1++;
                skillPoints--;
                sSkillp.Text = skill1.ToString();
                skillPointsTxt.Text = skillPoints.ToString();
            }
        }
        private void sMinus_Click(object sender, RoutedEventArgs e)
        {
            if (skillPoints < 10 && skill1 > 0)
            {
                skill1--;
                skillPoints++;
                sSkillp.Text = skill1.ToString();
                skillPointsTxt.Text = skillPoints.ToString();
            }
        }

        private void aAdd_Click(object sender, RoutedEventArgs e)
        {
            if (skillPoints > 0 && skill2 < 10)
            {
                skill2++;
                skillPoints--;
                aSkillp.Text = skill2.ToString();
                skillPointsTxt.Text = skillPoints.ToString();
            }
        }

        private void aMinus_Click(object sender, RoutedEventArgs e)
        {
            if (skillPoints < 10 && skill2 > 0)
            {
                skill2--;
                skillPoints++;
                aSkillp.Text = skill2.ToString();
                skillPointsTxt.Text = skillPoints.ToString();
            }
        }

        private void lAdd_Click(object sender, RoutedEventArgs e)
        {
            if (skillPoints > 0 && skill3 < 10)
            {
                skill3++;
                skillPoints--;
                lSkillp.Text = skill3.ToString();
                skillPointsTxt.Text = skillPoints.ToString();
            }
        }

        private void lMinus_Click(object sender, RoutedEventArgs e)
        {
            if (skillPoints < 10 && skill3 > 0)
            {
                skill3--;
                skillPoints++;
                lSkillp.Text = skill3.ToString();
                skillPointsTxt.Text = skillPoints.ToString();
            }
        }









        //=================================== CREATE AND CLASS BUTTONS ==================================================

        private void createCharBtn_Click(object sender, RoutedEventArgs e)
        {


            if (warriorRadioBtn.IsChecked == true && skillPoints == 0)
            {
                if (playerNameInput.Text == "your name")
                {
                    MessageBox.Show("I swear to god I will break your knee caps");
                }
                businessClass.createClass("warrior", skill1, skill2, skill3, playerNameInput.Text);
            }
            if (skillPoints > 0)
            {
                MessageBox.Show("Please use all of your skill points.......     You'll need it.");
            }

            if (warriorRadioBtn.IsChecked == false && deathKnightRadioBtn.IsChecked == false)
            {
                MessageBox.Show("Please pick a class!");
            }
            if (playerNameInput.Text == "")
            {
                MessageBox.Show("Please write your name");
            }
            
        }


        private void warriorRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            dkChar.Visibility = Visibility.Hidden;
            warriorChar.Visibility = Visibility.Visible;
        }

        private void deathKnightRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            dkChar.Visibility = Visibility.Visible;
            warriorChar.Visibility = Visibility.Hidden;
        }
























        /*
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (radioWarrior.IsChecked == true)
            {
                businessClass.createClass("warrior",
                    Convert.ToInt32(strengthComboBox.Text),
                    Convert.ToInt32(agilityComboBox.Text),
                    Convert.ToInt32(luckComboBox.Text));
            }
            else if (radioDK.IsChecked == true)
            {
                businessClass.createClass("death knight",
                    Convert.ToInt32(strengthComboBox.Text),
                    Convert.ToInt32(agilityComboBox.Text),
                    Convert.ToInt32(luckComboBox.Text));

            }
            if (radioDK.IsChecked == false && radioWarrior.IsChecked == false)
            {
                MessageBox.Show("Please pick a class!");

            }


        }





        public void strengthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            skillPoints = Convert.ToInt32(createMenuSkillPoints.Text);
            if (skillPoints > 0)
            {
                createMenuSkillPoints.Text = skillPoints.ToString();
                if (skillPoints - Convert.ToInt32(strengthComboBox.SelectedValue.ToString()) < 1)
                {
                    createBtn.IsEnabled = false;
                    createMenuSkillPoints.Text = skillPoints.ToString();
                    MessageBox.Show("not enough skill points");
                }
                else
                {
                    if (skill1 == null)
                    {
                        skill1 = 0;
                    }
                    skill2 = Convert.ToInt32(agilityComboBox.SelectedValue.ToString());
                    if (skill2 == null)
                    {
                        skill2 = 0;
                    }
                    skill3 = Convert.ToInt32(luckComboBox.SelectedValue.ToString());
                    if (skill3 == null)
                    {
                        skill3 = 0;
                    }
                    skill1 = Convert.ToInt32(strengthComboBox.SelectedValue.ToString());
                    skill2 = Convert.ToInt32(agilityComboBox.SelectedValue.ToString());
                    skill3 = Convert.ToInt32(luckComboBox.SelectedValue.ToString());
                    skillPoints = 10 - (skill1 + skill2 + skill3);
                    createMenuSkillPoints.Text = skillPoints.ToString();
                    createBtn.IsEnabled = true;
                }
            }
        }

        public void agilityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            skillPoints = Convert.ToInt32(createMenuSkillPoints.Text);

            if (skillPoints > 0)
            {
                if (skillPoints - Convert.ToInt32(agilityComboBox.SelectedValue.ToString()) < 1)
                {
                    createBtn.IsEnabled = false;
                    MessageBox.Show("not enough skill points");
                }
                else
                {
                    if (skill1 == null)
                    {
                        skill1 = 0;
                    }
                    skill2 = Convert.ToInt32(agilityComboBox.SelectedValue.ToString());
                    if (skill2 == null)
                    {
                        skill2 = 0;
                    }
                    skill3 = Convert.ToInt32(luckComboBox.SelectedValue.ToString());
                    if (skill3 == null)
                    {
                        skill3 = 0;
                    }
                    skill1 = Convert.ToInt32(strengthComboBox.SelectedValue.ToString());
                    skill2 = Convert.ToInt32(agilityComboBox.SelectedValue.ToString());
                    skill3 = Convert.ToInt32(luckComboBox.SelectedValue.ToString());
                    createMenuSkillPoints.Text = skillPoints.ToString();
                    skillPoints = 10 - (skill1 + skill2 + skill3);
                    createBtn.IsEnabled = true;
                }
            }
        }

        public void luckComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            skillPoints = Convert.ToInt32(createMenuSkillPoints.Text);

            if (skillPoints > 0)
            {
                if (skillPoints - Convert.ToInt32(luckComboBox.SelectedValue.ToString()) < 1)
                {
                    createBtn.IsEnabled = false;
                    MessageBox.Show("not enough skill points");
                }
                else
                {

                    skill1 = Convert.ToInt32(strengthComboBox.SelectedValue.ToString());
                    if (skill1 == null)
                    {
                        skill1 = 0;
                    }
                    skill2 = Convert.ToInt32(agilityComboBox.SelectedValue.ToString());
                    if (skill2 == null)
                    {
                        skill2 = 0;
                    }
                    skill3 = Convert.ToInt32(luckComboBox.SelectedValue.ToString());
                    if (skill3 == null)
                    {
                        skill3 = 0;
                    }
                    skillPoints = 10 - (skill1 + skill2 + skill3);
                    createMenuSkillPoints.Text = skillPoints.ToString();
                    createBtn.IsEnabled = true;
                }
            }
        }

        //Warrior
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            imgShowClass.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/Documents/S2/Klasser oh Objekter/wpf_gaming_3/wpf_gaming_3/Images/warrior.png"));
        }
        //DeathKnight
        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            imgShowClass.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/Documents/S2/Klasser oh Objekter/wpf_gaming_3/wpf_gaming_3/Images/dk.jpg"));

        }

        */
    }
}
