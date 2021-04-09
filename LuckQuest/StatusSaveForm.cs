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
        Hero hero = new Hero();
        Job job = new Job();


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
            if(hero.Name == "キクヌンティウス")
            {
                SettingInit();
            }
        } 

        public void jobButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var number = random.Next(System.Enum.GetNames(typeof(Enum.JobsType)).Length-1);

            job.JobType = (Enum.JobsType)number;
            //job.JobType = (Enum.JobsType)5;
            job.JobInit();
            jobTextBox.Text = job.JobName;
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
            if (jobButton.Enabled == true)
            {
                announcement();
                equip1Button.Enabled = true;
                this.ActiveControl = equip1Button;
            }
            else
            {
                equip1TextBox.Text = job.Weapon;
                equip1Button.Enabled = false;
            }
        }

        private void equip2Button_Click(object sender, EventArgs e)
        {
            if (jobButton.Enabled == true)
            {
                announcement();
                equip2Button.Enabled = true;
                this.ActiveControl = equip2Button;
            }
            else
            {
                equip2TextBox.Text = job.Helmet;
                equip2Button.Enabled = false;
            }
        }

        private void equip3Button_Click(object sender, EventArgs e)
        {
            if (jobButton.Enabled == true)
            {
                announcement();
                equip3Button.Enabled = true;
                this.ActiveControl = equip3Button;
            }
            else
            {
                equip3TextBox.Text = job.Armor;
                equip3Button.Enabled = false;
            }
        }

        private void equip4Button_Click(object sender, EventArgs e)
        {
            if (jobButton.Enabled == true)
            {
                announcement();
                equip4Button.Enabled = true;
                this.ActiveControl = equip4Button;
            }
            else
            {
                equip4TextBox.Text = job.Shield;
                equip4Button.Enabled = false;
            }
        }

        private void battleButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "" ||
                jobButton.Enabled == true ||
                levelButton.Enabled == true ||
                attackButton.Enabled == true ||
                defenseButton.Enabled == true ||
                hpButton.Enabled == true ||
                mpButton.Enabled == true ||
                equip1Button.Enabled == true ||
                equip2Button.Enabled == true ||
                equip3Button.Enabled == true ||
                equip4Button.Enabled == true)
            {
                announcement2();
                this.ActiveControl = battleButton;
            }
            else
            {
                BattleForm f = new BattleForm(   //クラスの中のコンストラクターを呼び出す。コンストラクターに対してはオーバーロードをよく使う。
                hero, job);
                f.ShowDialog();
                Init(); //初期化！ロードイベントやコンストラクタは、起動時にしか動かない。ShowDialogは、そのクラスの処理が終わったらここに帰ってくるんやで。
            }  
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

        public void SettingInit()
        {
            jobTextBox.Text = "勇者";
            job.JobType = (Enum.JobsType)0;
            job.JobInit();
            levelTextBox.Text = "100";
            hero.Level = 100;
            attackTextBox.Text = "50";
            hero.Attack = 50;
            defenseTextBox.Text = "50";
            hero.Defense = 50;
            hpTextBox.Text = "9";
            hero.HP = 9;
            mpTextBox.Text = "999";
            hero.MP = 999;
            equip1TextBox.Text = "伝説の剣(攻撃 + 100)";
            job.WeaponAttack = 100;
            equip2TextBox.Text = "伝説の兜(防御+100)";
            job.HelmetDefense = 100;
            equip3TextBox.Text = "伝説の鎧(防御+100)";
            job.ArmorDefense = 100;
            equip4TextBox.Text = "伝説の盾(防御 + 100)";
            job.ShieldDefense = 100;

            jobButton.Enabled = false;
            levelButton.Enabled = false;
            attackButton.Enabled = false;
            defenseButton.Enabled = false;
            hpButton.Enabled = false;
            mpButton.Enabled = false;
            equip1Button.Enabled = false;
            equip2Button.Enabled = false;
            equip3Button.Enabled = false;
            equip4Button.Enabled = false;
        }

        public void announcement()
        {
            DialogResult dialogResult = MessageBox.Show(
                    "選ばれし者よ…職業を選択せよ…",
                    "神の警告",
                    MessageBoxButtons.OK);
        }

        public void announcement2()
        {
            DialogResult dialogResult = MessageBox.Show(
                    "選ばれし者よ…未入力箇所を入力せよ…",
                    "神の警告",
                    MessageBoxButtons.OK);
        }
    }
}
