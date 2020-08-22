﻿using System;
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
        private int skillActionIndex = 0;
        private int skillPoints = 10;
        Random random = new Random();
        private int dungoenGlobalIndex;
        private int currentEnemyHp;
        private int currentPlayerHp;
        private int currentPlayerStamina;
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
            businessClass.selcectSound();

            mainMenuCanvas.Visibility = Visibility.Hidden;
            charCreationMenu.Visibility = Visibility.Visible;
        }

        private void exitMainBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();

            System.Environment.Exit(1);
        }







        //=================================== ADD SKILL BUTTONS ==================================================

        private void sAdd_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();

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
            businessClass.selcectSound();

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
            businessClass.selcectSound();

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
            businessClass.selcectSound();

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
            businessClass.selcectSound();

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
            businessClass.selcectSound();

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
            businessClass.selcectSound();
            if (warriorRadioBtn.IsChecked == true && skillPoints == 0)
            {
                if (playerNameInput.Text == "your name")
                {
                    MessageBox.Show("I swear to god I will break your knee caps");
                }
                
                businessClass.createClass("warrior", skill1, skill2, skill3, playerNameInput.Text);
                charCreationMenu.Visibility = Visibility.Hidden;
                map.Visibility = Visibility.Visible;
                
                //temp

            }
            else
            {
                MessageBox.Show("Error 20");
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

        //Back Btn
        private void backBtnChar_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();

            mainMenuCanvas.Visibility = Visibility.Visible;
            charCreationMenu.Visibility = Visibility.Hidden;
        }


        private void warriorRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();

            dkChar.Visibility = Visibility.Hidden;
            warriorChar.Visibility = Visibility.Visible;
        }

        private void deathKnightRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();

            dkChar.Visibility = Visibility.Visible;
            warriorChar.Visibility = Visibility.Hidden;
        }





        //============================================ MAP BUTTONS =========================
        private void mapArea1_Click(object sender, RoutedEventArgs e)
        {
            dungoenGlobalIndex = 0;
            businessClass.createDungoen(dungoenGlobalIndex);
            businessClass.selcectSound();
            preImg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgPath));

            confirmEnter.Visibility = Visibility.Visible;
            nameAreaTxt.Text = businessClass.dungoens[0].DungoenName;
            reqLvlTxt.Text = businessClass.dungoens[0].DungoenDifficulty.ToString();
        }

        private void mapArea2_Click(object sender, RoutedEventArgs e)
        {
            dungoenGlobalIndex = 1;
            businessClass.createDungoen(dungoenGlobalIndex);
            businessClass.selcectSound();
            preImg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgPath));
            confirmEnter.Visibility = Visibility.Visible;
            nameAreaTxt.Text = businessClass.dungoens[1].DungoenName;
            reqLvlTxt.Text = businessClass.dungoens[1].DungoenDifficulty.ToString();

        }
        private void mapArea3_Click(object sender, RoutedEventArgs e)
        {
            dungoenGlobalIndex = 2;
            businessClass.createDungoen(dungoenGlobalIndex);
            businessClass.selcectSound();
            confirmEnter.Visibility = Visibility.Visible;
            preImg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgPath));
            nameAreaTxt.Text = businessClass.dungoens[2].DungoenName;
            reqLvlTxt.Text = businessClass.dungoens[2].DungoenDifficulty.ToString();

        }

        private void enterAreaBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            loadDungoen();
        }

        private void cancelAreaBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            confirmEnter.Visibility = Visibility.Hidden;
        }





        //================================= DUNGOEN LOADER =====================
        private void loadDungoen()
        {
            map.Visibility = Visibility.Hidden;
            loadingScreen.Visibility = Visibility.Visible;
            loadingScreenImg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgPath));
            loadingDungoenName.Text = businessClass.dungoens[dungoenGlobalIndex].DungoenName;
             Shake();
        }
        public async Task Shake()
        {
            if (businessClass.pClass.ClassName == "warrior")
            {
                action1img.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior1.jpg"));
                action2img.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior2.jpg"));
                action3img.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior3.jpg"));
                action4img.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior4.jpg"));
            }
            else
            {
                action1img.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk1.jpg"));
                action2img.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk2.jpg"));
                action3img.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk3.jpg"));
                action4img.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk4.jpg"));
            }
        
            for (int i = 0; i < 6; i++)
            {

            await Task.Delay(500);
            Canvas.SetLeft(loadingScreenImg, 0);

            await Task.Delay(500);
            Canvas.SetLeft(loadingScreenImg, -5);

            }
            loadingScreen.Visibility = Visibility.Hidden;
            inGame.Visibility = Visibility.Visible;
            dungoenGui();
        }


        private void dungoenGui()
        {
            main.Visibility = Visibility.Hidden;
            inDungoen.Visibility = Visibility.Visible;
            dungoenBg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgBgPath));
            loadingDungoenName.Text = businessClass.dungoens[dungoenGlobalIndex].DungoenName;
            if (businessClass.pClass.ClassName == "warrior")
            {
                playerImage.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/k2.png"));
            }
            else
            {
                playerImage.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/k1.png"));
            }
            startCombat(dungoenGlobalIndex);
        }





        //===================================== INGAME BUTTONS
        private void action1_Click(object sender, RoutedEventArgs e)
        {
            skillActionIndex = 0;
            confirmAction.Visibility = Visibility.Visible;
            actionType.Text = "Damage:";
            actionDmg.Text = businessClass.playerObject.PlayerClass.Ability1.AbilityDmg.ToString();
            actionStamina.Text = businessClass.playerObject.PlayerClass.Ability1.AbilityStaminaCost.ToString();
            abilityNameTxt.Text = businessClass.playerObject.PlayerClass.Ability1.AbilityName;
            cornfirmActionImg.Source = new BitmapImage(new Uri(businessClass.playerObject.PlayerClass.Ability1.AbilityImgPath));

        }

        private void action2_Click(object sender, RoutedEventArgs e)
        {
            skillActionIndex = 1;
            confirmAction.Visibility = Visibility.Visible;
            actionType.Text = "Damage:";
            actionDmg.Text = businessClass.playerObject.PlayerClass.Ability2.AbilityDmg.ToString();
            actionStamina.Text = businessClass.playerObject.PlayerClass.Ability2.AbilityStaminaCost.ToString();
            abilityNameTxt.Text = businessClass.playerObject.PlayerClass.Ability2.AbilityName;
            cornfirmActionImg.Source = new BitmapImage(new Uri(businessClass.playerObject.PlayerClass.Ability2.AbilityImgPath));

        }

        private void action3_Click(object sender, RoutedEventArgs e)
        {
            skillActionIndex = 2;
            confirmAction.Visibility = Visibility.Visible;
            actionType.Text = "Damage:";
            actionDmg.Text = businessClass.playerObject.PlayerClass.Ability3.AbilityDmg.ToString();
            actionStamina.Text = businessClass.playerObject.PlayerClass.Ability3.AbilityStaminaCost.ToString();
            abilityNameTxt.Text = businessClass.playerObject.PlayerClass.Ability3.AbilityName;
            cornfirmActionImg.Source = new BitmapImage(new Uri(businessClass.playerObject.PlayerClass.Ability3.AbilityImgPath));

        }

        public void action4_Click(object sender, RoutedEventArgs e)
        {
            skillActionIndex = 3;
            confirmAction.Visibility = Visibility.Visible;
            actionType.Text = "Heal:";
            actionDmg.Text = businessClass.playerObject.PlayerClass.HealAbility4.AbilityDmg.ToString();
            actionStamina.Text = businessClass.playerObject.PlayerClass.HealAbility4.AbilityStaminaCost.ToString();
            abilityNameTxt.Text = businessClass.playerObject.PlayerClass.HealAbility4.AbilityName;
            cornfirmActionImg.Source = new BitmapImage(new Uri(businessClass.playerObject.PlayerClass.HealAbility4.AbilityImgPath));
        }




        
        private void cancelActionBtn_Click(object sender, RoutedEventArgs e)
        {
            confirmAction.Visibility = Visibility.Hidden;
            
        }

        private void useActionBtn_Click(object sender, RoutedEventArgs e)
        {
            confirmAction.Visibility = Visibility.Hidden;
            action1.IsEnabled = false;
            action2.IsEnabled = false;
            action3.IsEnabled = false;
            action4.IsEnabled = false;
            turn();

        }

        private void nextTurnBtn_Click(object sender, RoutedEventArgs e)
        {

        }


        private bool battleBegun = true;
        private bool playersTurn = true;
        private int enemyCount;
        private int playerHP;
        private int playerStamina;
        public async Task startCombat( int dungoenIndexValue)
        {
            playerHP = businessClass.pClass.MaxHP;
            playerStamina = businessClass.pClass.MaxStamina;
            checkHpAndHeal();
            enemyCount = businessClass.dungoens[dungoenGlobalIndex].DungoenDifficulty * 2;
            if (battleBegun == true)
            {
                monsterName.Text = businessClass.dungoens[dungoenIndexValue].Enemies[0].Name + "has appeared";
                monsterDamage.Text = "";
                battleBegun = false;
                playersTurn = true;
            }
            
        }
        public void checkHpAndHeal()
        {
            hpBar.Maximum = businessClass.pClass.MaxHP;
            hpBar.Minimum = 0;
            hpBar.Value = playerHP;
            staminaBar.Value = playerStamina;
            staminaBar.Maximum = businessClass.pClass.MaxStamina;
            staminaBar.Minimum = 0;
            xpBar.Value = businessClass.playerObject.Xp;
            xpBar.Maximum = businessClass.playerObject.NextLvlUp;
            xpBar.Minimum = 0;
            enemyHpBar.Value = businessClass.dungoens[dungoenGlobalIndex].Enemies[0].Hp;
            enemyHpBar.Maximum = businessClass.dungoens[dungoenGlobalIndex].Enemies[0].Hp;
            enemyHpBar.Minimum = 0;
            currentEnemyHp = businessClass.dungoens[dungoenGlobalIndex].Enemies[0].Hp;
        } 

        public void checkHp()
        {
            hpBar.Value = currentPlayerHp;
            staminaBar.Value = currentPlayerStamina;
            xpBar.Value = businessClass.playerObject.Xp;
        }


        public async Task turn()
            
        {
            checkHp();
            /*
            if (random.Next(0, 10) > 6)
            {
                if (skillIndex < 3)
                {
                    monsterName.Text = "You hit CRITICAL" + businessClass.dungoens[dungoenGlobalIndex].Enemies[0].Name + "for:";
                    monsterDamage.Text = (businessClass.playerObject.PlayerClass.Ability3.AbilityDmg + 5).ToString();
                    currentEnemyHp = currentEnemyHp - businessClass.playerObject.PlayerClass.Ability3.AbilityDmg + 5;
                    checkHp();
                }

            }*/

            monsterName.Text = "You hit " + businessClass.dungoens[dungoenGlobalIndex].Enemies[0].Name;
                monsterDamage.Text = "for: "+ businessClass.playerObject.PlayerClass.Ability2.AbilityDmg.ToString();
                currentEnemyHp = currentEnemyHp - businessClass.playerObject.PlayerClass.Ability2.AbilityDmg;
                MessageBox.Show(currentEnemyHp.ToString());
                MessageBox.Show(currentPlayerHp.ToString());
            checkHp();
            
            if (currentEnemyHp <= 0)
            {
                MessageBox.Show("you won or something like that......");
            }
            MessageBox.Show("debug 3");
            await Task.Delay(100);
            MessageBox.Show("debug 4");
            action1.IsEnabled = true;
            action2.IsEnabled = true;
            action3.IsEnabled = true;
            action4.IsEnabled = true;
        }


    }
}
