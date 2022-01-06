
namespace CookieClickerBot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._Start = new System.Windows.Forms.Button();
            this._StatusText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _Start
            // 
            this._Start.Location = new System.Drawing.Point(55, 42);
            this._Start.Name = "_Start";
            this._Start.Size = new System.Drawing.Size(125, 57);
            this._Start.TabIndex = 0;
            this._Start.Text = "Start (F6)";
            this._Start.UseVisualStyleBackColor = true;
            this._Start.Click += new System.EventHandler(this._Start_Click);
            // 
            // _StatusText
            // 
            this._StatusText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._StatusText.Cursor = System.Windows.Forms.Cursors.Default;
            this._StatusText.Location = new System.Drawing.Point(77, 15);
            this._StatusText.Multiline = false;
            this._StatusText.Name = "_StatusText";
            this._StatusText.ReadOnly = true;
            this._StatusText.Size = new System.Drawing.Size(80, 15);
            this._StatusText.TabIndex = 1;
            this._StatusText.Text = "Status: Stopped!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 111);
            this.Controls.Add(this._StatusText);
            this.Controls.Add(this._Start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Cookie Clicker Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing_1);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _Start;
        private System.Windows.Forms.RichTextBox _StatusText;
    }
}

