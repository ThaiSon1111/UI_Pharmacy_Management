
namespace WindowsFormsApp_Pharmacy_Management.SMAPP_FunctionCommon
{
    partial class frm_Notification
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
            this.pic_Icon = new System.Windows.Forms.PictureBox();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.timer_Close = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Icon
            // 
            this.pic_Icon.Image = global::WindowsFormsApp_Pharmacy_Management.Properties.Resources.bell_117974;
            this.pic_Icon.Location = new System.Drawing.Point(5, 6);
            this.pic_Icon.Name = "pic_Icon";
            this.pic_Icon.Size = new System.Drawing.Size(73, 65);
            this.pic_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Icon.TabIndex = 0;
            this.pic_Icon.TabStop = false;
            this.pic_Icon.Click += new System.EventHandler(this.pic_Icon_Click);
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.ForeColor = System.Drawing.Color.White;
            this.lbl_Message.Location = new System.Drawing.Point(84, 23);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(51, 20);
            this.lbl_Message.TabIndex = 1;
            this.lbl_Message.Text = "label1";
            // 
            // timer_Close
            // 
            this.timer_Close.Interval = 10;
            // 
            // frm_Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(424, 73);
            this.Controls.Add(this.lbl_Message);
            this.Controls.Add(this.pic_Icon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Notification";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pic_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Icon;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Timer timer_Close;
    }
}