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
using ZCGSeekCardForm.Properties;
namespace ZCGSeekCardForm
{
    public partial class Form1 : Form
    {
        //string sPath = System.Web.HttpContext.Current.Server.MapPath(@"~\App_Data\mapConfig.json");

        //新建一个卡片库，在窗口加载时初始化所有卡片数据对象
        private IList<Card> cards;
        //筛选后的卡片库
        private IList<Card> searchCards;
        //判断控件是否打开（觉得这个方法有点蠢）
        private bool isSearch;
        private Form2 form;
        //列表开关，如果选中列表元素则不关闭其他元素
        private bool listBool;
        //获取当前卡片索引的位置
        public static int index;

        public Form1()
        {
            //初始化卡片库对象
            cards = JsonConvert.DeserializeObject<IList<Card>>(File.ReadAllText("CardData.json", Encoding.Default));
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();

            //初始化控件文本
            this.setCodeComboBox1.Text = this.setCodeComboBox1.Items[0].ToString();
            this.setCodeComboBox2.Text = this.setCodeComboBox2.Items[0].ToString();
            this.setCodeComboBox3.Text = this.setCodeComboBox3.Items[0].ToString();
            this.setCodeComboBox4.Text = this.setCodeComboBox4.Items[0].ToString();
            this.levelComboBox.Text = this.levelComboBox.Items[0].ToString();
            this.raceComboBox.Text = this.raceComboBox.Items[0].ToString();
            this.AttComboBox.Text = this.AttComboBox.Items[0].ToString();
            this.cardTypeComboBox.Text = this.cardTypeComboBox.Items[0].ToString();
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
            //MessageBox.Show(cards[0].SetCode[0]);
            //MessageBox.Show(cards[1].SetCode[0]);
            MessageBox.Show(cards[0].BaseDes);

        }
        //搜索时根据当前条件筛选对应卡片
        private void cardSearch()
        {
            //同调控件
            if (this.checkBox1.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card=>card.CardType!=null && card.CardType.Contains(checkBox1.Text)).ToList();
                if (searchCards == null) return;
            }
            //超量控件
            if (this.checkBox2.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox2.Text)).ToList();
                if (searchCards == null) return;
            }
            //灵摆控件
            if (this.checkBox3.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox3.Text)).ToList();
                if (searchCards == null) return;
            }
            //效果控件
            if (this.checkBox4.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox4.Text)).ToList();
                if (searchCards == null) return;
            }
            //通常控件
            if (this.checkBox5.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox5.Text)).ToList();
                if (searchCards == null) return;
            }
            //反转控件
            if (this.checkBox6.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox6.Text)).ToList();
                if (searchCards == null) return;
            }
            //卡通控件
            if (this.checkBox7.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox7.Text)).ToList();
                if (searchCards == null) return;
            }
            //调整控件
            if (this.checkBox8.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox8.Text)).ToList();
                if (searchCards == null) return;
            }
            //同盟控件
            if (this.checkBox9.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox9.Text)).ToList();
                if (searchCards == null) return;
            }
            //二重控件
            if (this.checkBox10.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox10.Text)).ToList();
                if (searchCards == null) return;
            }
            //仪式控件
            if (this.checkBox11.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox11.Text)).ToList();
                if (searchCards == null) return;
            }
            //衍生物控件
            if (this.checkBox16.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox16.Text)).ToList();
                if (searchCards == null) return;
            }
            //场地控件
            if (this.checkBox15.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox15.Text)).ToList();
                if (searchCards == null) return;
            }
            //速攻控件
            if (this.checkBox14.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox14.Text)).ToList();
                if (searchCards == null) return;
            }
            //永续控件
            if (this.checkBox13.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox13.Text)).ToList();
                if (searchCards == null) return;
            }
            //装备控件
            if (this.checkBox12.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox12.Text)).ToList();
                if (searchCards == null) return;
            }
            //反击控件
            if (this.checkBox17.CheckState == CheckState.Checked)
            {
                isSearch = true;
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox17.Text)).ToList();
                if (searchCards == null) return;
            }
        }
        //当用户单击“搜索”时触发
        private void button1_Click(object sender, EventArgs e)
        {
            //显示当前json库中所有卡片的名称
            if (this.textBox1.Text == "")//不能用null，这里要用""来表示文本的不存在
            {
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
                    if (searchCards == null) return;
                    foreach (Card card in searchCards)
                    {
                        this.menuListBox.Items.Add(card.Name);
                    }
                    //重置，这个可能需要换位置
                    isSearch = false;
                }
            }
            else if (this.textBox1.Text != "")
            {
                //这里需要改动，在筛选后还是可以搜索到原来的卡
                foreach (Card card in cards)
                {
                    if (card.Name == textBox1.Text)
                    {
                        //获取当前卡片的索引位置
                         index = cards.IndexOf(card);
                         CreateForm();
                         CreateCardData(index);
                         break;
                        
                    }
                    //如果列表中包含输入的字符串
                    else if (card.Name.Contains(this.textBox1.Text))
                    {
                        if (this.menuListBox.Items.Count > 0)
                        {
                            //列表返回第一个值
                            menuListBox.SetSelected(0, true);
                        }
                        break;
                    }
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
            this.Hide();
            //释放窗口一卡片数据库内存
            //this.cards.Clear();
            form = new Form2();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.cards = this.cards;
            form.Show();

            form.baseRichTextBox.Multiline = true;
            form.desRichTextBox.Multiline = true;
            form.baseRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            form.desRichTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
        }
        //创建卡片数据库方法
        public void CreateCardData(int index)
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

            form.codeLabel.Text = "卡号：" + cards[index].Code;
            form.setCodeLabel.Text = "字段：" + cards[index].SetCode;
            form.setCodeScriptLable.Text = "字段代码：" + cards[index].SetScriptCode;
            form.cardBaseTypeLabel.Text = "种类：" + cards[index].CardBaseType;
            form.cardTypeLabel.Text = "卡类：" + cards[index].CardType;
            form.cardAttributeLabel.Text = "属性：" + cards[index].CardAttribute;
            form.cardRaceLabel.Text = "种族：" + cards[index].CardRace;
            form.nameLabel.Text = "卡名：" + cards[index].Name;
            form.desRichTextBox.Text = cards[index].Des;
            form.baseRichTextBox.Text = cards[index].BaseDes;

            object cardPicture = Resources.ResourceManager.GetObject("_" + cards[index].Code);
            if (cardPicture != null)
            {
                form.pictureBox1.Image = cardPicture as Image;
            }

        }

        //当用户的输入框中文字变化时触发
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                foreach (Card card in cards)
                {
                    if (card.Name.Contains(this.textBox1.Text) && !this.menuListBox.Items.Contains(card.Name))
                    {
                        this.menuListBox.Items.Add(card.Name);
                    }
                    if(!card.Name.Contains(this.textBox1.Text) && !listBool)
                    {
                        this.menuListBox.Items.Remove(card.Name);
                    }
                }
            }
            else
            {
                this.menuListBox.Items.Clear();
            }
        }

        //当用户选中列表中的元素时触发
        private void menuListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBool = true;
            //menuListBox必须被选中时才触发
            if (menuListBox.Items.Count > 0 && menuListBox.SelectedItem!=null)
            {
                this.textBox1.Text = menuListBox.SelectedItem.ToString();
                foreach (Card card in cards)
                {
                    if (card.Name == menuListBox.SelectedItem.ToString())
                    {
                        object cardPicture = Resources.ResourceManager.GetObject("_" + card.Code);
                        if (cardPicture == null) return;
                        this.pictureBox.Image= cardPicture as Image;
                        break;
                    }
                }
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
            if (e.KeyChar != '\b' && !char.IsDigit(e.KeyChar) && e.KeyChar!= '?' && e.KeyChar != '∞')
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
            if (e.KeyChar != '\b' && (!(e.KeyChar >= 48 && e.KeyChar <= 57)|| LtextBox.Text.Length > 1))
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

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            //列表中没有元素的话就直接跳过
             if (this.menuListBox.Items.Count < 1 || !checkBox11.Checked) return;
             if (searchCards == null)
             {
                 searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox11.Text)).ToList();
             }
             if (searchCards != null)
             {
                this.menuListBox.Items.Clear();
                this.textBox1.Text="";
                foreach (Card card in searchCards)
                {
                    if (card.CardType != null && card.CardType.Contains(checkBox11.Text))
                    {
                        this.menuListBox.Items.Add(card.Name);
                    }
                }
             }
        }
    }
}
