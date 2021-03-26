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
        //敵守備力から①を減算
        private static int atk_sum = 0;
        
        //敵番号
        private static int number = 0;
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

        private Hero hero = new Hero();

        private static int critical;

        public BattleForm(Hero Hero)
        {
            
            InitializeComponent();

            hero = Hero;

            BattleFormLoad();
        }

        public void BattleFormLoad()
        {
            waza1 = 20;
            //if (hero.Job == "勇者")
            //{
            //    waza1 = 20;
            //    //waza2 = 30;
            //    //waza3 = 40;
            //}
            //else if (hero.Job == "戦士")
            //{
            //    waza1 = 20;
            //    //waza2 = 30;
            //    //waza3 = 40;
            //}
            //else if (hero.Job == "盗賊")
            //{
            //    waza1 = 20;
            //    //waza2 = 30;
            //    //waza3 = 40;
            //}
            //else if (hero.Job == "遊び人")
            //{
            //    waza1 = 20;
            //    //waza2 = 30;
            //    //waza3 = 40;
            //}
            //else if (hero.Job == "魔法使い")
            //{
            //    waza1 = 20;
            //    //waza2 = 30;
            //    //waza3 = 40;
            //}
            //else if (hero.Job == "賢者")
            //{
            //    waza1 = 20;
            //    //waza2 = 30;
            //    //waza3 = 40;
            //}

            sum = hero.Attack + hero.WeaponAttack;
            sum2 = hero.Defense + hero.HelmetDefense + hero.ArmorDefense + hero.ShieldDefense;

            //画面上部のステータスバーに、初期ステータス登録画面から受け取った値を反映
            nameTextBox2.Text = hero.Name;
            jobTextBox2.Text = hero.Job;
            levelTextBox2.Text = hero.Level.ToString();
            hpTextBox2.Text = hero.HP.ToString();
            mpTextBox2.Text = hero.MP.ToString();
        　　attackTextBox2.Text = sum.ToString();
            defenseTextBox2.Text = sum2.ToString();

            if (hero.MP < waza1)
            {
                logTextBox.Text = "運がない！" + Environment.NewLine + hero.Name + "はわざを使えるほどMPがない！最悪だ！";
            }

            //背景画像ファイルを描画
            battlePictureBox.Image = Image.FromFile("haikei.png");

            //敵画像ファイルをランダムに描画
            string[] enemies = { "suraimu-removebg-preview.png", "suraimu_night-removebg-preview.png", "goremu.png", "killer_micine.jpg", "dragon.png", "maou-removebg-preview.png" };
            var random = new Random();
            number = random.Next(enemies.Length);
            monsterPictureBox.Image = Image.FromFile(enemies[number]);

            string m_name = "";
            int e_hp = 0;
            int e_attack = 0;
            int e_defense = 0;

            if (number == 0)
            {
                m_name = "スライム";
                e_hp = 300;
                e_attack = 100;
                e_defense = 20;
            }
            else if (number == 1)
            {
                m_name = "スライムナイト";
                e_hp = 400;
                e_attack = 130;
                e_defense = 30;
            }
            else if (number == 2)
            {
                m_name = "ゴーレム";
                e_hp = 500;
                e_attack = 140;
                e_defense = 40;
            }
            else if (number == 3)
            {
                m_name = "キラーマシーン";
                e_hp = 700;
                e_attack = 150;
                e_defense = 50;
            }
            else if (number == 4)
            {
                m_name = "ドラゴン";
                e_hp = 1000;
                e_attack = 180;
                e_defense = 60;
            }
            else if (number == 5)
            {
                m_name = "魔王";
                e_hp = 2000;
                e_attack = 250;
                e_defense = 70;
            }

            monster_name = m_name;
            enemy_hp = e_hp;
            enemy_attack = e_attack;
            enemy_defense = e_defense;
            Encount(waza1);

            //BattleFormロード時にフォーカスを攻撃ボタンに当てる
            this.ActiveControl = attackButton;
        }

        //こうげきボタン押下で戦闘処理を実行
        private void attackButton_Click(object sender, EventArgs e)
        {
            techniquePanel.Visible = false;
            monsterPictureBox.Visible = true;
            battlePictureBox.Image = Image.FromFile("haikei.png");
            Attack();
        }

        //職業ごとに技名を設定
        private void techniqueButton_Click(object sender, EventArgs e)
        {
            techniquePanel.Visible = true;
            monsterPictureBox.Visible = true;
            battlePictureBox.Image = Image.FromFile("haikei.png");

            string waza_name = "";

            if (hero.Job == "勇者")
            {
                waza_name = "ライデイン（消費MP：20、攻撃力：200）";
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
            else if (hero.Job == "戦士")
            {
                waza_name = "魔人斬り（消費MP：20、攻撃力：200）";
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
            else if (hero.Job == "盗賊")
            {
                waza_name = "ポイズンダガー（消費MP：20、攻撃力：100）";
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
            else if (hero.Job == "遊び人")
            {
                waza_name = "奇妙なダンス（使うと…？）";
            }
            else if (hero.Job == "魔法使い")
            {
                waza_name = "バギクロス（消費MP：20、攻撃力：200）";
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
            else if (hero.Job == "賢者")
            {
                waza_name = "イオナズン（消費MP：20、攻撃力：500）";
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
            skillButton.Text = waza_name;
        }

        //わざボタン
        private void skillButton_Click(object sender, EventArgs e)
        {
            monsterPictureBox.Visible = true;
            battlePictureBox.Image = Image.FromFile("haikei.png");
            if (hero.MP < waza1)
            {
                logTextBox.AppendText(Environment.NewLine + "MPが足りない！");
                techniquePanel.Visible = false;
            }
            else
            {
                string waza1_message1 = "";
                string waza1_message2 = "";
                int waza1_damage = 0;
                string image_file = "";

                if (hero.Job == "勇者")
                {
                    waza1_message1 = "わざ発動！ライデイン！";
                    waza1_message2 = "に稲光が走る！";
                    waza1_damage = 200;
                    image_file = "inaduma.gif";
                }
                else if (hero.Job == "戦士")
                {
                    waza1_message1 = "わざ発動！魔人斬り！";
                    waza1_message2 = "に斬撃が襲う！";
                    waza1_damage = 200;
                    image_file = "majingiri.gif";
                }
                else if (hero.Job == "盗賊")
                {
                    waza1_message1 = "わざ発動！ポイズンダガー！";
                    waza1_message2 = "に猛毒が迫る！";
                    waza1_damage = 200;
                    image_file = "doku.gif";
                }
                else if (hero.Job == "魔法使い")
                {
                    waza1_message1 = "わざ発動！バギクロス！";
                    waza1_message2 = "に真空波が襲い掛かる！";
                    waza1_damage = 200;
                    image_file = "kaze.gif";
                }
                else if (hero.Job == "賢者")
                {
                    waza1_message1 = "わざ発動！イオナズン！";
                    waza1_message2 = "も含め、辺り一帯が吹き飛んだ！";
                    waza1_damage = 500;
                    image_file = "bakuhatu.gif";
                }
                else if (hero.Job == "遊び人")
                {
                    waza1_message1 = "わざ発動！奇妙なダンス！";
                    waza1_message2 = "にダメージは入らなかった！が、反省して賢者にjobチェンジした！";
                    hero.Job = "賢者";
                    jobTextBox2.Text = hero.Job + "(元遊び人)";
                    image_file = "odori.gif";
                }

                hero.MP = hero.MP - waza1;
                mpTextBox2.Text = hero.MP.ToString();
                enemy_hp = enemy_hp - waza1_damage;
                logTextBox.AppendText(Environment.NewLine + waza1_message1 + Environment.NewLine + monster_name + waza1_message2);
                logTextBox.AppendText(Environment.NewLine + monster_name + "に" + waza1_damage + "のダメージ！");
                techniquePanel.Visible = false;
                monsterPictureBox.Visible = false;
                battlePictureBox.Image = Image.FromFile(image_file);
            }

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
                else if (dialogResult == DialogResult.Cancel)
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
            if (hero.MP < waza_mp)
            {
                logTextBox.AppendText(Environment.NewLine + monster_name + "が現れた！" + Environment.NewLine + hero.Name + "はどうする？");
            }
            else
            {
                logTextBox.Text = monster_name + "が現れた！" + Environment.NewLine + hero.Name + "はどうする？";
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
                else
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
                    else
                    {
                        enemy_atk_sum = -enemy_atk_sum;
                    }

                    logTextBox.AppendText(Environment.NewLine + monster_name + "の攻撃！");

                    string message = "";
                    
                    if (number == 0)
                    {
                        message = "は勢いよく突進してきた！";
                    }
                    else if(number == 1)
                    {
                        message = "のコンビネーションアタック！";
                    }
                    else if (number == 2)
                    {
                        message = "は岩石を飛ばしてきた！";
                    }
                    else if (number == 3)
                    {
                        message = "の無数の刃が襲い掛かる！";
                    }
                    else if (number == 4)
                    {
                        message = "は猛烈な炎を噴き出した！";
                    }
                    else if (number == 5)
                    {
                        message = "は魔王のオーラを放った！";
                    }
                    logTextBox.AppendText(Environment.NewLine + monster_name + message);
                    logTextBox.AppendText(Environment.NewLine + hero.Name + "に" + enemy_atk_sum + "のダメージ!");
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
                    else
                    {
                        enemy_atk_sum = -enemy_atk_sum;
                    }
                    logTextBox.AppendText(Environment.NewLine + monster_name + "の攻撃！");
                    logTextBox.AppendText(Environment.NewLine + hero.Name + "に" + enemy_atk_sum + "のダメージ!");
                }
                hero.HP = hero.HP - enemy_atk_sum;
                hpTextBox2.Text = hero.HP.ToString();
                if (hero.HP <= 0)
                {
                    hpTextBox2.Text = "0";
                    logTextBox.AppendText(Environment.NewLine + hero.Name + "はやられてしまった…");
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
            }
            else
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
                else if (dialogResult == DialogResult.Cancel)
                {
                    logTextBox.AppendText(Environment.NewLine + "世界は平和に包まれている…");
                }
            }
        }
    }
}
