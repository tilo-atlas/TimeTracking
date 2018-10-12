namespace TimeTrackingUI_WinForms
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
            this.panelTimeAccounts = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttTimeAccountAdd = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblSessionStart = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSessionDuration = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerSession = new System.Windows.Forms.Timer(this.components);
            this.txtComment = new System.Windows.Forms.TextBox();
            this.bttAddComment = new System.Windows.Forms.Button();
            this.listComments = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTimeAccounts
            // 
            this.panelTimeAccounts.AutoScroll = true;
            this.panelTimeAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTimeAccounts.Location = new System.Drawing.Point(3, 19);
            this.panelTimeAccounts.Name = "panelTimeAccounts";
            this.panelTimeAccounts.Size = new System.Drawing.Size(521, 190);
            this.panelTimeAccounts.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panelTimeAccounts);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 212);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Accounts";
            // 
            // bttTimeAccountAdd
            // 
            this.bttTimeAccountAdd.Image = global::TimeTrackingUI_WinForms.Properties.Resources.add;
            this.bttTimeAccountAdd.Location = new System.Drawing.Point(120, 9);
            this.bttTimeAccountAdd.Name = "bttTimeAccountAdd";
            this.bttTimeAccountAdd.Size = new System.Drawing.Size(26, 23);
            this.bttTimeAccountAdd.TabIndex = 2;
            this.bttTimeAccountAdd.UseVisualStyleBackColor = true;
            this.bttTimeAccountAdd.Click += new System.EventHandler(this.bttTimeAccountAdd_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSessionStart,
            this.lblSessionDuration});
            this.statusStrip.Location = new System.Drawing.Point(0, 399);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(551, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblSessionStart
            // 
            this.lblSessionStart.Name = "lblSessionStart";
            this.lblSessionStart.Size = new System.Drawing.Size(0, 17);
            // 
            // lblSessionDuration
            // 
            this.lblSessionDuration.Name = "lblSessionDuration";
            this.lblSessionDuration.Size = new System.Drawing.Size(0, 17);
            // 
            // timerSession
            // 
            this.timerSession.Interval = 1000;
            this.timerSession.Tick += new System.EventHandler(this.timerSession_Tick);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(15, 233);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(486, 20);
            this.txtComment.TabIndex = 4;
            this.txtComment.Visible = false;
            this.txtComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtComment_KeyDown);
            // 
            // bttAddComment
            // 
            this.bttAddComment.Image = global::TimeTrackingUI_WinForms.Properties.Resources.add;
            this.bttAddComment.Location = new System.Drawing.Point(510, 233);
            this.bttAddComment.Name = "bttAddComment";
            this.bttAddComment.Size = new System.Drawing.Size(26, 23);
            this.bttAddComment.TabIndex = 5;
            this.bttAddComment.UseVisualStyleBackColor = true;
            this.bttAddComment.Visible = false;
            this.bttAddComment.Click += new System.EventHandler(this.bttAddComment_Click);
            // 
            // listComments
            // 
            this.listComments.FormattingEnabled = true;
            this.listComments.Location = new System.Drawing.Point(15, 264);
            this.listComments.Name = "listComments";
            this.listComments.Size = new System.Drawing.Size(521, 121);
            this.listComments.TabIndex = 6;
            this.listComments.Visible = false;
            this.listComments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listComments_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 421);
            this.Controls.Add(this.listComments);
            this.Controls.Add(this.bttAddComment);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.bttTimeAccountAdd);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Working Time Tracking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelTimeAccounts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttTimeAccountAdd;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Timer timerSession;
        private System.Windows.Forms.ToolStripStatusLabel lblSessionStart;
        private System.Windows.Forms.ToolStripStatusLabel lblSessionDuration;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button bttAddComment;
        private System.Windows.Forms.ListBox listComments;
    }
}

