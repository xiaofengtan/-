namespace PrintStroe
{
    partial class PaperManger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.paper = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.text_factor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_type = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.text_unitprice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.text_kg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.text_len = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_width = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.paper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // paper
            // 
            this.paper.Controls.Add(this.splitContainer1);
            this.paper.Location = new System.Drawing.Point(8, 39);
            this.paper.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.paper.Name = "paper";
            this.paper.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.paper.Size = new System.Drawing.Size(1806, 1158);
            this.paper.TabIndex = 0;
            this.paper.Text = "纸张管理";
            this.paper.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 5);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBox1);
            this.splitContainer1.Panel1.Controls.Add(this.text_factor);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.cbx_type);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.text_unitprice);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.text_kg);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.text_len);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.text_width);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1798, 1148);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1076, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 24);
            this.label7.TabIndex = 27;
            this.label7.Text = "纸张用于产品";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(908, 221);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 28);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "单价";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(1068, 67);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(494, 184);
            this.checkedListBox1.TabIndex = 25;
            // 
            // text_factor
            // 
            this.text_factor.Location = new System.Drawing.Point(172, 216);
            this.text_factor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.text_factor.Name = "text_factor";
            this.text_factor.Size = new System.Drawing.Size(306, 35);
            this.text_factor.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 226);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 23;
            this.label6.Text = "纸张品牌";
            // 
            // cbx_type
            // 
            this.cbx_type.FormattingEnabled = true;
            this.cbx_type.Items.AddRange(new object[] {
            "大规",
            "正规",
            "自定义"});
            this.cbx_type.Location = new System.Drawing.Point(172, 67);
            this.cbx_type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_type.Name = "cbx_type";
            this.cbx_type.Size = new System.Drawing.Size(306, 32);
            this.cbx_type.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(38, 78);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 24);
            this.label16.TabIndex = 21;
            this.label16.Text = "纸张类型";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 11F);
            this.button2.Location = new System.Drawing.Point(1620, 160);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 61);
            this.button2.TabIndex = 19;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // text_unitprice
            // 
            this.text_unitprice.Location = new System.Drawing.Point(666, 216);
            this.text_unitprice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.text_unitprice.Name = "text_unitprice";
            this.text_unitprice.Size = new System.Drawing.Size(229, 35);
            this.text_unitprice.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "纸张克重";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 11F);
            this.button1.Location = new System.Drawing.Point(1620, 59);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 61);
            this.button1.TabIndex = 0;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "纸张尺寸";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(540, 232);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 24);
            this.label9.TabIndex = 11;
            this.label9.Text = "销售单价";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "大规",
            "正规",
            "自定义"});
            this.comboBox1.Location = new System.Drawing.Point(666, 59);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(306, 32);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // text_kg
            // 
            this.text_kg.Location = new System.Drawing.Point(172, 139);
            this.text_kg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.text_kg.Name = "text_kg";
            this.text_kg.Size = new System.Drawing.Size(306, 35);
            this.text_kg.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "纸张规格";
            // 
            // text_len
            // 
            this.text_len.Location = new System.Drawing.Point(666, 142);
            this.text_len.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.text_len.Name = "text_len";
            this.text_len.Size = new System.Drawing.Size(127, 35);
            this.text_len.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(796, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "X";
            // 
            // text_width
            // 
            this.text_width.Location = new System.Drawing.Point(820, 142);
            this.text_width.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.text_width.Name = "text_width";
            this.text_width.Size = new System.Drawing.Size(151, 35);
            this.text_width.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1798, 836);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.paper);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1822, 1205);
            this.tabControl1.TabIndex = 0;
            // 
            // PaperManger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1822, 1205);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PaperManger";
            this.Text = "纸张管理";
            this.paper.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage paper;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox text_factor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_type;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox text_unitprice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox text_kg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_len;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox text_width;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;



    }
}