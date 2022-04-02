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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ////序列化——对象->字符串 的过程
            ////转换成 skill 类型的数组
            ////ReadAllText：打开一个文本文件，读取所有行，然后关闭该文件
            //Skill[] skills= JsonConvert.DeserializeObject<Skill[]>(File.ReadAllText("temp.json"));
            //foreach (Skill s in skills)
            //{

            //}

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
            //using (StreamWriter str = new StreamWriter("E:\\Learn-More\\DIYSeekCardForm\\temp.txt"))
            //{
            //    str.Write("我在这里！");
            //}
            //MessageBox.Show("写入成功！");
            Form2 form = new Form2();
            this.Hide();
            form.Show();
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
    }
}
