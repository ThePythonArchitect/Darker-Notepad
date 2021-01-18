namespace DarkerNotepad
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mainStripMenu = new System.Windows.Forms.MenuStrip();
            this.fileStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sanSerifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segoeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timesNewRomanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thirteenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fifteenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.mainStripMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.mainStripMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(892, 554);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // mainStripMenu
            // 
            this.mainStripMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStripMenu,
            this.fontToolStripMenuItem,
            this.themeStripMenu});
            this.mainStripMenu.Location = new System.Drawing.Point(0, 0);
            this.mainStripMenu.Name = "mainStripMenu";
            this.mainStripMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainStripMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainStripMenu.Size = new System.Drawing.Size(892, 24);
            this.mainStripMenu.TabIndex = 1;
            this.mainStripMenu.Text = "menuStrip1";
            // 
            // fileStripMenu
            // 
            this.fileStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.autoSaveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileStripMenu.Name = "fileStripMenu";
            this.fileStripMenu.Size = new System.Drawing.Size(37, 20);
            this.fileStripMenu.Text = "File";
            this.fileStripMenu.Click += new System.EventHandler(this.fileStripMenu_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // autoSaveToolStripMenuItem
            // 
            this.autoSaveToolStripMenuItem.Name = "autoSaveToolStripMenuItem";
            this.autoSaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autoSaveToolStripMenuItem.Text = "Auto Save •";
            this.autoSaveToolStripMenuItem.Click += new System.EventHandler(this.autoSaveToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.styleToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.wordWrapToolStripMenuItem});
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arialToolStripMenuItem,
            this.calibriToolStripMenuItem,
            this.consolaToolStripMenuItem,
            this.sanSerifToolStripMenuItem,
            this.segoeToolStripMenuItem,
            this.timesNewRomanToolStripMenuItem});
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.styleToolStripMenuItem.Text = "Style";
            this.styleToolStripMenuItem.Click += new System.EventHandler(this.styleToolStripMenuItem_Click);
            // 
            // arialToolStripMenuItem
            // 
            this.arialToolStripMenuItem.Name = "arialToolStripMenuItem";
            this.arialToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.arialToolStripMenuItem.Text = "Arial";
            this.arialToolStripMenuItem.Click += new System.EventHandler(this.arialToolStripMenuItem_Click);
            // 
            // calibriToolStripMenuItem
            // 
            this.calibriToolStripMenuItem.Name = "calibriToolStripMenuItem";
            this.calibriToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.calibriToolStripMenuItem.Text = "Calibri";
            this.calibriToolStripMenuItem.Click += new System.EventHandler(this.calibriToolStripMenuItem_Click);
            // 
            // consolaToolStripMenuItem
            // 
            this.consolaToolStripMenuItem.Name = "consolaToolStripMenuItem";
            this.consolaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.consolaToolStripMenuItem.Text = "Consolas •";
            this.consolaToolStripMenuItem.Click += new System.EventHandler(this.consolaToolStripMenuItem_Click);
            // 
            // sanSerifToolStripMenuItem
            // 
            this.sanSerifToolStripMenuItem.Name = "sanSerifToolStripMenuItem";
            this.sanSerifToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.sanSerifToolStripMenuItem.Text = "San Serif";
            this.sanSerifToolStripMenuItem.Click += new System.EventHandler(this.sanSerifToolStripMenuItem_Click);
            // 
            // segoeToolStripMenuItem
            // 
            this.segoeToolStripMenuItem.Name = "segoeToolStripMenuItem";
            this.segoeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.segoeToolStripMenuItem.Text = "Segoe";
            this.segoeToolStripMenuItem.Click += new System.EventHandler(this.segoeToolStripMenuItem_Click);
            // 
            // timesNewRomanToolStripMenuItem
            // 
            this.timesNewRomanToolStripMenuItem.Name = "timesNewRomanToolStripMenuItem";
            this.timesNewRomanToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.timesNewRomanToolStripMenuItem.Text = "Times New Roman";
            this.timesNewRomanToolStripMenuItem.Click += new System.EventHandler(this.timesNewRomanToolStripMenuItem_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nineToolStripMenuItem,
            this.elevenToolStripMenuItem,
            this.thirteenToolStripMenuItem,
            this.fifteenToolStripMenuItem});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.sizeToolStripMenuItem.Text = "Size";
            this.sizeToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // nineToolStripMenuItem
            // 
            this.nineToolStripMenuItem.Name = "nineToolStripMenuItem";
            this.nineToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.nineToolStripMenuItem.Text = "9";
            this.nineToolStripMenuItem.Click += new System.EventHandler(this.nineToolStripMenuItem_Click);
            // 
            // elevenToolStripMenuItem
            // 
            this.elevenToolStripMenuItem.Name = "elevenToolStripMenuItem";
            this.elevenToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.elevenToolStripMenuItem.Text = "11 •";
            this.elevenToolStripMenuItem.Click += new System.EventHandler(this.elevenToolStripMenuItem_Click);
            // 
            // thirteenToolStripMenuItem
            // 
            this.thirteenToolStripMenuItem.Name = "thirteenToolStripMenuItem";
            this.thirteenToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.thirteenToolStripMenuItem.Text = "13";
            this.thirteenToolStripMenuItem.Click += new System.EventHandler(this.thirteenToolStripMenuItem_Click);
            // 
            // fifteenToolStripMenuItem
            // 
            this.fifteenToolStripMenuItem.Name = "fifteenToolStripMenuItem";
            this.fifteenToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.fifteenToolStripMenuItem.Text = "15";
            this.fifteenToolStripMenuItem.Click += new System.EventHandler(this.fifteenToolStripMenuItem_Click);
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.wordWrapToolStripMenuItem.Text = "Word Wrap •";
            this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // themeStripMenu
            // 
            this.themeStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkModeToolStripMenuItem,
            this.lightModeToolStripMenuItem});
            this.themeStripMenu.Name = "themeStripMenu";
            this.themeStripMenu.Size = new System.Drawing.Size(55, 20);
            this.themeStripMenu.Text = "Theme";
            this.themeStripMenu.Click += new System.EventHandler(this.themeStripMenu_Click);
            // 
            // darkModeToolStripMenuItem
            // 
            this.darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            this.darkModeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.darkModeToolStripMenuItem.Text = "Dark Mode";
            this.darkModeToolStripMenuItem.Click += new System.EventHandler(this.darkModeToolStripMenuItem_Click);
            // 
            // lightModeToolStripMenuItem
            // 
            this.lightModeToolStripMenuItem.Name = "lightModeToolStripMenuItem";
            this.lightModeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.lightModeToolStripMenuItem.Text = "Light Mode";
            this.lightModeToolStripMenuItem.Click += new System.EventHandler(this.lightModeToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.mainTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 530);
            this.panel1.TabIndex = 2;
            // 
            // mainTextBox
            // 
            this.mainTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainTextBox.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mainTextBox.Location = new System.Drawing.Point(0, 0);
            this.mainTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.mainTextBox.MaxLength = 65535;
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainTextBox.Size = new System.Drawing.Size(910, 530);
            this.mainTextBox.TabIndex = 3;
            this.mainTextBox.TabStop = false;
            this.mainTextBox.Click += new System.EventHandler(this.mainTextBox_Click);
            this.mainTextBox.TextChanged += new System.EventHandler(this.mainTextBox_TextChanged);
            this.mainTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainTextBox_KeyDown);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(892, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Darker Notepad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.mainStripMenu.ResumeLayout(false);
            this.mainStripMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip mainStripMenu;
        private System.Windows.Forms.ToolStripMenuItem fileStripMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeStripMenu;
        private System.Windows.Forms.ToolStripMenuItem darkModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sanSerifToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segoeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timesNewRomanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elevenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thirteenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fifteenToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox mainTextBox;
    }
}

