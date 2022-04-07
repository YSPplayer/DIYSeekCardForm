using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCGSeekCardForm
{
     public class Card
     {
        public int Id { get; set; }//设置卡片的索引Id，方便后续管理
        public int BaseCode { get; set; }//同名卡卡号
        public int Code { get; set; } //卡号
        public string CardBaseType { get; set; }//种类
        public string CardType { get; set; }//卡类
        public string SetCode { get; set; }//字段
        public string SetScriptCode { get; set;}//字段代码
        public string CardAttribute { get; set; }//属性
        public string CardRace { get; set; }//种族
        //源码描述？
        public string Name { get; set; }//卡片名称
        public string BaseDes { get; set; }//卡片原版描述
        public string Des { get; set; }//卡片描述述

        public int Level { get; set; }//等级
        public int Rank { get; set; }//阶级
        public int LPendulum { get; set; }//左灵摆刻度
        public int RPendulum { get; set; }//右灵摆刻度
        public int Attack { get; set; }//攻击力
        public int Defense { get; set; }//守备力

        //构造函数
        public Card(int id, int baseCode, int code, string setCode,string setScriptCode, string cardBaseType, string cardType, string name, string cardAttribute,
                    string cardRace, int level, int rank, int lPendulum,int rPendulum, int attack, int defense,string baseDes,  string des)
        {
            this.Id = id;
            this.BaseCode = baseCode;
            this.Code = code;
            this.SetCode= setCode;
            this.SetScriptCode = setScriptCode;
            this.CardBaseType = cardBaseType;
            this.CardType = cardType;
            this.Name = name;
            this.CardAttribute = cardAttribute;
            this.CardRace = cardRace;
            this.Level = level;
            this.Rank = rank;
            this.LPendulum = lPendulum;
            this.RPendulum = rPendulum;
            this.Attack = attack;
            this.Defense = defense;
            this.BaseDes = baseDes;
            this.Des = des;
        }
    }
}
