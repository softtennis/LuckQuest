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
    /// ステータス登録画面のクラス
    /// </summary>
    public partial class StatusSaveForm : Form
    {
        int equip1_attack;
        int equip2_defense;
        int equip3_defense;
        int equip4_defense;

        Hero hero = new Hero();

        public StatusSaveForm()
        {
            InitializeComponent();

            //フォーカスを名前入力欄に当てる
            this.ActiveControl = nameTextBox;
            Init();

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            hero.Name = nameTextBox.Text;
        } 

        public void jobButton_Click(object sender, EventArgs e)
        {
            string[] jobs = { "勇者", "戦士", "盗賊", "遊び人" ,"魔法使い","賢者"};

            var random = new Random();
            var number = random.Next(jobs.Length);

            hero.Job = jobs[number];
            jobTextBox.Text = jobs[number];
            jobButton.Enabled = false;
        }

        private void levelButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            int number = random.Next(1, 101);

            hero.Level = number;
            levelTextBox.Text = number.ToString();
            levelButton.Enabled = false;
        }

        private void attackButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            int number = random.Next(1, 101);

            hero.Attack = number;
            attackTextBox.Text = number.ToString();
            attackButton.Enabled = false;
        }

        private void defenseButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            int number = random.Next(1, 101);

            hero.Defense = number;
            defenseTextBox.Text = number.ToString();
            defenseButton.Enabled = false;
        }

        private void hpButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            int number = random.Next(1, 1000);

            hero.HP = number;
            hpTextBox.Text = number.ToString();
            hpButton.Enabled = false;
        }

        private void mpButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            int number = random.Next(1, 1000);

            hero.MP = number;
            mpTextBox.Text = number.ToString();
            mpButton.Enabled = false;
        }

        private void equip1Button_Click(object sender, EventArgs e)
        {
            string[] equip1 = { "おたま(攻撃+5)", "果物ナイフ(攻撃+10)", "銅の剣(攻撃+20)", "銀の剣(攻撃+30)", "金の剣(攻撃+50)", "伝説の剣(攻撃+100)" };
            string[] equip1_magic = { "木の棒(攻撃+5)", "新聞紙マルメターノ(攻撃+10)", "テレビのリモコン(攻撃+20)", "鉄パイプ(攻撃+30)", "杖(攻撃+50)", "ニワトコの杖(攻撃+100)" };

            var random = new Random();
            var number = random.Next(equip1.Length);
            if(jobTextBox.Text == "勇者"|| jobTextBox.Text == "戦士"||jobTextBox.Text == "盗賊" || jobTextBox.Text == "遊び人")
            {
                equip1TextBox.Text = equip1[number];
            }
            if (jobTextBox.Text == "魔法使い" || jobTextBox.Text == "賢者")
            {
                equip1TextBox.Text = equip1_magic[number];
            }

            equip1Button.Enabled = false;

            if (number == 0)
            {
                equip1_attack = 5;
            }
            else if (number == 1)
            {
                equip1_attack = 10;
            }
            else if (number == 2)
            {
                equip1_attack = 20;
            }
            else if (number == 3)
            {
                equip1_attack = 30;
            }
            else if (number == 4)
            {
                equip1_attack = 50;
            }
            else if (number == 5)
            {
                equip1_attack = 100;
            }
            hero.WeaponAttack = equip1_attack;
        }

        private void equip2Button_Click(object sender, EventArgs e)
        {
            string[] equip2 = { "帽子(防御+5)", "防災ヘルメット(防御+10)", "銅の兜(防御+20)", "銀の兜(防御+30)", "金の兜(防御+50)", "伝説の兜(防御+100)" };
            string[] equip2_magic = { "紙の帽子(防御+5)", "羽飾り(防御+10)", "すごい羽根飾り(防御+20)", "とてつもない羽根飾り(防御+30)", "魔法の帽子(防御+50)", "大賢者の帽子(防御+100)" };

            var random = new Random();
            var number = random.Next(equip2.Length);
            if (jobTextBox.Text == "勇者" || jobTextBox.Text == "戦士" || jobTextBox.Text == "盗賊" || jobTextBox.Text == "遊び人")
            {
                equip2TextBox.Text = equip2[number];
            }
            if (jobTextBox.Text == "魔法使い" || jobTextBox.Text == "賢者")
            {
                equip2TextBox.Text = equip2_magic[number];
            }
            equip2Button.Enabled = false;

            if (number == 0)
            {
                equip2_defense = 5;
            }
            else if (number == 1)
            {
                equip2_defense = 10;
            }
            else if (number == 2)
            {
                equip2_defense = 20;
            }
            else if (number == 3)
            {
                equip2_defense = 30;
            }
            else if (number == 4)
            {
                equip2_defense = 50;
            }
            else if (number == 5)
            {
                equip2_defense = 100;
            }
            hero.WeaponAttack = equip2_defense;
        }

        private void equip3Button_Click(object sender, EventArgs e)
        {
            string[] equip3 = { "Tシャツ(防御+5)", "マント(防御+10)", "銅の鎧(防御+20)", "銀の鎧(防御+30)", "金の鎧(防御+50)", "伝説の鎧(防御+100)" };
            string[] equip3_magic = { "アロハシャツ(防御+5)", "バスローブ(防御+10)", "シルクのローブ(防御+20)", "魔法のローブ(防御+30)", "金のローブ(防御+50)", "大賢者のローブ(防御+100)" };
            var random = new Random();
            var number = random.Next(equip3.Length);
            if (jobTextBox.Text == "勇者" || jobTextBox.Text == "戦士" || jobTextBox.Text == "盗賊" || jobTextBox.Text == "遊び人")
            {
                equip3TextBox.Text = equip3[number];
            }
            if (jobTextBox.Text == "魔法使い" || jobTextBox.Text == "賢者")
            {
                equip3TextBox.Text = equip3_magic[number];
            }
            equip3Button.Enabled = false;

            if (number == 0)
            {
                equip3_defense = 5;
            }
            else if (number == 1)
            {
                equip3_defense = 10;
            }
            else if (number == 2)
            {
                equip3_defense = 20;
            }
            else if (number == 3)
            {
                equip3_defense = 30;
            }
            else if (number == 4)
            {
                equip3_defense = 50;
            }
            else if (number == 5)
            {
                equip3_defense = 100;
            }
            hero.WeaponAttack = equip3_defense;
        }

        private void equip4Button_Click(object sender, EventArgs e)
        {
            string[] equip4 = { "おなべのふた(防御+5)", "木の盾(防御+10)", "銅の盾(防御+20)", "銀の盾(防御+30)", "金の盾(防御+50)", "伝説の盾(防御+100)" };
            string[] equip4_magic = { "安物の腕輪(防御+5)", "初任給で買った腕輪(防御+10)", "奮発したネックレス(防御+20)", "衝動買いしたイヤリング(防御+30)", "金のサークレット(防御+50)", "幻の指輪(防御+100)" };

            var random = new Random();
            var number = random.Next(equip4.Length);
            if (jobTextBox.Text == "勇者" || jobTextBox.Text == "戦士" || jobTextBox.Text == "盗賊" || jobTextBox.Text == "遊び人")
            {
                equip4TextBox.Text = equip4[number];
            }
            if (jobTextBox.Text == "魔法使い" || jobTextBox.Text == "賢者")
            {
                equip4TextBox.Text = equip4_magic[number];
            }
            equip4Button.Enabled = false;

            if (number == 0)
            {
                equip4_defense = 5;
            }
            else if (number == 1)
            {
                equip4_defense = 10;
            }
            else if (number == 2)
            {
                equip4_defense = 20;
            }
            else if (number == 3)
            {
                equip4_defense = 30;
            }
            else if (number == 4)
            {
                equip4_defense = 50;
            }
            else if (number == 5)
            {
                equip4_defense = 100;
            }
            hero.WeaponAttack = equip4_defense;
        }

        private void battleButton_Click(object sender, EventArgs e)
        {
            BattleForm f = new BattleForm(   //クラスの中のコンストラクターを呼び出す。コンストラクターに対してはオーバーロードをよく使う。
                hero);
            f.ShowDialog();

            Init(); //初期化！ロードイベントやコンストラクタは、起動時にしか動かない。ShowDialogは、そのクラスの処理が終わったらここに帰ってくるんやで。
        }

        public void Init()
        {
            nameTextBox.Text = "";
            jobTextBox.Text = "";
            levelTextBox.Text = "";
            attackTextBox.Text = "";
            defenseTextBox.Text = "";
            hpTextBox.Text = "";
            mpTextBox.Text = "";
            equip1TextBox.Text = "";
            equip2TextBox.Text = "";
            equip3TextBox.Text = "";
            equip4TextBox.Text = "";

            jobButton.Enabled = true;
            levelButton.Enabled = true;
            attackButton.Enabled = true;
            defenseButton.Enabled = true;
            hpButton.Enabled = true;
            mpButton.Enabled = true;
            equip1Button.Enabled = true;
            equip2Button.Enabled = true;
            equip3Button.Enabled = true;
            equip4Button.Enabled = true;
        }
    }
}
