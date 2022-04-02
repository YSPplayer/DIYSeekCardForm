using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCGSeekCardForm
{
    class MonsterCard:Card
    {
        private CardType[] CardType { get; set; }//卡类
        private CardAttribute CardAttribute { get; set; }//属性
        private CardRace CardRace { get; set; }//种族
        private int Level { get; set; }//等级
        private int Rank { get; set; }//阶级
        private int LPendulum { get; set; }//左灵摆刻度
        private int RPendulum { get; set; }//右灵摆刻度
        private int Attack { get; set; }//攻击力
        private int Defense { get; set; }//守备力

    }
}
