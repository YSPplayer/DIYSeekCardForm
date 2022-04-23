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
        public static  List<Card> cards;
        public Form3()
        {
            cards = JsonConvert.DeserializeObject<List<Card>>(File.ReadAllText(@"./CardData/CardData.json", Encoding.Default));
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => {
                this.Hide();
                this.Opacity = 1;
            }));
            Form1 form = new Form1();
            form.Show();
        }
    }
}
