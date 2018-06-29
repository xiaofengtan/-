namespace OrderInput
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tssb02 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.入库修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出库修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.初始库存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.AutoSize = false;
            this.toolbar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolbar.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolbar.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolbar.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton2,
            this.toolStripSeparator6,
            this.tssb02,
            this.toolStripSeparator4,
            this.toolStripButton1,
            this.toolStripSeparator2});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolbar.Size = new System.Drawing.Size(149, 736);
            this.toolbar.Stretch = true;
            this.toolbar.TabIndex = 1;
            this.toolbar.Text = "toolStrip1";
            this.toolbar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolbar_ItemClicked);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(147, 0);
            this.toolStripLabel1.Text = "toolStripLabel1";
            this.toolStripLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton2.Image = global::OrderInput.Properties.Resources.b3;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(148, 80);
            this.toolStripButton2.Text = "自接业务";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(147, 6);
            // 
            // tssb02
            // 
            this.tssb02.AutoSize = false;
            this.tssb02.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tssb02.Image = global::OrderInput.Properties.Resources.b4;
            this.tssb02.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tssb02.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssb02.Name = "tssb02";
            this.tssb02.Size = new System.Drawing.Size(148, 80);
            this.tssb02.Text = "业务部订单";
            this.tssb02.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tssb02.ToolTipText = "批量入库";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(147, 6);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1.Image = global::OrderInput.Properties.Resources.b2;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(148, 80);
            this.toolStripButton1.Text = "纸张管理";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // 入库修改ToolStripMenuItem
            // 
            this.入库修改ToolStripMenuItem.Name = "入库修改ToolStripMenuItem";
            this.入库修改ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 出库修改ToolStripMenuItem
            // 
            this.出库修改ToolStripMenuItem.Name = "出库修改ToolStripMenuItem";
            this.出库修改ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 修改订单ToolStripMenuItem
            // 
            this.修改订单ToolStripMenuItem.Name = "修改订单ToolStripMenuItem";
            this.修改订单ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 初始库存ToolStripMenuItem
            // 
            this.初始库存ToolStripMenuItem.Name = "初始库存ToolStripMenuItem";
            this.初始库存ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(149, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 736);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 736);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolbar);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "浙江嘉报印刷设计有限公司订单录入系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tssb02;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem 入库修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出库修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 初始库存ToolStripMenuItem;
    }
}

