using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace ZCGSeekCardForm
{
    //新建一个卡片库，在窗口加载时初始化所有卡片数据对象
    public partial class Form3 : Form
    {
        // public static List<Card> cards;
        private List<Card> cards;
        public Form3()
        {
            cards = JsonConvert.DeserializeObject<List<Card>>(File.ReadAllText(@"./CardData/CardData.json", Encoding.Default));
            cards.Sort((cardA, cardB) => string.Compare(cardA.Name, cardB.Name));
            InitializeComponent();
        }
        //加载卡片数据库
        public List<Card> InitializeCardData()
        {
            return cards;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => {
                this.Hide();
                this.Opacity = 0;
            }));
            Form1 form = new Form1();
            form.CardDataDelegate = new Func<List<Card>>(InitializeCardData);
            form.Show();
        }
    }
}
