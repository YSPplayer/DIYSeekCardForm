using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCGSeekCardForm
{
    public enum CardType
    {
        /// <summary>
        /// 怪兽
        /// </summary>
        TYPE_MONSTER = 1,
        /// <summary>
        /// 魔法
        /// </summary>
        TYPE_SPELL = 2,
        /// <summary>
        /// 陷阱
        /// </summary>
        TYPE_TRAP = 3,
        /// <summary>
        /// 通常
        /// </summary>
        TYPE_NORMAL = 4,
        /// <summary>
        /// 效果
        /// </summary>
        TYPE_EFFECT = 5,
        /// <summary>
        /// 融合
        /// </summary>
        TYPE_FUSION=6,
        /// <summary>
        /// 仪式
        /// </summary>
        TYPE_RITUAL = 7,
        /// <summary>
        /// 灵魂
        /// </summary>
        TYPE_SPIRIT=8,
        /// <summary>
        /// 同盟
        /// </summary>
        TYPE_UNION = 9,
        /// <summary>
        /// 二重
        /// </summary>
        TYPE_DUAL=10,
        /// <summary>
        /// 调整
        /// </summary>
        TYPE_TUNER=11,
        /// <summary>
        /// 同调
        /// </summary>
        TYPE_SYNCHRO=12,
        /// <summary>
        /// 衍生物
        /// </summary>
        TYPE_TOKEN=13,
        /// <summary>
        /// 翻转
        /// </summary>
        TYPE_FLIP=14,
        /// <summary>
        /// 卡通
        /// </summary>
        TYPE_TOON =15,
        /// <summary>
        /// 超量
        /// </summary>
        TYPE_XYZ=16,
        /// <summary>
        /// 灵摆
        /// </summary>
        TYPE_PENDULUM=17,
        /// <summary>
        /// 特殊召唤
        /// </summary>
        TYPE_SPSUMMON=18,
        /// <summary>
        /// 速攻
        /// </summary>
        TYPE_QUICKPLAY=19,
        /// <summary>
        /// 永续
        /// </summary>
        TYPE_CONTINUOUS=20,
        /// <summary>
        /// 装备
        /// </summary>
        TYPE_EQUIP=21,
        /// <summary>
        /// 场地
        /// </summary>
        TYPE_FIELD=22,
        /// <summary>
        ///反击
        /// </summary>
        TYPE_COUNTER=23,
    }
}
