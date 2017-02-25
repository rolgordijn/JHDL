namespace JHDL
{
    partial class JHDL
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opslaanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opslaanAlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beheerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toevoegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem,
            this.beheerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1019, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opslaanToolStripMenuItem,
            this.opslaanAlsToolStripMenuItem});
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.bestandToolStripMenuItem.Text = "Bestand";
            // 
            // opslaanToolStripMenuItem
            // 
            this.opslaanToolStripMenuItem.Name = "opslaanToolStripMenuItem";
            this.opslaanToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.opslaanToolStripMenuItem.Text = "Opslaan";
            // 
            // opslaanAlsToolStripMenuItem
            // 
            this.opslaanAlsToolStripMenuItem.Name = "opslaanAlsToolStripMenuItem";
            this.opslaanAlsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.opslaanAlsToolStripMenuItem.Text = "Opslaan Als";
            // 
            // beheerToolStripMenuItem
            // 
            this.beheerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ledenToolStripMenuItem});
            this.beheerToolStripMenuItem.Name = "beheerToolStripMenuItem";
            this.beheerToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.beheerToolStripMenuItem.Text = "Beheer";
            // 
            // ledenToolStripMenuItem
            // 
            this.ledenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toevoegenToolStripMenuItem});
            this.ledenToolStripMenuItem.Name = "ledenToolStripMenuItem";
            this.ledenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ledenToolStripMenuItem.Text = "Leden";
            // 
            // toevoegenToolStripMenuItem
            // 
            this.toevoegenToolStripMenuItem.Name = "toevoegenToolStripMenuItem";
            this.toevoegenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.toevoegenToolStripMenuItem.Text = "Beheer leden";
            this.toevoegenToolStripMenuItem.Click += new System.EventHandler(this.toevoegenToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 502);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "JHDL ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opslaanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opslaanAlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beheerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toevoegenToolStripMenuItem;
    }
}

