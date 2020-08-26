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
using System.Reflection;

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
        private int enemyIndex = 0;
        private bool enemyIsDead = false;
        private int shopIndex;
        private SoundPlayer mainBg = new SoundPlayer("C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/startMenu.wav");
        private SoundPlayer mapMusic = new SoundPlayer("C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/map.wav");
        private SoundPlayer gameLoad = new SoundPlayer("C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/battleLoad.wav");
        private SoundPlayer battle = new SoundPlayer("C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/battle.wav");
        private SoundPlayer victory = new SoundPlayer("C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/victory.wav");
        private SoundPlayer gameOverSound = new SoundPlayer("C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/gameOver.wav");

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
                mapMusic.LoadCompleted += delegate (object sender, AsyncCompletedEventArgs e) {
                    mapMusic.PlayLooping();
                };
                mapMusic.LoadAsync();

                //temp

            }
            else if (deathKnightRadioBtn.IsChecked == true && skillPoints == 0)
            {
                if (playerNameInput.Text == "your name")
                {
                    MessageBox.Show("I swear to god I will break your knee caps");
                }

                businessClass.createClass("death knight", skill1, skill2, skill3, playerNameInput.Text);
                charCreationMenu.Visibility = Visibility.Hidden;
                map.Visibility = Visibility.Visible;
                mapMusic.LoadCompleted += delegate (object sender, AsyncCompletedEventArgs e) {
                    mapMusic.PlayLooping();
                };
                mapMusic.LoadAsync();
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
            preImg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgPath));
            confirmEnter.Visibility = Visibility.Visible;
            nameAreaTxt.Text = businessClass.dungoens[2].DungoenName;
            reqLvlTxt.Text = businessClass.dungoens[2].DungoenDifficulty.ToString();
            /*
            dungoenGlobalIndex = 2;
            businessClass.createDungoen(dungoenGlobalIndex);
            businessClass.selcectSound();
            confirmEnter.Visibility = Visibility.Visible;
            preImg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgPath));
            nameAreaTxt.Text = businessClass.dungoens[2].DungoenName;
            reqLvlTxt.Text = businessClass.dungoens[2].DungoenDifficulty.ToString();*/

        }

        private void enterAreaBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            battleBegun = true;
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
            enemyIndex = 0;
            map.Visibility = Visibility.Hidden;
            loadingScreen.Visibility = Visibility.Visible;
            loadingScreenImg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgPath));
            loadingDungoenName.Text = businessClass.dungoens[dungoenGlobalIndex].DungoenName;
            dungoenBg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgBgPath));
            gameLoad.LoadCompleted += delegate (object sender, AsyncCompletedEventArgs e) {
                gameLoad.PlayLooping();
            };
            gameLoad.LoadAsync();
            Shake();
        }


        //SHAKE LOADING SCREEN AND LOAD ACTION BUTTONS
        public async Task Shake()
        {
            if (businessClass.pClass.ClassName == "warrior")
            {
                action1img.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior1.jpg"));
                action2img.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior2.jpg"));
                action3img.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior3.jpg"));
                action4img.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/warrior4.jpg"));
            }
            else
            {
                action1img.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk1.jpg"));
                action2img.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk2.jpg"));
                action3img.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk3.jpg"));
                action4img.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/dk4.jpg"));
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
            battle.LoadCompleted += delegate (object sender, AsyncCompletedEventArgs e) {
                battle.PlayLooping();
            };
            battle.LoadAsync();
            main.Visibility = Visibility.Hidden;
            inDungoen.Visibility = Visibility.Visible;
            dungoenBg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgBgPath));
            loadingDungoenName.Text = businessClass.dungoens[dungoenGlobalIndex].DungoenName;
            enemyImage.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].ImgPath));
            if (businessClass.pClass.ClassName == "warrior")
            {
                playerImage.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/k2.png"));
            }
            else
            {
                playerImage.Source = new BitmapImage(new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/k1.png"));
            }
            startCombat(dungoenGlobalIndex);
        }


















        //===================================== INGAME BUTTONS =======================================
        private void action1_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
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
            businessClass.selcectSound();
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
            businessClass.selcectSound();
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
            businessClass.selcectSound();
            skillActionIndex = 3;
            confirmAction.Visibility = Visibility.Visible;
            actionType.Text = "Heal";
            actionDmg.Text = businessClass.playerObject.PlayerClass.HealAbility4.AbilityDmg.ToString();
            actionStamina.Text = businessClass.playerObject.PlayerClass.HealAbility4.AbilityStaminaCost.ToString();
            abilityNameTxt.Text = businessClass.playerObject.PlayerClass.HealAbility4.AbilityName;
            cornfirmActionImg.Source = new BitmapImage(new Uri(businessClass.playerObject.PlayerClass.HealAbility4.AbilityImgPath));
        }

        private void skipTurnBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            skipTurn.Visibility = Visibility.Visible;
            staminaRegainTxt.Text = (5+(5 * businessClass.playerObject.Agility)).ToString();
        }

        private void skipBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            if (currentPlayerStamina >= businessClass.pClass.MaxStamina)
            {
                currentPlayerStamina = businessClass.pClass.MaxStamina;
            }
            else
            {
                currentPlayerStamina = currentPlayerStamina + 5 +(5 * businessClass.playerObject.Agility);
            }
            skipTurn.Visibility = Visibility.Hidden;
            checkHp();
            enemyTurn();
        }

        private void cancelSkipBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            skipTurn.Visibility = Visibility.Hidden;
        }

        private void cancelActionBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            confirmAction.Visibility = Visibility.Hidden;
            
        }

        private void useActionBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            List<ability> abilities = new List<ability>()
            {
                businessClass.pClass.Ability1,
                businessClass.pClass.Ability2,
                businessClass.pClass.Ability3,
                businessClass.pClass.HealAbility4
            };
            if (currentPlayerStamina >= abilities[skillActionIndex].AbilityStaminaCost)
            {
                checkHp();
                confirmAction.Visibility = Visibility.Hidden;
                action1.IsEnabled = false;
                action2.IsEnabled = false;
                action3.IsEnabled = false;
                action4.IsEnabled = false;
                turn();
            }
            else
            {
                MessageBox.Show("not enough stamina");
            }
        }


        private void restartBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            gameOverScreen.Visibility = Visibility.Hidden;
            main.Visibility = Visibility.Visible;
            mainMenuCanvas.Visibility = Visibility.Visible;
            mainBg.LoadCompleted += delegate (object sender, AsyncCompletedEventArgs e) {
                mainBg.PlayLooping();
            };
            mainBg.LoadAsync();
        }













        //======================================== COMBAT =================================

        private bool battleBegun = true;
        private int playerHP;
        private int playerStamina;


        //SET COMBAT STATS AND GET ENEMY
        public async Task startCombat( int dungoenIndexValue)
        {
            checkHpAndHeal();
            playerHP = businessClass.pClass.MaxHP;
            playerStamina = businessClass.pClass.MaxStamina;
            if (battleBegun == true)
            {
                monsterName.Text = businessClass.dungoens[dungoenIndexValue].Enemies[enemyIndex].Name + "has appeared";
                monsterDamage.Text = "";
                battleBegun = false;
            }
            
        }

        //CHECK HP AND FULLY HEAL ENEMY AND PLAYER
        public void checkHpAndHeal()
        {
            currentPlayerStamina = businessClass.pClass.MaxStamina;
            currentPlayerHp = businessClass.pClass.MaxHP;
            hpBar.Maximum = businessClass.pClass.MaxHP;
            hpBar.Minimum = 0;
            hpBar.Value = businessClass.pClass.MaxHP;
            staminaBar.Value = businessClass.pClass.MaxStamina;
            staminaBar.Maximum = businessClass.pClass.MaxStamina;
            staminaBar.Minimum = 0;
            xpBar.Value = businessClass.playerObject.Xp;
            xpBar.Maximum = businessClass.playerObject.NextLvlUp;
            xpBar.Minimum = 0;
         
            enemyHpBar.Value = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].Hp;
            enemyHpBar.Maximum = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].Hp;
            enemyHpBar.Minimum = 0;
            currentEnemyHp = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].Hp;
            hpCount.Text = currentPlayerHp.ToString();
            staminaCount.Text = currentPlayerStamina.ToString();
            xpCount.Text = businessClass.playerObject.Xp.ToString();
            enemyHpCount.Text = currentEnemyHp.ToString();
            enemyIsDead = false;
        }



        //CHECKS HP/OTHER   AND EVENTS RELATED
        public void checkHp()
        {
            hpBar.Value = currentPlayerHp;
            hpCount.Text = currentPlayerHp.ToString();
            staminaBar.Value = currentPlayerStamina;
            staminaCount.Text = currentPlayerStamina.ToString();
            xpBar.Value = businessClass.playerObject.Xp;
            xpCount.Text = businessClass.playerObject.Xp.ToString();
            enemyHpBar.Value = currentEnemyHp;           
                enemyHpCount.Text = currentEnemyHp.ToString();
            
            if (currentPlayerHp <= 0)
            {
                gameOver();
            }
            if (businessClass.playerObject.Xp >= businessClass.playerObject.NextLvlUp)
            {
                businessClass.playerObject.NextLvlUp = businessClass.playerObject.NextLvlUp * 2;
                businessClass.playerObject.PlayerLvl++;
                businessClass.playerObject.Xp = 0;
                MessageBox.Show("You leveled up!");
            }           
        }

        

        //PLAYERS TURN         
        public async Task turn()
            
        {
            checkHp();

            List<ability> abilities = new List<ability>()
            {
                businessClass.pClass.Ability1,
                businessClass.pClass.Ability2,
                businessClass.pClass.Ability3,
                businessClass.pClass.HealAbility4
            };
            if (actionType.Text == "Heal")
            {
                monsterName.Text = "You healed yourself";
                monsterDamage.Text = "for: " + abilities[skillActionIndex].AbilityDmg.ToString() + " HP";
                currentPlayerHp = currentPlayerHp + abilities[skillActionIndex].AbilityDmg;
                currentPlayerStamina = currentPlayerStamina - abilities[skillActionIndex].AbilityStaminaCost;
                MediaPlayer heal = new MediaPlayer();
                Uri healPath = new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/heal.wav");
                heal.Open(healPath);
                heal.Play();
            }
            else
            {
                monsterName.Text = "You hit " + businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].Name;
                monsterDamage.Text = "for: "+ abilities[skillActionIndex].AbilityDmg.ToString()+ " DMG";
                currentEnemyHp = currentEnemyHp - abilities[skillActionIndex].AbilityDmg;
                if (currentEnemyHp <= 0 && enemyIsDead == false)
                {
                    enemyIsDead = true;
                    enemyHpCount.Text = "0";
                    battleBegun = false;
                    battleWin();
                }
                currentPlayerStamina = currentPlayerStamina - abilities[skillActionIndex].AbilityStaminaCost;
                shakeEnemy();
            }            
            checkHp();           
            await Task.Delay(2000);
            if (currentEnemyHp > 0)
            {
                enemyTurn();
            }
            action1.IsEnabled = true;
            action2.IsEnabled = true;
            action3.IsEnabled = true;
            action4.IsEnabled = true;
            checkHp();
        }



        // ENEMY TURN + PLAYER STATS IMPACT ON COMBAT CALCULATION

        // STRENGTH = EVERY STRENGTH IS 1- DMG

        // AGILITY = HIGH ENEMY MISS CHANCE

        // LUCK = LOWER CRIT CHANCE
       public void enemyTurn()
        {
            bool isMiss = false;
            bool isCrit = false;
            int damageDone = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].Power;
            damageDone = damageDone - businessClass.playerObject.Strength;
            if (random.Next(0, 10) > 5 + businessClass.playerObject.Luck)
            {
                isCrit = true;
                damageDone = damageDone + 10;               
            }
            if (random.Next(0, 20) < 2 + businessClass.playerObject.Agility)
            {
                isMiss = true;
                monsterName.Text = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].Name + " MISSED";
                monsterDamage.Text = "0 DMG";
                missSound();
            }
            if (isMiss == false && isCrit == false)
            {
                monsterName.Text = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].Name + " hit for:";
                monsterDamage.Text = Convert.ToInt32(damageDone).ToString() + " DMG";
                currentPlayerHp = currentPlayerHp - Convert.ToInt32(damageDone);
                shakePlayer();
            }
            if (isCrit == true && isMiss == false)
                {
                    monsterName.Text = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].Name + " hit CRITICAL for:";
                    monsterDamage.Text = damageDone.ToString() + " DMG";
                    currentPlayerHp = currentPlayerHp - Convert.ToInt32(damageDone);
                    shakePlayer();
                }
            checkHp();
        }


        // GAME OVER METHOD
        public void gameOver()
        {
            inGame.Visibility = Visibility.Hidden;
            inDungoen.Visibility = Visibility.Hidden;
            gameOverScreen.Visibility = Visibility.Visible;
            gameOverSound.LoadCompleted += delegate (object sender, AsyncCompletedEventArgs e) {
                gameOverSound.PlayLooping();
            };
            gameOverSound.LoadAsync();
        }



        //SHAKE ENEMY ANIMATION
        public async Task shakeEnemy()
        {
            enemySlash.Visibility = Visibility.Visible;
            slashSound();
            for (int i = 0; i < 2; i++)
            {

                await Task.Delay(200);
                Canvas.SetLeft(enemyImage, Canvas.GetLeft(enemyImage) + 10);

                await Task.Delay(200);
                Canvas.SetLeft(enemyImage, Canvas.GetLeft(enemyImage) - 10);

            }
            enemySlash.Visibility = Visibility.Hidden;
        }


        // SHAKE PLAYER ANIMATION
        public async Task shakePlayer()
        {
            playerSlash.Visibility = Visibility.Visible;
            slashSound();
            for (int i = 0; i < 2; i++)
            {

                await Task.Delay(200);
                Canvas.SetLeft(playerImage, Canvas.GetLeft(playerImage)+10);

                await Task.Delay(200);
                Canvas.SetLeft(playerImage, Canvas.GetLeft(playerImage)-10);

            }
            playerSlash.Visibility = Visibility.Hidden;
        }


        //PLAY SLASH SOUND
        public void slashSound()
        {
            MediaPlayer selcect = new MediaPlayer();
            Uri selectPath = new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/slash.wav");
            selcect.Open(selectPath);
            selcect.Play();
        }


        // PLAY MISS SOUND
        public void missSound()
        {
            MediaPlayer miss = new MediaPlayer();
            Uri missPath = new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/miss.wav");
            miss.Open(missPath);
            miss.Play();
        }

        // BATTLEWIN
        public void battleWin()
        {
            enemyIndex++;
            if (enemyIndex == businessClass.dungoens[dungoenGlobalIndex].Enemies.Count())
            {
                dungoenCompleted.Visibility = Visibility.Visible;
                goldRewardTxt.Text = businessClass.dungoens[dungoenGlobalIndex].ExReward.ToString();
                xpRewardTxt.Text = (businessClass.dungoens[dungoenGlobalIndex].ExReward * 2).ToString();
                businessClass.playerObject.Gold = businessClass.dungoens[dungoenGlobalIndex].ExReward;
                businessClass.playerObject.Xp = businessClass.dungoens[dungoenGlobalIndex].ExReward * 2;
                battle.Stop();
                MediaPlayer selcect = new MediaPlayer();
                Uri selectPath = new Uri(@"C:/Users/chri45n5/source/repos/taarss/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/victory.wav");
                selcect.Open(selectPath);
                selcect.Play();


            }
            else
            {
                battleWinScreen.Visibility = Visibility.Visible;
                goldRewardedTxt.Text = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].GoldReward.ToString();
                xpRewardedTxt.Text = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].XpReward.ToString();
                businessClass.playerObject.Xp = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].XpReward;
                businessClass.playerObject.Gold = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].GoldReward;
                enemyDefeatedTxt.Text = businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex - 1].Name;
            }
        }


        //NEXT ENCOUNTER IN DUNGOEN
        private void nextEncounterBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            battleBegun = true;
           
            dungoenGui();
            battleWinScreen.Visibility = Visibility.Hidden;
            checkHpAndHeal();
            flashCanvas.Visibility = Visibility.Hidden;
        }


        // DOES NOT WORK
        private async Task flashScreen()
        {
            flashCanvas.Visibility = Visibility.Visible;
            await Task.Delay(500);
            flashCanvas.Visibility = Visibility.Hidden;

        }



        //RETURN TO MAP AFTER DUNGOEN BUTTON
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            inGame.Visibility = Visibility.Hidden;
            inDungoen.Visibility = Visibility.Hidden;
            dungoenCompleted.Visibility = Visibility.Hidden;
            map.Visibility = Visibility.Visible;
            mapMusic.LoadCompleted += delegate (object sender, AsyncCompletedEventArgs e) {
                mapMusic.PlayLooping();
            };
            mapMusic.LoadAsync();
        }




        // ENTER SHOP BUTTON
        private void shopBtn_Click(object sender, RoutedEventArgs e)
        {
            shop.Visibility = Visibility.Visible;
        }

        private void generateShop()
        {

            shopItemContainer.Children.Clear();

            int loopIndex = 0;
            List<item> items = new List<item>();
            if (shopIndex == 0)
            {
                foreach (var item in businessClass.consumes)
                {
                    items.Add(item);
                }

            }
            else if (shopIndex == 1)
            {
                foreach (var item in businessClass.weaponItems)
                {
                    items.Add(item);
                }
            }
            else if (shopIndex == 2)
            {
                foreach (var item in businessClass.armourItems)
                {
                    items.Add(item);
                }
            }
                    
                   foreach (var item in items)
                        {
                            Button button = new Button();
                            Image image = new Image();
                            if (shopIndex == 0)
                            {
                                image.Source = new BitmapImage(new Uri(businessClass.consumes[loopIndex].IconPath));


                            }
                            else if (shopIndex == 1)
                            {
                                image.Source = new BitmapImage(new Uri(businessClass.weaponItems[loopIndex].IconPath));

                            }
                            else if (shopIndex == 2)
                            {
                                image.Source =  new BitmapImage(new Uri(businessClass.armourItems[loopIndex].IconPath));
                                
                            }
                            image.Height = 60;
                            image.Width = 60;
                            loopIndex++;
                            image.Stretch = Stretch.Fill;
                            button.Content = image;
                            button.BorderBrush = Brushes.White;
                            button.BorderThickness = new Thickness(2);
                            button.Margin = new 
                            shopItemContainer.Children.Add(button);

                        }                        

        }


     


        //SHOW STATS BUTTON
        private void statsBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            stats.Visibility = Visibility.Visible;
            playerStatsTxt.Text = businessClass.playerObject.PlayerLvl.ToString();
            goldStatsTxt.Text = businessClass.playerObject.Gold.ToString();
            xpStatsTxt.Text = businessClass.playerObject.Xp.ToString();
            nextLvlStatsTxt.Text = businessClass.playerObject.NextLvlUp.ToString();
        }

        //LEAVE STATS MENU
        private void statsBackBtn_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();
            stats.Visibility = Visibility.Hidden;
            deatilStats.Visibility = Visibility.Hidden;
        }


        //SHOW DEATILED STATS
        private void showDetailStats_Click(object sender, RoutedEventArgs e)
        {
            businessClass.selcectSound();  
            deatilStats.Visibility = Visibility.Visible;
            AgilityStatsTxt.Text = businessClass.playerObject.Agility.ToString();
            luckStatsTxt.Text = businessClass.playerObject.Luck.ToString();
            strengthStatsTxt.Text = businessClass.playerObject.Strength.ToString();
        }

        private void shopBackBtn_Click(object sender, RoutedEventArgs e)
        {
            shop.Visibility = Visibility.Hidden;
        }

        private void shopConsumeBtn_Click(object sender, RoutedEventArgs e)
        {
            shopIndex = 0;
            generateShop();
        }

        private void shopArmourBtn_Click(object sender, RoutedEventArgs e)
        {
            shopIndex = 2;
            generateShop();
        }

        private void shopWeaponBtn_Click(object sender, RoutedEventArgs e)
        {
            shopIndex = 1;
            generateShop();
        }
    }
}
