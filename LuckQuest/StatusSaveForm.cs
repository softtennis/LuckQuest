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
            equip1TextBox.Text = job.Weapon;
            equip1Button.Enabled = false;
            if (jobButton.Enabled == true)
            {
                announcement();
                equip1Button.Enabled = true;
                this.ActiveControl = equip1Button;
            }
        }

        private void equip2Button_Click(object sender, EventArgs e)
        {
            equip2TextBox.Text = job.Helmet;
            equip2Button.Enabled = false;
            if (jobButton.Enabled == true)
            {
                announcement();
                equip2Button.Enabled = true;
                this.ActiveControl = equip2Button;
            }
        }

        private void equip3Button_Click(object sender, EventArgs e)
        {
            equip3TextBox.Text = job.Armor;
            equip3Button.Enabled = false;
            if (jobButton.Enabled == true)
            {
                announcement();
                equip3Button.Enabled = true;
                this.ActiveControl = equip3Button;
            }
        }

        private void equip4Button_Click(object sender, EventArgs e)
        {
            equip4TextBox.Text = job.Shield;
            equip4Button.Enabled = false;
            if (jobButton.Enabled == true)
            {
                announcement();
                equip4Button.Enabled = true;
                this.ActiveControl = equip4Button;
            }
        }

        private void battleButton_Click(object sender, EventArgs e)
        {
            BattleForm f = new BattleForm(   //クラスの中のコンストラクターを呼び出す。コンストラクターに対してはオーバーロードをよく使う。
                hero,job);
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

        public void announcement()
        {
            DialogResult dialogResult = MessageBox.Show(
                    "選ばれし者よ…職業を選択せよ…",
                    "神の警告",
                    MessageBoxButtons.YesNo);
        }
    }
}
