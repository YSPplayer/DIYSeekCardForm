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
using Newtonsoft.Json.Linq;

namespace ZCGSeekCardForm
{
    public partial class Form1 : Form
    {
        //string sPath = System.Web.HttpContext.Current.Server.MapPath(@"~\App_Data\mapConfig.json");

        //新建一个卡片库，在窗口加载时初始化所有卡片数据对象
        public IList<Card> cards;
        private Form2 form;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化卡片库对象
            cards = JsonConvert.DeserializeObject<IList<Card>>(File.ReadAllText("CardData.json", Encoding.Default));
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (StreamReader str = new StreamReader("E:\\Learn-More\\DIYSeekCardForm\\temp.txt", Encoding.UTF8))
            {
                while (!str.EndOfStream)//如果没读取完
                {
                    MessageBox.Show(str.ReadLine());
                }
            }
            MessageBox.Show("完成！");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //序列化——对象->字符串 的过程
            //转换成 skill 类型的数组
            //ReadAllText：打开一个文本文件，读取所有行，然后关闭该文件
            //Skill[] skills = JsonConvert.DeserializeObject<Skill[]>(File.ReadAllText("temp.json"));
            //序列化
            //string = JsonConvert.SerializeObject();
            //DeserializeObject:反序列化：字符串——对象

            //Encoding.UTF8 加上这个防止乱码
            IList<Card> cards = JsonConvert.DeserializeObject<IList<Card>>(File.ReadAllText("CardData.json",Encoding.Default));
            MessageBox.Show("开始");
            MessageBox.Show(cards[0].Name);
            MessageBox.Show(cards[0].Des);
            MessageBox.Show(cards[0].SetCode[0]);
            MessageBox.Show(cards[1].SetCode[0]);
            MessageBox.Show(cards[0].BaseDes);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //form = new Form2();
            //form.Show();

            //CreateCardData();
            foreach (Card card in cards)
            {
                this.menuListBox.Items.Add(card.Name);
            }
        }
        //静态方法，创建卡片数据库方法
        private void CreateCardData()
        {
            form.baseRichTextBox.Multiline = true;
            form.baseRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            form.desRichTextBox.Multiline = true;
            form.desRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;

            form.levelLabel.Text = "等级：" + cards[0].Level.ToString();
            form.rankLabel.Text = "阶级：" + cards[0].Rank.ToString();
            form.rPendulumLabel.Text = "右灵摆：" + cards[0].RPendulum.ToString();
            form.lPendulumLabel.Text = "左灵摆：" + cards[0].LPendulum.ToString();
            form.setCodeLabel.Text = "字段：" + cards[0].SetCode[0];
            form.attackLabel.Text = "攻击力：" + cards[0].Attack.ToString();
            form.defenseLabel.Text = "守备力：" + cards[0].Defense.ToString();
            form.nameLabel.Text = "卡名：" + cards[0].Name;
            form.cardBaseTypeLabel.Text = "种类：" + cards[0].CardBaseType;
            form.cardTypeLabel.Text = "卡类：" + cards[0].CardType;
            form.cardAttributeLabel.Text = "属性：" + cards[0].CardAttribute;
            form.cardRaceLabel.Text = "种族：" + cards[0].CardRace;
            form.desRichTextBox.Text = cards[0].Des;
            form.baseRichTextBox.Text = cards[0].BaseDes;
        }
    }
}
