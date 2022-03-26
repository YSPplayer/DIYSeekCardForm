using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCGSeekCardForm
{
     abstract class Card
     {
        int BaseCode { get; set; }//同名卡卡号
        int Code { get; set; } //卡号
        CardType CardBaseType { get; set; }//种类
        SetCode SetCode { get; set; }//字段
        //图片？
        string Describe { get; set; }//卡片描述
        //源码描述？
     }
}
