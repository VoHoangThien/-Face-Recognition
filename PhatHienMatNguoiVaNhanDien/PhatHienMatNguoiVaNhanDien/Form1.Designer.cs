namespace PhatHienMatNguoiVaNhanDien
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInfomation = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imgAddToCamera1 = new Emgu.CV.UI.ImageBox();
            this.btnTakeAShot = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddData = new System.Windows.Forms.Button();
            this.cbbBranchStudent = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbFacultyStudent = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCousreStudent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdbFM = new System.Windows.Forms.RadioButton();
            this.rdbM = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNameStudent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodeStudent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imgShowImgGray1 = new Emgu.CV.UI.ImageBox();
            this.btnAddToPC = new System.Windows.Forms.Button();
            this.btnAddToCamera = new System.Windows.Forms.Button();
            this.imgAddToCamera = new Emgu.CV.UI.ImageBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtEigenDistanceThreshold = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.btnDeleteAllItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsvResult = new System.Windows.Forms.ListView();
            this.imgShowCamera = new Emgu.CV.UI.ImageBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgAddToCamera1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgShowImgGray1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAddToCamera)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgShowCamera)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(859, 455);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 31);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInfomation
            // 
            this.btnInfomation.Location = new System.Drawing.Point(4, 455);
            this.btnInfomation.Name = "btnInfomation";
            this.btnInfomation.Size = new System.Drawing.Size(113, 31);
            this.btnInfomation.TabIndex = 2;
            this.btnInfomation.Text = "Thông tin";
            this.btnInfomation.UseVisualStyleBackColor = true;
            this.btnInfomation.Click += new System.EventHandler(this.btnInfomation_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.imgAddToCamera1);
            this.tabPage2.Controls.Add(this.btnTakeAShot);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btnAddToPC);
            this.tabPage2.Controls.Add(this.btnAddToCamera);
            this.tabPage2.Controls.Add(this.imgAddToCamera);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(936, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thêm dữ liệu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // imgAddToCamera1
            // 
            this.imgAddToCamera1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgAddToCamera1.Location = new System.Drawing.Point(558, 21);
            this.imgAddToCamera1.Name = "imgAddToCamera1";
            this.imgAddToCamera1.Size = new System.Drawing.Size(320, 240);
            this.imgAddToCamera1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgAddToCamera1.TabIndex = 8;
            this.imgAddToCamera1.TabStop = false;
            // 
            // btnTakeAShot
            // 
            this.btnTakeAShot.Location = new System.Drawing.Point(773, 340);
            this.btnTakeAShot.Name = "btnTakeAShot";
            this.btnTakeAShot.Size = new System.Drawing.Size(105, 55);
            this.btnTakeAShot.TabIndex = 7;
            this.btnTakeAShot.Text = "Chụp";
            this.btnTakeAShot.UseVisualStyleBackColor = true;
            this.btnTakeAShot.Click += new System.EventHandler(this.btnTakeAShot_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.txtMonth);
            this.groupBox1.Controls.Add(this.txtDay);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnAddData);
            this.groupBox1.Controls.Add(this.cbbBranchStudent);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbbFacultyStudent);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCousreStudent);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rdbFM);
            this.groupBox1.Controls.Add(this.rdbM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNameStudent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCodeStudent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.imgShowImgGray1);
            this.groupBox1.Location = new System.Drawing.Point(36, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 382);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dữ liệu ";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(284, 187);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.ShortcutsEnabled = false;
            this.txtYear.Size = new System.Drawing.Size(45, 20);
            this.txtYear.TabIndex = 28;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(223, 187);
            this.txtMonth.MaxLength = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ShortcutsEnabled = false;
            this.txtMonth.Size = new System.Drawing.Size(37, 20);
            this.txtMonth.TabIndex = 27;
            this.txtMonth.Click += new System.EventHandler(this.txtMonth_Click);
            this.txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonth_KeyPress);
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(162, 187);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.ShortcutsEnabled = false;
            this.txtDay.Size = new System.Drawing.Size(37, 20);
            this.txtDay.TabIndex = 26;
            this.txtDay.Click += new System.EventHandler(this.txtDay_Click);
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDay_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(266, 190);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(12, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "/";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(205, 190);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "/";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(56, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 39);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddData
            // 
            this.btnAddData.Location = new System.Drawing.Point(310, 319);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(105, 39);
            this.btnAddData.TabIndex = 6;
            this.btnAddData.Text = "Thêm dữ liệu";
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // cbbBranchStudent
            // 
            this.cbbBranchStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBranchStudent.FormattingEnabled = true;
            this.cbbBranchStudent.Location = new System.Drawing.Point(162, 287);
            this.cbbBranchStudent.Name = "cbbBranchStudent";
            this.cbbBranchStudent.Size = new System.Drawing.Size(253, 21);
            this.cbbBranchStudent.TabIndex = 18;
            this.cbbBranchStudent.Click += new System.EventHandler(this.cbbBranchStudent_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Ngành:";
            // 
            // cbbFacultyStudent
            // 
            this.cbbFacultyStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFacultyStudent.FormattingEnabled = true;
            this.cbbFacultyStudent.Items.AddRange(new object[] {
            "Công nghệ thông tin",
            "Công nghệ sinh học",
            "Kinh tế và Quản lý công",
            "Kế toán - Kiểm toán",
            "Xây dựng và Điện",
            "Luật",
            "Ngoại ngữ",
            "Quản trị kinh doanh",
            "Tài chính - Ngân hàng",
            "XHH - CTXH - ĐNA"});
            this.cbbFacultyStudent.Location = new System.Drawing.Point(162, 260);
            this.cbbFacultyStudent.Name = "cbbFacultyStudent";
            this.cbbFacultyStudent.Size = new System.Drawing.Size(253, 21);
            this.cbbFacultyStudent.TabIndex = 16;
            this.cbbFacultyStudent.Click += new System.EventHandler(this.cbbFacultyStudent_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Khoa:";
            // 
            // txtCousreStudent
            // 
            this.txtCousreStudent.Location = new System.Drawing.Point(162, 234);
            this.txtCousreStudent.MaxLength = 4;
            this.txtCousreStudent.Name = "txtCousreStudent";
            this.txtCousreStudent.ShortcutsEnabled = false;
            this.txtCousreStudent.Size = new System.Drawing.Size(253, 20);
            this.txtCousreStudent.TabIndex = 14;
            this.txtCousreStudent.Click += new System.EventHandler(this.txtCourseStudent_Click);
            this.txtCousreStudent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCourseStudent_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Khóa học:";
            // 
            // rdbFM
            // 
            this.rdbFM.AutoSize = true;
            this.rdbFM.Location = new System.Drawing.Point(334, 213);
            this.rdbFM.Name = "rdbFM";
            this.rdbFM.Size = new System.Drawing.Size(39, 17);
            this.rdbFM.TabIndex = 12;
            this.rdbFM.TabStop = true;
            this.rdbFM.Text = "Nữ";
            this.rdbFM.UseVisualStyleBackColor = true;
            // 
            // rdbM
            // 
            this.rdbM.AutoSize = true;
            this.rdbM.Location = new System.Drawing.Point(208, 213);
            this.rdbM.Name = "rdbM";
            this.rdbM.Size = new System.Drawing.Size(47, 17);
            this.rdbM.TabIndex = 11;
            this.rdbM.TabStop = true;
            this.rdbM.Text = "Nam";
            this.rdbM.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Giới tính:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ngày sinh:";
            // 
            // txtNameStudent
            // 
            this.txtNameStudent.Location = new System.Drawing.Point(162, 162);
            this.txtNameStudent.Name = "txtNameStudent";
            this.txtNameStudent.ShortcutsEnabled = false;
            this.txtNameStudent.Size = new System.Drawing.Size(253, 20);
            this.txtNameStudent.TabIndex = 7;
            this.txtNameStudent.Click += new System.EventHandler(this.txtNameStudent_Click);
            this.txtNameStudent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNameStudent_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Họ tên:";
            // 
            // txtCodeStudent
            // 
            this.txtCodeStudent.Location = new System.Drawing.Point(162, 138);
            this.txtCodeStudent.MaxLength = 10;
            this.txtCodeStudent.Name = "txtCodeStudent";
            this.txtCodeStudent.ShortcutsEnabled = false;
            this.txtCodeStudent.Size = new System.Drawing.Size(253, 20);
            this.txtCodeStudent.TabIndex = 5;
            this.txtCodeStudent.Click += new System.EventHandler(this.txtCodeStudent_Click);
            this.txtCodeStudent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodeStudent_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã Số SV:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File ảnh:";
            // 
            // imgShowImgGray1
            // 
            this.imgShowImgGray1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgShowImgGray1.Location = new System.Drawing.Point(162, 19);
            this.imgShowImgGray1.Name = "imgShowImgGray1";
            this.imgShowImgGray1.Size = new System.Drawing.Size(100, 100);
            this.imgShowImgGray1.TabIndex = 2;
            this.imgShowImgGray1.TabStop = false;
            // 
            // btnAddToPC
            // 
            this.btnAddToPC.Location = new System.Drawing.Point(558, 291);
            this.btnAddToPC.Name = "btnAddToPC";
            this.btnAddToPC.Size = new System.Drawing.Size(105, 33);
            this.btnAddToPC.TabIndex = 4;
            this.btnAddToPC.Text = "Thêm từ máy tính";
            this.btnAddToPC.UseVisualStyleBackColor = true;
            this.btnAddToPC.Click += new System.EventHandler(this.btnAddToPC_Click);
            // 
            // btnAddToCamera
            // 
            this.btnAddToCamera.Location = new System.Drawing.Point(773, 291);
            this.btnAddToCamera.Name = "btnAddToCamera";
            this.btnAddToCamera.Size = new System.Drawing.Size(105, 33);
            this.btnAddToCamera.TabIndex = 3;
            this.btnAddToCamera.Text = "Thêm từ camera";
            this.btnAddToCamera.UseVisualStyleBackColor = true;
            this.btnAddToCamera.Click += new System.EventHandler(this.btnAddToCamera_Click);
            // 
            // imgAddToCamera
            // 
            this.imgAddToCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgAddToCamera.Location = new System.Drawing.Point(558, 21);
            this.imgAddToCamera.Name = "imgAddToCamera";
            this.imgAddToCamera.Size = new System.Drawing.Size(320, 240);
            this.imgAddToCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgAddToCamera.TabIndex = 2;
            this.imgAddToCamera.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.btnSaveFile);
            this.tabPage1.Controls.Add(this.btnDeleteAllItem);
            this.tabPage1.Controls.Add(this.btnDeleteItem);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.imgShowCamera);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(936, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Điểm danh";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.txtTime);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.txtEigenDistanceThreshold);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Location = new System.Drawing.Point(734, 279);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 137);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(112, 97);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(20, 13);
            this.label20.TabIndex = 11;
            this.label20.Text = "ms";
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Location = new System.Drawing.Point(6, 90);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 10;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 67);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 13);
            this.label21.TabIndex = 9;
            this.label21.Text = "Thời gian khi nhận dạng:";
            // 
            // txtEigenDistanceThreshold
            // 
            this.txtEigenDistanceThreshold.Location = new System.Drawing.Point(6, 28);
            this.txtEigenDistanceThreshold.MaxLength = 4;
            this.txtEigenDistanceThreshold.Name = "txtEigenDistanceThreshold";
            this.txtEigenDistanceThreshold.Size = new System.Drawing.Size(100, 20);
            this.txtEigenDistanceThreshold.TabIndex = 4;
            this.txtEigenDistanceThreshold.Text = "3000";
            this.txtEigenDistanceThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEigenDistanceThreshold_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(162, 13);
            this.label19.TabIndex = 3;
            this.label19.Tag = "";
            this.label19.Text = "Ngưỡng khoảng cách(0 -> 5000)";
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(620, 379);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(91, 37);
            this.btnSaveFile.TabIndex = 6;
            this.btnSaveFile.Text = "Lưu";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // btnDeleteAllItem
            // 
            this.btnDeleteAllItem.Location = new System.Drawing.Point(620, 322);
            this.btnDeleteAllItem.Name = "btnDeleteAllItem";
            this.btnDeleteAllItem.Size = new System.Drawing.Size(91, 37);
            this.btnDeleteAllItem.TabIndex = 5;
            this.btnDeleteAllItem.Text = "Xóa tất cả";
            this.btnDeleteAllItem.UseVisualStyleBackColor = true;
            this.btnDeleteAllItem.Click += new System.EventHandler(this.btnDeleteAllItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeleteItem.Location = new System.Drawing.Point(620, 279);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(91, 37);
            this.btnDeleteItem.TabIndex = 4;
            this.btnDeleteItem.Text = "Xóa";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvResult);
            this.groupBox2.Location = new System.Drawing.Point(6, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 416);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả";
            // 
            // lsvResult
            // 
            this.lsvResult.Location = new System.Drawing.Point(0, 19);
            this.lsvResult.Name = "lsvResult";
            this.lsvResult.Size = new System.Drawing.Size(598, 397);
            this.lsvResult.TabIndex = 0;
            this.lsvResult.UseCompatibleStateImageBehavior = false;
            this.lsvResult.SelectedIndexChanged += new System.EventHandler(this.lsvResult_SelectedIndexChanged);
            // 
            // imgShowCamera
            // 
            this.imgShowCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgShowCamera.Location = new System.Drawing.Point(610, 19);
            this.imgShowCamera.Name = "imgShowCamera";
            this.imgShowCamera.Size = new System.Drawing.Size(320, 240);
            this.imgShowCamera.TabIndex = 2;
            this.imgShowCamera.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(944, 448);
            this.tabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnAddData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(946, 494);
            this.Controls.Add(this.btnInfomation);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ĐIỂM DANH BẰNG NHẬN DẠNG KHUÔN MẶT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgAddToCamera1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgShowImgGray1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAddToCamera)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgShowCamera)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInfomation;
        private System.Windows.Forms.TabPage tabPage2;
        private Emgu.CV.UI.ImageBox imgAddToCamera1;
        private System.Windows.Forms.Button btnTakeAShot;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.ComboBox cbbBranchStudent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbFacultyStudent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCousreStudent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdbFM;
        private System.Windows.Forms.RadioButton rdbM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNameStudent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodeStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Emgu.CV.UI.ImageBox imgShowImgGray1;
        private System.Windows.Forms.Button btnAddToPC;
        private System.Windows.Forms.Button btnAddToCamera;
        private Emgu.CV.UI.ImageBox imgAddToCamera;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtEigenDistanceThreshold;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.Button btnDeleteAllItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lsvResult;
        private Emgu.CV.UI.ImageBox imgShowCamera;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

