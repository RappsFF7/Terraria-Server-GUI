namespace TerrariaServerGUI
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
            this.toolStrip_Footer = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_StatusIcon = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_StatusText = new System.Windows.Forms.ToolStripLabel();
            this.toolStripProgressBar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip_Header = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_File = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.button_StartServer = new System.Windows.Forms.Button();
            this.richTextBox_Console = new System.Windows.Forms.RichTextBox();
            this.toolStrip_Footer.SuspendLayout();
            this.toolStrip_Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_Footer
            // 
            this.toolStrip_Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_Footer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_StatusIcon,
            this.toolStripLabel_StatusText,
            this.toolStripProgressBar_Main});
            this.toolStrip_Footer.Location = new System.Drawing.Point(0, 278);
            this.toolStrip_Footer.Name = "toolStrip_Footer";
            this.toolStrip_Footer.Size = new System.Drawing.Size(408, 25);
            this.toolStrip_Footer.TabIndex = 0;
            this.toolStrip_Footer.Text = "toolStrip_Footer";
            // 
            // toolStripButton_StatusIcon
            // 
            this.toolStripButton_StatusIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_StatusIcon.Image = global::TerrariaServerCS.Properties.Resources.Bunny;
            this.toolStripButton_StatusIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_StatusIcon.Name = "toolStripButton_StatusIcon";
            this.toolStripButton_StatusIcon.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_StatusIcon.Text = "toolStripButton1";
            // 
            // toolStripLabel_StatusText
            // 
            this.toolStripLabel_StatusText.Name = "toolStripLabel_StatusText";
            this.toolStripLabel_StatusText.Size = new System.Drawing.Size(139, 22);
            this.toolStripLabel_StatusText.Text = "toolStripLabel_StatusText";
            // 
            // toolStripProgressBar_Main
            // 
            this.toolStripProgressBar_Main.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar_Main.Name = "toolStripProgressBar_Main";
            this.toolStripProgressBar_Main.Size = new System.Drawing.Size(100, 22);
            this.toolStripProgressBar_Main.Visible = false;
            // 
            // toolStrip_Header
            // 
            this.toolStrip_Header.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_File});
            this.toolStrip_Header.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Header.Name = "toolStrip_Header";
            this.toolStrip_Header.Size = new System.Drawing.Size(408, 25);
            this.toolStrip_Header.TabIndex = 1;
            this.toolStrip_Header.Text = "toolStrip_Header";
            // 
            // toolStripDropDownButton_File
            // 
            this.toolStripDropDownButton_File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Exit});
            this.toolStripDropDownButton_File.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_File.Image")));
            this.toolStripDropDownButton_File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_File.Name = "toolStripDropDownButton_File";
            this.toolStripDropDownButton_File.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton_File.Text = "File";
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem_Exit.Text = "Exit";
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.toolStripMenuItem_Exit_Click);
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 25);
            this.splitContainer_Main.Name = "splitContainer_Main";
            this.splitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.button_StartServer);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.richTextBox_Console);
            this.splitContainer_Main.Size = new System.Drawing.Size(408, 253);
            this.splitContainer_Main.SplitterDistance = 122;
            this.splitContainer_Main.TabIndex = 2;
            // 
            // button_StartServer
            // 
            this.button_StartServer.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_StartServer.Location = new System.Drawing.Point(167, 97);
            this.button_StartServer.Name = "button_StartServer";
            this.button_StartServer.Size = new System.Drawing.Size(75, 22);
            this.button_StartServer.TabIndex = 0;
            this.button_StartServer.Text = "Start Server";
            this.button_StartServer.UseVisualStyleBackColor = true;
            this.button_StartServer.Click += new System.EventHandler(this.button_StartServer_Click);
            // 
            // richTextBox_Console
            // 
            this.richTextBox_Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Console.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_Console.Name = "richTextBox_Console";
            this.richTextBox_Console.Size = new System.Drawing.Size(408, 127);
            this.richTextBox_Console.TabIndex = 0;
            this.richTextBox_Console.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 303);
            this.Controls.Add(this.splitContainer_Main);
            this.Controls.Add(this.toolStrip_Header);
            this.Controls.Add(this.toolStrip_Footer);
            this.Name = "MainForm";
            this.Text = "Terraria Server GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip_Footer.ResumeLayout(false);
            this.toolStrip_Footer.PerformLayout();
            this.toolStrip_Header.ResumeLayout(false);
            this.toolStrip_Header.PerformLayout();
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_Footer;
        private System.Windows.Forms.ToolStrip toolStrip_Header;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.ToolStripButton toolStripButton_StatusIcon;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_StatusText;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_Main;
        private System.Windows.Forms.Button button_StartServer;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
        private System.Windows.Forms.RichTextBox richTextBox_Console;
    }
}

