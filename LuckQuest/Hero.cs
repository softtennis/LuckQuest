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
        /// 職業
        /// </summary>
        public string Job { get; set; }

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
        /// 装備1の攻撃力
        /// </summary>
        public int WeaponAttack { get; set; }

        /// <summary>
        /// 装備2の守備力
        /// </summary>
        public int HelmetDefense { get; set; }

        /// <summary>
        /// 装備3の守備力
        /// </summary>
        public int ArmorDefense { get; set; }

        /// <summary>
        /// 装備4の守備力
        /// </summary>
        public int ShieldDefense { get; set; }

        //将来の拡張を踏まえて用意
        /// <summary>
        /// コンストラクター
        /// </summary>
        public Hero()
        {

        }
    }

    
}
