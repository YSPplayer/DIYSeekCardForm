using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using ZCGSeekCardForm.Properties;

namespace ZCGSeekCardForm
{
    public partial class Form2 : Form
    {
        private  Form1 form = new Form1();
        public List<Card> cards;
        public static Image image;//image作为静态属性保存，因为这样可以减少内存消耗，无需作为对象
        public Form2()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //这是网上大佬的码——根据图片名称建立图片
            //this.pictureBox1.Image = Properties.Resources.ResourceManager.GetObject("_9982459") as Image;
            if (Form1.index < cards.Count-1)
            {
                //这里++要写在里面，因为写在外面点击同样执行
                Form1.index++;
                this.CreateCardData(Form1.index);
            }
            else
            {
                MessageBox.Show("已是最后一张！");
            }
        } 

        private void LastButton_Click(object sender, EventArgs e)
        {
            
            if (Form1.index > 0)
            {
                Form1.index--;
                this.CreateCardData(Form1.index);
            }
            else
            {
                MessageBox.Show("已是第一张！");
            }
        }
        //清空当前窗口重置信息
        private void ClearCardData()
        {
            this.levelLabel.Text = "等级：";
            this.rankLabel.Text = "阶级：";
            this.rPendulumLabel.Text = "右灵摆：";
            this.lPendulumLabel.Text = "左灵摆：";
            this.attackLabel.Text = "攻击力：";
            this.defenseLabel.Text = "守备力：";
            this.baseCodeLabel.Text = "同名卡：";
            this.codeLabel.Text = "卡号：";
            this.setCodeLabel.Text = "字段：";
            this.setCodeScriptLable.Text = "字段代码：";
            this.cardBaseTypeLabel.Text = "种类：";
            this.cardTypeLabel.Text = "卡类：";
            this.cardAttributeLabel.Text = "属性：";
            this.cardRaceLabel.Text = "种族：";
            this.nameLabel.Text = "卡名：";
            this.desRichTextBox.Text = "";
            this.baseRichTextBox.Text ="";

            object cardPicture = Resources.ResourceManager.GetObject("_0");
            if (cardPicture != null)
            {
                this.pictureBox1.Image = cardPicture as Image;
            }
        }
        //创建卡片数据库方法
        public void CreateCardData(int index)
        {
            
            switch (cards[index].Level)
            {
                case -1:
                    this.levelLabel.Text = "等级：";
                    break;
                default:
                    this.levelLabel.Text = "等级：" + cards[index].Level;
                    break;
            }
            switch (cards[index].Rank)
            {
                case -1:
                    this.rankLabel.Text = "阶级：";
                    break;
                default:
                    this.rankLabel.Text = "阶级：" + cards[index].Rank;
                    break;
            }
            switch (cards[index].RPendulum)
            {
                case -1:
                    this.rPendulumLabel.Text = "右灵摆：";
                    break;
                default:
                    this.rPendulumLabel.Text = "右灵摆：" + cards[index].RPendulum;
                    break;
            }
            switch (cards[index].LPendulum)
            {
                case -1:
                    this.lPendulumLabel.Text = "左灵摆：";
                    break;
                default:
                    this.lPendulumLabel.Text = "左灵摆：" + cards[index].LPendulum;
                    break;
            }
            switch (cards[index].Attack)
            {
                case -1:
                    this.attackLabel.Text = "攻击力：";
                    break;
                case -2:
                    this.attackLabel.Text = "攻击力：?";
                    break;
                case -3:
                    this.attackLabel.Text = "攻击力：∞";
                    break;
                default:
                    this.attackLabel.Text = "攻击力：" + cards[index].Attack;
                    break;
            }
            switch (cards[index].Defense)
            {
                case -1:
                    this.defenseLabel.Text = "守备力：";
                    break;
                case -2:
                    this.defenseLabel.Text = "守备力：?";
                    break;
                case -3:
                    this.defenseLabel.Text = "守备力：∞";
                    break;
                default:
                    this.defenseLabel.Text = "守备力：" + cards[index].Defense;
                    break;
            }
            switch (cards[index].BaseCode)
            {
                case -1:
                    this.baseCodeLabel.Text = "同名卡：";
                    break;
                default:
                    this.baseCodeLabel.Text = "同名卡：" + cards[index].BaseCode;
                    break;
            }

            this.codeLabel.Text = "卡号：" + cards[index].Code;
            this.setCodeLabel.Text = "字段：" + cards[index].SetCode;
            this.setCodeScriptLable.Text = "字段代码：" + cards[index].SetScriptCode;
            this.cardBaseTypeLabel.Text = "种类：" + cards[index].CardBaseType;
            this.cardTypeLabel.Text = "卡类：" + cards[index].CardType;
            this.cardAttributeLabel.Text = "属性：" + cards[index].CardAttribute;
            this.cardRaceLabel.Text = "种族：" + cards[index].CardRace;
            this.nameLabel.Text = "卡名：" + cards[index].Name;
            this.desRichTextBox.Text = cards[index].Des;
            this.baseRichTextBox.Text = cards[index].BaseDes;

            object cardPicture = Resources.ResourceManager.GetObject("_" + cards[index].Code);
            if (cardPicture != null)
            {
                this.pictureBox1.Image = cardPicture as Image;
            }
        }
        private void ygoButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.position = this.Location;
            this.Close();
        }
        //重置窗体
        private void ClearForm()
        {
            ClearCardData();
            //隐藏控件
            this.ygoButton.Hide();
            this.edoButton.Hide();
            this.LastButton.Hide();
            this.NextButton.Hide();

            //显示控件
            for (int number = 1; number <= 15; number++)
            {
                string objNameStr = "label" + number;
                //字符串转换成对象名，反射——解决方案来自互联网
                Object obj = this.GetType().GetField(objNameStr,
                                 System.Reflection.BindingFlags.NonPublic
                               | System.Reflection.BindingFlags.Instance
                               | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                Label laber = (Label)obj;
                laber.Show();
            }
            for (int number = 1; number <= 4; number++)
            {
                string objNameStr = "comboBox" + number;
                Object obj = this.GetType().GetField(objNameStr,
                                 System.Reflection.BindingFlags.NonPublic
                               | System.Reflection.BindingFlags.Instance
                               | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                ComboBox comboBox = (ComboBox)obj;
                comboBox.Show();
            }
            for (int number = 1; number <= 9; number++)
            {
                string objNameStr = "textBox" + number;
                Object obj = this.GetType().GetField(objNameStr,
                                 System.Reflection.BindingFlags.NonPublic
                               | System.Reflection.BindingFlags.Instance
                               | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                TextBox textBox = (TextBox)obj;
                textBox.Text = "";
                textBox.Show();
            }
            completeButton.Show();
            AttComboBox.Show();
            raceComboBox.Show();

            //初始化控件
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
            comboBox3.Text = comboBox3.Items[0].ToString();
            comboBox4.Text = comboBox4.Items[0].ToString();
            AttComboBox.Text = AttComboBox.Items[0].ToString();
            raceComboBox.Text = raceComboBox.Items[0].ToString();
            desRichTextBox.ReadOnly = false;
            baseRichTextBox.ReadOnly = false;
        }
        private void 添加卡片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格或十进制数字，则屏蔽输入
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != '?' && e.KeyChar != '∞')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格或十进制数字，则屏蔽输入
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != '?' && e.KeyChar != '∞')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格或十进制数字，则屏蔽输入
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格或十进制数字，则屏蔽输入
            //if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }
        /// <summary>
        /// 准备添加卡片的数据库
        /// </summary>
        private void CreateNewCard()
        {
            //Id
            int id = cards.Count;
            //同名卡
            int baseCode = -1;
            if (textBox3.Text != "")
            {
                baseCode = int.Parse(textBox3.Text);
            }
            //卡号
            int code = -1;
            if (textBox4.Text != "")
            {
                code = int.Parse(textBox4.Text);
            }
            //字段
            string setCode = "";
            if (textBox6.Text != "")
            {
                setCode = textBox6.Text;
            }
            //字段代码
            string setScriptCode = "";
            if (textBox7.Text != "")
            {
                setScriptCode = textBox7.Text;
            }
            //种类
            string cardBaseType = "";
            if (textBox8.Text != "")
            {
                cardBaseType = textBox8.Text;
            }
            //卡类
            string cardType = "";
            if (textBox9.Text != "")
            {
                cardType = textBox9.Text;
            }
            //卡名
            string name = "";
            if (textBox5.Text != "")
            {
                name = textBox5.Text;
            }
            //属性
            string att = "";
            if (AttComboBox.Text != AttComboBox.Items[0].ToString())
            {
                att = AttComboBox.Text;
            }
            //种族
            string race = "";
            if (raceComboBox.Text != raceComboBox.Items[0].ToString())
            {
                race = raceComboBox.Text;
            }
            //等级
            int level = -1;
            if (comboBox1.Text != comboBox1.Items[0].ToString())
            {
                level =  int.Parse(comboBox1.Text);
            }
            //阶级
            int rank = -1;
            if (comboBox2.Text != comboBox2.Items[0].ToString())
            {
                rank = int.Parse(comboBox2.Text);
            }
            //左灵摆
            int lP = -1;
            if (comboBox3.Text != comboBox3.Items[0].ToString())
            {
                lP = int.Parse(comboBox3.Text);
            }
            //右灵摆
            int rP = -1;
            if (comboBox4.Text != comboBox4.Items[0].ToString())
            {
                rP = int.Parse(comboBox4.Text);
            }
            //攻击力
            int attack = -1;
            if (textBox1.Text != "")
            {
                switch (textBox1.Text)
                {
                    case "?":
                        attack = -2;
                        break;
                    case "∞":
                        attack = -3;
                        break;
                    default:
                        attack = int.Parse(textBox1.Text);
                        break;
                }
                
            }
            //守备力
            int defense = -1;
            if (textBox2.Text != "")
            {
                switch (textBox2.Text)
                {
                    case "?":
                        defense = -2;
                        break;
                    case "∞":
                        defense = -3;
                        break;
                    default:
                        defense = int.Parse(textBox2.Text);
                        break;
                }

            }
            //原描述
            string baseDes = null;
            if (baseRichTextBox != null)
            {
                baseDes = baseRichTextBox.Text;
            }
            //实现描述
            string des = null;
            if (desRichTextBox != null)
            {
                des = desRichTextBox.Text;
            }
            Card card = new Card(id, baseCode, code, setCode, setScriptCode, cardBaseType, cardType, name, att, race, level, rank, lP, rP, attack, defense, baseDes, des);
            string text = Card.ToJson(card);
            string filepath = @"E:\Learn-More\DIYSeekCardForm\ZCGSeekCardForm\ZCGSeekCardForm\CardData.json";
            Card.WriteJsonFile(filepath, text);
        }
        /// <summary>
        /// 构造卡片对象函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void completeButton_Click(object sender, EventArgs e)
        {
            CreateNewCard();
            MessageBox.Show("添加成功！");
            ClearForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = Form1.index;
            cards[index].BaseDes = baseRichTextBox.Text;
            cards[index].Des = desRichTextBox.Text;
            MessageBox.Show("编辑成功!");
            button2.Hide();
            baseRichTextBox.ReadOnly = true;
            desRichTextBox.ReadOnly = true;
        }

        private void 编辑卡片ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            button2.Show();
            baseRichTextBox.ReadOnly = false;
            desRichTextBox.ReadOnly = false;
        }
    }
}
