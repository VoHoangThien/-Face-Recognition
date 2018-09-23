using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using cExcel = Microsoft.Office.Interop.Excel;


namespace PhatHienMatNguoiVaNhanDien
{
    public partial class Form1 : Form
    {
        Image<Bgr, Byte> currentFrame;
        Image<Bgr, Byte> currentFrameAddToCamera;
        Capture grabberTest;
        Capture grabberAddToCamera = new Capture();
        HaarCascade face;
        Image<Gray, byte> result, TrainedFace;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        Image<Bgr, Byte> img;
        MCvAvgComp[][] facesDetectedtofile;
        List<string> nameSD = new List<string>();
        List<string> codeSD = new List<string>();
        List<string> dateSD = new List<string>();
        List<string> sexSD = new List<string>();
        List<string> courseSD = new List<string>();
        List<string> facultySD = new List<string>();
        List<string> branchSD = new List<string>();

        List<Student> ListStudent = new List<Student>();
        List<Student> ListStudentOnListView = new List<Student>();
        Student StudentOnListView;
        List<string> NamePersons = new List<string>();
        List<string> ListStudentTest = new List<string>();
        int ContTrain, NumLabels;
        string nameStudent;// tên sinh viên
        string codeStudent;// mã số sinh viên
        string dateStudent;// ngày sinh của sinh viên
        string sexStudent;// giới tính sinh viên
        string courseStudent;// khóa hoc của sinh viên
        string facultyStudent;// tên khoa của sinh viên
        string branchStudent;// tên ngành của sinh viên 
        Student StudentSelect;
        int MaxDay;
        bool check;
        bool checkSpace;
        string filePath = "/TrainedFaces/TrainedFaces.txt";
        Stopwatch sw = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                string Labelsinfo = File.ReadAllText(Application.StartupPath + filePath);
                List<string> test = new List<string>();
                string[] Labels;
                string[] name;
                Labels = File.ReadAllLines(Application.StartupPath + filePath);
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;
                for (int i = 1; i <= NumLabels; i++)
                {
                    LoadFaces = "face" + i + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    name = Labels[i].Split('-');
                    for (int j = 0; j < name.Count(); j++)
                    {
                        switch (j)
                        {
                            case 0:
                                {
                                    nameSD.Add(name[j]);
                                    break;
                                }
                            case 1:
                                {
                                    codeSD.Add(name[j]);
                                    break;
                                }
                            case 2:
                                {
                                    dateSD.Add(name[j]);
                                    break;
                                }
                            case 3:
                                {
                                    sexSD.Add(name[j]);
                                    break;
                                }
                            case 4:
                                {
                                    courseSD.Add(name[j]);
                                    break;
                                }
                            case 5:
                                {
                                    facultySD.Add(name[j]);
                                    break;
                                }
                            case 6:
                                {
                                    branchSD.Add(name[j]);
                                    break;
                                }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hiện tại vẫn chưa có dữ liệu nào để nhận dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #region controls button
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn muốn thoát chương trình ?", "thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (h == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void btnAddToPC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có thể thêm một người với tối đa 3 ảnh để nhận diện chính xác hơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAddToCamera.Enabled = false;
            //imgAddToCamera1.Hide();
            btnTakeAShot.Enabled = false;
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                img = new Image<Bgr, byte>(openfile.FileName);
                imgAddToCamera.Image = img;
                // chuyển ảnh mới thêm thành ảnh xám 
                gray = img.Convert<Gray, Byte>();
                //phát hiện ra khuôn mặt
                bool checkDetect = true;
                facesDetectedtofile = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                foreach (MCvAvgComp f in facesDetectedtofile[0])
                {
                    result = img.Copy(f.rect).Convert<Gray, byte>();
                    // vẽ khuôn mặt được phát hiện
                    img.Draw(f.rect, new Bgr(Color.Green), 1);
                    checkDetect = false;
                }
                if (checkDetect)
                {
                    MessageBox.Show("Không tìm thấy khuôn mặt trong hình,\nLưu ý khi chọn hình phải có ít nhất một mặt người, hình mặt người phải thẳng và không bị che khuất bởi bất cứ vật gì", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    imgAddToCamera.Image = null;
                    btnAddToCamera.Enabled = true;
                }
                else
                {
                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    imgShowImgGray1.Image = TrainedFace;
                    btnCancel.Enabled = true;
                    btnAddData.Enabled = true;
                }
            }
            else
                ResetAll();
            txtCodeStudent.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
        private void btnAddToCamera_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có thể thêm một người với tối đa 3 ảnh để nhận diện chính xác hơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            check = true;
            btnTakeAShot.Enabled = true;
            btnAddToCamera.Enabled = false;
            btnAddToPC.Enabled = false;

            //if (!grabberAddToCamera.FlipHorizontal)
            //{
            imgAddToCamera1.Show();
            grabberAddToCamera.FlipHorizontal = !grabberAddToCamera.FlipHorizontal;// đưa ảnh về cùng chiều 
            Application.Idle += new EventHandler(FrameGrabberAddToCamera);
            //}
        }
        private void btnTakeAShot_Click(object sender, EventArgs e)
        {
            bool checkDetect = true;
            btnAddToCamera.Enabled = false;
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in facesDetected[0])
            {
                result = currentFrameAddToCamera.Copy(f.rect).Convert<Gray, byte>();
                checkDetect = false;
                break;
            }
            if (checkDetect)
            {
                MessageBox.Show("Không tìm thấy khuôn mặt trong hình.\nchú ý khi thêm ảnh vui lòng gỡ bỏ khẩu trang, không đeo khính, nhìn thẳng vào camera hoặc webcam đẻ nhận diện được tốt hơn", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                imgShowImgGray1.Image = TrainedFace;
                btnCancel.Enabled = true;
                txtCodeStudent.Focus();
                btnAddData.Enabled = true;
            }
        }
        private void btnAddData_Click(object sender, EventArgs e)
        {

            bool checkData = true;
            if (txtCodeStudent.Text == "")
            {
                MessageBox.Show("bạn chưa nhập mã số sinh viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodeStudent.Focus();
            }
            else if (txtNameStudent.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameStudent.Focus();
            }
            else if (txtDay.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDay.Focus();
            }
            else if (txtMonth.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMonth.Focus();
            }
            else if (txtYear.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtYear.Focus();
            }
            else if (rdbM.Checked == false && rdbFM.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtCousreStudent.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập khóa học", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCousreStudent.Focus();
            }
            else if (cbbFacultyStudent.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khoa", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbbBranchStudent.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn ngành", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else// đã điền đầy đủ thông tin 
            {
                try
                {
                    int temp = 0;
                    int Day = int.Parse(txtDay.Text);
                    string Month = txtMonth.Text;
                    int Year = int.Parse(txtYear.Text);
                    int Course = int.Parse(txtCousreStudent.Text);
                    if (txtCodeStudent.Text.Length < 10)
                    {
                        MessageBox.Show("Mã số sinh viên không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        checkData = false;
                    }
                    if (rdbM.Checked)
                    {
                        sexStudent = "Nam";
                    }
                    else sexStudent = "Nữ";
                    if (Course <= 2010 || Course > 2018)
                    {
                        MessageBox.Show("Khóa học không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCousreStudent.ResetText();
                        txtCousreStudent.Focus();
                        checkData = false;
                    }
                    if (Year <= 1900 || Year >= 2018)
                    {
                        MessageBox.Show("Năm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtYear.ResetText();
                        txtYear.Focus();
                        checkData = false;
                    }
                    switch (Month)
                    {
                        case "01":
                        case "1":
                        case "03":
                        case "3":
                        case "05":
                        case "5":
                        case "07":
                        case "7":
                        case "08":
                        case "8":
                        case "10":
                        case "12":
                            {
                                MaxDay = 31;
                                break;
                            }
                        case "04":
                        case "4":
                        case "06":
                        case "6":
                        case "9":
                        case "09":
                        case "11":
                            {
                                MaxDay = 30;
                                break;
                            }
                        case "02":
                        case "2":
                            {
                                if ((Year % 4 == 0 && Year % 100 != 0) || (Year % 400 == 0))
                                {
                                    MaxDay = 29;
                                }
                                else MaxDay = 28;
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Tháng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtMonth.ResetText();
                                txtMonth.Focus();
                                checkData = false;
                                break;
                            }
                    }
                    if ((Day < 1 || Day > MaxDay))
                    {
                        MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDay.ResetText();
                        txtDay.Focus();
                        checkData = false;
                    }
                    for (int i = 0; i < codeSD.Count; i++)
                    {
                        if (codeSD[i] == txtCodeStudent.Text)
                        {
                            temp++;
                        }
                        if (temp == 3)
                        {
                            MessageBox.Show("Hiện tại đã có ít nhất 3 ảnh về người này để nhận dạng\n Bạn không thể thêm ảnh người này vào cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetAll();
                            checkData = false;
                            break;
                        }
                    }
                    if (checkData == true)
                    {
                        ContTrain = ContTrain + 1;
                        dateStudent = txtDay.Text + "/" + txtMonth.Text + "/" + txtYear.Text;
                        trainingImages.Add(TrainedFace);
                        nameSD.Add(txtNameStudent.Text);
                        codeSD.Add(txtCodeStudent.Text);
                        dateSD.Add(dateStudent);
                        sexSD.Add(sexStudent);
                        courseSD.Add(txtCousreStudent.Text);
                        facultySD.Add(cbbFacultyStudent.Text);
                        branchSD.Add(cbbBranchStudent.Text);
                        // tạo file mới và ghi vào
                        File.WriteAllText(Application.StartupPath + filePath, trainingImages.ToArray().Length.ToString() + Environment.NewLine);
                        for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                        {
                            File.AppendAllText(Application.StartupPath + filePath, nameSD.ToArray()[i - 1] + "-" + codeSD.ToArray()[i - 1] + "-" + dateSD.ToArray()[i - 1] + "-" + sexSD.ToArray()[i - 1] + "-" + courseSD.ToArray()[i - 1] + "-" + facultySD.ToArray()[i - 1] + "-" + branchSD.ToArray()[i - 1] + Environment.NewLine);
                            trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                        }
                        if (MessageBox.Show("Thêm ảnh thành công Bạn có muốn tiếp tục thêm ảnh cho " + txtNameStudent.Text + " không?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            btnCancel.Enabled = false;
                            btnAddToCamera.Enabled = true;
                            btnAddToPC.Enabled = true;
                            btnTakeAShot.Enabled = false;
                            imgShowImgGray1.Image = null;
                            btnAddData.Enabled = false;
                            txtCodeStudent.Enabled = false;
                            txtNameStudent.Enabled = false;
                            txtDay.Enabled = false; txtMonth.Enabled = false; txtYear.Enabled = false;
                            rdbFM.Enabled = false; rdbM.Enabled = false;
                            cbbBranchStudent.Enabled = false;
                            cbbFacultyStudent.Enabled = false;
                            txtCousreStudent.Enabled = false;
                        }
                        else
                        {
                            ResetAll();

                        }


                    }
                }
                catch
                {
                    MessageBox.Show("Thêm ảnh không thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (StudentSelect != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string codeItem = StudentSelect.MSSV1;
                    ListStudentOnListView.Remove(StudentSelect);// xóa trên mảng 
                    ListStudentTest.Remove(codeItem);
                    int n = lsvResult.Items.Count;
                    for (int i = 0; i < n; i++)
                    {

                        if (lsvResult.Items[i].SubItems[0].Text == codeItem)
                        {
                            lsvResult.Items.RemoveAt(i);
                            StudentSelect = null;
                            n--;
                            break;
                        }
                    }

                }
                else StudentSelect = null;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sinh viên để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteAllItem_Click(object sender, EventArgs e)
        {
            if (lsvResult.Items.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa tất cả sinh viên trong danh sách không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ListStudentTest.Clear();
                    ListStudentOnListView.Clear();
                    lsvResult.Items.Clear();
                }
            }
            else
                MessageBox.Show("Hiện tại chưa có danh sách để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                btnSaveFile.Enabled = false;
                if (ListStudentTest.Count > 0)
                {
                    cExcel.Application Excel = new cExcel.Application();
                    cExcel.Workbook exBook = Excel.Workbooks.Add(cExcel.XlWBATemplate.xlWBATWorksheet);
                    // Lấy sheet 1.
                    cExcel.Worksheet exSheet = (cExcel.Worksheet)exBook.Worksheets[1];
                    exSheet.Activate();
                    exSheet.Name = "Diểm danh";
                    // Range là ô [1,1] (A1)
                    cExcel.Range colum = (cExcel.Range)exSheet.Cells[1, 1];
                    // Ghi dữ liệu
                    colum.Value2 = "MÃ SỐ SINH VIÊN";
                    // Giãn cột
                    colum.Columns.AutoFit();
                    for (int i = 1; i <= ListStudentTest.Count; i++)
                    {
                        colum = (cExcel.Range)exSheet.Cells[i + 1, 1];
                        colum.Value2 = ListStudentTest[i - 1];
                    }
                    // Hiển thị chương trình excel
                    Excel.Visible = true;
                    btnSaveFile.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Hiện tại chưa có dữ liệu để lưu", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                if (MessageBox.Show("Máy tính của bạn hiện tại không có phần mềm hỗ trợ xuất file excel, bạn có thể lưu dưới dạng file txt", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    for (int i = 1; i < ListStudentTest.ToArray().Length + 1; i++)
                    {
                        File.AppendAllText(Application.StartupPath + "C:/FileDiemDanh", ListStudentTest.ToArray()[i - 1] + Environment.NewLine);
                    }
                }
            }
        }
        private void btnInfomation_Click(object sender, EventArgs e)
        {
            Infomation info = new Infomation();
            info.ShowDialog();
        }
        #endregion

        #region controls textBox
        private void txtCodeStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) || (txtCodeStudent.Text.Length == 10 && !char.IsControl(e.KeyChar)))
            {
                e.Handled = true;// không cho nhập
            }
        }
        private void txtNameStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            int space = txtNameStudent.Text.LastIndexOf(" ");
            if (char.IsDigit(e.KeyChar) || (e.KeyChar >= 33 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 126))
            {
                e.Handled = true;
            }
            else if (txtNameStudent.Text == "" && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;// không cho phép nhập
            }
            else if (txtNameStudent.Text == "" && char.IsLetter(e.KeyChar) == char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
            else
            {
                for (int i = 0; i < txtNameStudent.Text.Length; i++)
                {
                    if (txtNameStudent.Text[i] == 32)
                    {
                        checkSpace = true;
                    }
                    if (space == i && char.IsWhiteSpace(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    else if (checkSpace == true && char.IsLetter(e.KeyChar) == char.IsLower(e.KeyChar))
                    {
                        e.KeyChar = char.ToUpper(e.KeyChar);
                        checkSpace = false;
                    }
                    else if (!char.IsWhiteSpace(e.KeyChar))
                    {
                        e.KeyChar = char.ToLower(e.KeyChar);
                    }
                    else e.Handled = false;
                }
            }
        }
        private void txtCodeStudent_Click(object sender, EventArgs e)
        {
            txtCodeStudent.Text = "";
        }
        private void txtNameStudent_Click(object sender, EventArgs e)
        {
            txtNameStudent.Text = "";
        }
        private void txtDay_Click(object sender, EventArgs e)
        {
            txtDay.Text = "";
        }
        private void txtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) || (txtDay.Text.Length == 2 && !char.IsControl(e.KeyChar)))
            {
                e.Handled = true;// không cho nhập
            }
        }
        private void txtMonth_Click(object sender, EventArgs e)
        {
            txtMonth.Text = "";
        }
        private void txtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) || (txtMonth.Text.Length == 2 && !char.IsControl(e.KeyChar)))
            {
                e.Handled = true;// không cho nhập
            }
        }
        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) || (txtYear.Text.Length == 4 && !char.IsControl(e.KeyChar)))
            {
                e.Handled = true;// không cho nhập
            }
        }
        private void txtCourseStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) || (txtCousreStudent.Text.Length == 4 && !char.IsControl(e.KeyChar)))
            {
                e.Handled = true;// không cho nhập
            }
        }
        private void txtCourseStudent_Click(object sender, EventArgs e)
        {
            txtCousreStudent.Text = "";
        }
        private void txtEigenDistanceThreshold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) || (txtEigenDistanceThreshold.Text.Length == 4 && !char.IsControl(e.KeyChar)))
            {
                e.Handled = true;// không cho nhập
            }
        }
        private void txtEigenDistanceThreshold_Click(object sender, EventArgs e)
        {
            txtEigenDistanceThreshold.SelectAll();
        }
        #endregion

        #region controls comboBox
        private void cbbBranchStudent_Click(object sender, EventArgs e)
        {
            string factulty = cbbFacultyStudent.Text;
            switch (factulty)
            {
                case "Công nghệ thông tin":
                    {
                        cbbBranchStudent.Items.Clear();
                        cbbBranchStudent.Items.AddRange(new object[] { "Khoa học máy tính", "Hệ thống thông tin quản lý", "Mạng máy tính", "Đồ họa máy tính", "Cơ sở dữ liệu" });
                        cbbBranchStudent.ResetText();
                        break;
                    }
                case "Công nghệ sinh học":
                    {
                        cbbBranchStudent.Items.Clear();
                        cbbBranchStudent.Items.AddRange(new object[] { "Công nghệ sinh học", "Công nghệ thực phẩm", "Quản lý môi trường" });
                        cbbBranchStudent.ResetText();
                        break;
                    }
                case "Kinh tế và Quản lý công":
                    {
                        cbbBranchStudent.Items.Clear();
                        cbbBranchStudent.Items.AddRange(new object[] { "Kinh tế - Luật", "Quản lý Công" });
                        break;
                    }
                case "Kế toán - Kiểm toán":
                    {
                        cbbBranchStudent.Items.Clear();
                        this.cbbBranchStudent.Items.AddRange(new object[] { "Kế toán", "Kiểm toán" });
                        break;
                    }
                case "Xây dựng và Điện":
                    {
                        cbbBranchStudent.Items.Clear();
                        this.cbbBranchStudent.Items.AddRange(new object[] { "Quản lý xây dựng", "Cấp thoát nước", "Xây dựng dân dụng và công nghiệp" });
                        break;
                    }
                case "Luật":
                    {
                        cbbBranchStudent.Items.Clear();
                        this.cbbBranchStudent.Items.AddRange(new object[] { "Luật kinh tế", "Luật học" });
                        break;
                    }
                case "Ngoại ngữ":
                    {
                        cbbBranchStudent.Items.Clear();
                        this.cbbBranchStudent.Items.AddRange(new object[] { "Ngôn ngữ Anh", "Tiếng anh thương mại" });
                        break;
                    }
                case "Quản trị kinh doanh":
                    {
                        cbbBranchStudent.Items.Clear();
                        this.cbbBranchStudent.Items.AddRange(new object[] { "Quản trị maketing", "Quản trị kinh doanh", "Quản trị nhân lực", "Quản trị du lịch", "Kinh doanh quốc tế" });
                        break;
                    }
                case "Tài chính - Ngân hàng":
                    {
                        cbbBranchStudent.Items.Clear();
                        this.cbbBranchStudent.Items.AddRange(new object[] { "Tài chính nhà nước", "Tài chính doanh nghiệp", "Bảo hiểm", "Tài chính ngân hàng" });
                        break;
                    }
                case "XHH - CTXH - ĐNA":
                    {
                        cbbBranchStudent.Items.Clear();
                        this.cbbBranchStudent.Items.AddRange(new object[] { "Xã hội học tổ chức và Quản lý nhân sự", "Xã hội học", "Công tác xã hội" });
                        break;
                    }
                case "":
                    {
                        cbbBranchStudent.Items.Clear();
                        break;
                    }
            }
        }
        private void cbbFacultyStudent_Click(object sender, EventArgs e)
        {
            if (cbbFacultyStudent.Text != "")
            {
                cbbBranchStudent.Text = null;
            }
        }
        #endregion

        #region orther funtions
        private void ResetAll()
        {
            txtCodeStudent.Enabled = true;
            txtCodeStudent.ResetText();
            txtCodeStudent.Focus();
            txtNameStudent.Enabled = true;
            txtNameStudent.ResetText();
            txtDay.Enabled = true; txtMonth.Enabled = true; txtYear.Enabled = true;
            txtDay.ResetText();
            txtMonth.ResetText();
            txtYear.ResetText();
            rdbFM.Enabled = true; rdbM.Enabled = true;
            rdbM.Checked = false;
            rdbFM.Checked = false;
            txtCousreStudent.Enabled = true;
            txtCousreStudent.ResetText();
            cbbFacultyStudent.Enabled = true;
            cbbFacultyStudent.Text = null;
            cbbBranchStudent.Enabled = true;
            cbbBranchStudent.Text = null;
            btnCancel.Enabled = false;
            btnAddToPC.Enabled = true;
            imgShowImgGray1.Image = null;
            imgAddToCamera.Image = null;
            btnAddToCamera.Enabled = true;
            btnAddToPC.Enabled = true;
            btnTakeAShot.Enabled = false;
            btnAddData.Enabled = false;
            TrainedFace = null;
            btnCancel.Enabled = false;
            imgShowImgGray1.Image = null;
            btnAddData.Enabled = false;
            for (int i = 0; i < cbbBranchStudent.Items.Count; i++)
            {
                cbbBranchStudent.Items.RemoveAt(i);
            }
            if (check)
            {
                Application.Idle -= new EventHandler(FrameGrabberAddToCamera);
                imgAddToCamera1.Hide();// ẩn đi
                grabberAddToCamera.FlipHorizontal = !grabberAddToCamera.FlipHorizontal;
                check = !check;
            }
            //if (grabberAddToCamera != null)
            //{
            //    if (check)
            //    {
            //        Application.Idle -= new EventHandler(FrameGrabberAddToCamera);// dừng camera
            //        imgAddToCamera1.Hide();// ẩn đi
            //        grabberAddToCamera.FlipHorizontal = !grabberAddToCamera.FlipHorizontal;
            //    }
            //    check = !check;
            //}
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            grabberTest = new Capture();
            grabberTest.QueryFrame();
            grabberTest.FlipHorizontal = !grabberTest.FlipHorizontal;// đưa ảnh về cùng chiều
            btnTakeAShot.Enabled = false;
            btnCancel.Enabled = false;
            imgAddToCamera1.Hide();
            btnAddData.Enabled = false;
            // phát hiện khuôn mặt
            
            sw.Start();
            Application.Idle += new EventHandler(FrameGrabberTest);
            lsvResult.GridLines = true; // có lằng kẻ ngang
            lsvResult.FullRowSelect = true; // chọn hết nguyên dòng 
            lsvResult.View = View.Details;// xem chi tiết 

            lsvResult.Columns.Add("MSSV", 70);
            lsvResult.Columns.Add("Họ Và Tên", 125);
            lsvResult.Columns.Add("Ngày Sinh", 70);
            lsvResult.Columns.Add("Phái", 35);
            lsvResult.Columns.Add("Khóa", 40);
            lsvResult.Columns.Add("Khoa", 115);
            lsvResult.Columns.Add("Chuyên Ngành", 139);
            ToolTip tool = new ToolTip();
            tool.AutoPopDelay = 5000;
            tool.InitialDelay = 500;
            tool.ReshowDelay = 500;
            tool.ToolTipIcon = ToolTipIcon.Info;
            tool.ToolTipTitle = "Chú ý";

            tool.SetToolTip(this.label19, "Số càng nhỏ, hình ảnh được kiểm tra sẽ được xem như là đối tượng không được công nhận \nNếu ngưỡng là 0, bộ nhận dạng sẽ luôn xử lý hình ảnh được kiểm tra như là một trong những đối tượng đã biết."); // Bạn cần hiển thị gì thì lấy trong cơ sở dữ liệu ra ném vào đó là được
            tool.IsBalloon = true;
        }
        Student SearchStudenWithCode(string code)
        {
            Student st = new Student();
            for (int i = 0; i < ListStudentOnListView.Count; i++)
            {
                if (ListStudentOnListView[i].MSSV1 == code)
                {
                    st = ListStudentOnListView[i];
                    break;
                }
            }
            return st;
        }
        private void lsvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvResult.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvResult.SelectedItems[0];
                string code = item.SubItems[0].Text;
                StudentSelect = SearchStudenWithCode(code);
            }
        }
        void FrameGrabberTest(object sender, EventArgs e)
        {
            try
            {
                currentFrame = grabberTest.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                gray = currentFrame.Convert<Gray, Byte>();
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.1, 3, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                bool checkDetect = true;
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    currentFrame.Draw(f.rect, new Bgr(Color.Green), 1);
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    if (trainingImages.ToArray().Length != 0)
                    {
                        double eigenDistanceThreshold;
                        if (txtEigenDistanceThreshold.Text == "")
                        {
                            eigenDistanceThreshold = 1000;
                        }
                        else
                        {
                            eigenDistanceThreshold = double.Parse(txtEigenDistanceThreshold.Text);
                        }
                        //TermCriteria cho nhận dạng khuôn mặt với số lượng hình ảnh được đào tạo như maxIteration

                        MCvTermCriteria termCritname = new MCvTermCriteria(ContTrain, 0.001);
                        MCvTermCriteria termCritcode = new MCvTermCriteria(ContTrain, 0.001);
                        MCvTermCriteria termCritdate = new MCvTermCriteria(ContTrain, 0.001);
                        MCvTermCriteria termCritsex = new MCvTermCriteria(ContTrain, 0.001);
                        MCvTermCriteria termCritcourse = new MCvTermCriteria(ContTrain, 0.001);
                        MCvTermCriteria termCritfaculty = new MCvTermCriteria(ContTrain, 0.001);
                        MCvTermCriteria termCritbranchSD = new MCvTermCriteria(ContTrain, 0.001);
                        //Eigen face recognizer
                        
                        EigenObjectRecognizer recognizerNameSD = new EigenObjectRecognizer(trainingImages.ToArray(), nameSD.ToArray(), eigenDistanceThreshold, ref termCritname);
                        EigenObjectRecognizer recognizerCodeSD = new EigenObjectRecognizer(trainingImages.ToArray(), codeSD.ToArray(), eigenDistanceThreshold, ref termCritcode);
                        EigenObjectRecognizer recognizerDateSD = new EigenObjectRecognizer(trainingImages.ToArray(), dateSD.ToArray(), eigenDistanceThreshold, ref termCritdate);
                        EigenObjectRecognizer recognizerSexSD = new EigenObjectRecognizer(trainingImages.ToArray(), sexSD.ToArray(), eigenDistanceThreshold, ref termCritsex);
                        EigenObjectRecognizer recognizerCourseSD = new EigenObjectRecognizer(trainingImages.ToArray(), courseSD.ToArray(), eigenDistanceThreshold, ref termCritcourse);
                        EigenObjectRecognizer recognizerFacultySD = new EigenObjectRecognizer(trainingImages.ToArray(), facultySD.ToArray(), eigenDistanceThreshold, ref termCritfaculty);
                        EigenObjectRecognizer recognizerBranchSD = new EigenObjectRecognizer(trainingImages.ToArray(), branchSD.ToArray(), eigenDistanceThreshold, ref termCritbranchSD);
                       

                        nameStudent = recognizerNameSD.Recognize(result);
                        codeStudent = recognizerCodeSD.Recognize(result);
                        dateStudent = recognizerDateSD.Recognize(result);
                        sexStudent = recognizerSexSD.Recognize(result);
                        courseStudent = recognizerCourseSD.Recognize(result);
                        facultyStudent = recognizerFacultySD.Recognize(result);
                        branchStudent = recognizerBranchSD.Recognize(result);
                        
                        checkDetect = false;

                        // thử nghiệm
                        //imgShowImgGray1.Image = recognizerNameSD.AverageImage;
                        //imgShowImgGray1.Image = recognizerNameSD.EigenImages[7];

                    }
                    for (int i = 0; i < ListStudentTest.Count; i++)
                    {
                        if (ListStudentTest[i] == codeStudent)
                        {
                            checkDetect = true;
                            break;
                        }
                    }
                    if (nameStudent == "" || codeStudent == "" || dateStudent == "" || sexStudent == "" || courseStudent == "" || facultyStudent == "" || branchStudent == "")
                    {
                        checkDetect = true;
                    }
                }
                imgShowCamera.Image = currentFrame;
                if (!checkDetect)
                {
                    ListViewItem item = new ListViewItem(codeStudent);
                    item.SubItems.Add(nameStudent);
                    item.SubItems.Add(dateStudent);
                    item.SubItems.Add(sexStudent);
                    item.SubItems.Add(courseStudent);
                    item.SubItems.Add(facultyStudent);
                    item.SubItems.Add(branchStudent);
                    lsvResult.Items.Add(item);
                    ListStudentTest.Add(codeStudent);
                    StudentOnListView = new Student(codeStudent, nameStudent, dateStudent, facultyStudent, branchStudent, courseStudent, sexStudent);
                    ListStudentOnListView.Add(StudentOnListView);
                    sw.Stop();
                    double time = sw.ElapsedMilliseconds;
                    txtTime.Text = Math.Round(time, 10).ToString();
                    sw.Reset();
                }
            }
            catch
            {
                MessageBox.Show("Hiện tại camera của bạn không hoạt động", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn lưu file không?", "Lưu file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnSaveFile.PerformClick();
            }
        }
        void FrameGrabberAddToCamera(object sender, EventArgs e)
        {
            try
            {
                currentFrameAddToCamera = grabberAddToCamera.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                gray = currentFrameAddToCamera.Convert<Gray, Byte>();
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    currentFrameAddToCamera.Draw(f.rect, new Bgr(Color.Green), 1);
                }
                imgAddToCamera1.Image = currentFrameAddToCamera;
            }
            catch
            {
                MessageBox.Show("Hiện tại camera của bạn không hoạt động", "Thong báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        #endregion orther funtions
    }
}
