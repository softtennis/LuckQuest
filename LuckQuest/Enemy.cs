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
        private int critical = 0;

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
        /// 敵の固有わざのメッセージ
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// BattleFormのnumberの受け取り先
        /// </summary>
        public Enum.EnemiesType EnemyType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int EnemyAttackSum { get; set; }



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
                    Message = "は勢いよく突進してきた！";
                    break;
                case Enum.EnemiesType.スライムナイト:
                    Name = "スライムナイト";
                    HP = 400;
                    Attack = 130;
                    Defense = 30;
                    ImageFile = "suraimu_night-removebg-preview.png";
                    Message = "のコンビネーションアタック！";
                    break;
                case Enum.EnemiesType.ゴーレム:
                    Name = "ゴーレム";
                    HP = 500;
                    Attack = 140;
                    Defense = 40;
                    ImageFile = "goremu.png";
                    Message = "は岩石を飛ばしてきた！";
                    break;
                case Enum.EnemiesType.キラーマシン:
                    Name = "キラーマシン";
                    HP = 700;
                    Attack = 150;
                    Defense = 50;
                    ImageFile = "killer_micine.jpg";
                    Message = "の無数の刃が襲い掛かる！";
                    break;
                case Enum.EnemiesType.ドラゴン:
                    Name = "ドラゴン";
                    HP = 1000;
                    Attack = 180;
                    Defense = 60;
                    ImageFile = "dragon.png";
                    Message = "は猛烈な炎を噴き出した！";
                    break;
                case Enum.EnemiesType.魔王:
                    Name = "魔王";
                    HP = 2000;
                    Attack = 250;
                    Defense = 70;
                    ImageFile = "maou-removebg-preview.png";
                    Message = "は魔王のオーラを放った！";
                    break;
            }
            critical = Attack * 2;
        }

        public void EnemyAttackProcessing(int defense_sum)
        {
            //主人公守備力合計から敵攻撃力を減算
            EnemyAttackSum = defense_sum - Attack;

            //敵の攻撃が守備を下回った時
            if (EnemyAttackSum >= 0)
            {
                EnemyAttackSum = 1;
            }
            //敵の攻撃が守備を上回った時
            else
            {
                EnemyAttackSum = -EnemyAttackSum;
            }
        }

        public void EnemyCriticalProcessing(int defense_sum)
        {
            EnemyAttackSum = defense_sum - critical;

            //敵の攻撃が守備を下回った時
            if (EnemyAttackSum >= 0)
            {
                EnemyAttackSum = 1;
            }
            //敵の攻撃が守備を上回った時
            else
            {
                EnemyAttackSum = -EnemyAttackSum;
            }
        }
    }
}
