
namespace WindowsFormsApp_Pharmacy_Management
{
    partial class frm_user_info
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
            this.dtp_IdDtDetail = new System.Windows.Forms.DateTimePicker();
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btnImportImage = new System.Windows.Forms.Button();
            this.USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOBI_PHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_ORG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WORK_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UPD_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PWD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_IMAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picUserImage = new System.Windows.Forms.PictureBox();
            this.gbSearch.SuspendLayout();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserImage)).BeginInit();
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
            this.gbSearch.Size = new System.Drawing.Size(2382, 72);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Điều kiện tra cứu";
            // 
            // btnReload
            // 
            this.btnReload.Enabled = false;
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
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tra cứu";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchPhone
            // 
            this.txtSearchPhone.Location = new System.Drawing.Point(602, 22);
            this.txtSearchPhone.Name = "txtSearchPhone";
            this.txtSearchPhone.Size = new System.Drawing.Size(170, 26);
            this.txtSearchPhone.TabIndex = 2;
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
            this.txtSearchEmail.TabIndex = 1;
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
            this.gbDetails.Controls.Add(this.dtp_IdDtDetail);
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
            this.gbDetails.Size = new System.Drawing.Size(1283, 168);
            this.gbDetails.TabIndex = 1;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Thông tin chi tiết";
            this.gbDetails.Enter += new System.EventHandler(this.gbDetails_Enter);
            // 
            // dtp_IdDtDetail
            // 
            this.dtp_IdDtDetail.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_IdDtDetail.CustomFormat = "dd/MM/yyyy";
            this.dtp_IdDtDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_IdDtDetail.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_IdDtDetail.Location = new System.Drawing.Point(683, 74);
            this.dtp_IdDtDetail.Name = "dtp_IdDtDetail";
            this.dtp_IdDtDetail.Size = new System.Drawing.Size(211, 26);
            this.dtp_IdDtDetail.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(397, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 30);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(155, 121);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 31);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(281, 121);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 31);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(37, 121);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(100, 31);
            this.btnAddNew.TabIndex = 12;
            this.btnAddNew.Text = "Thêm mới";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIdPwdDetail
            // 
            this.txtIdPwdDetail.Location = new System.Drawing.Point(420, 28);
            this.txtIdPwdDetail.Name = "txtIdPwdDetail";
            this.txtIdPwdDetail.Size = new System.Drawing.Size(152, 26);
            this.txtIdPwdDetail.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(335, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Mật khẩu";
            // 
            // txtIdOrgDetail
            // 
            this.txtIdOrgDetail.Location = new System.Drawing.Point(999, 69);
            this.txtIdOrgDetail.Name = "txtIdOrgDetail";
            this.txtIdOrgDetail.Size = new System.Drawing.Size(272, 26);
            this.txtIdOrgDetail.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(918, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Nơi cấp";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(592, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Ngày cấp";
            // 
            // txtIdNoDetail
            // 
            this.txtIdNoDetail.Location = new System.Drawing.Point(420, 74);
            this.txtIdNoDetail.Name = "txtIdNoDetail";
            this.txtIdNoDetail.Size = new System.Drawing.Size(152, 26);
            this.txtIdNoDetail.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(352, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "CCCD";
            // 
            // txtUsernameDetail
            // 
            this.txtUsernameDetail.Location = new System.Drawing.Point(117, 70);
            this.txtUsernameDetail.Name = "txtUsernameDetail";
            this.txtUsernameDetail.Size = new System.Drawing.Size(212, 26);
            this.txtUsernameDetail.TabIndex = 8;
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
            this.txtPhoneDetail.Location = new System.Drawing.Point(999, 29);
            this.txtPhoneDetail.Name = "txtPhoneDetail";
            this.txtPhoneDetail.Size = new System.Drawing.Size(272, 26);
            this.txtPhoneDetail.TabIndex = 7;
            this.txtPhoneDetail.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(918, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "SĐT";
            // 
            // txtEmailDetail
            // 
            this.txtEmailDetail.Location = new System.Drawing.Point(683, 32);
            this.txtEmailDetail.Name = "txtEmailDetail";
            this.txtEmailDetail.Size = new System.Drawing.Size(211, 26);
            this.txtEmailDetail.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(615, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Email";
            // 
            // txtUserIdDetail
            // 
            this.txtUserIdDetail.Location = new System.Drawing.Point(117, 25);
            this.txtUserIdDetail.Name = "txtUserIdDetail";
            this.txtUserIdDetail.Size = new System.Drawing.Size(212, 26);
            this.txtUserIdDetail.TabIndex = 4;
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
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.USER_ID,
            this.USERNAME,
            this.MOBI_PHONE,
            this.EMAIL,
            this.ID_NO,
            this.ID_DT,
            this.ID_ORG,
            this.WORK_DT,
            this.UPD_DT,
            this.PWD,
            this.USER_IMAGE});
            this.dgvUsers.Location = new System.Drawing.Point(34, 284);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 62;
            this.dgvUsers.RowTemplate.Height = 28;
            this.dgvUsers.Size = new System.Drawing.Size(1283, 831);
            this.dgvUsers.TabIndex = 3;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btnImportImage
            // 
            this.btnImportImage.Location = new System.Drawing.Point(1497, 742);
            this.btnImportImage.Name = "btnImportImage";
            this.btnImportImage.Size = new System.Drawing.Size(179, 33);
            this.btnImportImage.TabIndex = 18;
            this.btnImportImage.Text = "Chọn ảnh";
            this.btnImportImage.UseVisualStyleBackColor = true;
            this.btnImportImage.Click += new System.EventHandler(this.btnImportImage_Click_1);
            // 
            // USER_ID
            // 
            this.USER_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.USER_ID.HeaderText = "Tài khoản";
            this.USER_ID.MinimumWidth = 8;
            this.USER_ID.Name = "USER_ID";
            this.USER_ID.ReadOnly = true;
            this.USER_ID.Width = 113;
            // 
            // USERNAME
            // 
            this.USERNAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.USERNAME.HeaderText = "Họ tên";
            this.USERNAME.MinimumWidth = 8;
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.ReadOnly = true;
            this.USERNAME.Width = 112;
            // 
            // MOBI_PHONE
            // 
            this.MOBI_PHONE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MOBI_PHONE.HeaderText = "Số Điện Thoại";
            this.MOBI_PHONE.MinimumWidth = 8;
            this.MOBI_PHONE.Name = "MOBI_PHONE";
            this.MOBI_PHONE.ReadOnly = true;
            this.MOBI_PHONE.Width = 92;
            // 
            // EMAIL
            // 
            this.EMAIL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EMAIL.HeaderText = "Email";
            this.EMAIL.MinimumWidth = 8;
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.ReadOnly = true;
            this.EMAIL.Width = 113;
            // 
            // ID_NO
            // 
            this.ID_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID_NO.HeaderText = "CMND/CCCD";
            this.ID_NO.MinimumWidth = 8;
            this.ID_NO.Name = "ID_NO";
            this.ID_NO.ReadOnly = true;
            this.ID_NO.Width = 113;
            // 
            // ID_DT
            // 
            this.ID_DT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID_DT.HeaderText = "Ngày Cấp CMND";
            this.ID_DT.MinimumWidth = 8;
            this.ID_DT.Name = "ID_DT";
            this.ID_DT.ReadOnly = true;
            this.ID_DT.Width = 113;
            // 
            // ID_ORG
            // 
            this.ID_ORG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID_ORG.HeaderText = "Nơi Cấp CMND";
            this.ID_ORG.MinimumWidth = 8;
            this.ID_ORG.Name = "ID_ORG";
            this.ID_ORG.ReadOnly = true;
            this.ID_ORG.Width = 112;
            // 
            // WORK_DT
            // 
            this.WORK_DT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.WORK_DT.HeaderText = "Ngày Vào Làm";
            this.WORK_DT.MinimumWidth = 8;
            this.WORK_DT.Name = "WORK_DT";
            this.WORK_DT.ReadOnly = true;
            this.WORK_DT.Width = 113;
            // 
            // UPD_DT
            // 
            this.UPD_DT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UPD_DT.HeaderText = "Cập Nhật Cuối";
            this.UPD_DT.MinimumWidth = 8;
            this.UPD_DT.Name = "UPD_DT";
            this.UPD_DT.ReadOnly = true;
            this.UPD_DT.Width = 113;
            // 
            // PWD
            // 
            this.PWD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PWD.HeaderText = "Mật Khẩu (Hash)";
            this.PWD.MinimumWidth = 8;
            this.PWD.Name = "PWD";
            this.PWD.ReadOnly = true;
            this.PWD.Width = 113;
            // 
            // USER_IMAGE
            // 
            this.USER_IMAGE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.USER_IMAGE.HeaderText = "Ảnh Đại Diện";
            this.USER_IMAGE.MinimumWidth = 8;
            this.USER_IMAGE.Name = "USER_IMAGE";
            this.USER_IMAGE.ReadOnly = true;
            this.USER_IMAGE.Width = 112;
            // 
            // picUserImage
            // 
            this.picUserImage.Location = new System.Drawing.Point(1344, 108);
            this.picUserImage.Name = "picUserImage";
            this.picUserImage.Size = new System.Drawing.Size(448, 614);
            this.picUserImage.TabIndex = 17;
            this.picUserImage.TabStop = false;
            // 
            // frm_user_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1849, 964);
            this.Controls.Add(this.btnImportImage);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.picUserImage);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.gbSearch);
            this.MaximizeBox = false;
            this.Name = "frm_user_info";
            this.Text = "Thông Tin & Tra Cứu Tài Khoản";
            this.Load += new System.EventHandler(this.UserInfoForm_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbDetails.ResumeLayout(false);
            this.gbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserImage)).EndInit();
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
        private System.Windows.Forms.DateTimePicker dtp_IdDtDetail;
        private System.Windows.Forms.PictureBox picUserImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btnImportImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOBI_PHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_ORG;
        private System.Windows.Forms.DataGridViewTextBoxColumn WORK_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn UPD_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PWD;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_IMAGE;
    }
}