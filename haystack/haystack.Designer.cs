namespace haystack
{
    partial class haystack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(haystack));
            this.timerSearch = new System.Windows.Forms.Timer(this.components);
            this.buttonToggle = new System.Windows.Forms.Button();
            this.timerSecond = new System.Windows.Forms.Timer(this.components);
            this.labelRemain = new System.Windows.Forms.Label();
            this.labelLastSearchEngine = new System.Windows.Forms.Label();
            this.labelLastQuery = new System.Windows.Forms.Label();
            this.textBoxLastQuery = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupSearchEngines = new System.Windows.Forms.GroupBox();
            this.labelSelected = new System.Windows.Forms.Label();
            this.labelAvailable = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.listSelected = new System.Windows.Forms.ListBox();
            this.listAvailable = new System.Windows.Forms.ListBox();
            this.groupSearchEngines.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerSearch
            // 
            this.timerSearch.Tick += new System.EventHandler(this.timerSearch_Tick);
            // 
            // buttonToggle
            // 
            this.buttonToggle.Location = new System.Drawing.Point(12, 12);
            this.buttonToggle.Name = "buttonToggle";
            this.buttonToggle.Size = new System.Drawing.Size(199, 25);
            this.buttonToggle.TabIndex = 0;
            this.buttonToggle.Text = "Start Burying";
            this.buttonToggle.UseVisualStyleBackColor = true;
            this.buttonToggle.Click += new System.EventHandler(this.buttonToggle_Click);
            // 
            // timerSecond
            // 
            this.timerSecond.Interval = 1000;
            this.timerSecond.Tick += new System.EventHandler(this.timerSecond_Tick);
            // 
            // labelRemain
            // 
            this.labelRemain.AutoSize = true;
            this.labelRemain.Location = new System.Drawing.Point(12, 40);
            this.labelRemain.Name = "labelRemain";
            this.labelRemain.Size = new System.Drawing.Size(98, 13);
            this.labelRemain.TabIndex = 5;
            this.labelRemain.Text = "Next search in: Idle";
            // 
            // labelLastSearchEngine
            // 
            this.labelLastSearchEngine.AutoSize = true;
            this.labelLastSearchEngine.Location = new System.Drawing.Point(12, 53);
            this.labelLastSearchEngine.Name = "labelLastSearchEngine";
            this.labelLastSearchEngine.Size = new System.Drawing.Size(132, 13);
            this.labelLastSearchEngine.TabIndex = 6;
            this.labelLastSearchEngine.Text = "Last Search Engine: None";
            // 
            // labelLastQuery
            // 
            this.labelLastQuery.AutoSize = true;
            this.labelLastQuery.Location = new System.Drawing.Point(12, 72);
            this.labelLastQuery.Name = "labelLastQuery";
            this.labelLastQuery.Size = new System.Drawing.Size(61, 13);
            this.labelLastQuery.TabIndex = 7;
            this.labelLastQuery.Text = "Last Query:";
            // 
            // textBoxLastQuery
            // 
            this.textBoxLastQuery.Location = new System.Drawing.Point(12, 88);
            this.textBoxLastQuery.Multiline = true;
            this.textBoxLastQuery.Name = "textBoxLastQuery";
            this.textBoxLastQuery.Size = new System.Drawing.Size(199, 111);
            this.textBoxLastQuery.TabIndex = 8;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "haystack : left = restore / right = exit";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // groupSearchEngines
            // 
            this.groupSearchEngines.Controls.Add(this.labelSelected);
            this.groupSearchEngines.Controls.Add(this.labelAvailable);
            this.groupSearchEngines.Controls.Add(this.buttonAdd);
            this.groupSearchEngines.Controls.Add(this.buttonRemove);
            this.groupSearchEngines.Controls.Add(this.listSelected);
            this.groupSearchEngines.Controls.Add(this.listAvailable);
            this.groupSearchEngines.Location = new System.Drawing.Point(217, 12);
            this.groupSearchEngines.Name = "groupSearchEngines";
            this.groupSearchEngines.Size = new System.Drawing.Size(264, 187);
            this.groupSearchEngines.TabIndex = 13;
            this.groupSearchEngines.TabStop = false;
            this.groupSearchEngines.Text = "Search Engines To Use";
            // 
            // labelSelected
            // 
            this.labelSelected.AutoSize = true;
            this.labelSelected.Location = new System.Drawing.Point(157, 16);
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new System.Drawing.Size(49, 13);
            this.labelSelected.TabIndex = 18;
            this.labelSelected.Text = "Selected";
            // 
            // labelAvailable
            // 
            this.labelAvailable.AutoSize = true;
            this.labelAvailable.Location = new System.Drawing.Point(3, 16);
            this.labelAvailable.Name = "labelAvailable";
            this.labelAvailable.Size = new System.Drawing.Size(50, 13);
            this.labelAvailable.TabIndex = 17;
            this.labelAvailable.Text = "Available";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(110, 50);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(44, 20);
            this.buttonAdd.TabIndex = 15;
            this.buttonAdd.Text = "-->";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(110, 76);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(44, 20);
            this.buttonRemove.TabIndex = 16;
            this.buttonRemove.Text = "<--";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // listSelected
            // 
            this.listSelected.FormattingEnabled = true;
            this.listSelected.Location = new System.Drawing.Point(160, 32);
            this.listSelected.Name = "listSelected";
            this.listSelected.Size = new System.Drawing.Size(98, 147);
            this.listSelected.Sorted = true;
            this.listSelected.TabIndex = 14;
            this.listSelected.DoubleClick += new System.EventHandler(this.listSelected_DoubleClick);
            // 
            // listAvailable
            // 
            this.listAvailable.FormattingEnabled = true;
            this.listAvailable.Location = new System.Drawing.Point(6, 32);
            this.listAvailable.Name = "listAvailable";
            this.listAvailable.Size = new System.Drawing.Size(98, 147);
            this.listAvailable.Sorted = true;
            this.listAvailable.TabIndex = 13;
            this.listAvailable.DoubleClick += new System.EventHandler(this.listAvailable_DoubleClick);
            // 
            // haystack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 208);
            this.Controls.Add(this.groupSearchEngines);
            this.Controls.Add(this.textBoxLastQuery);
            this.Controls.Add(this.labelLastQuery);
            this.Controls.Add(this.labelLastSearchEngine);
            this.Controls.Add(this.labelRemain);
            this.Controls.Add(this.buttonToggle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "haystack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "haystack";
            this.Load += new System.EventHandler(this.haystack_Load);
            this.Resize += new System.EventHandler(this.haystack_Resize);
            this.groupSearchEngines.ResumeLayout(false);
            this.groupSearchEngines.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerSearch;
        private System.Windows.Forms.Button buttonToggle;
        private System.Windows.Forms.Timer timerSecond;
        private System.Windows.Forms.Label labelRemain;
        private System.Windows.Forms.Label labelLastSearchEngine;
        private System.Windows.Forms.Label labelLastQuery;
        private System.Windows.Forms.TextBox textBoxLastQuery;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox groupSearchEngines;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListBox listSelected;
        private System.Windows.Forms.ListBox listAvailable;
        private System.Windows.Forms.Label labelSelected;
        private System.Windows.Forms.Label labelAvailable;
    }
}

