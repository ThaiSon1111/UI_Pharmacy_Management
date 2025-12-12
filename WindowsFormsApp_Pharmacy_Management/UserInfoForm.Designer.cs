
namespace WindowsFormsApp_Pharmacy_Management
{
    partial class UserInfoForm
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
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchUserId = new System.Windows.Forms.TextBox();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.txtIdPwdDetail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIdOrgDetail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIdNoDetail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsernameDetail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhoneDetail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmailDetail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserIdDetail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.txtIdDtDetail = new System.Windows.Forms.DateTimePicker();
            this.gbSearch.SuspendLayout();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearch.Controls.Add(this.btnReload);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.txtSearchPhone);
            this.gbSearch.Controls.Add(this.label3);
            this.gbSearch.Controls.Add(this.txtSearchEmail);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.txtSearchUserId);
            this.gbSearch.Location = new System.Drawing.Point(34, 19);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1782, 72);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Điều kiện tra cứu";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(936, 22);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(115, 29);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(815, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 29);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Tra cứu";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchPhone
            // 
            this.txtSearchPhone.Location = new System.Drawing.Point(602, 22);
            this.txtSearchPhone.Name = "txtSearchPhone";
            this.txtSearchPhone.Size = new System.Drawing.Size(170, 26);
            this.txtSearchPhone.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "SĐT";
            // 
            // txtSearchEmail
            // 
            this.txtSearchEmail.Location = new System.Drawing.Point(362, 25);
            this.txtSearchEmail.Name = "txtSearchEmail";
            this.txtSearchEmail.Size = new System.Drawing.Size(157, 26);
            this.txtSearchEmail.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tài khoản";
            // 
            // txtSearchUserId
            // 
            this.txtSearchUserId.Location = new System.Drawing.Point(117, 25);
            this.txtSearchUserId.Name = "txtSearchUserId";
            this.txtSearchUserId.Size = new System.Drawing.Size(157, 26);
            this.txtSearchUserId.TabIndex = 0;
            // 
            // gbDetails
            // 
            this.gbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetails.Controls.Add(this.txtIdDtDetail);
            this.gbDetails.Controls.Add(this.btnSave);
            this.gbDetails.Controls.Add(this.btnEdit);
            this.gbDetails.Controls.Add(this.btnDelete);
            this.gbDetails.Controls.Add(this.btnAddNew);
            this.gbDetails.Controls.Add(this.txtIdPwdDetail);
            this.gbDetails.Controls.Add(this.label11);
            this.gbDetails.Controls.Add(this.txtIdOrgDetail);
            this.gbDetails.Controls.Add(this.label10);
            this.gbDetails.Controls.Add(this.label9);
            this.gbDetails.Controls.Add(this.txtIdNoDetail);
            this.gbDetails.Controls.Add(this.label8);
            this.gbDetails.Controls.Add(this.txtUsernameDetail);
            this.gbDetails.Controls.Add(this.label7);
            this.gbDetails.Controls.Add(this.txtPhoneDetail);
            this.gbDetails.Controls.Add(this.label6);
            this.gbDetails.Controls.Add(this.txtEmailDetail);
            this.gbDetails.Controls.Add(this.label5);
            this.gbDetails.Controls.Add(this.txtUserIdDetail);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Location = new System.Drawing.Point(34, 97);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(1782, 168);
            this.gbDetails.TabIndex = 1;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Thông tin chi tiết";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(397, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 30);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(155, 121);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 31);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(281, 121);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 31);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(37, 121);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(100, 31);
            this.btnAddNew.TabIndex = 16;
            this.btnAddNew.Text = "Thêm mới";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIdPwdDetail
            // 
            this.txtIdPwdDetail.Location = new System.Drawing.Point(362, 24);
            this.txtIdPwdDetail.Name = "txtIdPwdDetail";
            this.txtIdPwdDetail.Size = new System.Drawing.Size(152, 26);
            this.txtIdPwdDetail.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(277, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Mật khẩu";
            // 
            // txtIdOrgDetail
            // 
            this.txtIdOrgDetail.Location = new System.Drawing.Point(878, 66);
            this.txtIdOrgDetail.Name = "txtIdOrgDetail";
            this.txtIdOrgDetail.Size = new System.Drawing.Size(170, 26);
            this.txtIdOrgDetail.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(797, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Nơi cấp";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(534, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Ngày cấp";
            // 
            // txtIdNoDetail
            // 
            this.txtIdNoDetail.Location = new System.Drawing.Point(362, 70);
            this.txtIdNoDetail.Name = "txtIdNoDetail";
            this.txtIdNoDetail.Size = new System.Drawing.Size(152, 26);
            this.txtIdNoDetail.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(294, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "CCCD";
            // 
            // txtUsernameDetail
            // 
            this.txtUsernameDetail.Location = new System.Drawing.Point(117, 70);
            this.txtUsernameDetail.Name = "txtUsernameDetail";
            this.txtUsernameDetail.Size = new System.Drawing.Size(152, 26);
            this.txtUsernameDetail.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Họ tên";
            // 
            // txtPhoneDetail
            // 
            this.txtPhoneDetail.Location = new System.Drawing.Point(878, 26);
            this.txtPhoneDetail.Name = "txtPhoneDetail";
            this.txtPhoneDetail.Size = new System.Drawing.Size(170, 26);
            this.txtPhoneDetail.TabIndex = 5;
            this.txtPhoneDetail.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(797, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "SĐT";
            // 
            // txtEmailDetail
            // 
            this.txtEmailDetail.Location = new System.Drawing.Point(625, 28);
            this.txtEmailDetail.Name = "txtEmailDetail";
            this.txtEmailDetail.Size = new System.Drawing.Size(152, 26);
            this.txtEmailDetail.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Email";
            // 
            // txtUserIdDetail
            // 
            this.txtUserIdDetail.Location = new System.Drawing.Point(117, 25);
            this.txtUserIdDetail.Name = "txtUserIdDetail";
            this.txtUserIdDetail.Size = new System.Drawing.Size(152, 26);
            this.txtUserIdDetail.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tài khoản";
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(34, 284);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 62;
            this.dgvUsers.RowTemplate.Height = 28;
            this.dgvUsers.Size = new System.Drawing.Size(1782, 491);
            this.dgvUsers.TabIndex = 3;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            // 
            // txtIdDtDetail
            // 
            this.txtIdDtDetail.CustomFormat = "dd/MM/yyyy";
            this.txtIdDtDetail.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtIdDtDetail.Location = new System.Drawing.Point(625, 69);
            this.txtIdDtDetail.Name = "txtIdDtDetail";
            this.txtIdDtDetail.ShowUpDown = true;
            this.txtIdDtDetail.Size = new System.Drawing.Size(152, 26);
            this.txtIdDtDetail.TabIndex = 23;
            this.txtIdDtDetail.ValueChanged += new System.EventHandler(this.txtIdDtDetail_ValueChanged);
            // 
            // UserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1828, 908);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.gbSearch);
            this.Name = "UserInfoForm";
            this.Text = "Thông Tin & Tra Cứu Tài Khoản";
            this.Load += new System.EventHandler(this.UserInfoForm_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchUserId;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIdNoDetail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUsernameDetail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPhoneDetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmailDetail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserIdDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.TextBox txtIdPwdDetail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIdOrgDetail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker txtIdDtDetail;
    }
}