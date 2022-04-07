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
        public IList<Card> cards;
        public static Image image;//image作为静态属性保存，因为这样可以减少内存消耗，无需作为对象
        public Form2()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //这是网上大佬的码——根据图片名称建立图片
            this.pictureBox1.Image = Properties.Resources.ResourceManager.GetObject("_9982459") as Image;
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
    }
}
