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
            スライム,
            スライムナイト,
            ゴーレム,
            キラーマシン,
            ドラゴン,
            魔王
        }

        public enum JobType
        {
            勇者,
            戦士,
            盗賊,
            魔法使い,
            賢者,
            遊び人
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
