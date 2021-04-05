using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckQuest
{
    public class Job
    {
        /// <summary>
        /// 職業名
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// わざ名
        /// </summary>
        public string WazaName { get; set; }

        /// <summary>
        /// わざ１メッセージ１
        /// </summary>
        public string Waza1Message1 { get; set; }

        /// <summary>
        /// わざ１メッセージ２
        /// </summary>
        public string Waza1Message2 { get; set; }

        /// <summary>
        /// わざ１メッセージ２
        /// </summary>
        public int Waza1Mp { get; set; }

        /// <summary>
        ///わざ１ダメージ
        /// </summary>
        public int Waza1Damage { get; set; }

        /// <summary>
        /// わざ１のエフェクト画像
        /// </summary>
        public string ImageFile { get; set; }

        /// <summary>
        /// 装備1の名前
        /// </summary>
        public string Weapon { get; set; }

        /// <summary>
        /// 装備2の名前
        /// </summary>
        public string Helmet { get; set; }

        /// <summary>
        /// 装備3の名前
        /// </summary>
        public string Armor { get; set; }

        /// <summary>
        /// 装備4の名前
        /// </summary>
        public string Shield { get; set; }

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

        /// <summary>
        /// StatusSaveFormのnumberの受け取り先
        /// </summary>
        public Enum.JobsType JobType { get; set; }

        public void JobInit()
        {
            switch (JobType)
            {
                case Enum.JobsType.勇者:
                    JobName = "勇者";
                    WazaName = "ライデイン（消費MP：20、攻撃力：200）";
                    Waza1Message1 = "わざ発動！ライデイン！";
                    Waza1Message2 = "に稲光が走る！";
                    Waza1Mp = 20;
                    Waza1Damage = 200;
                    ImageFile = "inaduma.gif";
                    Equip();
                    break;
                case Enum.JobsType.戦士:
                    JobName = "戦士";
                    WazaName = "魔人斬り（消費MP：30、攻撃力：300）";
                    Waza1Message1 = "わざ発動！魔人斬り！";
                    Waza1Message2 = "に斬撃が襲う！";
                    Waza1Mp = 30;
                    Waza1Damage = 300;
                    ImageFile = "majingiri.gif";
                    Equip();
                    break;
                case Enum.JobsType.盗賊:
                    JobName = "盗賊";
                    WazaName = "ポイズンダガー（消費MP：10、攻撃力：150）";
                    Waza1Message1 = "わざ発動！ポイズンダガー！";
                    Waza1Message2 = "に猛毒が迫る！";
                    Waza1Mp = 10;
                    Waza1Damage = 150;
                    ImageFile = "doku.gif";
                    Equip();
                    break;
                case Enum.JobsType.魔法使い:
                    JobName = "魔法使い";
                    WazaName = "バギクロス（消費MP：35、攻撃力：400）";
                    Waza1Message1 = "わざ発動！バギクロス！";
                    Waza1Message2 = "に真空波が襲い掛かる！";
                    Waza1Mp = 35;
                    Waza1Damage = 400;
                    ImageFile = "kaze.gif";
                    Equip();
                    break;
                case Enum.JobsType.賢者:
                    JobName = "賢者";
                    WazaName = "イオナズン（消費MP：40、攻撃力：500）";
                    Waza1Message1 = "わざ発動！イオナズン！";
                    Waza1Message2 = "も含め、辺り一帯が吹き飛んだ！";
                    Waza1Mp = 40;
                    Waza1Damage = 500;
                    ImageFile = "bakuhatu.gif";
                    Equip();
                    break;
                case Enum.JobsType.遊び人:
                    JobName = "遊び人";
                    WazaName = "奇妙なダンス（消費MP：20、攻撃力：0、使うと・・・？）";
                    Waza1Message1 = "わざ発動！奇妙なダンス！";
                    Waza1Message2 = "にダメージは入らなかった！が、反省して賢者にjobチェンジした！";
                    Waza1Mp = 20;
                    Waza1Damage = 0;
                    ImageFile = "odori.gif";
                    Equip();
                    break;
                case Enum.JobsType.元遊び人:
                    JobName = "賢者（元遊び人）";
                    WazaName = "イオナズン（消費MP：30、攻撃力：1000）";
                    Waza1Message1 = "わざ発動！イオナズン！";
                    Waza1Message2 = "も含め、辺り一帯が地獄のような惨状に！"+ Environment.NewLine + "反省した男は強いぞ！";
                    Waza1Mp = 30;
                    Waza1Damage = 1000;
                    ImageFile = "bakuhatu.gif";
                    break;
            }
        }

        public void Equip()
        {
            string[] equip1 = new string[6];
            string[] equip2 = new string[6];
            string[] equip3 = new string[6];
            string[] equip4 = new string[6];
            if (JobType == Enum.JobsType.勇者 || JobType == Enum.JobsType.戦士 || JobType == Enum.JobsType.盗賊 || JobType == Enum.JobsType.遊び人)
            {
                equip1[0] = "おたま(攻撃+5)";
                equip1[1] = "果物ナイフ(攻撃+10)";
                equip1[2] = "銅の剣(攻撃+20)";
                equip1[3] = "銀の剣(攻撃+30)";
                equip1[4] = "金の剣(攻撃+50)";
                equip1[5] = "伝説の剣(攻撃+100)";

                equip2[0] = "帽子(防御+5)";
                equip2[1] = "防災ヘルメット(防御+10)";
                equip2[2] = "銅の兜(防御+20)";
                equip2[3] = "銀の兜(防御+30)";
                equip2[4] = "金の兜(防御+50)";
                equip2[5] = "伝説の兜(防御+100)";

                equip3[0] = "Tシャツ(防御+5)";
                equip3[1] = "マント(防御+10)";
                equip3[2] = "銅の鎧(防御+20)";
                equip3[3] = "銀の鎧(防御+30)";
                equip3[4] = "金の鎧(防御+50)";
                equip3[5] = "伝説の鎧(防御+100)";

                equip4[0] = "おなべのふた(防御+5)";
                equip4[1] = "木の盾(防御+10)";
                equip4[2] = "銅の盾(防御+20)";
                equip4[3] = "銀の盾(防御+30)";
                equip4[4] = "金の盾(防御+50)";
                equip4[5] = "伝説の盾(防御+100)";
            }
            else 
            {
                equip1[0] = "リモコン(攻撃+5)";
                equip1[1] = "安物の杖(攻撃+10)";
                equip1[2] = "奮発して買った杖(攻撃+20)";
                equip1[3] = "あの時の杖(攻撃+30)";
                equip1[4] = "すごい杖(攻撃+50)";
                equip1[5] = "やばい杖(攻撃+100)";

                equip2[0] = "紙の帽子(防御+5)";
                equip2[1] = "羽飾り(防御+10)";
                equip2[2] = "すごい羽根飾り(防御+20)";
                equip2[3] = "とてつもない羽根飾り(防御+30)";
                equip2[4] = "魔法の帽子(防御+50)";
                equip2[5] = "大賢者の帽子(防御+100)";

                equip3[0] = "アロハシャツ(防御+5)";
                equip3[1] = "バスローブ(防御+10)";
                equip3[2] = "シルクのローブ(防御+20)";
                equip3[3] = "魔法のローブ(防御+30)";
                equip3[4] = "金のローブ(防御+50)";
                equip3[5] = "大賢者のローブ(防御+100)";

                equip4[0] = "安物の腕輪(防御+5)";
                equip4[1] = "初任給で買った腕輪(防御+10)";
                equip4[2] = "奮発したネックレス(防御+20)";
                equip4[3] = "衝動買いしたイヤリング(防御+30)";
                equip4[4] = "金のサークレット(防御+50)";
                equip4[5] = "幻の指輪(防御+100)";
            }
            var random = new Random();
            var number1 = random.Next(equip1.Length);
            var number2 = random.Next(equip2.Length);
            var number3 = random.Next(equip3.Length);
            var number4 = random.Next(equip4.Length);

            Weapon = equip1[number1];
            Helmet = equip2[number2];
            Armor = equip3[number3];
            Shield = equip4[number4];

            int[] power = { 5, 10, 20, 30, 50, 100 };
            int equip1_attack = power[number1];
            
            int[] guard1 = { 5, 10, 20, 30, 50, 100 };
            int equip2_defense = guard1[number2];

            int[] guard2 = { 5, 10, 20, 30, 50, 100 };
            int equip3_defense = guard2[number3];

            int[] guard3 = { 5, 10, 20, 30, 50, 100 };
            int equip4_defense = guard3[number4];

            WeaponAttack = equip1_attack;
            HelmetDefense = equip2_defense;
            ArmorDefense = equip3_defense;
            ShieldDefense = equip4_defense;
        }
    }
}
