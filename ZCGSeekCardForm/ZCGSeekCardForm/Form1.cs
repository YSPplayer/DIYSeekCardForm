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
        public static int times=0;
        //获取窗口二的位置，同步窗口一
        public static Point position;
        
        public Form1()
        {
            //初始化卡片库对象
            cards = JsonConvert.DeserializeObject<List<Card>>(File.ReadAllText("CardData.json", Encoding.Default));
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
                        searchCards = cards.Where(card => (card.Level >-1 && card.Level.ToString()==comboBox.Text) || (card.Rank > -1 && card.Rank.ToString() == comboBox.Text)).ToList();
                        break;
                    case "AttComboBox":
                        searchCards = cards.Where(card => card.CardAttribute != null && card.CardAttribute==comboBox.Text).ToList();
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
                        searchCards = searchCards.Where(card => card.CardRace != null && card.CardRace+'族' == comboBox.Text).ToList();
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
            if (this.attackTextBox.Text!="")
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
        //当用户单击“搜索”时触发
        private void button1_Click(object sender, EventArgs e)
        {
            //显示当前json库中所有卡片的名称
            if (this.textBox1.Text == "")//不能用null，这里要用""来表示文本的不存在
            {
                //初始化searchCards
                searchCards = null;
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
                    isFirstOpen = false;
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
            form = new Form2();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.cards = this.cards;
            Form2.Id = form.cards.Count;
            //网上找的大佬写法，面向互联网编程
            form.FormClosed += new FormClosedEventHandler(form_FormClosed);
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
        #endregion

        //筛选的公共方法
        private void conditionalScreening(CheckBox checkBox)
        {
            //列表中没有元素的话就直接跳过
            if (this.menuListBox.Items.Count < 1 || !checkBox.Checked) return;
            if (searchCards == null)
            {
                searchCards = cards.Where(card => card.CardType != null && card.CardType.Contains(checkBox.Text)).ToList();
            }
            if (searchCards != null)
            {
                this.menuListBox.Items.Clear();
                this.textBox1.Text = "";
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
            }
        }

        
        //当窗口二关闭时调用这个方法，显示窗口一
        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {


                this.Location = position;
                this.Show();
                //释放资源
                form.Dispose();
            
        }
    }
}
