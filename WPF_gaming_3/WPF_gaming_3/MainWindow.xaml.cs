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
        private int skillActionIndex = 0;
        private int skillPoints = 10;
        Random random = new Random();
        private int dungoenGlobalIndex;
        private int currentEnemyHp;
        private int currentPlayerHp;
        private int currentPlayerStamina;
        private int enemyIndex = 0;
        private SoundPlayer mainBg = new SoundPlayer("C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/startMenu.wav");
        private SoundPlayer mapMusic = new SoundPlayer("C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/map.wav");
        private SoundPlayer gameLoad = new SoundPlayer("C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/battleLoad.wav");
        private SoundPlayer battle = new SoundPlayer("C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/battle.wav");
        private SoundPlayer victory = new SoundPlayer("C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/victory.wav");
        private SoundPlayer gameOverSound = new SoundPlayer("C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/gameOver.wav");
        private SoundPlayer healSound = new SoundPlayer("C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/heal.wav");

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
            confirmEnter.Visibility = Visibility.Visible;
            preImg.Source = new BitmapImage(new Uri(businessClass.dungoens[dungoenGlobalIndex].ImgPath));
            nameAreaTxt.Text = businessClass.dungoens[2].DungoenName;
            reqLvlTxt.Text = businessClass.dungoens[2].DungoenDifficulty.ToString();

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
                playerImage.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/k2.png"));
            }
            else
            {
                playerImage.Source = new BitmapImage(new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/images/k1.png"));
            }
            startCombat(dungoenGlobalIndex);
        }


















        //===================================== INGAME BUTTONS =======================================
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
            actionType.Text = "Heal";
            actionDmg.Text = businessClass.playerObject.PlayerClass.HealAbility4.AbilityDmg.ToString();
            actionStamina.Text = businessClass.playerObject.PlayerClass.HealAbility4.AbilityStaminaCost.ToString();
            abilityNameTxt.Text = businessClass.playerObject.PlayerClass.HealAbility4.AbilityName;
            cornfirmActionImg.Source = new BitmapImage(new Uri(businessClass.playerObject.PlayerClass.HealAbility4.AbilityImgPath));
        }

        private void skipTurnBtn_Click(object sender, RoutedEventArgs e)
        {
            skipTurn.Visibility = Visibility.Visible;
            staminaRegainTxt.Text = (5+(5 * businessClass.playerObject.Agility)).ToString();
        }

        private void skipBtn_Click(object sender, RoutedEventArgs e)
        {
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
            skipTurn.Visibility = Visibility.Hidden;
        }

        private void cancelActionBtn_Click(object sender, RoutedEventArgs e)
        {
            confirmAction.Visibility = Visibility.Hidden;
            
        }

        private void useActionBtn_Click(object sender, RoutedEventArgs e)
        {
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
        private int enemyCount;
        private int playerHP;
        private int playerStamina;
        public async Task startCombat( int dungoenIndexValue)
        {
            enemyIndex = 0;
            playerHP = businessClass.pClass.MaxHP;
            playerStamina = businessClass.pClass.MaxStamina;
            checkHpAndHeal();
            enemyCount = businessClass.dungoens[dungoenGlobalIndex].DungoenDifficulty * 2;
            if (battleBegun == true)
            {
                monsterName.Text = businessClass.dungoens[dungoenIndexValue].Enemies[enemyIndex].Name + "has appeared";
                monsterDamage.Text = "";
                battleBegun = false;
            }
            
        }
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

        }

        public void checkHp()
        {
            hpBar.Value = currentPlayerHp;
            hpCount.Text = currentPlayerHp.ToString();
            staminaBar.Value = currentPlayerStamina;
            staminaCount.Text = currentPlayerStamina.ToString();
            xpBar.Value = businessClass.playerObject.Xp;
            xpCount.Text = businessClass.playerObject.Xp.ToString();
            enemyHpBar.Value = currentEnemyHp;
            if (currentEnemyHp < 0)
            {
                enemyHpCount.Text = "0";
                enemyIndex++;
                battleBegun = false;
                MessageBox.Show("you won or something like that......");

            }
            else
            {
                enemyHpCount.Text = currentEnemyHp.ToString();
            }
            if (currentPlayerHp <= 0)
            {
                gameOver();
            }
        }

        
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
                healSound.LoadAsync();
            }
            else
            {
                monsterName.Text = "You hit " + businessClass.dungoens[dungoenGlobalIndex].Enemies[enemyIndex].Name;
                monsterDamage.Text = "for: "+ abilities[skillActionIndex].AbilityDmg.ToString()+ " DMG";
                currentEnemyHp = currentEnemyHp - abilities[skillActionIndex].AbilityDmg;
                currentPlayerStamina = currentPlayerStamina - abilities[skillActionIndex].AbilityStaminaCost;
                shakeEnemy();
            }
            checkHp();
            await Task.Delay(2000);
            enemyTurn();
            action1.IsEnabled = true;
            action2.IsEnabled = true;
            action3.IsEnabled = true;
            action4.IsEnabled = true;
            checkHp();
        }

       public async Task enemyTurn()
        {
            bool isMiss = false;
            bool isCrit = false;
            await Task.Delay(2000);
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

        public void slashSound()
        {
            MediaPlayer selcect = new MediaPlayer();
            Uri selectPath = new Uri(@"C:/Users/chris/source/repos/WPF_gaming_3/WPF_gaming_3/WPF_gaming_3/sounds/slash.wav");
            selcect.Open(selectPath);
            selcect.Play();
        }















        
    }
}
