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
using ZCGSeekCardForm.Properties;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ZCGSeekCardForm
{
    public partial class Form2 : Form
    {
        //添加字体
        public FontType FontType { get; set; }
        public List<Card> cards;
        private Form1 form;
        //添加卡片时id的索引
        public static int Id;
        //为卡片添加脚本
        public static int Code=-1;
        public static string CodeName = "";

        private float newx;
        private float newy;
        //新建加载时的窗口
        FormSize size = new FormSize();
        public Form2()
        {
            //缓冲，解决背景图片闪烁的问题
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            InitializeComponent();
        }
        //根据窗口大小来判断修改字体的尺寸
        private float fontSize(float size)
        {
            if (this.WindowState == FormWindowState.Maximized && FormSize.currentSize > 0)
            {
                return FormSize.currentSize;
            }
            else
            {
                return size;
            }
        }
        //设置背景图片
        private void StartBg()
        {
            switch (Form1.Bg)
            {
                case 1:
                    this.BackgroundImage = Resources.bg1;
                    break;
                case 2:
                    this.BackgroundImage = Resources.bg2;
                    break;
                case 3:
                    this.BackgroundImage = Resources.bg3;
                    break;
                case 4:
                    this.BackgroundImage = Resources.bg4;
                    break;
                case 5:
                    this.BackgroundImage = Resources.bg5;
                    break;
                default:
                    this.BackgroundImage = null;
                    break;
            }
        }
        [HandleProcessCorruptedStateExceptions]
        public void StartFont()
        {
            switch (Form1.fontType)
            {
                case FontType.Songti:
                    using (Font font = new Font("宋体", fontSize(9), FontStyle.Regular), font2 = new Font("宋体", fontSize(9), FontStyle.Bold))
                    {
                        SetFont(font, font2);
                        //释放资源
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case FontType.Lishu:
                    string path = @".\Font\方正隶书简体.TTF";
                    using (Font font = NewFont.FontSet(path, fontSize(10), FontStyle.Regular), font2 = NewFont.FontSet(path, fontSize(10), FontStyle.Bold))
                    {
                        SetFont(font, font2);
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case FontType.Heiti:
                    string path2 = @".\Font\方正黑体简体.TTF";
                    using (Font font = NewFont.FontSet(path2, fontSize(9), FontStyle.Regular), font2 = NewFont.FontSet(path2, fontSize(9), FontStyle.Bold))
                    {
                        SetFont(font, font2);
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case FontType.Youyuan:
                    string path3 = @".\Font\方正幼圆.TTF";
                    using (Font font = NewFont.FontSet(path3, fontSize(9), FontStyle.Regular), font2 = NewFont.FontSet(path3, fontSize(9), FontStyle.Bold))
                    {
                        SetFont(font, font2);
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case FontType.Kaiti:
                    string path4 = @".\Font\方正楷体简体.ttf";
                    using (Font font = NewFont.FontSet(path4, fontSize(9), FontStyle.Regular), font2 = NewFont.FontSet(path4, fontSize(9), FontStyle.Bold))
                    {
                        SetFont(font, font2);
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                default:
                    break;
            }
        }
        //设置字体
        private void SetFont(Font font, Font font2)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Visible == false) continue;
                if (control.GetType() == desRichTextBox.GetType()
                   || control.GetType() == completeButton.GetType()
                   || control.GetType() == textBox7.GetType()
                   || control.GetType() == menuStrip1.GetType())
                {
                    try
                    {
                        control.Font = font;
                    }
                    catch (AccessViolationException ex)
                    {
                        MessageBox.Show("读取异常！");
                        MessageBox.Show("AccessViolationException错误提示：" + ex.Message);
                        return;
                    }
                }
                else if (control.GetType() == baseCodeLabel.GetType())
                {
                    try
                    {
                        control.BackColor = Color.Transparent;
                        control.ForeColor = Form1.textColor;
                        control.Font = font2;
                    }
                    catch (AccessViolationException ex)
                    {
                        MessageBox.Show("读取异常！");
                        MessageBox.Show("AccessViolationException错误提示：" + ex.Message);
                        return;
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        private void NextButton_Click(object sender, EventArgs e)
        {
            //这是网上大佬的码——根据图片名称建立图片
            //this.pictureBox1.Image = Properties.Resources.ResourceManager.GetObject("_9982459") as Image;
            if (Form1.index < cards.Count - 1)
            {
                //这里++要写在里面，因为写在外面点击同样执行
                Form1.index++;
                this.BackgroundImage = null;
                this.CreateCardData(Form1.index);
                StartBg();
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
                this.BackgroundImage = null;
                this.CreateCardData(Form1.index);
                StartBg();
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
            this.baseRichTextBox.Text = "";

            object cardPicture = Resources.ResourceManager.GetObject("_0");
            if (cardPicture != null)
            {
                this.pictureBox1.Image = cardPicture as Image;
                cardPicture = null;
                //GC回收
                GC.Collect();
            }
            this.attPictureBox.Image = null;

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
            Form2.Code = cards[index].Code;
            Form2.CodeName = cards[index].Name;
            this.codeLabel.Text = "卡号：" + cards[index].Code;
            this.setCodeLabel.Text = "字段：" + cards[index].SetCode;
            this.setCodeScriptLable.Text = "字段代码：" + cards[index].SetScriptCode;
            this.cardBaseTypeLabel.Text = "种类：" + cards[index].CardBaseType;
            this.cardTypeLabel.Text = "卡类：" + cards[index].CardType;
            this.cardAttributeLabel.Text = "属性：" + cards[index].CardAttribute;
            this.cardRaceLabel.Text = "种族：" + cards[index].CardRace;
            //因为同名卡的原因，删去空格
            for (int charIndex = cards[index].Name.Length - 1; charIndex >= 0; charIndex--)
            {
                if (cards[index].Name[charIndex] == ' ')
                {
                    //保留前cards[index].Name.Length - 1位字符
                    cards[index].Name = cards[index].Name.Remove(cards[index].Name.Length - 1);
                }
                else
                {
                    break;
                }
            }
            this.nameLabel.Text = "卡名：" + cards[index].Name;
            this.desRichTextBox.Text = cards[index].Des;
            this.baseRichTextBox.Text = cards[index].BaseDes;

            object cardPicture = Resources.ResourceManager.GetObject("_" + cards[index].Code);
            if (cardPicture != null)
            {
                this.pictureBox1.Image = cardPicture as Image;
                cardPicture = null;
                //GC回收
                GC.Collect();
            }
            object attPicture = null;
            switch (cards[index].CardBaseType)
            {
                case "怪兽":
                    attPicture = Resources.ResourceManager.GetObject(cards[index].CardAttribute);

                    break;
                case "魔法":
                case "陷阱":
                    attPicture = Resources.ResourceManager.GetObject(cards[index].CardBaseType);
                    break;
                default:
                    this.attPictureBox.Image = null;
                    break;
            }
            if (attPicture != null)
            {
                this.attPictureBox.Image = attPicture as Image;
                attPicture = null;
                //GC回收
                GC.Collect();
            }
            object racePicture = null;
            switch (cards[index].CardRace)
            {
                case null:
                case "":
                    this.racePictureBox.Image = null;
                    break;
                default:
                    racePicture = Resources.ResourceManager.GetObject("_" + cards[index].CardRace);
                    break;
            }
            if (racePicture != null)
            {
                this.racePictureBox.Image = racePicture as Image;
                racePicture = null;
                //GC回收
                GC.Collect();
            }

        }
        private void ygoButton_Click(object sender, EventArgs e)
        {
            if (Form2.CodeName == "") return;
            string path = @".\CardScript\YgoLua\lua.zip";
            CreatScript(Form2.Code,Form2.CodeName,path);
        }
        
        //尝试创建脚本文件
        private void CreatScript(int code,string codeName,string path)
        {
            string name = "c"+ code + ".lua";
            string name2 = codeName +".lua";
            string res = StreamExtend.GetFileFromZIP(path, name,name2);
            if (res == null) return;
            Form4 form = new Form4(res);
            form.Show();
        }
        private void edoButton_Click(object sender, EventArgs e)
        {
            if (Form2.Code == -1) return;
            string path = @".\CardScript\EdoLua\lua.zip";
            CreatScript(Form2.Code, Form2.CodeName,path);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form = new Form1();
            form.Position = this.Location;
            if (this.WindowState == FormWindowState.Maximized)
            {
                form.FormOldSize = 1;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                form.FormOldSize = 0;
            }
            form.Show();
            this.BackgroundImage = null;
            this.Dispose();
            FlushMemory();
        }
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        //刷新存储器
        private static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
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
            for (int number = 1; number <= 16; number++)
            {
                string objNameStr = "label" + number;
                //字符串转换成对象名，反射——解决方案来自互联网
                Object obj = this.GetType().GetField(objNameStr,
                                 System.Reflection.BindingFlags.NonPublic
                               | System.Reflection.BindingFlags.Instance
                               | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                Label laber = (Label)obj;
                laber.Show();

                obj = null;
                GC.Collect();
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
                obj = null;
                GC.Collect();
            }
            for (int number = 1; number <= 10; number++)
            {
                string objNameStr = "textBox" + number;
                Object obj = this.GetType().GetField(objNameStr,
                                 System.Reflection.BindingFlags.NonPublic
                               | System.Reflection.BindingFlags.Instance
                               | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                TextBox textBox = (TextBox)obj;
                textBox.Text = "";
                textBox.Show();

                obj = null;
                GC.Collect();
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
            textBox10.Text = (Id + Form1.times).ToString();
        }
        private void 添加卡片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
            SynchronizationInterface();
        }
        //同步界面
        private void SynchronizationInterface()
        {
            if (FontType != FontType.Null)
            {
                switch (FontType)
                {
                    case FontType.Lishu:
                        string path = @".\Font\方正隶书简体.TTF";
                        using (Font font = NewFont.FontSet(path, fontSize(10), FontStyle.Regular))
                        {
                            SetHideFont(font);
                            font.Dispose();
                        }
                        break;
                    case FontType.Heiti:
                        string path2 = @".\Font\方正黑体简体.TTF";
                        using (Font font = NewFont.FontSet(path2, fontSize(9), FontStyle.Regular))
                        {
                            SetHideFont(font);
                            font.Dispose();
                        }
                        break;
                    case FontType.Youyuan:
                        string path3 = @".\Font\方正幼圆.TTF";
                        using (Font font = NewFont.FontSet(path3, fontSize(9), FontStyle.Regular))
                        {
                            SetHideFont(font);
                            font.Dispose();
                        }
                        break;
                    case FontType.Kaiti:
                        string path4 = @".\Font\方正楷体简体.ttf";
                        using (Font font = NewFont.FontSet(path4, fontSize(9), FontStyle.Regular))
                        {
                            SetHideFont(font);
                            font.Dispose();
                        }
                        break;
                    default:
                        using (Font font = new Font("宋体", fontSize(9), FontStyle.Regular))
                        {
                            SetHideFont(font);
                            font.Dispose();
                        }
                        break;
                }

            }
        }
        //设置隐藏窗口的字体
        private void SetHideFont(Font font)
        {
            #region 字体控件
            label16.Font = font;
            textBox10.Font = font;
            label9.Font = font;
            textBox5.Font = font;
            label10.Font = font;
            textBox6.Font = font;
            label11.Font = font;
            textBox7.Font = font;
            label12.Font = font;
            textBox8.Font = font;
            label13.Font = font;
            textBox9.Font = font;       
            label2.Font = font;
            label3.Font = font;
            label4.Font = font;
            label5.Font = font;
            textBox1.Font = font;
            label6.Font = font;
            textBox2.Font = font;
            label7.Font = font;
            textBox3.Font = font;
            label8.Font = font;
            textBox4.Font = font;
            label15.Font = font;
            label14.Font = font;
            label1.Font = font;
            completeButton.Font = font;

            comboBox1.Font = font;
            comboBox2.Font = font;
            comboBox3.Font = font;
            comboBox4.Font = font;
            AttComboBox.Font = font;
            raceComboBox.Font = font;
            if (this.WindowState == FormWindowState.Maximized)
            {
                FormSize size = new FormSize();
                string[] mytag1 = comboBox1.Tag.ToString().Split(new char[] { ':' });
                size.SetComBoxSize(mytag1, newx, newy, comboBox1);
                string[] mytag2 = comboBox2.Tag.ToString().Split(new char[] { ':' });
                size.SetComBoxSize(mytag2, newx, newy, comboBox2);
                string[] mytag3 = comboBox3.Tag.ToString().Split(new char[] { ':' });
                size.SetComBoxSize(mytag3, newx, newy, comboBox3);
                string[] mytag4 = comboBox4.Tag.ToString().Split(new char[] { ':' });
                size.SetComBoxSize(mytag4, newx, newy, comboBox4);
                string[] mytag5 = AttComboBox.Tag.ToString().Split(new char[] { ':' });
                size.SetComBoxSize(mytag5, newx, newy, AttComboBox);
                string[] mytag6 = raceComboBox.Tag.ToString().Split(new char[] { ':' });
                size.SetComBoxSize(mytag6, newx, newy, raceComboBox);
                size = null;
            }
            font.Dispose();
            #endregion
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
            int id = -1;
            if (textBox10.Text != "")
            {
                id = int.Parse(textBox10.Text);
            }
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
                level = int.Parse(comboBox1.Text);
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
            string filepath = @".\CardData\CardData.json";
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
            Form1.times++;
            ClearForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = Form1.index;
            InsertStream(baseRichTextBox.Text, desRichTextBox.Text, index);
        }
        /// <summary>
        /// 在自己定义好的json流处插入自己需要添加的文本（重写）
        /// </summary>
        private void InsertStream(string insertBaseText, string insertText, int indexId)
        {
            string filepath = @".\CardData\CardData.json";
            using (Stream stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //json文件中需要查找的指定位置的字符
                //string findIndex = "\"BaseDes\":\"";
                string findIndex = "{";
                //把当前查找字符转换成byte数组
                byte[] byteIndex = StreamExtend.ToByteArray(findIndex);
                //在当前json文件流中查找第indexId次查找到的指定byte数组的流位置
                long index = StreamExtend.Search(stream, 0, byteIndex, indexId);
                //新建卡片对象，即把此对象转化为json字符串，作为文本添加
                Card card = new Card(cards[indexId].Id, cards[indexId].BaseCode, cards[indexId].Code, cards[indexId].SetCode,
                                      cards[indexId].SetScriptCode, cards[indexId].CardBaseType, cards[indexId].CardType, cards[indexId].Name, cards[indexId].CardAttribute, cards[indexId].CardRace,
                                      cards[indexId].Level, cards[indexId].Rank, cards[indexId].LPendulum, cards[indexId].RPendulum, cards[indexId].Attack, cards[indexId].Defense, insertBaseText, insertText);
                string text = Card.ToJson(card);
                //获取下一次{的位置，相减获取中间部分的长度
                long index_2 = StreamExtend.Search(stream, 0, byteIndex, indexId + 1);
                //如果下一个索引不存在，抛出错误，跳出
                if (index_2 == -1)
                {
                    MessageBox.Show("错误，无法获取下一个相同索引！当前索引为最后一个索引值！");
                    return;
                }
                long restLength = index_2 - index;
                //根据查找到的位置，新建一个和返回值后面所有内容的数量一致的byte数组
                byte[] bytes = new byte[stream.Length - index_2 - findIndex.Length];
                //把指针定位到当前查找到的流位置下
                stream.Seek(index_2 + findIndex.Length, SeekOrigin.Begin);
                //根据流位置把剩余内容全部读取到新建的byte数组中
                stream.Read(bytes, 0, bytes.Length);
                //新建一个新字符串，该字符串=自己插入的文本+索引后剩余的文本
                string res = text + ",\r  {" + StreamExtend.ToStr(bytes);
                //把该文本转化成byte数组保存
                bytes = StreamExtend.ToByteArray(res);
                //重新把指针定位到之前查找到的流位置下（因为read后指针位置会改变）
                stream.Seek(index + findIndex.Length - 3, SeekOrigin.Begin);
                //写入重新整合后的文本，完成“替换”
                stream.Write(bytes, 0, bytes.Length);
                //释放流资源
                stream.Close();
                MessageBox.Show("编辑成功，重启后生效!");
            }
        }
        private void 编辑卡片ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            button2.Show();
            baseRichTextBox.ReadOnly = false;
            desRichTextBox.ReadOnly = false;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格或十进制数字，则屏蔽输入
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = null;

            size.X = this.Width;//获取窗体的宽度
            size.Y = this.Height;//获取窗体的高度
            size.setTag(this);//调用方法
            if (Form1.isMax)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            StartBg();

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form.Dispose();
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Normal)
            {
                this.BackgroundImage=null;
                GC.Collect();
                float newx = (this.Width) / size.X; //窗体宽度缩放比例
                float newy = (this.Height) / size.Y;//窗体高度缩放比例
                size.setControls(newx, newy, this, Form1.fontType);//随窗体改变控件大小
            }
            StartBg();
        }
    }
}
