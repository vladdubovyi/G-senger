
namespace DesktopApp
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonShowMore = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBoxContacts = new System.Windows.Forms.ListBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonCloseMore = new System.Windows.Forms.Button();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBoxAva = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAva)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonShowMore);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.listBoxContacts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 627);
            this.panel1.TabIndex = 0;
            // 
            // buttonShowMore
            // 
            this.buttonShowMore.BackColor = System.Drawing.SystemColors.Control;
            this.buttonShowMore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonShowMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowMore.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonShowMore.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowMore.Image")));
            this.buttonShowMore.Location = new System.Drawing.Point(0, 0);
            this.buttonShowMore.Name = "buttonShowMore";
            this.buttonShowMore.Size = new System.Drawing.Size(56, 47);
            this.buttonShowMore.TabIndex = 3;
            this.buttonShowMore.UseVisualStyleBackColor = false;
            this.buttonShowMore.Click += new System.EventHandler(this.buttonShowMore_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(62, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(368, 29);
            this.textBox1.TabIndex = 2;
            // 
            // listBoxContacts
            // 
            this.listBoxContacts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxContacts.FormattingEnabled = true;
            this.listBoxContacts.ItemHeight = 15;
            this.listBoxContacts.Location = new System.Drawing.Point(0, 53);
            this.listBoxContacts.Name = "listBoxContacts";
            this.listBoxContacts.Size = new System.Drawing.Size(430, 574);
            this.listBoxContacts.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonCloseMore);
            this.panelMenu.Controls.Add(this.labelEmail);
            this.panelMenu.Controls.Add(this.labelName);
            this.panelMenu.Controls.Add(this.pictureBoxAva);
            this.panelMenu.Location = new System.Drawing.Point(479, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(430, 627);
            this.panelMenu.TabIndex = 1;
            this.panelMenu.Visible = false;
            // 
            // buttonCloseMore
            // 
            this.buttonCloseMore.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCloseMore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCloseMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseMore.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonCloseMore.Image = ((System.Drawing.Image)(resources.GetObject("buttonCloseMore.Image")));
            this.buttonCloseMore.Location = new System.Drawing.Point(0, 0);
            this.buttonCloseMore.Name = "buttonCloseMore";
            this.buttonCloseMore.Size = new System.Drawing.Size(56, 47);
            this.buttonCloseMore.TabIndex = 4;
            this.buttonCloseMore.UseVisualStyleBackColor = false;
            this.buttonCloseMore.Click += new System.EventHandler(this.buttonCloseMore_Click);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.Location = new System.Drawing.Point(176, 53);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(82, 20);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "labelEmail";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(175, 16);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(89, 20);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "labelName";
            // 
            // pictureBoxAva
            // 
            this.pictureBoxAva.Location = new System.Drawing.Point(69, 7);
            this.pictureBoxAva.Name = "pictureBoxAva";
            this.pictureBoxAva.Size = new System.Drawing.Size(100, 77);
            this.pictureBoxAva.TabIndex = 0;
            this.pictureBoxAva.TabStop = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 627);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAva)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBoxContacts;
        private System.Windows.Forms.Button buttonShowMore;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonCloseMore;
        private System.Windows.Forms.PictureBox pictureBoxAva;
    }
}