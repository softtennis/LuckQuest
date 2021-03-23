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
    public partial class BattleForm : Form
    {
        //初期ステータス変数
        private static string name;
        private static string job;
        private static int level;
        private static int hp; 
        private static int mp;
        private static string attack;
        private static string defense;
        private static string equip1_attack;
        private static string equip2_defense;
        private static string equip3_defense;
        private static string equip4_defense;

        //攻撃力+装備1の合計攻撃力・・・①
        private static int sum = 0;
        //守備力+装備2,3,4の合計守備力・・・②
        private static int sum2 = 0;
        //敵守備力から①を減算
        private static int atk_sum = 0;
        
        //敵番号
        private static int number;
        //敵名
        private static string monster_name;
        //敵HP
        private static int enemy_hp = 0;
        //敵攻撃力
        private static int enemy_attack = 0;
        //敵守備力
        private static int enemy_defense = 0;
        //②から敵攻撃力を減算
        private static int enemy_atk_sum = 0;

        int waza1 = 0;
        //int waza2 = 0;
        //int waza3 = 0;

        private static int critical;

        public BattleForm(
            string nameText, 
            string jobText, 
            string levelText,
            string attackText,
            string defenseText,
            string hpText,  
            string mpText, 
            string equip1Text,
            string equip2Text,
            string equip3Text,
            string equip4Text)
        {
            
            InitializeComponent();

            name = nameText;
            job = jobText;
            level = int.Parse(levelText);
            hp = int.Parse(hpText);　
            mp = int.Parse(mpText);
            attack = attackText;
            defense = defenseText;
            equip1_attack = equip1Text;
            equip2_defense = equip2Text;
            equip3_defense = equip3Text;
            equip4_defense = equip4Text;

            BattleFormLoad();
        }

        public void BattleFormLoad()
        {

            if (job == "勇者")
            {
                waza1 = 20;
                //waza2 = 30;
                //waza3 = 40;
            }

            if (job == "戦士")
            {
                waza1 = 20;
                //waza2 = 30;
                //waza3 = 40;
            }

            if (job == "盗賊")
            {
                waza1 = 20;
                //waza2 = 30;
                //waza3 = 40;
            }

            if (job == "遊び人")
            {
                waza1 = 20;
                //waza2 = 30;
                //waza3 = 40;
            }

            if (job == "魔法使い")
            {
                waza1 = 20;
                //waza2 = 30;
                //waza3 = 40;
            }

            if (job == "賢者")
            {
                waza1 = 20;
                //waza2 = 30;
                //waza3 = 40;
            }

            sum = int.Parse(attack) + int.Parse(equip1_attack);
            sum2 = int.Parse(defense) + int.Parse(equip2_defense) + int.Parse(equip3_defense) + int.Parse(equip4_defense);

            //画面上部のステータスバーに、初期ステータス登録画面から受け取った値を反映
            nameTextBox2.Text = name;
            jobTextBox2.Text = job;
            levelTextBox2.Text = level.ToString();
            hpTextBox2.Text = hp.ToString();
            mpTextBox2.Text = mp.ToString();
        　　attackTextBox2.Text = sum.ToString();
            defenseTextBox2.Text = sum2.ToString();

            if (mp < waza1)
            {
                logTextBox.Text = "運がない！" + Environment.NewLine + name + "はわざを使えるほどMPがない！最悪だ！";
            }

            //背景画像ファイルを描画
            battlePictureBox.Image = Image.FromFile("haikei.png");

            //敵画像ファイルをランダムに描画
            string[] enemies = { "suraimu-removebg-preview.png", "suraimu_night-removebg-preview.png", "goremu.png", "killer_micine.jpg", "dragon.png", "maou-removebg-preview.png" };
            var random = new Random();
            number = random.Next(enemies.Length);
            monsterPictureBox.Image = Image.FromFile(enemies[number]);

            if (number == 0)
            {
                monster_name = "スライム";
                enemy_hp = 300;
                enemy_attack = 100;
                enemy_defense = 20;
                Encount(waza1);
            }

            if (number == 1)
            {
                monster_name = "スライムナイト";
                enemy_hp = 400;
                enemy_attack = 130;
                enemy_defense = 30;
                Encount(waza1);
            }

            if (number == 2)
            {
                monster_name = "ゴーレム";
                enemy_hp = 500;
                enemy_attack = 140;
                enemy_defense = 40;
                Encount(waza1);
            }

            if (number == 3)
            {
                monster_name = "キラーマシン";
                enemy_hp = 700;
                enemy_attack = 150;
                enemy_defense = 50;
                Encount(waza1);
            }

            if (number == 4)
            {
                monster_name = "ドラゴン";
                enemy_hp = 800;
                enemy_attack = 180;
                enemy_defense = 60;
                Encount(waza1);
            }

            if (number == 5)
            {
                monster_name = "魔王";
                enemy_hp = 1000;
                enemy_attack = 250;
                enemy_defense = 70;
                Encount(waza1);
            }
            //BattleFormロード時にフォーカスを攻撃ボタンに当てる
            this.ActiveControl = attackButton;
        }

        //こうげきボタン押下で戦闘処理を実行
        private void attackButton_Click(object sender, EventArgs e)
        {
            techniquePanel.Visible = false;
            monsterPictureBox.Visible = true;
            battlePictureBox.Image = Image.FromFile("haikei.png");
            //敵番号が0（スライム）の時
            if (number == 0)
            {
                Attack();
            }
            if (number == 1)
            {
                Attack();
            }
            if (number == 2)
            {
                Attack();
            }
            if (number == 3)
            {
                Attack();
            }
            if (number == 4)
            {
                Attack();
            }
            if (number == 5)
            {
                Attack();
            }
        }


        //職業ごとに技名を設定
        private void techniqueButton_Click(object sender, EventArgs e)
        {
            techniquePanel.Visible = true;
            monsterPictureBox.Visible = true;
            battlePictureBox.Image = Image.FromFile("haikei.png");
            if (job == "勇者")
            {
                skillButton.Text = "ライデイン（消費MP：20、攻撃力：200）";
                //if(level >= 30)
                //{
                //    skillButton2.Visible = true;
                //    skillButton2.Text = "ギガデイン";
                //    if (level >= 50)
                //    {
                //        skillButton3.Visible = true;
                //        skillButton3.Text = " ミナデイン";
                //    }
                //}
            }
            if (job == "戦士")
            {
                skillButton.Text = "魔人斬り（消費MP：20、攻撃力：200）";
                //if (level >= 30)
                //{
                //    skillButton2.Visible = true;
                //    skillButton2.Text = "鬼神斬り";
                //    if (level >= 50)
                //    {
                //        skillButton3.Visible = true;
                //        skillButton3.Text = "凶斬り";
                //    }
                //}
            }
            if (job == "盗賊")
            {
                skillButton.Text = "ポイズンダガー（消費MP：20、攻撃力：100）";
                //if (level >= 30)
                //{
                //    skillButton2.Visible = true;
                //    skillButton2.Text = "アサシンアタック";
                //    if (level >= 50)
                //    {
                //        skillButton3.Visible = true;
                //        skillButton3.Text = "ナイトメアファング";
                //    }
                //}
            }
            if (job == "遊び人")
            {
                skillButton.Text = "奇妙なダンス（使うと…？）";
            }
            if (job == "魔法使い")
            {
                skillButton.Text = "バギクロス（消費MP：20、攻撃力：200）";
                //if (level >= 30)
                //{
                //    skillButton2.Visible = true;
                //    skillButton2.Text = "バギムーチョ";
                //    if (level >= 50)
                //    {
                //        skillButton3.Visible = true;
                //        skillButton3.Text = "ベギラゴン";
                //    }
                //}
            }
            if (job == "賢者")
            {
                skillButton.Text = "イオナズン（消費MP：20、攻撃力：500）";
                //if (level >= 30)
                //{
                //    skillButton2.Visible = true;
                //    skillButton2.Text = "イオグランデ";
                //    if (level >= 50)
                //    {
                //        skillButton3.Visible = true;
                //        skillButton3.Text = "メラガイアー";
                //    }
                //}
            }
        }

        //わざボタン
        private void skillButton_Click(object sender, EventArgs e)
        {
            monsterPictureBox.Visible = true;
            battlePictureBox.Image = Image.FromFile("haikei.png");
            if (mp < waza1)
            {
                logTextBox.AppendText(Environment.NewLine + "MPが足りない！");
                techniquePanel.Visible = false;
            }

            if (mp >= waza1)
            {
                if (job == "勇者")
                {
                    mp = mp - waza1;
                    logTextBox.AppendText(Environment.NewLine + "わざ発動！ライデイン！" + Environment.NewLine + monster_name + "に稲光が走る！");
                    logTextBox.AppendText(Environment.NewLine + monster_name + "に200のダメージ！");
                    enemy_hp = enemy_hp - 200;
                    System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
                    mpTextBox2.Text = mp.ToString();
                    techniquePanel.Visible = false;
                    monsterPictureBox.Visible = false;
                    battlePictureBox.Image = Image.FromFile("inaduma.gif");

                }

                if (job == "戦士")
                {
                    mp = mp - waza1;
                    logTextBox.AppendText(Environment.NewLine + "わざ発動！魔人斬り！" + Environment.NewLine + monster_name + "に斬撃が襲う！");
                    logTextBox.AppendText(Environment.NewLine + monster_name + "に200のダメージ！");
                    enemy_hp = enemy_hp - 200;
                    System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
                    mpTextBox2.Text = mp.ToString();
                    techniquePanel.Visible = false;
                    monsterPictureBox.Visible = false;
                    battlePictureBox.Image = Image.FromFile("majingiri.gif");
                }

                if (job == "盗賊")
                {
                    mp = mp - waza1;
                    logTextBox.AppendText(Environment.NewLine + "わざ発動！ポイズンダガー！" + Environment.NewLine + monster_name + "に猛毒が迫る！");
                    logTextBox.AppendText(Environment.NewLine + monster_name + "に200のダメージ！");
                    enemy_hp = enemy_hp - 200;
                    System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
                    mpTextBox2.Text = mp.ToString();
                    techniquePanel.Visible = false;
                    monsterPictureBox.Visible = false;
                    battlePictureBox.Image = Image.FromFile("doku.gif");
                }

                if (job == "魔法使い")
                {
                    mp = mp - waza1;
                    logTextBox.AppendText(Environment.NewLine + "わざ発動！バギクロス！" + Environment.NewLine + monster_name + "に真空波が襲い掛かる！");
                    logTextBox.AppendText(Environment.NewLine + monster_name + "に200のダメージ！");
                    enemy_hp = enemy_hp - 200;
                    System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
                    mpTextBox2.Text = mp.ToString();
                    techniquePanel.Visible = false;
                    monsterPictureBox.Visible = false;
                    battlePictureBox.Image = Image.FromFile("kaze.gif");
                }

                if (job == "賢者")
                {
                    mp = mp - waza1;
                    logTextBox.AppendText(Environment.NewLine + "わざ発動！イオナズン！" + Environment.NewLine + monster_name + "も含め、辺り一帯が吹き飛んだ！");
                    logTextBox.AppendText(Environment.NewLine + monster_name + "に500のダメージ！");
                    enemy_hp = enemy_hp - 500;
                    System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
                    mpTextBox2.Text = mp.ToString();
                    techniquePanel.Visible = false;
                    monsterPictureBox.Visible = false;
                    battlePictureBox.Image = Image.FromFile("bakuhatu.gif");
                }

                if (job == "遊び人")
                {
                    mp = mp - waza1;
                    logTextBox.AppendText(Environment.NewLine + "わざ発動！奇妙なダンス！" + Environment.NewLine + monster_name + "にダメージはなさそうだ！");
                    logTextBox.AppendText(Environment.NewLine + monster_name + "にダメージは入らなかった！が、反省して賢者にjobチェンジした！");
                    job = "賢者";
                    jobTextBox2.Text = job + "(元遊び人)";
                    System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
                    mpTextBox2.Text = mp.ToString();
                    techniquePanel.Visible = false;
                    monsterPictureBox.Visible = false;
                    battlePictureBox.Image = Image.FromFile("odori.gif");
                }
            }

            //if (mp >= waza2)
            //{
            //    if (job == "勇者")
            //    {
            //        mp = mp - waza2;
            //        logTextBox.AppendText(Environment.NewLine + "わざ発動！ギガデイン！" + Environment.NewLine + monster_name + "に稲光が走る！");
            //        logTextBox.AppendText(Environment.NewLine + monster_name + "に200のダメージ！");
            //        enemy_hp = enemy_hp - 200;
            //        System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
            //        mpTextBox2.Text = mp.ToString();
            //        techniquePanel.Visible = false;
            //    }

            //    if (job == "戦士")
            //    {
            //        mp = mp - waza2;
            //        logTextBox.AppendText(Environment.NewLine + "わざ発動！鬼神斬り！" + Environment.NewLine + monster_name + "に斬撃が襲う！");
            //        logTextBox.AppendText(Environment.NewLine + monster_name + "に200のダメージ！");
            //        enemy_hp = enemy_hp - 200;
            //        System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
            //        mpTextBox2.Text = mp.ToString();
            //        techniquePanel.Visible = false;
            //    }

            //    if (job == "盗賊")
            //    {
            //        mp = mp - waza2;
            //        logTextBox.AppendText(Environment.NewLine + "わざ発動！アサシンアタック！" + Environment.NewLine + monster_name + "に猛毒が迫る！");
            //        logTextBox.AppendText(Environment.NewLine + monster_name + "に200のダメージ！");
            //        enemy_hp = enemy_hp - 200;
            //        System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
            //        mpTextBox2.Text = mp.ToString();
            //        techniquePanel.Visible = false;
            //    }

            //    if (job == "魔法使い")
            //    {
            //        mp = mp - waza2;
            //        logTextBox.AppendText(Environment.NewLine + "わざ発動！バギムーチョ！" + Environment.NewLine + monster_name + "に真空波が襲い掛かる！");
            //        logTextBox.AppendText(Environment.NewLine + monster_name + "に200のダメージ！");
            //        enemy_hp = enemy_hp - 200;
            //        System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
            //        mpTextBox2.Text = mp.ToString();
            //        techniquePanel.Visible = false;
            //    }

            //    if (job == "賢者")
            //    {
            //        mp = mp - waza2;
            //        logTextBox.AppendText(Environment.NewLine + "わざ発動！イオグランデ！" + Environment.NewLine + monster_name + "も含め、辺り一帯が吹き飛んだ！");
            //        logTextBox.AppendText(Environment.NewLine + monster_name + "に300のダメージ！");
            //        enemy_hp = enemy_hp - 300;
            //        System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
            //        mpTextBox2.Text = mp.ToString();
            //        techniquePanel.Visible = false;
            //    }
            //}

            if (enemy_hp <= 0)
            {
                logTextBox.AppendText(Environment.NewLine + monster_name + "を倒した！");
                monsterPictureBox.Visible = false;
                if (monsterPictureBox.Visible == false)
                {
                    attackButton.Enabled = false;
                }
                DialogResult dialogResult = MessageBox.Show(
                    "世界は守られた。もう一度守りますか？",
                    "GAME CLEAR",
                    MessageBoxButtons.RetryCancel);
                if (dialogResult == DialogResult.Retry)
                {
                    this.Close();
                }
                if (dialogResult == DialogResult.Cancel)
                {
                    battlePictureBox.Image = Image.FromFile("haikei.png");
                    techniqueButton.Enabled = false;
                    logTextBox.AppendText(Environment.NewLine + "世界は平和に包まれている…");
                }
            }
        }

        //確率(5%)判定
        private bool probability()
        {
            var random = new Random();
            var number = random.Next(1, 101);

            if (number <= 3)
            {
                return true;
            }
            return false;
        }

        //確率(25%)判定
        private bool probability2()
        {
            var random = new Random();
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
            critical = enemy_attack * 2;
            if (mp < waza_mp)
            {
                logTextBox.AppendText(Environment.NewLine + monster_name + "が現れた！" + Environment.NewLine + name + "はどうする？");
            }
            else
            {
                logTextBox.Text = monster_name + "が現れた！" + Environment.NewLine + name + "はどうする？";
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
            logTextBox.AppendText(Environment.NewLine + name + "の攻撃！");
            if (probability())
            {
                logTextBox.AppendText(Environment.NewLine + "会心の一撃！" + Environment.NewLine + monster_name + "は砕け散った！");
                enemy_hp = 0;
            }

            if (enemy_hp > 0)
            {
                //敵守備力から主人公攻撃力合計を減算
                atk_sum = enemy_defense - sum;

                //敵の守備が攻撃を上回った時
                if (atk_sum >= 0)
                {
                    atk_sum = 1;
                }
                //敵の守備が攻撃を下回った時
                if (atk_sum < 0)
                {
                    atk_sum = -atk_sum;
                }
                enemy_hp = enemy_hp - atk_sum;
                System.Diagnostics.Debug.WriteLine("敵の残りHPは" + enemy_hp);
                logTextBox.AppendText(Environment.NewLine + monster_name + "に" + atk_sum + "のダメージ!");

                if (probability2())
                {
                    enemy_atk_sum = sum2 - critical;

                    //敵の攻撃が守備を下回った時
                    if (enemy_atk_sum >= 0)
                    {
                        enemy_atk_sum = 1;
                    }
                    //敵の攻撃が守備を上回った時
                    if (enemy_atk_sum < 0)
                    {
                        enemy_atk_sum = -enemy_atk_sum;
                    }

                    logTextBox.AppendText(Environment.NewLine + monster_name + "の攻撃！");

                    if (number == 0)
                    {
                        logTextBox.AppendText(Environment.NewLine + monster_name + "は勢いよく突進してきた！");
                    }
                    if (number == 1)
                    {
                        logTextBox.AppendText(Environment.NewLine + monster_name + "のコンビネーションアタック！");
                    }
                    if (number == 2)
                    {
                        logTextBox.AppendText(Environment.NewLine + monster_name + "は岩石を飛ばしてきた！");
                    }
                    if (number == 3)
                    {
                        logTextBox.AppendText(Environment.NewLine + monster_name + "の無数の刃が襲い掛かる！");
                    }
                    if (number == 4)
                    {
                        logTextBox.AppendText(Environment.NewLine + monster_name + "は猛烈な炎を噴き出した！");
                    }
                    if (number == 5)
                    {
                        logTextBox.AppendText(Environment.NewLine + monster_name + "は魔王のオーラを放った！");
                    }
                    logTextBox.AppendText(Environment.NewLine + name + "に" + enemy_atk_sum + "のダメージ!");
                }
                else
                {
                    //主人公守備力合計から敵攻撃力を減算
                    enemy_atk_sum = sum2 - enemy_attack;

                    //敵の攻撃が守備を下回った時
                    if (enemy_atk_sum >= 0)
                    {
                        enemy_atk_sum = 1;
                    }
                    //敵の攻撃が守備を上回った時
                    if (enemy_atk_sum < 0)
                    {
                        enemy_atk_sum = -enemy_atk_sum;
                    }
                    logTextBox.AppendText(Environment.NewLine + monster_name + "の攻撃！");
                    logTextBox.AppendText(Environment.NewLine + name + "に" + enemy_atk_sum + "のダメージ!");
                }

                hp = hp - enemy_atk_sum;
                hpTextBox2.Text = hp.ToString();
                if (hp <= 0)
                {
                    hpTextBox2.Text = "0";
                    logTextBox.AppendText(Environment.NewLine + name + "はやられてしまった…");
                    DialogResult dialogResult = MessageBox.Show(
                    "世界は闇に包まれた…。やり直しますか？",
                    "GAME OVER",
                    MessageBoxButtons.RetryCancel);
                    if (dialogResult == DialogResult.Retry)
                    {
                        this.Close();
                    }
                    if (dialogResult == DialogResult.Cancel)
                    {
                        attackButton.Enabled = false;
                        techniqueButton.Enabled = false;
                        logTextBox.AppendText(Environment.NewLine + "世界は闇に包まれている…");
                    }
                }

            }


            if (enemy_hp <= 0)
            {
                logTextBox.AppendText(Environment.NewLine + monster_name + "を倒した！");
                monsterPictureBox.Visible = false;
                if (monsterPictureBox.Visible == false)
                {
                    attackButton.Enabled = false;
                    techniqueButton.Enabled = false;
                }
                DialogResult dialogResult = MessageBox.Show(
                    "世界は守られた。もう一度守りますか？",
                    "GAME CLEAR",
                    MessageBoxButtons.RetryCancel);
                if (dialogResult == DialogResult.Retry)
                {
                    this.Close();
                }
                if (dialogResult == DialogResult.Cancel)
                {
                    logTextBox.AppendText(Environment.NewLine + "世界は平和に包まれている…");
                }
            }

        }
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    timer1.Interval = 2000;

        //    if (battlePictureBox.Image == Image.FromFile("raidein.png"))
        //    {
        //        timer1.Enabled = true;
        //        battlePictureBox.Image = Image.FromFile("raidein.png");
        //    }
        //}
    }
}
