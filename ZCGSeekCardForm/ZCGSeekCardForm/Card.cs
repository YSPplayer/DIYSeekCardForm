﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCGSeekCardForm
{
     public class Card
     {
        private int BaseCode { get; set; }//同名卡卡号
        private int Code { get; set; } //卡号
        private CardType CardBaseType { get; set; }//种类
        private CardType[] CardType { get; set; }//卡类
        private SetCode[] SetCode { get; set; }//字段
        private CardAttribute CardAttribute { get; set; }//属性
        private CardRace CardRace { get; set; }//种族
        //图片？
        //源码描述？
        private string Name { get; set; }//卡片名称
        private string BaseDes { get; set; }//卡片原版描述
        private string Des { get; set; }//卡片描述述

        private int Level { get; set; }//等级
        private int Rank { get; set; }//阶级
        private int LPendulum { get; set; }//左灵摆刻度
        private int RPendulum { get; set; }//右灵摆刻度
        private int Attack { get; set; }//攻击力
        private int Defense { get; set; }//守备力
     }
}
