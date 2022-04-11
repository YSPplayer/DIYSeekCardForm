using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

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

        public string Name { get; set; }//卡片名称
        public string BaseDes { get; set; }//卡片原版描述
        public string Des { get; set; }//卡片描述

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

        /// <summary>
        /// 将序列化的json字符串内容写入Json文件，并且保存
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="jsonConents">Json内容</param>
        public static void WriteJsonFile(string path, string jsonConents)
        {
            using (Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //把string文件转化为byte数组
                byte[] bytes = new byte[100];
                //\b 退格
                //\n 换行
                //\r回车
                bytes = Encoding.Default.GetBytes("\r  },\r" + jsonConents + "\r]");
                string findIndex = "]";
                byte[] byteIndex = StreamExtend.ToByteArray(findIndex);
                long index = StreamExtend.Search(stream, 0, byteIndex);
                stream.Seek(index-5, SeekOrigin.Begin);
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
        }
        

        /// <summary>
        /// 对象 转换为Json字符串
        /// </summary>
        /// <param name="tablelList"></param>
        /// <returns></returns>
        public static string ToJson(object tablellist)
        {
            string jsonData = JsonConvert.SerializeObject(tablellist);

            //给json嵌入回车符以还原格式
            for (int index = 0; index < jsonData.Length; index++)
            {
                if (index == 0 || jsonData[index] == ',' || index == jsonData.Length - 2)
                {
                    jsonData = jsonData.Insert(index+1, "\r");
                    //这里需要索引+1，不然死循环
                    index++;
                }
            }
            //给json嵌入空格符
            jsonData=jsonData.Insert(jsonData.LastIndexOf('{'), "  ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"Id\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"BaseCode\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"Code\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"SetCode\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"SetScriptCode\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"CardBaseType\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"CardType\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"Name\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"CardAttribute\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"CardRace\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"Level\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"Rank\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"LPendulum\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"RPendulum\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"Attack\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"Defense\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"BaseDes\""), "     ");
            jsonData = jsonData.Insert(jsonData.IndexOf("\"Des\""), "     ");
            jsonData = jsonData.Insert(jsonData.LastIndexOf('}'), "  ");
            return jsonData;
        }

     }
}
