using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZCGSeekCardForm.Properties;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ZCGSeekCardForm
{
    //字体种类
    public enum FontType
    {
        Songti,
        Lishu,
        Heiti,
        Youyuan,
        Kaiti,
        Null
    }
    public partial class Form1 : Form
    {

        //新建一个卡片库，在窗口加载时初始化所有卡片数据对象
        private List<Card> cards;
        //筛选后的卡片库
        private IList<Card> searchCards;
        //判断控件是否打开（觉得这个方法有点蠢）
        private bool isSearch;
        //判断控件是否是第一次打开
        private bool isFirstOpen;
        private Form2 form;
        //列表开关，如果选中列表元素则不关闭其他元素
        private bool listBool;
        //获取当前卡片索引的位置
        public static int index;
        //窗口二添加卡片的次数
        public static int times = 0;
        public static bool isMax = false;
        //获取窗口二的位置，同步窗口一

        //窗口居中坐标
        private static int startX;
        private static int startY;
        //当前字体文件的判断
        public static FontType fontType = FontType.Null;
        //自定义文本颜色
        public static Color textColor = Color.Black;
        //为背景图片的保存提供索引数字
        public static int Bg = -1;
        //不触发textbox事件
        private bool isTextBoxChange;
        //存储图片文件路径的集合
        IList<string> fileNmaes = new List<string>();
        FormSize size = new FormSize();
        public Point Position { get; set; }
        public int FormOldSize { get; set; }
        //定义卡片库的委托方法
        public Func<List<Card>> CardDataDelegate;
        public Form1()
        {
            FormOldSize = -1;
            //缓冲，解决背景图片闪烁的问题
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            groupBox1.Hide();
            setCodeComboBox2.Items.Clear();
            setCodeComboBox3.Items.Clear();
            setCodeComboBox4.Items.Clear();
            foreach (var item in setCodeComboBox1.Items)
            {
                setCodeComboBox2.Items.Add(item);
                setCodeComboBox3.Items.Add(item);
                setCodeComboBox4.Items.Add(item);
            }
            StartText();
            SetConSize();
        }
        //初始化控件文本
        private void StartText()
        {
            this.setCodeComboBox1.Text = this.setCodeComboBox1.Items[0].ToString();
            this.setCodeComboBox2.Text = this.setCodeComboBox2.Items[0].ToString();
            this.setCodeComboBox3.Text = this.setCodeComboBox3.Items[0].ToString();
            this.setCodeComboBox4.Text = this.setCodeComboBox4.Items[0].ToString();
            this.levelComboBox.Text = this.levelComboBox.Items[0].ToString();
            this.raceComboBox.Text = this.raceComboBox.Items[0].ToString();
            this.AttComboBox.Text = this.AttComboBox.Items[0].ToString();
            this.cardTypeComboBox.Text = this.cardTypeComboBox.Items[0].ToString();

        }
        //筛选卡片的公共方法
        //卡类筛选
        private void cardMethodSearch(CheckBox checkBox)
        {
            isSearch = true;
            if (searchCards == null && isFirstOpen) return;
            else if (searchCards == null)
            {
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox.Text)).ToList();
                isFirstOpen = true;
            }
            else
            {
                searchCards = searchCards.Where(card => card.CardType != null && card.CardType.Contains(checkBox.Text)).ToList();
            }
        }
        //ComboBox控件属性筛选
        private void cardMethodSearch(ComboBox comboBox)
        {
            isSearch = true;
            if (searchCards == null && isFirstOpen) return;
            else if (searchCards == null)
            {
                switch (comboBox.Name)
                {
                    case "setCodeComboBox1":
                    case "setCodeComboBox2":
                    case "setCodeComboBox3":
                    case "setCodeComboBox4":
                        searchCards = cards.Where(card => card.SetCode != null && card.SetCode.Contains(comboBox.Text)).ToList();
                        break;
                    case "cardTypeComboBox":
                        searchCards = cards.Where(card => card.CardBaseType != null && card.CardBaseType.Contains(comboBox.Text)).ToList();
                        break;
                    case "levelComboBox":
                        searchCards = cards.Where(card => (card.Level > -1 && card.Level.ToString() == comboBox.Text) || (card.Rank > -1 && card.Rank.ToString() == comboBox.Text)).ToList();
                        break;
                    case "AttComboBox":
                        searchCards = cards.Where(card => card.CardAttribute != null && card.CardAttribute == comboBox.Text).ToList();
                        break;
                    case "raceComboBox":
                        searchCards = cards.Where(card => card.CardRace != null && card.CardRace + '族' == comboBox.Text).ToList();
                        break;
                }
                isFirstOpen = true;
            }
            else
            {
                switch (comboBox.Name)
                {
                    case "setCodeComboBox1":
                    case "setCodeComboBox2":
                    case "setCodeComboBox3":
                    case "setCodeComboBox4":
                        searchCards = searchCards.Where(card => card.SetCode != null && card.SetCode.Contains(comboBox.Text)).ToList();
                        break;
                    case "cardTypeComboBox":
                        searchCards = searchCards.Where(card => card.CardBaseType != null && card.CardBaseType.Contains(comboBox.Text)).ToList();
                        break;
                    case "levelComboBox":
                        searchCards = searchCards.Where(card => card.Level > -1 && card.Level.ToString() == comboBox.Text).ToList();
                        break;
                    case "AttComboBox":
                        searchCards = searchCards.Where(card => card.CardAttribute != null && card.CardAttribute == comboBox.Text).ToList();
                        break;
                    case "raceComboBox":
                        searchCards = searchCards.Where(card => card.CardRace != null && card.CardRace + '族' == comboBox.Text).ToList();
                        break;
                }
            }
        }
        private void cardMethodSearch(TextBox textBox)
        {
            isSearch = true;
            if (searchCards == null && isFirstOpen) return;
            else if (searchCards == null)
            {
                switch (textBox.Name)
                {
                    case "attackTextBox":
                        searchCards = cards.Where(card => (card.Attack > -1 && card.Attack.ToString() == textBox.Text) || (card.Attack == -2 && textBox.Text == "?" || (card.Attack == -3 && textBox.Text == "∞"))).ToList();
                        break;
                    case "defenseTextBox":
                        searchCards = cards.Where(card => (card.Defense > -1 && card.Defense.ToString() == textBox.Text) || (card.Defense == -2 && textBox.Text == "?" || (card.Defense == -3 && textBox.Text == "∞"))).ToList();
                        break;
                    case "LtextBox":
                        searchCards = cards.Where(card => card.LPendulum > -1 && card.LPendulum.ToString() == textBox.Text).ToList();
                        break;
                    case "RtextBox":
                        searchCards = cards.Where(card => card.RPendulum > -1 && card.RPendulum.ToString() == textBox.Text).ToList();
                        break;
                }
                isFirstOpen = true;
            }
            else
            {
                switch (textBox.Name)
                {
                    case "attackTextBox":
                        searchCards = searchCards.Where(card => (card.Attack > -1 && card.Attack.ToString() == textBox.Text) || (card.Attack == -2 && textBox.Text == "?" || (card.Attack == -3 && textBox.Text == "∞"))).ToList();
                        break;
                    case "defenseTextBox":
                        searchCards = searchCards.Where(card => (card.Defense > -1 && card.Defense.ToString() == textBox.Text) || (card.Defense == -2 && textBox.Text == "?" || (card.Defense == -3 && textBox.Text == "∞"))).ToList();
                        break;
                    case "LtextBox":
                        searchCards = searchCards.Where(card => card.LPendulum > -1 && card.LPendulum.ToString() == textBox.Text).ToList();
                        break;
                    case "RtextBox":
                        searchCards = searchCards.Where(card => card.RPendulum > -1 && card.RPendulum.ToString() == textBox.Text).ToList();
                        break;
                }
            }
        }
        //搜索时根据当前条件筛选对应卡片
        private void cardSearch()
        {
            //同调控件
            if (this.checkBox1.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox1);
            }
            //超量控件
            if (this.checkBox2.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox2);
            }
            //灵摆控件
            if (this.checkBox3.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox3);
            }
            //效果控件
            if (this.checkBox4.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox4);
            }
            //通常控件
            if (this.checkBox5.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox5);
            }
            //反转控件
            if (this.checkBox6.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox6);
            }
            //卡通控件
            if (this.checkBox7.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox7);
            }
            //调整控件
            if (this.checkBox8.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox8);
            }
            //同盟控件
            if (this.checkBox9.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox9);
            }
            //二重控件
            if (this.checkBox10.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox10);
            }
            //仪式控件
            if (this.checkBox11.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox11);
            }
            //衍生物控件
            if (this.checkBox16.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox16);
            }
            //场地控件
            if (this.checkBox15.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox15);
            }
            //速攻控件
            if (this.checkBox14.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox14);
            }
            //永续控件
            if (this.checkBox13.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox13);
            }
            //装备控件
            if (this.checkBox12.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox12);
            }
            //反击控件
            if (this.checkBox17.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox17);
            }
            //融合控件
            if (this.checkBox18.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox18);
            }
            //灵魂控件
            if (this.checkBox20.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox20);
            }
            //特殊召唤控件
            if (this.checkBox19.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox19);
            }
            //石板控件
            if (this.checkBox21.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox21);
            }
            //千年控件
            if (this.checkBox22.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox22);
            }
            //禁忌控件
            if (this.checkBox23.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox23);
            }
            //七星控件
            if (this.checkBox24.CheckState == CheckState.Checked)
            {
                cardMethodSearch(checkBox24);
            }
            //字段控件1
            if (this.setCodeComboBox1.Text != "" && this.setCodeComboBox1.Text != this.setCodeComboBox1.Items[0].ToString())
            {
                cardMethodSearch(setCodeComboBox1);
            }
            //字段控件2
            if (this.setCodeComboBox2.Text != "" && this.setCodeComboBox2.Text != this.setCodeComboBox2.Items[0].ToString())
            {
                cardMethodSearch(setCodeComboBox2);
            }
            //字段控件3
            if (this.setCodeComboBox3.Text != "" && this.setCodeComboBox3.Text != this.setCodeComboBox3.Items[0].ToString())
            {
                cardMethodSearch(setCodeComboBox3);
            }
            //字段控件4
            if (this.setCodeComboBox4.Text != "" && this.setCodeComboBox4.Text != this.setCodeComboBox4.Items[0].ToString())
            {
                cardMethodSearch(setCodeComboBox4);
            }
            //种类控件
            if (this.cardTypeComboBox.Text != "" && this.cardTypeComboBox.Text != this.cardTypeComboBox.Items[0].ToString())
            {
                cardMethodSearch(cardTypeComboBox);
            }
            //星级控件
            if (this.levelComboBox.Text != "" && this.levelComboBox.Text != this.levelComboBox.Items[0].ToString())
            {
                cardMethodSearch(levelComboBox);
            }
            //属性控件
            if (this.AttComboBox.Text != "" && this.AttComboBox.Text != this.AttComboBox.Items[0].ToString())
            {
                cardMethodSearch(AttComboBox);
            }
            //种族控件
            if (this.raceComboBox.Text != "" && this.raceComboBox.Text != this.raceComboBox.Items[0].ToString())
            {
                cardMethodSearch(raceComboBox);
            }
            //攻击力控件
            if (this.attackTextBox.Text != "")
            {
                cardMethodSearch(attackTextBox);
            }
            //守备力控件
            if (this.defenseTextBox.Text != "")
            {
                cardMethodSearch(defenseTextBox);
            }
            //左灵摆控件
            if (this.LtextBox.Text != "")
            {
                cardMethodSearch(LtextBox);
            }
            //右灵摆控件
            if (this.RtextBox.Text != "")
            {
                cardMethodSearch(RtextBox);
            }
        }
        /*
           //当用户的输入框中文字变化时触发
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cardSearch();
            if(isSearch)
            {
               isSearch = false;
            }
            if (this.textBox1.Text != "")
            {
                if (!listBool)
                {
                    this.menuListBox.Items.Clear();
                }
                if (searchCards == null)
                {
                    searchCards = cards;
                }
                foreach (Card card in searchCards)
                {
                    //文本+卡号+名称
                    //这个暂不提供
                    if (card.Name.Contains(this.textBox1.Text) && !this.menuListBox.Items.Contains(card.Name))
                    {
                        this.menuListBox.Items.Add(card.Name);
                    }
                    if (!card.Name.Contains(this.textBox1.Text) && !listBool)
                    {
                        this.menuListBox.Items.Remove(card.Name);
                    }
                }
            }
            else
            {
                this.menuListBox.Items.Clear();
                this.pictureBox.Image = null;
                //GC回收
                GC.Collect();
            }
        }
         */
        private void ButtonSearchCard()
        {
            //初始化searchCards
            searchCards = null;
            //不知道需不需要，但linq查询的结果好似是新new的结果，有必要去回收
            GC.Collect();

            this.menuListBox.Items.Clear();
            cardSearch();
            //如果控件没被选中，直接返回全部卡片
            if (!isSearch)
            {
                foreach (Card card in cards)
                {

                    this.menuListBox.Items.Add(card.Name);
                }
            }
            else
            {
                //有BUG？
                if (searchCards == null)
                {
                    searchCards = cards;
                }
                foreach (Card card in searchCards)
                {
                    this.menuListBox.Items.Add(card.Name);
                }
                //重置，这个可能需要换位置
                isSearch = false;
                isFirstOpen = false;
            }
        }
        //当用户单击“搜索”时触发
        private void button1_Click(object sender, EventArgs e)
        {
            //注意：searchCards调用的是cards的引用，所以不能对其进行直接的删改！
            //显示当前json库中所有卡片的名称
            if (this.textBox1.Text == "")//不能用null，这里要用""来表示文本的不存在
            {
                ButtonSearchCard();
            }
            else if (this.textBox1.Text != "")
            {
                //这里需要改动，在筛选后还是可以搜索到原来的卡
                foreach (Card card in cards)
                {
                    //如果名字和文本框中的一致，则不检索了，直接返回窗口二;
                    if (card.Name == textBox1.Text)
                    {
                        //获取当前卡片的索引位置
                        if (searchCards == null)
                        {
                            index = cards.IndexOf(card);
                        }
                        else
                        {
                            index = searchCards.IndexOf(card);
                            //如果找不到这个值，那么就默认
                            if (index < 0)
                            {
                                MessageBox.Show("当前筛选中没有找到此卡！请重新输入正确信息！");
                                return;
                            }
                        }
                        //这个地方要让其重新排序
                        CreateForm();
                        if (searchCards == null)
                        {
                            CreateCardData(index, cards);
                        }
                        else
                        {
                            CreateCardData(index, searchCards.ToList());
                        }
                        return;

                    }

                }
                //如果列表中没有元素，说明没有与该字符匹配的筛选项目，直接返回（不能这样写了）
                //if (this.menuListBox.Items.Count <= 0) return;
                ButtonSearchCard();
                if (searchCards == null)
                {
                    searchCards = cards;
                }
                searchCards = searchCards.Where(card => (card.Name.Contains(this.textBox1.Text) || card.BaseDes.Contains(this.textBox1.Text) || card.Des.Contains(this.textBox1.Text) || card.Code.ToString().Contains(this.textBox1.Text) || card.BaseCode.ToString().Contains(this.textBox1.Text))).ToList();
                //如果searchCards为空(因为linq只会返回空集合而不会返回空，所及检查对象的数量)，则不继续走，直接返回
                if (searchCards.Count <= 0)
                {
                    this.menuListBox.Items.Clear();
                    return;
                }
                foreach (Card card in searchCards)
                {
                    for (int index = 0; index < this.menuListBox.Items.Count; index++)
                    {
                        //如果集合当中不包含这个项，则移除它
                        if (this.menuListBox.Items[index].ToString()!= card.Name)
                        {
                            this.menuListBox.Items.Remove(this.menuListBox.Items[index]);
                            index--;
                        }
                    }
                }

                foreach (Card card in searchCards)
                {
                    //文本+卡号+名称
                    //这个暂不提供
                    this.menuListBox.Items.Add(card.Name);
                }
            }
            else
            {
                this.menuListBox.Items.Clear();
            }
        }
        //创建第二个窗口
        private void CreateForm()
        {
            //打开窗口
            //给窗口二确定窗口大小
            if (this.WindowState == FormWindowState.Maximized)
            {
                isMax = true;
            }
            else
            {
                isMax = false;
            }
            form = new Form2();
            form.CardDataDelegate = new Func<List<Card>>(this.CardDataDelegate);
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.FontType = fontType;
            if (searchCards == null)
            {
                form.cards = this.cards;
            }
            else
            {
                form.cards = this.searchCards.ToList();
            }
            //ID修改
            // Form2.Id = form.cards.Count;
            Form2.Id = form.cards.Count + 1131;
            form.Show();
            form.baseRichTextBox.Multiline = true;
            form.desRichTextBox.Multiline = true;
            form.baseRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            form.desRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            //给窗口二设置字体
            form.StartFont();
            //把窗口二的图片背景删除
            form.attPictureBox.BackColor = Color.Transparent;
            form.racePictureBox.BackColor = Color.Transparent;
            form.pictureBox1.BackColor = Color.Transparent;
            //注意：背景不会随窗口的Dispose而被释放内存！！！
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
        //创建卡片数据库方法
        public void CreateCardData(int index, List<Card> cards)
        {
            switch (cards[index].Level)
            {
                case -1:
                    form.levelLabel.Text = "等级：";
                    break;
                default:
                    form.levelLabel.Text = "等级：" + cards[index].Level;
                    break;
            }
            switch (cards[index].Rank)
            {
                case -1:
                    form.rankLabel.Text = "阶级：";
                    break;
                default:
                    form.rankLabel.Text = "阶级：" + cards[index].Rank;
                    break;
            }
            switch (cards[index].RPendulum)
            {
                case -1:
                    form.rPendulumLabel.Text = "右灵摆：";
                    break;
                default:
                    form.rPendulumLabel.Text = "右灵摆：" + cards[index].RPendulum;
                    break;
            }
            switch (cards[index].LPendulum)
            {
                case -1:
                    form.lPendulumLabel.Text = "左灵摆：";
                    break;
                default:
                    form.lPendulumLabel.Text = "左灵摆：" + cards[index].LPendulum;
                    break;
            }
            switch (cards[index].Attack)
            {
                case -1:
                    form.attackLabel.Text = "攻击力：";
                    break;
                case -2:
                    form.attackLabel.Text = "攻击力：?";
                    break;
                case -3:
                    form.attackLabel.Text = "攻击力：∞";
                    break;
                default:
                    form.attackLabel.Text = "攻击力：" + cards[index].Attack;
                    break;
            }
            switch (cards[index].Defense)
            {
                case -1:
                    form.defenseLabel.Text = "守备力：";
                    break;
                case -2:
                    form.defenseLabel.Text = "守备力：?";
                    break;
                case -3:
                    form.defenseLabel.Text = "守备力：∞";
                    break;
                default:
                    form.defenseLabel.Text = "守备力：" + cards[index].Defense;
                    break;
            }
            switch (cards[index].BaseCode)
            {
                case -1:
                    form.baseCodeLabel.Text = "同名卡：";
                    break;
                default:
                    form.baseCodeLabel.Text = "同名卡：" + cards[index].BaseCode;
                    break;
            }
            Form2.Code = cards[index].Code;
            Form2.CodeName = cards[index].Name;
            form.codeLabel.Text = "卡号：" + cards[index].Code;
            form.setCodeLabel.Text = "字段：" + cards[index].SetCode;
            form.setCodeScriptLable.Text = "字段代码：" + cards[index].SetScriptCode;
            form.cardBaseTypeLabel.Text = "种类：" + cards[index].CardBaseType;
            form.cardTypeLabel.Text = "卡类：" + cards[index].CardType;
            form.cardAttributeLabel.Text = "属性：" + cards[index].CardAttribute;
            form.cardRaceLabel.Text = "种族：" + cards[index].CardRace;
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
            form.nameLabel.Text = "卡名：" + cards[index].Name;
            form.desRichTextBox.Text = cards[index].Des;
            form.baseRichTextBox.Text = cards[index].BaseDes;

            object cardPicture = Resources.ResourceManager.GetObject("_" + cards[index].Code);
            if (cardPicture != null)
            {
                form.pictureBox1.Image = cardPicture as Image;
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
                case "人物主题":
                    attPicture = Resources.ResourceManager.GetObject(cards[index].CardBaseType);
                    break;
                default:
                    form.attPictureBox.Image = null;
                    break;
            }
            if (attPicture != null)
            {
                form.attPictureBox.Image = attPicture as Image;
                attPicture = null;
                //GC回收
                GC.Collect();
            }
            object racePicture = null;
            switch (cards[index].CardRace)
            {
                case null:
                case "":
                    form.racePictureBox.Image = null;
                    break;
                default:
                    racePicture = Resources.ResourceManager.GetObject("_" + cards[index].CardRace);
                    break;
            }
            if (racePicture != null)
            {
                form.racePictureBox.Image = racePicture as Image;
                racePicture = null;
                //GC回收
                GC.Collect();
            }

        }

        //当用户的输入框中文字变化时触发
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isTextBoxChange) return;
            //初始化searchCards
            searchCards = null;
            GC.Collect();
            this.menuListBox.Items.Clear();
            cardSearch();
            if (isSearch)
            {
                isSearch = false;
            }
            if (this.textBox1.Text != "")
            {
                if (!listBool)
                {
                    this.menuListBox.Items.Clear();
                }
                if (searchCards == null)
                {
                    searchCards = cards;
                }
                searchCards = searchCards.Where(card => (card.Name.Contains(this.textBox1.Text) || card.BaseDes.Contains(this.textBox1.Text) || card.Des.Contains(this.textBox1.Text) || card.Code.ToString().Contains(this.textBox1.Text) || card.BaseCode.ToString().Contains(this.textBox1.Text))).ToList();
                if (searchCards.Count <= 0)
                {
                    this.menuListBox.Items.Clear();
                    this.pictureBox.Image = null;
                    //GC回收
                    GC.Collect();
                }
                foreach (Card card in searchCards)
                {
                    //文本+卡号+名称
                    //这个暂不提供
                    this.menuListBox.Items.Add(card.Name);
                }
            }
            else
            {

                this.menuListBox.Items.Clear();
                this.pictureBox.Image = null;
                //GC回收
                GC.Collect();
            }
        }

        //当用户选中列表中的元素时触发
        private void menuListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBool = true;
            //menuListBox必须被选中时才触发
            if (menuListBox.Items.Count > 0 && menuListBox.SelectedItem != null)
            {
                //设置开关，这里的选中状态禁止触发textBox1变化的事件;
                isTextBoxChange = true;
                this.textBox1.Text = menuListBox.SelectedItem.ToString();
                foreach (Card card in cards)
                {
                    if (card.Name == menuListBox.SelectedItem.ToString())
                    {
                        object cardPicture = Resources.ResourceManager.GetObject("_" + card.Code);
                        if (cardPicture == null) return;
                        this.pictureBox.Image = cardPicture as Image;
                        cardPicture = null;

                        //GC：让GC在此刻就回收cardPicture的内存
                        GC.Collect();
                        break;
                    }
                }
                isTextBoxChange = false;
            }

        }

        //单击textBox组件时触发，重置按钮
        private void textBox1_Click(object sender, EventArgs e)
        {
            listBool = false;
            foreach (Card card in cards)
            {
                if (!card.Name.Contains(this.textBox1.Text))
                {
                    this.menuListBox.Items.Remove(card.Name);
                }
            }
        }

        private void attackTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格或十进制数字，则屏蔽输入
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != '?' && e.KeyChar != '∞')
            {
                e.Handled = true;
            }
        }

        private void defenseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格或十进制数字，则屏蔽输入
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar != '?' && e.KeyChar != '∞')
            {
                e.Handled = true;
            }
        }

        private void LtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格或指定范围数字，则屏蔽输入
            //48为0
            if (e.KeyChar != '\b' && (!(e.KeyChar >= 48 && e.KeyChar <= 57) || LtextBox.Text.Length > 1))
            {
                e.Handled = true;
            }
        }

        private void RtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是退格或指定范围数字，则屏蔽输入
            //48为0
            if (e.KeyChar != '\b' && (!(e.KeyChar >= 48 && e.KeyChar <= 57) || RtextBox.Text.Length > 1))
            {
                e.Handled = true;
            }
        }
        #region 控件筛选实现效果
        //同调
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox1);
        }
        //超量
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox2);
        }
        //灵摆
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox3);
        }
        //效果
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox4);
        }
        //通常
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox5);
        }
        //反转
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox6);
        }
        //卡通
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox7);
        }
        //调整
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox8);
        }
        //同盟
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox9);
        }
        //二重
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox10);
        }
        //仪式
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox11);
        }
        //衍生物
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox16);
        }
        //场地
        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox15);
        }
        //速攻
        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox14);
        }
        //永续
        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox13);
        }
        //装备
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox12);
        }
        //反击
        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox17);
        }
        //融合
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox18);
        }
        //灵魂
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox20);
        }
        //特殊召唤
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox19);
        }
        //石板
        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox21);
        }
        //千年
        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox22);
        }
        //禁忌
        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox23);
        }
        //七星
        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            conditionalScreening(checkBox24);
        }
        #endregion

        //筛选的公共方法
        private void conditionalScreening(CheckBox checkBox)
        {
            //列表中没有元素的话就直接跳过
            if (this.menuListBox.Items.Count < 1 || !checkBox.Checked) return;
            if (searchCards == null || searchCards.Count <= 0)
            {
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox.Text)).ToList();
            }
            if (searchCards != null)
            {
                //不触发textBox1.Text事件;
                isTextBoxChange = true;
                this.menuListBox.Items.Clear();
                //this.textBox1.Text = "";
                for (int index = 0; index < searchCards.Count; index++)
                {
                    if (searchCards[index].CardType != null && searchCards[index].CardType.Contains(checkBox.Text))
                    {
                        this.menuListBox.Items.Add(searchCards[index].Name);
                    }
                    else
                    {
                        searchCards.Remove(searchCards[index]);
                        //这里因为索引元素被删除，所以索引也相应往后减去1
                        index--;
                    }
                }
                isTextBoxChange = false;
            }
        }
    


        ////当窗口二关闭时调用这个方法，显示窗口一
        //private void form_FormClosed(object sender, FormClosedEventArgs e)
        //{

        //    //this.Location = Position;
        //    //this.Show();
        //    this.Close();
        //}
        //清理当前窗体的数据
        private void ClearData()
        {
            StartText();
            menuListBox.Items.Clear();
            textBox1.Text = "";
            LtextBox.Text = "";
            RtextBox.Text = "";
            attackTextBox.Text = "";
            defenseTextBox.Text = "";
            for (int number = 1; number <= 24; number++)
            {
                string objNameStr = "checkBox" + number;
                Object obj = this.GetType().GetField(objNameStr,
                                 System.Reflection.BindingFlags.NonPublic
                               | System.Reflection.BindingFlags.Instance
                               | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                CheckBox checkBox = (CheckBox)obj;
                checkBox.Checked = false;

                //GC:释放obj资源
                obj = null;
                GC.Collect();
            }
            //searchCards = null;
        }
        //重置当前所有按钮
        private void resButton_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        private void 源码ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/YSPplayer/DIYSeekCardForm");
        }

        [HandleProcessCorruptedStateExceptions]
        private void 投稿ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData();
            try
            {
                groupBox1.Show();
                SynchronizationInterface();
            }
            catch (AccessViolationException ex)
            {
                MessageBox.Show("读取异常！");
                MessageBox.Show("AccessViolationException错误提示：" + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常！" + ex.Message);
                return;
            }
        }
        //设置隐藏窗口的字体
        private void SetHideFont(Font font)
        {
            button6.Font = font;
            button5.Font = font;
            button4.Font = font;
            button3.Font = font;

            label12.Font = font;
            label13.Font = font;
            richTextBox1.Font = font;
            textBox2.Font = font;
            font.Dispose();
        }
        //同步界面
        private void SynchronizationInterface()
        {
            if (fontType != FontType.Null)
            {
                switch (fontType)
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
        //用户从投稿界面返回主界面
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();

            textBox2.Text = "";
            richTextBox1.Text = "";
            this.label14.Text = "";
            fileNmaes.Clear();
        }
        //用户添加图片
        private void button5_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                if (!StreamExtend.CheckFileRealType(path))
                {
                    MessageBox.Show("请选择图片文件（jpg/png/gif）!");
                    return;
                }
                //向集合中添加图片路径的信息
                fileNmaes.Add(path);
                MessageBox.Show("添加成功！");
                this.label14.Text = "已插入：" + fileNmaes.Count + "张";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //邮件标题或内容标题
            if (textBox2.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("邮件标题、内容不得为空！");
                return;
            }
            SendEmail();
        }
        //发送邮件
        private void SendEmail()
        {
            //实例化一个发送邮件类。
            MailMessage mailMessage = new MailMessage();
            //发件人邮箱地址
            mailMessage.From = new MailAddress("479310608@qq.com");
            //收件人邮箱地址
            mailMessage.To.Add(new MailAddress("479310608@qq.Com"));
            //邮件的标题
            mailMessage.Subject = this.textBox2.Text;
            //邮件内容
            mailMessage.Body = this.richTextBox1.Text;
            //先将要处理的图片作为附件添加
            if (fileNmaes.Count > 0)
            {
                //相当与邮件内容定义成html
                mailMessage.IsBodyHtml = true;

                foreach (string fileName in fileNmaes)
                {
                    Attachment attachment = new Attachment(fileName);
                    mailMessage.Attachments.Add(attachment);

                    //这边邮件的内容就可以用html标签（img）来插入图片
                    //attachment.contendid为附件固定的id
                    //cid:邮件BASE64编码的某个位置.然后从这个位置上读图片的数据
                    mailMessage.Body += "<img src=\"cid:" + attachment.ContentId + "\"/>";

                    //释放资源
                    attachment.Dispose();
                }
            }
            //实例化一个SmtpClient类
            SmtpClient client = new SmtpClient();
            //qq邮箱，所以是smtp.qq.com
            client.Host = "smtp.qq.com";
            //使用安全加密连接。
            client.EnableSsl = true;
            //不和请求一块发送
            client.UseDefaultCredentials = false;
            //验证发件人身份（发件人的邮箱，这里第二个参数就是生成授权码）
            client.Credentials = new NetworkCredential("479310608@qq.com", "wmzihkhoxltbcacj");
            //发送
            client.Send(mailMessage);
            MessageBox.Show("发送成功！");

            //释放资源
            mailMessage.Dispose();
            client.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("有未收录或其他的Z卡资源（卡片效果描述·卡图）或BUG可以投稿上传至作者的邮箱采纳/反馈。");
        }
        //根据窗口大小来判断修改字体的尺寸
        private float fontSize(float size)
        {
            if (this.WindowState == FormWindowState.Maximized && FormSize.currentSize>0)
            {
                return FormSize.currentSize;
            }
            else
            {
                return size;
            }
        }
        private void 宋体ToolStripMenuItem_Click(object sender, EventArgs e)
        {

                using (Font font = new Font("宋体", fontSize(9), FontStyle.Regular), font2 = new Font("宋体", fontSize(9), FontStyle.Bold))
                {
                    SetFont(font, font2);
                    fontType = FontType.Songti;
                    //释放资源
                    font.Dispose();
                    font2.Dispose();
                }
        }

        private void 隶书ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                string path = @".\Font\方正隶书简体.TTF";
                using (Font font = NewFont.FontSet(path, fontSize(10), FontStyle.Regular), font2 = NewFont.FontSet(path, fontSize(10), FontStyle.Bold))
                {
                    SetFont(font, font2);
                    fontType = FontType.Lishu;
                    font.Dispose();
                    font2.Dispose();
                }
        }
        private void 黑体ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path = @".\Font\方正黑体简体.TTF";
            using (Font font = NewFont.FontSet(path, fontSize(9), FontStyle.Regular), font2 = NewFont.FontSet(path, fontSize(9), FontStyle.Bold))
            {
                SetFont(font, font2);
                fontType = FontType.Heiti;
                font.Dispose();
                font2.Dispose();
            }
        }

        private void 幼圆ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path = @".\Font\方正幼圆.TTF";
            using (Font font = NewFont.FontSet(path, fontSize(9), FontStyle.Regular), font2 = NewFont.FontSet(path, fontSize(9), FontStyle.Bold))
            {
                SetFont(font, font2);
                fontType = FontType.Youyuan;
                font.Dispose();
                font2.Dispose();
            }
        }
        private void 楷体ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path = @".\Font\方正楷体简体.ttf";
            using (Font font = NewFont.FontSet(path, fontSize(9), FontStyle.Regular), font2 = NewFont.FontSet(path, fontSize(9), FontStyle.Bold))
            {
                SetFont(font, font2);
                fontType = FontType.Kaiti;
                font.Dispose();
                font2.Dispose();
            }
        }
        //设置字体
        [HandleProcessCorruptedStateExceptions]
        private void SetFont(Font font, Font font2)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Visible == false) continue;
                if (control.GetType() == textBox1.GetType()
                   || control.GetType() == button1.GetType()
                   || control.GetType() == menuListBox.GetType()
                   || control.GetType() == levelComboBox.GetType()
                   || control.GetType() == panel2.GetType()
                   || control.GetType() == menuStrip1.GetType()
                )
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
                else if (control.GetType() == label1.GetType())
                {
                    try
                    {
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
        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "●点击搜索卡片即可在列表中搜索自己需要寻找的卡片\r●搜索列表暂支持名称的搜索\r●右侧为卡片搜索的筛选条件\r●通常魔法卡/陷阱卡搜索支持勾选通常\r●攻守支持输入“?”、“∞”搜索";
            MessageBox.Show(text);
        }

        private void 介绍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "●仅以简单的查卡器，弥补童年和现实的部分缺憾\r●仅情怀而做，勿作商业用途\r●作者：神数不神\r●作者扣扣：479310608";
            MessageBox.Show(str);
        }

        private void 版本ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string str = "●当前版本：V1.01\r●更新内容：暂无";
            MessageBox.Show(str);
        }
        private void 其他事项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "●卡片实现脚本仅提供作者DIY的相关部分\r●卡库资源主要基于KCG的ZCG卡包创建，该卡包由跟班、想摸鱼却摸不到的呆子ヽ(=ˆ･ω･ˆ=)丿等大佬制作，卡图/卡片信息有部分改动\r●本程序系作者第一次C#窗体应用实操尝试，1个月的踩坑跌撞好在糊里糊涂地走了过来，还是很开心！（*＾-＾*）期间不少困难的解决方案来自于百度（面向互联网编程YYDS!）。当前本项目的源码可在GitHub下载，代码写的些许混乱，多有不足之处，还请大佬见谅。";
            MessageBox.Show(str);
        }
        private void 英雄十代ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBg(Resources.bg1);
            Bg = 1;
        }
        private void 游戏社长ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBg(Resources.bg2);
            Bg = 2;
        }

        private void 吸血鬼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeBg(Resources.bg3);
            Bg = 3;
        }

        private void 冰结界ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChangeBg(Resources.bg4);
            Bg = 4;
        }

        private void 魔术师ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangeBg(Resources.bg5);
            Bg = 5;
        }
        private void 默认ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.BackgroundImage != null)
            {
                this.BackgroundImage=null;
                GC.Collect();
                Bg = -1;
            }

            ColorText();
        }
        private void ColorText()
        {
            foreach (Control control in this.Controls)
            {
                if (control.Visible == false) continue;
                if (control.GetType() == pictureBox.GetType()
                || control.GetType() == label5.GetType())
                {
                    if (control.BackColor != Color.Transparent)
                    {
                        control.BackColor = Color.Transparent;
                    }
                }
                if (control.GetType() == label5.GetType() || control.GetType() == panel2.GetType())
                {
                    if (textColor != null)
                    {
                        control.ForeColor = textColor;
                    }
                }

            }
        }
        //改变背景图片的方法
        private void ChangeBg(Image res)
        {
            if (this.BackgroundImage != res)
            {
                //先要释放内存
                this.BackgroundImage=null;
                GC.Collect();
                this.BackgroundImage = res;
            }
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == pictureBox.GetType()
                || control.GetType() == label5.GetType())
                {
                    control.BackColor = Color.Transparent;
                }
                if (control.GetType() == label5.GetType())
                {
                    control.ForeColor = textColor;
                }
            }
        }

        private void 金黄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textColor = Color.Gold;
            ColorText();
        }

        private void 洋红ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textColor = Color.Magenta;
            ColorText();
        }

        private void 红ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textColor = Color.Red;
            ColorText();
        }

        private void 紫罗兰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textColor = Color.BlueViolet;
            ColorText();
        }

        private void 默认ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            textColor = Color.SpringGreen;
            ColorText();
        }

        private void 白色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textColor = Color.White;
            ColorText();
        }

        private void 默认ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            textColor = Color.Black;
            ColorText();
        }
        private void 居中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startX = (SystemInformation.WorkingArea.Width - this.Size.Width) / 2;
            startY = (SystemInformation.WorkingArea.Height - this.Size.Height) / 2;
            this.Location = (Point)new Size(startX, startY);
        }

        private void 布局保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult TS = MessageBox.Show("是否保存当前页面布局（背景、字体样式、字体颜色）？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (TS == DialogResult.No)
            {
                return;
            }
            //背景保存
            switch (Bg)
            {
                case 1:
                    Properties.Settings.Default.BgImage = 1;
                    break;
                case 2:
                    Properties.Settings.Default.BgImage = 2;
                    break;
                case 3:
                    Properties.Settings.Default.BgImage = 3;
                    break;
                case 4:
                    Properties.Settings.Default.BgImage = 4;
                    break;
                case 5:
                    Properties.Settings.Default.BgImage = 5;
                    break;
                default:
                    Properties.Settings.Default.BgImage = -1;
                    break;
            }

            //字体保存
            switch (fontType)
            {
                case FontType.Heiti:
                    Properties.Settings.Default.FontImage = "黑体";
                    break;
                case FontType.Kaiti:
                    Properties.Settings.Default.FontImage = "楷体";
                    break;
                case FontType.Lishu:
                    Properties.Settings.Default.FontImage = "隶书";
                    break;
                case FontType.Songti:
                    Properties.Settings.Default.FontImage = "宋体";
                    break;
                case FontType.Youyuan:
                    Properties.Settings.Default.FontImage = "幼圆";
                    break;
                default:
                    Properties.Settings.Default.FontImage = "空";
                    break;
            }

            //字体颜色保存
            if (textColor == Color.Gold)
            {
                Properties.Settings.Default.ColorImage = "金黄";
            }
            else if (textColor == Color.Magenta)
            {
                Properties.Settings.Default.ColorImage = "洋红";
            }
            else if (textColor == Color.Red)
            {
                Properties.Settings.Default.ColorImage = "红";
            }
            else if (textColor == Color.BlueViolet)
            {
                Properties.Settings.Default.ColorImage = "紫罗兰";
            }
            else if (textColor == Color.SpringGreen)
            {
                Properties.Settings.Default.ColorImage = "春绿";
            }
            else if (textColor == Color.White)
            {
                Properties.Settings.Default.ColorImage = "白色";
            }
            else if (textColor == Color.Black)
            {
                Properties.Settings.Default.ColorImage = "黑色";
            }

            //将当前值保存
            Properties.Settings.Default.Save();

            MessageBox.Show("保存成功！");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化卡片库对象
            cards = CardDataDelegate?.Invoke();
            //加载保存的数据
            LoadData();
            //SetConSize();
            //这个是根据窗口二返回后和窗口二大小同步而设置的操作，不影响被保存后的窗口初始化大小
            if (this.FormOldSize == 0)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.FormOldSize == 1)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (Properties.Settings.Default.IsMax)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            if (cards == null)
            {
                throw new Exception("程序加载卡片数据库失败！请重试！");
            }
        }
        //设置控件的标签
        private void SetConSize()
        {
            size.X = this.Width;//获取窗体的宽度
            size.Y = this.Height;//获取窗体的高度
            size.setTag(this);//调用方法
        }
        //读取保存的数据
        private void LoadData()
        {
            //加载保存的背景
            switch (Properties.Settings.Default.BgImage)
            {
                case 1:
                    this.BackgroundImage = Resources.bg1;
                    Bg = 1;
                    break;
                case 2:
                    this.BackgroundImage = Resources.bg2;
                    Bg = 2;
                    break;
                case 3:
                    this.BackgroundImage = Resources.bg3;
                    Bg = 3;
                    break;
                case 4:
                    this.BackgroundImage = Resources.bg4;
                    Bg = 4;
                    break;
                case 5:
                    this.BackgroundImage = Resources.bg5;
                    Bg = 5;
                    break;
                default:
                    Bg = -1;
                    break;
            }
            //加载颜色
            switch (Properties.Settings.Default.ColorImage)
            {
                case "黑色":
                    textColor = Color.Black;
                    break;
                case "洋红":
                    textColor = Color.Magenta;
                    break;
                case "红":
                    textColor = Color.Red;
                    break;
                case "金黄":
                    textColor = Color.Gold;
                    break;
                case "紫罗兰":
                    textColor = Color.BlueViolet;
                    break;
                case "春绿":
                    textColor = Color.SpringGreen;
                    break;
                case "白色":
                    textColor = Color.White;
                    break;
                default:
                    break;
            }
            //加载字体样式
            switch (Properties.Settings.Default.FontImage)
            {
                case "宋体":
                    using (Font font = new Font("宋体", 9, FontStyle.Regular), font2 = new Font("宋体", 9, FontStyle.Bold))
                    {
                        SetFont(font, font2);
                        fontType = FontType.Songti;
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case "隶书":
                    string path = @".\Font\方正隶书简体.TTF";
                    using (Font font = NewFont.FontSet(path, 10, FontStyle.Regular), font2 = NewFont.FontSet(path, 10, FontStyle.Bold))
                    {
                        SetFont(font, font2);
                        fontType = FontType.Lishu;
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case "黑体":
                    string path2 = @".\Font\方正黑体简体.TTF";
                    using (Font font = NewFont.FontSet(path2, 9, FontStyle.Regular), font2 = NewFont.FontSet(path2, 9, FontStyle.Bold))
                    {
                        SetFont(font, font2);
                        fontType = FontType.Heiti;
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case "幼圆":
                    string path3 = @".\Font\方正幼圆.TTF";
                    using (Font font = NewFont.FontSet(path3, 9, FontStyle.Regular), font2 = NewFont.FontSet(path3, 9, FontStyle.Bold))
                    {
                        SetFont(font, font2);
                        fontType = FontType.Youyuan;
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                case "楷体":
                    string path4 = @".\Font\方正楷体简体.ttf";
                    using (Font font = NewFont.FontSet(path4, 9, FontStyle.Regular), font2 = NewFont.FontSet(path4, 9, FontStyle.Bold))
                    {
                        SetFont(font, font2);
                        fontType = FontType.Kaiti;
                        font.Dispose();
                        font2.Dispose();
                    }
                    break;
                default:
                    break;
            }
            ColorText();

        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Normal)
            {
                this.BackgroundImage = null;
                GC.Collect();
                float newx = (this.Width) / size.X; //窗体宽度缩放比例
                float newy = (this.Height) / size.Y;//窗体高度缩放比例
                size.setControls(newx, newy, this, fontType);//随窗体改变控件大小
                //设置背景图片
                switch (Bg)
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
            if (this.WindowState == FormWindowState.Maximized)
            {
                toolStripMenuItem3.Enabled = false;
            }
            else
            {
                toolStripMenuItem3.Enabled = true;
            }
        }

        private void 默认最大化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.IsMax)
            {
                Properties.Settings.Default.IsMax = true;
                Properties.Settings.Default.Save();
                MessageBox.Show("修改成功！");
            }
            else
            {
                Properties.Settings.Default.IsMax = false;
                Properties.Settings.Default.Save();
                MessageBox.Show("重置成功！");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.form.Dispose();
        }


    }
}
