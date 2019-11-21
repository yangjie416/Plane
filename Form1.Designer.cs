namespace 打字游戏
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "10000.png");
            this.imageList1.Images.SetKeyName(1, "10001.png");
            this.imageList1.Images.SetKeyName(2, "10002.png");
            this.imageList1.Images.SetKeyName(3, "10003.png");
            this.imageList1.Images.SetKeyName(4, "10004.png");
            this.imageList1.Images.SetKeyName(5, "10005.png");
            this.imageList1.Images.SetKeyName(6, "10006.png");
            this.imageList1.Images.SetKeyName(7, "10007.png");
            this.imageList1.Images.SetKeyName(8, "10008.png");
            this.imageList1.Images.SetKeyName(9, "10009.png");
            this.imageList1.Images.SetKeyName(10, "10010.png");
            this.imageList1.Images.SetKeyName(11, "10011.png");
            this.imageList1.Images.SetKeyName(12, "10012.png");
            this.imageList1.Images.SetKeyName(13, "10013.png");
            this.imageList1.Images.SetKeyName(14, "10014.png");
            this.imageList1.Images.SetKeyName(15, "10015.png");
            this.imageList1.Images.SetKeyName(16, "10016.png");
            this.imageList1.Images.SetKeyName(17, "10017.png");
            this.imageList1.Images.SetKeyName(18, "10018.png");
            this.imageList1.Images.SetKeyName(19, "10019.png");
            this.imageList1.Images.SetKeyName(20, "10020.png");
            this.imageList1.Images.SetKeyName(21, "10021.png");
            this.imageList1.Images.SetKeyName(22, "10022.png");
            this.imageList1.Images.SetKeyName(23, "10023.png");
            this.imageList1.Images.SetKeyName(24, "10024.png");
            this.imageList1.Images.SetKeyName(25, "10025.png");
            this.imageList1.Images.SetKeyName(26, "10026.png");
            this.imageList1.Images.SetKeyName(27, "10027.png");
            this.imageList1.Images.SetKeyName(28, "10028.png");
            this.imageList1.Images.SetKeyName(29, "10029.png");
            this.imageList1.Images.SetKeyName(30, "10030.png");
            this.imageList1.Images.SetKeyName(31, "10031.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "f1.png");
            this.imageList2.Images.SetKeyName(1, "f2.png");
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "飞机大战";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "飞机大战";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
    }
}

