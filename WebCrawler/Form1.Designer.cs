namespace WebCrawler
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Go_Button = new System.Windows.Forms.Button();
            this.Crawling_Button = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this._title = new System.Windows.Forms.Label();
            this.globalLinksList = new System.Windows.Forms.ListBox();
            this.new_linksOnPage = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this._totLinks = new System.Windows.Forms.Label();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Save_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 20);
            this.textBox1.TabIndex = 0;
            // 
            // Go_Button
            // 
            this.Go_Button.Location = new System.Drawing.Point(373, 45);
            this.Go_Button.Name = "Go_Button";
            this.Go_Button.Size = new System.Drawing.Size(29, 23);
            this.Go_Button.TabIndex = 1;
            this.Go_Button.Text = "Go";
            this.Go_Button.UseVisualStyleBackColor = true;
            this.Go_Button.Click += new System.EventHandler(this.Go_Button_Click);
            // 
            // Crawling_Button
            // 
            this.Crawling_Button.Location = new System.Drawing.Point(6, 357);
            this.Crawling_Button.Name = "Crawling_Button";
            this.Crawling_Button.Size = new System.Drawing.Size(246, 23);
            this.Crawling_Button.TabIndex = 2;
            this.Crawling_Button.Text = "Start Crawling";
            this.Crawling_Button.UseVisualStyleBackColor = true;
            this.Crawling_Button.Click += new System.EventHandler(this.Crawling_Button_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(246, 329);
            this.listBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "WebSite :";
            // 
            // _title
            // 
            this._title.AutoSize = true;
            this._title.Location = new System.Drawing.Point(408, 51);
            this._title.Name = "_title";
            this._title.Size = new System.Drawing.Size(0, 13);
            this._title.TabIndex = 6;
            // 
            // globalLinksList
            // 
            this.globalLinksList.FormattingEnabled = true;
            this.globalLinksList.HorizontalScrollbar = true;
            this.globalLinksList.Location = new System.Drawing.Point(6, 19);
            this.globalLinksList.Name = "globalLinksList";
            this.globalLinksList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.globalLinksList.Size = new System.Drawing.Size(246, 329);
            this.globalLinksList.TabIndex = 7;
            // 
            // new_linksOnPage
            // 
            this.new_linksOnPage.FormattingEnabled = true;
            this.new_linksOnPage.HorizontalScrollbar = true;
            this.new_linksOnPage.Location = new System.Drawing.Point(6, 19);
            this.new_linksOnPage.Name = "new_linksOnPage";
            this.new_linksOnPage.Size = new System.Drawing.Size(246, 329);
            this.new_linksOnPage.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Unique links :";
            // 
            // _totLinks
            // 
            this._totLinks.AutoSize = true;
            this._totLinks.Location = new System.Drawing.Point(446, 444);
            this._totLinks.Name = "_totLinks";
            this._totLinks.Size = new System.Drawing.Size(0, 13);
            this._totLinks.TabIndex = 10;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(11, 357);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(237, 23);
            this.Delete_Button.TabIndex = 11;
            this.Delete_Button.Text = "Delete";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.globalLinksList);
            this.groupBox1.Controls.Add(this.Delete_Button);
            this.groupBox1.Location = new System.Drawing.Point(14, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 386);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Links on Website";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.new_linksOnPage);
            this.groupBox2.Location = new System.Drawing.Point(288, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 355);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Links on Current Pages";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Controls.Add(this.Crawling_Button);
            this.groupBox3.Location = new System.Drawing.Point(564, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 386);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Found Links";
            // 
            // Save_Button
            // 
            this.Save_Button.Location = new System.Drawing.Point(747, 51);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(75, 23);
            this.Save_Button.TabIndex = 4;
            this.Save_Button.Text = "Save";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(312, 438);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.openToolStripMenuItem.Text = "Options";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 481);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._totLinks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Go_Button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Spider Search";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Go_Button;
        private System.Windows.Forms.Button Crawling_Button;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _title;
        private System.Windows.Forms.ListBox globalLinksList;
        private System.Windows.Forms.ListBox new_linksOnPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _totLinks;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

