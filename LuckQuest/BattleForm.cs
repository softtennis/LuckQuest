using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuckQuest
{
    /// <summary>
    /// 戦闘画面のクラス
    /// </summary>
    public partial class BattleForm : Form
    {
        //攻撃力+装備1の合計攻撃力・・・①
        private static int sum = 0;
        //守備力+装備2,3,4の合計守備力・・・②
        private static int sum2 = 0;
        
        //敵番号
        private static int number = 0;
        private static int number2 = 0;
        private static int number3 = 0;

        int waza = 0;
        int waza_damage = 0;
        string waza_message1 = "";
        string waza_message2 = "";
        string gif_image = "";

        private Hero hero = new Hero();
        private static Enemy enemy = new Enemy();
        private static Enemy enemy2 = new Enemy();
        private static Enemy enemy3 = new Enemy();
        private Job job = new Job();
        private Random random = new Random();

        //var enemyDictionary = new Dictionary<string, Enemy>();

        bool enemy_delete_flg1 = true;
        bool enemy_delete_flg2 = true;
        bool enemy_delete_flg3 = true;

        bool enemy_survival_flg1 = true;
        bool enemy_survival_flg2 = true;
        bool enemy_survival_flg3 = true;

        bool dialog_flg = true;

        public BattleForm(Hero Hero, Job Job)
        {
            InitializeComponent();

            hero = Hero;
            job = Job;

            BattleFormLoad();
        }

        public void BattleFormLoad()
        {
            //技使用のMP
            waza = job.Waza1Mp;

            sum = hero.Attack + job.WeaponAttack;
            sum2 = hero.Defense + job.HelmetDefense + job.ArmorDefense + job.ShieldDefense;

            //画面上部のステータスバーに、初期ステータス登録画面から受け取った値を反映
            nameTextBox2.Text = hero.Name;
            jobTextBox2.Text = job.JobName;
            levelTextBox2.Text = hero.Level.ToString();
            hpTextBox2.Text = hero.HP.ToString();
            mpTextBox2.Text = hero.MP.ToString();
        　　attackTextBox2.Text = sum.ToString();
            defenseTextBox2.Text = sum2.ToString();

            if (hero.MP < waza)
            {
                logTextBox.Text = "運がない！" + Environment.NewLine + hero.Name + "はわざを使えるほどMPがない！最悪だ！";
            }

            //背景画像ファイルを描画
            battlePictureBox.Image = Image.FromFile("haikei.png");

            //敵画像ファイルをランダムに描画
            var random = new Random();
            number = random.Next(System.Enum.GetNames(typeof(Enum.EnemiesType)).Length);
            number2 = random.Next(System.Enum.GetNames(typeof(Enum.EnemiesType)).Length);
            number3 = random.Next(System.Enum.GetNames(typeof(Enum.EnemiesType)).Length);

            enemy.EnemyType = (Enum.EnemiesType)number;
            enemy.Init();
            monsterPictureBox1.Image = Image.FromFile(enemy.ImageFile);

            enemy2.EnemyType = (Enum.EnemiesType)number2;
            enemy2.Init();
            monsterPictureBox2.Image = Image.FromFile(enemy2.ImageFile);

            enemy3.EnemyType = (Enum.EnemiesType)number3;
            enemy3.Init();
            monsterPictureBox3.Image = Image.FromFile(enemy3.ImageFile);

            Encount(waza);

            //BattleFormロード時にフォーカスを攻撃ボタンに当てる
            this.ActiveControl = attackButton;
        }

        //こうげきボタン押下で戦闘処理を実行
        private void attackButton_Click(object sender, EventArgs e)
        {
            techniquePanel.Visible = false;

            DisplayEnemy();

            battlePictureBox.Image = Image.FromFile("haikei.png");
            Attack();
        }

        //職業ごとにわざ名を表示する
        private void techniqueButton_Click(object sender, EventArgs e)
        {
            //わざ名の書かれたパネルを表示する
            techniquePanel.Visible = true;

            DisplayEnemy();

            //背景画像を戦闘背景に戻す
            battlePictureBox.Image = Image.FromFile("haikei.png");

            skillButton.Text = job.WazaName;
            if (hero.Level >= 50)
            {
                skillButton2.Text = job.WazaName2;
                skillButton2.Visible = true;
                if (hero.Level >= 80)
                {
                    skillButton3.Text = job.WazaName3;
                    skillButton3.Visible = true;
                }
            }
        }

        //確率(5%)判定
        private bool Probability()
        {
            var number = random.Next(1, 101);

            if (number <= 5)
            {
                return true;
            }
            return false;
        }

        //確率(25%)判定
        private bool Probability2()
        {
            var number = random.Next(1, 101);

            if (number <= 25)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Encount
        /// 機能概要:エンカウント時のログ内容（改行の有無）変更
        /// 引数[waza_mp]
        /// 戻り値:なし
        /// </summary>
        public void Encount(int waza_mp)
        {
            if (hero.MP < waza_mp)
            {
                logTextBox.AppendText(Environment.NewLine + enemy.Name + "が現れた！" + Environment.NewLine + hero.Name + "はどうする？");
            }
            else
            {
                if (hero.Name == "キクヌンティウス")
                {
                    logTextBox.Text = hero.Name + "様が降臨なされたぞ…！";
                    logTextBox.AppendText(Environment.NewLine + enemy.Name + "が現れた！" + Environment.NewLine + hero.Name + "様はどうする？");
                }
                else
                {
                    logTextBox.Text = enemy.Name + "が現れた！" + Environment.NewLine + hero.Name + "はどうする？";
                }
            }
        }

        /// <summary>
        /// DisplayEnemy
        /// 機能概要:モンスターのHPが0より大きい時、そのモンスターを表示する
        /// 引数:なし
        /// 戻り値:なし
        /// </summary>
        public void DisplayEnemy()
        {
            if (enemy.HP > 0)
            {
                monsterPictureBox1.Visible = true;
            }
            else
            {
                monsterPictureBox1.Visible = false;
            }

            if (enemy2.HP > 0)
            {
                monsterPictureBox2.Visible = true;
            }
            else
            {
                monsterPictureBox2.Visible = false;
            }

            if (enemy3.HP > 0)
            {
                monsterPictureBox3.Visible = true;
            }
            else
            {
                monsterPictureBox3.Visible = false;
            }
        }

        /// <summary>
        /// Attack
        /// 機能概要:戦闘時の計算処理
        /// 引数:なし
        /// 戻り値:なし
        /// </summary>
        public void Attack()
        {
            logTextBox.AppendText(Environment.NewLine + hero.Name + "の攻撃！");

            //5%の確率で敵を一撃必殺
            if (Probability() && enemy.HP > 0)
            {
                logTextBox.AppendText(Environment.NewLine + "会心の一撃！" + Environment.NewLine + enemy.Name + "は砕け散った！");
                enemy.HP = 0;
                monsterPictureBox1.Visible = false;
                enemy_survival_flg1 = false;
            }

            //敵1が生存しているとき、主人公の攻撃を行う
            if (enemy_survival_flg1)
            {
                //主人公が敵に攻撃
                hero.AttackProcessing(sum, enemy.Defense);
                logTextBox.AppendText(Environment.NewLine + enemy.Name + "に" + hero.AttackSum + "のダメージ!");
                enemy.HP = enemy.HP - hero.AttackSum;
            }

            //敵の生死判定
            if (enemy.HP <= 0)
            {
                enemy_survival_flg1 = false;
            }

            //敵が生存しているとき、敵の攻撃を行う
            if (enemy_survival_flg1)
            {
                logTextBox.AppendText(Environment.NewLine + enemy.Name + "の攻撃！");
                if (Probability2())
                {
                    //敵固有わざの計算処理
                    enemy.EnemyCriticalProcessing(sum2);
                    //敵固有わざのメッセージ
                    logTextBox.AppendText(Environment.NewLine + enemy.Name + enemy.Message);
                }
                else
                {
                    //敵通常攻撃時の計算処理
                    enemy.EnemyAttackProcessing(sum2);
                }

                if (hero.HP <= 0)
                {
                    hpTextBox2.Text = "0";
                    logTextBox.AppendText(Environment.NewLine + hero.Name + "はやられてしまった…");
                    if (dialog_flg == true)
                    {
                        GameOverDialog();
                        dialog_flg = false;
                    }
                }
                logTextBox.AppendText(Environment.NewLine + hero.Name + "に" + enemy.EnemyAttackSum + "のダメージ!");
                hero.HP = hero.HP - enemy.EnemyAttackSum;
                hpTextBox2.Text = hero.HP.ToString();
            }

            if (enemy.HP <= 0 && enemy_delete_flg1 == true)
            {
                logTextBox.AppendText(Environment.NewLine + enemy.Name + "を倒した！");
                enemy_delete_flg1 = false;
                monsterPictureBox1.Visible = false;
            }

            //5%の確率で敵を一撃必殺
            if (Probability() && enemy.HP > 0)
            {
                logTextBox.AppendText(Environment.NewLine + "会心の一撃！" + Environment.NewLine + enemy.Name + "は砕け散った！");
                enemy.HP = 0;
                monsterPictureBox1.Visible = false;
                enemy_survival_flg1 = false;
            }

            //敵2が生存しているとき、主人公の攻撃を行う
            if (enemy_survival_flg2)
            {
                //主人公が敵に攻撃
                hero.AttackProcessing(sum, enemy2.Defense);
                logTextBox.AppendText(Environment.NewLine + enemy2.Name + "に" + hero.AttackSum + "のダメージ!");
                enemy2.HP = enemy2.HP - hero.AttackSum;
            }

            //敵の生死判定
            if (enemy2.HP <= 0)
            {
                enemy_survival_flg2 = false;
            }

            //敵が生存しているとき、敵の攻撃を行う
            if (enemy_survival_flg2)
            {
                logTextBox.AppendText(Environment.NewLine + enemy2.Name + "の攻撃！");
                if (Probability2())
                {
                    //敵固有わざの計算処理
                    enemy2.EnemyCriticalProcessing(sum2);
                    //敵固有わざのメッセージ
                    logTextBox.AppendText(Environment.NewLine + enemy2.Name + enemy2.Message);
                }
                else
                {
                    //敵通常攻撃時の計算処理
                    enemy2.EnemyAttackProcessing(sum2);
                }

                if (hero.HP <= 0)
                {
                    hpTextBox2.Text = "0";
                    logTextBox.AppendText(Environment.NewLine + hero.Name + "はやられてしまった…");
                    if (dialog_flg == true)
                    {
                        GameOverDialog();
                        dialog_flg = false;
                    }
                }
                logTextBox.AppendText(Environment.NewLine + hero.Name + "に" + enemy2.EnemyAttackSum + "のダメージ!");
                hero.HP = hero.HP - enemy2.EnemyAttackSum;
                hpTextBox2.Text = hero.HP.ToString();
            }

            if (enemy2.HP <= 0 && enemy_delete_flg2 == true)
            {
                logTextBox.AppendText(Environment.NewLine + enemy2.Name + "を倒した！");
                enemy_delete_flg2 = false;
                monsterPictureBox2.Visible = false;
            }

            //敵3が生存しているとき、主人公の攻撃を行う
            if (enemy_survival_flg3)
            {
                //主人公が敵に攻撃
                hero.AttackProcessing(sum, enemy3.Defense);
                logTextBox.AppendText(Environment.NewLine + enemy3.Name + "に" + hero.AttackSum + "のダメージ!");
                enemy3.HP = enemy3.HP - hero.AttackSum;
            }

            //敵の生死判定
            if (enemy3.HP <= 0)
            {
                enemy_survival_flg3 = false;
            }

            //敵が生存しているとき、敵の攻撃を行う
            if (enemy_survival_flg3)
            {
                logTextBox.AppendText(Environment.NewLine + enemy3.Name + "の攻撃！");
                if (Probability2())
                {
                    //敵固有わざの計算処理
                    enemy3.EnemyCriticalProcessing(sum2);
                    //敵固有わざのメッセージ
                    logTextBox.AppendText(Environment.NewLine + enemy3.Name + enemy3.Message);
                }
                else
                {
                    //敵通常攻撃時の計算処理
                    enemy3.EnemyAttackProcessing(sum2);
                }

                if (hero.HP <= 0)
                {
                    hpTextBox2.Text = "0";
                    logTextBox.AppendText(Environment.NewLine + hero.Name + "はやられてしまった…");
                    if (dialog_flg == true)
                    {
                        GameOverDialog();
                        dialog_flg = false;
                    }
                }
                logTextBox.AppendText(Environment.NewLine + hero.Name + "に" + enemy3.EnemyAttackSum + "のダメージ!");
                hero.HP = hero.HP - enemy3.EnemyAttackSum;
                hpTextBox2.Text = hero.HP.ToString();
            }

            if (enemy3.HP <= 0 && enemy_delete_flg3 == true)
            {
                logTextBox.AppendText(Environment.NewLine + enemy3.Name + "を倒した！");
                enemy_delete_flg3 = false;
                monsterPictureBox3.Visible = false;
            }
            ////敵１、敵２、敵３の判別をつけたい
            //if (enemyBox[0])
            //{
            //    enemyHp = enemy.HP;
            //    enemyName = enemy.Name;
            //    enemy_survival_flg = enemy_survival_flg1;
            //    enemyDefense = enemy.Defense;
            //    enemyMessage = enemy.Message;
            //    monsterPictureBox = monsterPictureBox1;
            //}

            //AttackAlternate();

            if (enemy.HP <= 0 && enemy2.HP <= 0 && enemy3.HP <= 0)
            {
                if (monsterPictureBox1.Visible == false && monsterPictureBox2.Visible == false && monsterPictureBox3.Visible == false)
                {
                    attackButton.Enabled = false;
                    techniqueButton.Enabled = false;
                }
                GameClearDialog();
            }
        }

        //public void AttackAlternate()
        //{
        //    //5%の確率で敵を一撃必殺
        //    if (Probability() && enemyHp > 0)
        //    {
        //        logTextBox.AppendText(Environment.NewLine + "会心の一撃！" + Environment.NewLine + enemyName + "は砕け散った！");
        //        enemyHp = 0;
        //        monsterPictureBox.Visible = false;
        //        enemy_survival_flg = false;
        //    }

        //    //敵が生存しているとき、主人公の攻撃を行う
        //    if (enemy_survival_flg)
        //    {
        //        //主人公が敵に攻撃
        //        hero.AttackProcessing(sum, enemyDefense);
        //        logTextBox.AppendText(Environment.NewLine + enemyName + "に" + hero.AttackSum + "のダメージ!");
        //        enemyHp = enemyHp - hero.AttackSum;

        //        if (hero.HP <= 0)
        //        {
        //            hpTextBox2.Text = "0";
        //            logTextBox.AppendText(Environment.NewLine + hero.Name + "はやられてしまった…");
        //            if (dialog_flg == true)
        //            {
        //                GameOverDialog();
        //                dialog_flg = false;
        //            }
        //        }
        //    }

        //    //敵の生死判定
        //    if (enemyHp <= 0)
        //    {
        //        enemy_survival_flg = false;
        //    }

        //    //敵が生存しているとき、敵の攻撃を行う
        //    if (enemy_survival_flg)
        //    {
        //        logTextBox.AppendText(Environment.NewLine + enemyName + "の攻撃！");
        //        if (Probability2())
        //        {
        //            //敵固有わざの計算処理
        //            enemyBox.EnemyCriticalProcessing(sum2);
        //            //敵固有わざのメッセージ
        //            logTextBox.AppendText(Environment.NewLine + enemyName + enemyMessage);
        //        }
        //        else
        //        {
        //            //敵通常攻撃時の計算処理
        //            enemyBox.EnemyAttackProcessing(sum2);
        //        }
        //        logTextBox.AppendText(Environment.NewLine + hero.Name + "に" + enemyBox.EnemyAttackSum + "のダメージ!");
        //        hero.HP = hero.HP - enemyBox.EnemyAttackSum;
        //        hpTextBox2.Text = hero.HP.ToString();
        //    }

        //    if (enemyHp <= 0 && enemy_delete_flg == true)
        //    {
        //        logTextBox.AppendText(Environment.NewLine + enemyName + "を倒した！");
        //        enemy_delete_flg = false;
        //        monsterPictureBox1.Visible = false;
        //    }
        //}

        public void GameClearDialog()
        {
            DialogResult dialogResult = MessageBox.Show(
                    "世界は守られた。もう一度守りますか？",
                    "GAME CLEAR",
                    MessageBoxButtons.RetryCancel);
            if (dialogResult == DialogResult.Retry)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                attackButton.Enabled = false;
                techniqueButton.Enabled = false;
                battlePictureBox.Image = Image.FromFile("haikei.png");
                logTextBox.AppendText(Environment.NewLine + "世界は平和に包まれている…");
            }
        }

        public void GameOverDialog()
        {
            DialogResult dialogResult = MessageBox.Show(
                    "世界は闇に包まれた…。やり直しますか？",
                    "GAME OVER",
                    MessageBoxButtons.RetryCancel);
            if (dialogResult == DialogResult.Retry)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                attackButton.Enabled = false;
                techniqueButton.Enabled = false;
                logTextBox.AppendText(Environment.NewLine + "世界は闇に包まれている…");
            }
        }
        //わざ名ボタン
        private void skillButton_Click(object sender, EventArgs e)
        {
            gif_image = job.ImageFile;
            waza_damage = job.Waza1Damage;
            waza_message1 = job.Waza1Message1;
            waza_message2 = job.Waza1Message2;
            waza = job.Waza1Mp;
            skillProcessing();
        }

        private void skillButton2_Click(object sender, EventArgs e)
        {
            gif_image = job.ImageFile2;
            waza_damage = job.Waza2Damage;
            waza_message1 = job.Waza2Message1;
            waza_message2 = job.Waza2Message2;
            waza = job.Waza2Mp;
            skillProcessing();
        }

        private void skillButton3_Click(object sender, EventArgs e)
        {
            gif_image = job.ImageFile3;
            waza_damage = job.Waza3Damage;
            waza_message1 = job.Waza3Message1;
            waza_message2 = job.Waza3Message2;
            waza = job.Waza3Mp;
            skillProcessing();
        }

        private void skillProcessing()
        {
            battlePictureBox.Image = Image.FromFile("haikei.png");
            if (hero.MP < waza)
            {
                logTextBox.AppendText(Environment.NewLine + "MPが足りない！");
                techniquePanel.Visible = false;
            }
            else
            {
                string enemy_name = "";
                if (enemy.HP > 0)
                {
                    enemy_name = enemy.Name;
                }
                else if (enemy2.HP > 0)
                {
                    enemy_name = enemy2.Name;
                }
                else if (enemy3.HP > 0)
                {
                    enemy_name = enemy3.Name;
                }

                logTextBox.AppendText(Environment.NewLine + waza_message1 + Environment.NewLine + enemy_name + waza_message2);

                if (enemy.HP > 0 && enemy_delete_flg1 == true)
                {
                    logTextBox.AppendText(Environment.NewLine + enemy.Name + "に" + waza_damage + "のダメージ！");
                }

                if (enemy2.HP > 0 && enemy_delete_flg2 == true)
                {
                    logTextBox.AppendText(Environment.NewLine + enemy2.Name + "に" + waza_damage + "のダメージ！");
                }

                if (enemy3.HP > 0 && enemy_delete_flg3 == true)
                {
                    logTextBox.AppendText(Environment.NewLine + enemy3.Name + "に" + waza_damage + "のダメージ！");
                }

                hero.MP = hero.MP - waza;
                mpTextBox2.Text = hero.MP.ToString();
                enemy.HP = enemy.HP - waza_damage;
                enemy2.HP = enemy2.HP - waza_damage;
                enemy3.HP = enemy3.HP - waza_damage;

                techniquePanel.Visible = false;

                //わざエフェクト時に敵モンスターの画像ファイルを非表示にする
                monsterPictureBox1.Visible = false;
                monsterPictureBox2.Visible = false;
                monsterPictureBox3.Visible = false;

                //背景画像をわざエフェクトに差し替える
                battlePictureBox.Image = Image.FromFile(gif_image);

                if (job.JobType == Enum.JobsType.遊び人)
                {
                    job.JobType = Enum.JobsType.元遊び人;
                    job.JobInit();
                    jobTextBox2.Text = job.JobName;
                    skillButton.Text = job.WazaName;
                }
            }

            if (enemy.HP <= 0 && enemy_delete_flg1 == true)
            {
                logTextBox.AppendText(Environment.NewLine + enemy.Name + "を倒した！");
                enemy_delete_flg1 = false;
            }

            if (enemy2.HP <= 0 && enemy_delete_flg2 == true)
            {
                logTextBox.AppendText(Environment.NewLine + enemy2.Name + "を倒した！");
                enemy_delete_flg2 = false;
            }

            if (enemy3.HP <= 0 && enemy_delete_flg3 == true)
            {
                logTextBox.AppendText(Environment.NewLine + enemy3.Name + "を倒した！");
                enemy_delete_flg3 = false;
            }

            if (enemy.HP <= 0 && enemy2.HP <= 0 && enemy3.HP <= 0)
            {
                if (monsterPictureBox1.Visible == false && monsterPictureBox2.Visible == false && monsterPictureBox3.Visible == false)
                {
                    attackButton.Enabled = false;
                }
                GameClearDialog();
            }
        }
    }
}
