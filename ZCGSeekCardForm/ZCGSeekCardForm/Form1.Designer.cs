namespace ZCGSeekCardForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.setCodeComboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cardTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AttComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.raceComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LtextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RtextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.attackTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.defenseTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.setCodeComboBox2 = new System.Windows.Forms.ComboBox();
            this.setCodeComboBox3 = new System.Windows.Forms.ComboBox();
            this.setCodeComboBox4 = new System.Windows.Forms.ComboBox();
            this.menuListBox = new System.Windows.Forms.ListBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.levelComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "字段";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(196, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "搜索卡片";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // setCodeComboBox1
            // 
            this.setCodeComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setCodeComboBox1.FormattingEnabled = true;
            this.setCodeComboBox1.Items.AddRange(new object[] {
            "(N/A) 系列"});
            this.setCodeComboBox1.Location = new System.Drawing.Point(470, 77);
            this.setCodeComboBox1.Name = "setCodeComboBox1";
            this.setCodeComboBox1.Size = new System.Drawing.Size(121, 22);
            this.setCodeComboBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "种类";
            // 
            // cardTypeComboBox
            // 
            this.cardTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardTypeComboBox.FormattingEnabled = true;
            this.cardTypeComboBox.Items.AddRange(new object[] {
            "(N/A) 种类",
            "怪兽",
            "魔法",
            "陷阱"});
            this.cardTypeComboBox.Location = new System.Drawing.Point(470, 202);
            this.cardTypeComboBox.Name = "cardTypeComboBox";
            this.cardTypeComboBox.Size = new System.Drawing.Size(121, 22);
            this.cardTypeComboBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(608, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 14);
            this.label4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(636, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "星级";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(636, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "属性";
            // 
            // AttComboBox
            // 
            this.AttComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AttComboBox.FormattingEnabled = true;
            this.AttComboBox.Items.AddRange(new object[] {
            "(N/A) 属性",
            "地",
            "水",
            "炎",
            "风",
            "光",
            "暗",
            "神",
            "冥"});
            this.AttComboBox.Location = new System.Drawing.Point(677, 160);
            this.AttComboBox.Name = "AttComboBox";
            this.AttComboBox.Size = new System.Drawing.Size(121, 22);
            this.AttComboBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(636, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "种族";
            // 
            // raceComboBox
            // 
            this.raceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.raceComboBox.FormattingEnabled = true;
            this.raceComboBox.Items.AddRange(new object[] {
            "(N/A) 种族",
            "战士族",
            "魔法师族",
            "天使族",
            "恶魔族",
            "不死族",
            "机械族",
            "水族",
            "炎族",
            "岩石族",
            "鸟兽族",
            "植物族",
            "昆虫族",
            "雷族",
            "龙族",
            "兽族",
            "兽战士族",
            "恐龙族",
            "鱼族",
            "海龙族",
            "爬虫类族",
            "念动力族",
            "幻神兽族",
            "创造神族"});
            this.raceComboBox.Location = new System.Drawing.Point(677, 202);
            this.raceComboBox.Name = "raceComboBox";
            this.raceComboBox.Size = new System.Drawing.Size(121, 22);
            this.raceComboBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(636, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "灵摆刻度";
            // 
            // LtextBox
            // 
            this.LtextBox.Location = new System.Drawing.Point(705, 115);
            this.LtextBox.Name = "LtextBox";
            this.LtextBox.Size = new System.Drawing.Size(23, 23);
            this.LtextBox.TabIndex = 17;
            this.LtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LtextBox_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 11.78182F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(734, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "/";
            // 
            // RtextBox
            // 
            this.RtextBox.Location = new System.Drawing.Point(759, 115);
            this.RtextBox.Name = "RtextBox";
            this.RtextBox.Size = new System.Drawing.Size(23, 23);
            this.RtextBox.TabIndex = 19;
            this.RtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtextBox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(622, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 20;
            this.label10.Text = "攻击力";
            // 
            // attackTextBox
            // 
            this.attackTextBox.Location = new System.Drawing.Point(677, 241);
            this.attackTextBox.Name = "attackTextBox";
            this.attackTextBox.Size = new System.Drawing.Size(121, 23);
            this.attackTextBox.TabIndex = 21;
            this.attackTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.attackTextBox_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(622, 284);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 14);
            this.label11.TabIndex = 22;
            this.label11.Text = "守备力";
            // 
            // defenseTextBox
            // 
            this.defenseTextBox.Location = new System.Drawing.Point(677, 281);
            this.defenseTextBox.Name = "defenseTextBox";
            this.defenseTextBox.Size = new System.Drawing.Size(121, 23);
            this.defenseTextBox.TabIndex = 23;
            this.defenseTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.defenseTextBox_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox17);
            this.groupBox1.Controls.Add(this.checkBox16);
            this.groupBox1.Controls.Add(this.checkBox12);
            this.groupBox1.Controls.Add(this.checkBox13);
            this.groupBox1.Controls.Add(this.checkBox14);
            this.groupBox1.Controls.Add(this.checkBox15);
            this.groupBox1.Controls.Add(this.checkBox11);
            this.groupBox1.Controls.Add(this.checkBox10);
            this.groupBox1.Controls.Add(this.checkBox9);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(337, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 193);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "卡类";
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(21, 169);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(54, 18);
            this.checkBox17.TabIndex = 36;
            this.checkBox17.Text = "反击";
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(200, 92);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(68, 18);
            this.checkBox16.TabIndex = 35;
            this.checkBox16.Text = "衍生物";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(200, 134);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(54, 18);
            this.checkBox12.TabIndex = 34;
            this.checkBox12.Text = "装备";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(141, 134);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(54, 18);
            this.checkBox13.TabIndex = 33;
            this.checkBox13.Text = "永续";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(81, 134);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(54, 18);
            this.checkBox14.TabIndex = 32;
            this.checkBox14.Text = "速攻";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(21, 134);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(54, 18);
            this.checkBox15.TabIndex = 31;
            this.checkBox15.Text = "场地";
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(141, 92);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(54, 18);
            this.checkBox11.TabIndex = 30;
            this.checkBox11.Text = "仪式";
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.checkBox11_CheckedChanged);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(81, 92);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(54, 18);
            this.checkBox10.TabIndex = 29;
            this.checkBox10.Text = "二重";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(21, 92);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(54, 18);
            this.checkBox9.TabIndex = 28;
            this.checkBox9.Text = "同盟";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(200, 58);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(54, 18);
            this.checkBox8.TabIndex = 27;
            this.checkBox8.Text = "调整";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(141, 58);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(54, 18);
            this.checkBox7.TabIndex = 26;
            this.checkBox7.Text = "卡通";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(81, 58);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(54, 18);
            this.checkBox6.TabIndex = 25;
            this.checkBox6.Text = "反转";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(21, 58);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(54, 18);
            this.checkBox5.TabIndex = 24;
            this.checkBox5.Text = "通常";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(200, 23);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(54, 18);
            this.checkBox4.TabIndex = 23;
            this.checkBox4.Text = "效果";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(141, 23);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(54, 18);
            this.checkBox3.TabIndex = 22;
            this.checkBox3.Text = "灵摆";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(81, 23);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(54, 18);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.Text = "超量";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(21, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 18);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "同调";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // setCodeComboBox2
            // 
            this.setCodeComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setCodeComboBox2.FormattingEnabled = true;
            this.setCodeComboBox2.Items.AddRange(new object[] {
            "(N/A) 系列"});
            this.setCodeComboBox2.Location = new System.Drawing.Point(470, 107);
            this.setCodeComboBox2.Name = "setCodeComboBox2";
            this.setCodeComboBox2.Size = new System.Drawing.Size(121, 22);
            this.setCodeComboBox2.TabIndex = 25;
            // 
            // setCodeComboBox3
            // 
            this.setCodeComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setCodeComboBox3.FormattingEnabled = true;
            this.setCodeComboBox3.Items.AddRange(new object[] {
            "(N/A) 系列"});
            this.setCodeComboBox3.Location = new System.Drawing.Point(470, 135);
            this.setCodeComboBox3.Name = "setCodeComboBox3";
            this.setCodeComboBox3.Size = new System.Drawing.Size(121, 22);
            this.setCodeComboBox3.TabIndex = 26;
            // 
            // setCodeComboBox4
            // 
            this.setCodeComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setCodeComboBox4.FormattingEnabled = true;
            this.setCodeComboBox4.Items.AddRange(new object[] {
            "(N/A) 系列"});
            this.setCodeComboBox4.Location = new System.Drawing.Point(470, 163);
            this.setCodeComboBox4.Name = "setCodeComboBox4";
            this.setCodeComboBox4.Size = new System.Drawing.Size(121, 22);
            this.setCodeComboBox4.TabIndex = 27;
            // 
            // menuListBox
            // 
            this.menuListBox.FormattingEnabled = true;
            this.menuListBox.ItemHeight = 14;
            this.menuListBox.Location = new System.Drawing.Point(30, 77);
            this.menuListBox.Name = "menuListBox";
            this.menuListBox.Size = new System.Drawing.Size(159, 354);
            this.menuListBox.TabIndex = 33;
            this.menuListBox.SelectedIndexChanged += new System.EventHandler(this.menuListBox_SelectedIndexChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(200, 173);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(126, 181);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 34;
            this.pictureBox.TabStop = false;
            // 
            // levelComboBox
            // 
            this.levelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelComboBox.FormattingEnabled = true;
            this.levelComboBox.Items.AddRange(new object[] {
            "(N/A) 星级",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.levelComboBox.Location = new System.Drawing.Point(677, 77);
            this.levelComboBox.Name = "levelComboBox";
            this.levelComboBox.Size = new System.Drawing.Size(121, 22);
            this.levelComboBox.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 452);
            this.Controls.Add(this.levelComboBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuListBox);
            this.Controls.Add(this.setCodeComboBox4);
            this.Controls.Add(this.setCodeComboBox3);
            this.Controls.Add(this.setCodeComboBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.defenseTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.attackTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.RtextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LtextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.raceComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AttComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cardTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.setCodeComboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = " ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox setCodeComboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cardTypeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox AttComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox raceComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox LtextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox RtextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox attackTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox defenseTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.ComboBox setCodeComboBox2;
        private System.Windows.Forms.ComboBox setCodeComboBox3;
        private System.Windows.Forms.ComboBox setCodeComboBox4;
        private System.Windows.Forms.ListBox menuListBox;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox levelComboBox;
    }
}

