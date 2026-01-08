
namespace WindowsFormsApp_Pharmacy_Management
{
    partial class frm_customer_info
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
            this.dtp_RegiDtDetail = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.txt_HomeAddrDetail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_CustnmDetail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_PhoneDetail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_EmailDetail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_CustnoDetail = new System.Windows.Forms.TextBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_SexDetail = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_TaxNoDetail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_AccPointsDetail = new System.Windows.Forms.TextBox();
            this.cmb_ActiveYnDetail = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
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
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(969, 27);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(115, 29);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(848, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 29);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tra cứu";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchPhone
            // 
            this.txtSearchPhone.Location = new System.Drawing.Point(635, 27);
            this.txtSearchPhone.Name = "txtSearchPhone";
            this.txtSearchPhone.Size = new System.Drawing.Size(170, 26);
            this.txtSearchPhone.TabIndex = 2;
            this.txtSearchPhone.TextChanged += new System.EventHandler(this.txtSearchPhone_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "SĐT";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtSearchEmail
            // 
            this.txtSearchEmail.Location = new System.Drawing.Point(395, 30);
            this.txtSearchEmail.Name = "txtSearchEmail";
            this.txtSearchEmail.Size = new System.Drawing.Size(157, 26);
            this.txtSearchEmail.TabIndex = 1;
            this.txtSearchEmail.TextChanged += new System.EventHandler(this.txtSearchEmail_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã khách hàng";
            // 
            // txtSearchUserId
            // 
            this.txtSearchUserId.Location = new System.Drawing.Point(150, 30);
            this.txtSearchUserId.Name = "txtSearchUserId";
            this.txtSearchUserId.Size = new System.Drawing.Size(157, 26);
            this.txtSearchUserId.TabIndex = 0;
            this.txtSearchUserId.TextChanged += new System.EventHandler(this.txtSearchUserId_TextChanged);
            // 
            // gbDetails
            // 
            this.gbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetails.Controls.Add(this.label13);
            this.gbDetails.Controls.Add(this.cmb_ActiveYnDetail);
            this.gbDetails.Controls.Add(this.txt_AccPointsDetail);
            this.gbDetails.Controls.Add(this.label12);
            this.gbDetails.Controls.Add(this.txt_TaxNoDetail);
            this.gbDetails.Controls.Add(this.label11);
            this.gbDetails.Controls.Add(this.cmb_SexDetail);
            this.gbDetails.Controls.Add(this.label8);
            this.gbDetails.Controls.Add(this.label4);
            this.gbDetails.Controls.Add(this.dtp_RegiDtDetail);
            this.gbDetails.Controls.Add(this.btnSave);
            this.gbDetails.Controls.Add(this.btnEdit);
            this.gbDetails.Controls.Add(this.btnDelete);
            this.gbDetails.Controls.Add(this.btnAddNew);
            this.gbDetails.Controls.Add(this.txt_HomeAddrDetail);
            this.gbDetails.Controls.Add(this.label10);
            this.gbDetails.Controls.Add(this.label9);
            this.gbDetails.Controls.Add(this.txt_CustnmDetail);
            this.gbDetails.Controls.Add(this.label7);
            this.gbDetails.Controls.Add(this.txt_PhoneDetail);
            this.gbDetails.Controls.Add(this.label6);
            this.gbDetails.Controls.Add(this.txt_EmailDetail);
            this.gbDetails.Controls.Add(this.label5);
            this.gbDetails.Controls.Add(this.txt_CustnoDetail);
            this.gbDetails.Location = new System.Drawing.Point(34, 97);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(1782, 168);
            this.gbDetails.TabIndex = 1;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Thông tin chi tiết";
            // 
            // dtp_RegiDtDetail
            // 
            this.dtp_RegiDtDetail.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_RegiDtDetail.CustomFormat = "dd/MM/yyyy";
            this.dtp_RegiDtDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_RegiDtDetail.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_RegiDtDetail.Location = new System.Drawing.Point(1565, 34);
            this.dtp_RegiDtDetail.Name = "dtp_RegiDtDetail";
            this.dtp_RegiDtDetail.Size = new System.Drawing.Size(211, 26);
            this.dtp_RegiDtDetail.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(397, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 30);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(155, 121);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 31);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(281, 121);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 31);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(37, 121);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(100, 31);
            this.btnAddNew.TabIndex = 13;
            this.btnAddNew.Text = "Thêm mới";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_HomeAddrDetail
            // 
            this.txt_HomeAddrDetail.Location = new System.Drawing.Point(999, 30);
            this.txt_HomeAddrDetail.Name = "txt_HomeAddrDetail";
            this.txt_HomeAddrDetail.Size = new System.Drawing.Size(343, 26);
            this.txt_HomeAddrDetail.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(919, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Địa chỉ";
            // 
            // txt_CustnmDetail
            // 
            this.txt_CustnmDetail.Location = new System.Drawing.Point(383, 27);
            this.txt_CustnmDetail.Name = "txt_CustnmDetail";
            this.txt_CustnmDetail.Size = new System.Drawing.Size(212, 26);
            this.txt_CustnmDetail.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Họ tên";
            // 
            // txt_PhoneDetail
            // 
            this.txt_PhoneDetail.Location = new System.Drawing.Point(722, 27);
            this.txt_PhoneDetail.Name = "txt_PhoneDetail";
            this.txt_PhoneDetail.Size = new System.Drawing.Size(178, 26);
            this.txt_PhoneDetail.TabIndex = 7;
            this.txt_PhoneDetail.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(617, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "SĐT";
            // 
            // txt_EmailDetail
            // 
            this.txt_EmailDetail.Location = new System.Drawing.Point(999, 64);
            this.txt_EmailDetail.Name = "txt_EmailDetail";
            this.txt_EmailDetail.Size = new System.Drawing.Size(343, 26);
            this.txt_EmailDetail.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(928, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Email";
            // 
            // txt_CustnoDetail
            // 
            this.txt_CustnoDetail.Location = new System.Drawing.Point(154, 27);
            this.txt_CustnoDetail.Name = "txt_CustnoDetail";
            this.txt_CustnoDetail.Size = new System.Drawing.Size(153, 26);
            this.txt_CustnoDetail.TabIndex = 4;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mã khách hàng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1374, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "Ngày đăng ký";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 30);
            this.label8.TabIndex = 17;
            this.label8.Text = "Giới tính";
            // 
            // cmb_SexDetail
            // 
            this.cmb_SexDetail.FormattingEnabled = true;
            this.cmb_SexDetail.Location = new System.Drawing.Point(155, 63);
            this.cmb_SexDetail.Name = "cmb_SexDetail";
            this.cmb_SexDetail.Size = new System.Drawing.Size(152, 28);
            this.cmb_SexDetail.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(321, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 30);
            this.label11.TabIndex = 19;
            this.label11.Text = "MST";
            // 
            // txt_TaxNoDetail
            // 
            this.txt_TaxNoDetail.Location = new System.Drawing.Point(383, 63);
            this.txt_TaxNoDetail.Name = "txt_TaxNoDetail";
            this.txt_TaxNoDetail.Size = new System.Drawing.Size(212, 26);
            this.txt_TaxNoDetail.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(617, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 30);
            this.label12.TabIndex = 21;
            this.label12.Text = "Điểm tích lũy";
            // 
            // txt_AccPointsDetail
            // 
            this.txt_AccPointsDetail.Location = new System.Drawing.Point(722, 63);
            this.txt_AccPointsDetail.Name = "txt_AccPointsDetail";
            this.txt_AccPointsDetail.Size = new System.Drawing.Size(178, 26);
            this.txt_AccPointsDetail.TabIndex = 22;
            // 
            // cmb_ActiveYnDetail
            // 
            this.cmb_ActiveYnDetail.FormattingEnabled = true;
            this.cmb_ActiveYnDetail.Location = new System.Drawing.Point(1565, 67);
            this.cmb_ActiveYnDetail.Name = "cmb_ActiveYnDetail";
            this.cmb_ActiveYnDetail.Size = new System.Drawing.Size(211, 28);
            this.cmb_ActiveYnDetail.TabIndex = 23;
            this.cmb_ActiveYnDetail.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1374, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 20);
            this.label13.TabIndex = 24;
            this.label13.Text = "Trạng thái hoạt động";
            // 
            // frm_customer_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1828, 908);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.gbSearch);
            this.Name = "frm_customer_info";
            this.Text = "Thông Tin & Tra Cứu Khách Hàng";
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
        private System.Windows.Forms.TextBox txt_CustnmDetail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_PhoneDetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_EmailDetail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_CustnoDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.TextBox txt_HomeAddrDetail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtp_RegiDtDetail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmb_ActiveYnDetail;
        private System.Windows.Forms.TextBox txt_AccPointsDetail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_TaxNoDetail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_SexDetail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
    }
}