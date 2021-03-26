using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckQuest
{
    /// <summary>
    /// enemyのステータス
    /// </summary>
    public class Enemy
    {
        /// <summary>
        /// 敵の名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 敵の攻撃力
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// 敵の守備力
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// 敵のHP
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// 敵の画像
        /// </summary>
        public string ImageFile { get; set; }

        /// <summary>
        /// BattleFormのnumberの受け取り先
        /// </summary>
        public Enum.EnemiesType EnemyType { get; set; }



        //将来の拡張を踏まえて用意
        /// <summary>
        /// コンストラクター
        /// </summary>
        public Enemy()
        {

        }

        public void Init()
        {
            switch (EnemyType)
            {
                case Enum.EnemiesType.スライム:
                    Name = "スライム";
                    HP = 300;
                    Attack = 100;
                    Defense = 20;
                    ImageFile = "suraimu-removebg-preview.png";
                    break;
                case Enum.EnemiesType.スライムナイト:
                    Name = "スライムナイト";
                    HP = 400;
                    Attack = 130;
                    Defense = 30;
                    ImageFile = "suraimu_night-removebg-preview.png";
                    break;
                case Enum.EnemiesType.ゴーレム:
                    Name = "ゴーレム";
                    HP = 500;
                    Attack = 140;
                    Defense = 40;
                    ImageFile = "goremu.png";
                    break;
                case Enum.EnemiesType.キラーマシン:
                    Name = "キラーマシン";
                    HP = 700;
                    Attack = 150;
                    Defense = 50;
                    ImageFile = "killer_micine.jpg";
                    break;
                case Enum.EnemiesType.ドラゴン:
                    Name = "ドラゴン";
                    HP = 1000;
                    Attack = 180;
                    Defense = 60;
                    ImageFile = "dragon.png";
                    break;
                case Enum.EnemiesType.魔王:
                    Name = "魔王";
                    HP = 2000;
                    Attack = 250;
                    Defense = 70;
                    ImageFile = "maou-removebg-preview.png";
                    break;
            }
        }
    }
}
