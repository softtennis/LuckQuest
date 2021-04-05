using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckQuest
{
    public class Enum
    {
        public enum EnemiesType
        {
            スライム=0,
            スライムナイト=1,
            ゴーレム=2,
            キラーマシン=3,
            ドラゴン=4,
            魔王=5
        }

        /// <summary>
        /// ジョブタイプ
        /// 注意：職業追加の際は、元遊び人よりも前に追加すること
        /// </summary>
        public enum JobsType
        {
            勇者=0,
            戦士=1,
            盗賊=2,
            魔法使い=3,
            賢者=4,
            遊び人=5,
            元遊び人=99
        }
        //var enemy = EnemiesType.enemy1;

        //string enemyName = enemy.ToString();


        //static class Sample
        //{
        //    static void Main()
        //    {
        //        var enemyDictionary = new Dictionary<string, string>()
        //        {
        //            {"enemy1", "スライム"},
        //            {"enemy2", "スライムナイト"},
        //            {"enemy3", "ゴーレム"},
        //            {"enemy4", "キラーマシン"},
        //            {"enemy5", "ドラゴン"},
        //            {"enemy6", "魔王"}
        //        };

        //        EnemiesType enemy = EnemiesType.enemy1;
        //        string enemyName = enemy.ToString();
        //    }
        //}
    }
}
