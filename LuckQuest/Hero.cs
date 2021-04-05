using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckQuest
{
    /// <summary>
    /// heroのステータス
    /// </summary>
    public class Hero
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// レベル
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 攻撃力
        /// </summary>
        public int Attack { get; set; }

        /// <summary>
        /// 守備力
        /// </summary>
        public int Defense { get; set; }

        /// <summary>
        /// HP
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// MP
        /// </summary>
        public int MP { get; set; }

        /// <summary>
        /// 敵守備力から主人公攻撃力と装備1攻撃力を減算した最終攻撃値
        /// </summary>
        public int AttackSum { get; set; }

        //将来の拡張を踏まえて用意
        /// <summary>
        /// コンストラクター
        /// </summary>
        public Hero()
        {

        }

        public void AttackProcessing(int hero_attack ,int enemy_defense)
        {
            //敵守備力から主人公攻撃力合計を減算
            AttackSum = enemy_defense - hero_attack;

            //敵の守備が攻撃を上回った時
            if (AttackSum >= 0)
            {
                AttackSum = 1;
            }
            //敵の守備が攻撃を下回った時
            else
            {
                AttackSum = -AttackSum;
            }
        }
    }
}
