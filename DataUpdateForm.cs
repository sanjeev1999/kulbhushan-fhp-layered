using FHP_BM;
using System;
using System.Windows.Forms;
using FHP_VO;
using static FHP_VO.Education_Type;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using FHP_DL;

namespace File_Handling_Program
{
    internal class DataUpdateForm : Form
    {

        public Button Add;
        public Button Clear;
        public Label SrNo;
        public Label Prefix;
        public Label FirstName;
        public Label MiddleName;
        public Label LastName;
        public Label Qualification;
        public Label CurrentAddress;
        public Label DOJ;
        public Label DOB;
        public Label CurrentCompany;
        public TextBox SrNoText;
        public TextBox PrifixText;
        public TextBox FirstNameText;
        public TextBox MiddleNameText;
        public TextBox LastNameText;
        public TextBox CurrentAddressText;
        public TextBox CurrentCompanyText;
        public DateTimePicker DOBPicker1;
        public DateTimePicker DOJPicker1;
        public ComboBox QualificationcomboBox1;
        public Button Edit;



        FHP_Resource.Message msg = new FHP_Resource.Message();
        EntityHandle entityHandle;
        private Button btn_First;
        private Button btn_Previous;
        private Button btn_Last;
        private Button btn_Next;
        ValueObject_VO Object;
        int currentRecordIndex;
        private List<EmployeeData> records;
        //Education_Type education_Type = new Education_Type();

        public DataUpdateForm(ValueObject_VO VO, EntityHandle entityHandle)
        {
            
            this.entityHandle= entityHandle;
            Object = VO;
            InitializeComponent();
            LoadQualificationEnum();
            SrNoText.Text = Employee_DetailsForm.serialNum.ToString();
            SrNoText.ReadOnly = true;
            currentRecordIndex = Object.RowIndex;
            records = Object.EmpList;

            DOBPicker1.CustomFormat = " ";
            DOJPicker1.CustomFormat = " ";
            DOBPicker1.Format = DateTimePickerFormat.Custom;
            DOJPicker1.Format = DateTimePickerFormat.Custom;
            DOBPicker1.ValueChanged += DOBPicker1_ValueChanged;
            DOJPicker1.ValueChanged += DOJPicker1_ValueChanged;

            if (Object.EditMode == 2)
            {
                switchToViewForm();
                DisplayRecord(records[Object.RowIndex]);
            }
            if (Object.EditMode == 1 || Object.EditMode == 0)
            {
                switchToEditModeForm();
            }

        }
        private void LoadQualificationEnum()
        {
            // Get the values of the EducationLevel enum
            Array values = Enum.GetValues(typeof(Education_Type.EducationLevel));
            QualificationcomboBox1.DataSource = values;

        }

        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataUpdateForm));
            this.Add = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.SrNo = new System.Windows.Forms.Label();
            this.Prefix = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.Label();
            this.MiddleName = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.Qualification = new System.Windows.Forms.Label();
            this.CurrentAddress = new System.Windows.Forms.Label();
            this.DOJ = new System.Windows.Forms.Label();
            this.DOB = new System.Windows.Forms.Label();
            this.CurrentCompany = new System.Windows.Forms.Label();
            this.SrNoText = new System.Windows.Forms.TextBox();
            this.PrifixText = new System.Windows.Forms.TextBox();
            this.FirstNameText = new System.Windows.Forms.TextBox();
            this.MiddleNameText = new System.Windows.Forms.TextBox();
            this.LastNameText = new System.Windows.Forms.TextBox();
            this.CurrentAddressText = new System.Windows.Forms.TextBox();
            this.CurrentCompanyText = new System.Windows.Forms.TextBox();
            this.DOBPicker1 = new System.Windows.Forms.DateTimePicker();
            this.DOJPicker1 = new System.Windows.Forms.DateTimePicker();
            this.QualificationcomboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_First = new System.Windows.Forms.Button();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.btn_Last = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(170, 360);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(102, 45);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit.Location = new System.Drawing.Point(293, 360);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(107, 45);
            this.Edit.TabIndex = 1;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.Location = new System.Drawing.Point(424, 360);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(81, 45);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // SrNo
            // 
            this.SrNo.AutoSize = true;
            this.SrNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrNo.Location = new System.Drawing.Point(74, 57);
            this.SrNo.Name = "SrNo";
            this.SrNo.Size = new System.Drawing.Size(50, 16);
            this.SrNo.TabIndex = 3;
            this.SrNo.Text = "Sr No.";
            // 
            // Prefix
            // 
            this.Prefix.AutoSize = true;
            this.Prefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prefix.Location = new System.Drawing.Point(78, 95);
            this.Prefix.Name = "Prefix";
            this.Prefix.Size = new System.Drawing.Size(46, 16);
            this.Prefix.TabIndex = 3;
            this.Prefix.Text = "Prefix";
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstName.Location = new System.Drawing.Point(36, 139);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(88, 16);
            this.FirstName.TabIndex = 3;
            this.FirstName.Text = "First Name*";
            // 
            // MiddleName
            // 
            this.MiddleName.AutoSize = true;
            this.MiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MiddleName.Location = new System.Drawing.Point(25, 180);
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.Size = new System.Drawing.Size(99, 16);
            this.MiddleName.TabIndex = 3;
            this.MiddleName.Text = "Middle Name";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastName.Location = new System.Drawing.Point(36, 218);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(81, 16);
            this.LastName.TabIndex = 3;
            this.LastName.Text = "Last Name";
            // 
            // Qualification
            // 
            this.Qualification.AutoSize = true;
            this.Qualification.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Qualification.Location = new System.Drawing.Point(376, 139);
            this.Qualification.Name = "Qualification";
            this.Qualification.Size = new System.Drawing.Size(99, 16);
            this.Qualification.TabIndex = 3;
            this.Qualification.Text = "Qualification*";
            // 
            // CurrentAddress
            // 
            this.CurrentAddress.AutoSize = true;
            this.CurrentAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentAddress.Location = new System.Drawing.Point(6, 277);
            this.CurrentAddress.Name = "CurrentAddress";
            this.CurrentAddress.Size = new System.Drawing.Size(118, 16);
            this.CurrentAddress.TabIndex = 3;
            this.CurrentAddress.Text = "Current Address";
            // 
            // DOJ
            // 
            this.DOJ.AutoSize = true;
            this.DOJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOJ.Location = new System.Drawing.Point(421, 95);
            this.DOJ.Name = "DOJ";
            this.DOJ.Size = new System.Drawing.Size(43, 16);
            this.DOJ.TabIndex = 3;
            this.DOJ.Text = "DOJ*";
            // 
            // DOB
            // 
            this.DOB.AutoSize = true;
            this.DOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DOB.Location = new System.Drawing.Point(425, 57);
            this.DOB.Name = "DOB";
            this.DOB.Size = new System.Drawing.Size(39, 16);
            this.DOB.TabIndex = 3;
            this.DOB.Text = "DOB";
            // 
            // CurrentCompany
            // 
            this.CurrentCompany.AutoSize = true;
            this.CurrentCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentCompany.Location = new System.Drawing.Point(344, 180);
            this.CurrentCompany.Name = "CurrentCompany";
            this.CurrentCompany.Size = new System.Drawing.Size(131, 16);
            this.CurrentCompany.TabIndex = 3;
            this.CurrentCompany.Text = "Current Company*";
            // 
            // SrNoText
            // 
            this.SrNoText.Location = new System.Drawing.Point(144, 52);
            this.SrNoText.Multiline = true;
            this.SrNoText.Name = "SrNoText";
            this.SrNoText.Size = new System.Drawing.Size(141, 34);
            this.SrNoText.TabIndex = 4;
            // 
            // PrifixText
            // 
            this.PrifixText.Location = new System.Drawing.Point(145, 89);
            this.PrifixText.Multiline = true;
            this.PrifixText.Name = "PrifixText";
            this.PrifixText.Size = new System.Drawing.Size(141, 38);
            this.PrifixText.TabIndex = 4;
            // 
            // FirstNameText
            // 
            this.FirstNameText.Location = new System.Drawing.Point(144, 133);
            this.FirstNameText.Multiline = true;
            this.FirstNameText.Name = "FirstNameText";
            this.FirstNameText.Size = new System.Drawing.Size(141, 35);
            this.FirstNameText.TabIndex = 4;
            // 
            // MiddleNameText
            // 
            this.MiddleNameText.Location = new System.Drawing.Point(144, 174);
            this.MiddleNameText.Multiline = true;
            this.MiddleNameText.Name = "MiddleNameText";
            this.MiddleNameText.Size = new System.Drawing.Size(141, 35);
            this.MiddleNameText.TabIndex = 4;
            // 
            // LastNameText
            // 
            this.LastNameText.Location = new System.Drawing.Point(144, 215);
            this.LastNameText.Multiline = true;
            this.LastNameText.Name = "LastNameText";
            this.LastNameText.Size = new System.Drawing.Size(141, 35);
            this.LastNameText.TabIndex = 4;
            // 
            // CurrentAddressText
            // 
            this.CurrentAddressText.Location = new System.Drawing.Point(145, 259);
            this.CurrentAddressText.Multiline = true;
            this.CurrentAddressText.Name = "CurrentAddressText";
            this.CurrentAddressText.Size = new System.Drawing.Size(505, 44);
            this.CurrentAddressText.TabIndex = 4;
            // 
            // CurrentCompanyText
            // 
            this.CurrentCompanyText.Location = new System.Drawing.Point(505, 177);
            this.CurrentCompanyText.Multiline = true;
            this.CurrentCompanyText.Name = "CurrentCompanyText";
            this.CurrentCompanyText.Size = new System.Drawing.Size(145, 76);
            this.CurrentCompanyText.TabIndex = 4;
            // 
            // DOBPicker1
            // 
            this.DOBPicker1.Location = new System.Drawing.Point(505, 52);
            this.DOBPicker1.Name = "DOBPicker1";
            this.DOBPicker1.Size = new System.Drawing.Size(141, 22);
            this.DOBPicker1.TabIndex = 5;
            // 
            // DOJPicker1
            // 
            this.DOJPicker1.Location = new System.Drawing.Point(505, 89);
            this.DOJPicker1.Name = "DOJPicker1";
            this.DOJPicker1.Size = new System.Drawing.Size(141, 22);
            this.DOJPicker1.TabIndex = 6;
            // 
            // QualificationcomboBox1
            // 
            this.QualificationcomboBox1.FormattingEnabled = true;
            this.QualificationcomboBox1.Location = new System.Drawing.Point(505, 131);
            this.QualificationcomboBox1.Name = "QualificationcomboBox1";
            this.QualificationcomboBox1.Size = new System.Drawing.Size(141, 24);
            this.QualificationcomboBox1.TabIndex = 7;
            // 
            // btn_First
            // 
            this.btn_First.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_First.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_First.Location = new System.Drawing.Point(162, 324);
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(83, 40);
            this.btn_First.TabIndex = 8;
            this.btn_First.Text = "First";
            this.btn_First.UseVisualStyleBackColor = false;
            this.btn_First.Click += new System.EventHandler(this.btn_First_Click);
            // 
            // btn_Previous
            // 
            this.btn_Previous.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Previous.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Previous.Location = new System.Drawing.Point(268, 324);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(84, 40);
            this.btn_Previous.TabIndex = 9;
            this.btn_Previous.Text = "Previous";
            this.btn_Previous.UseVisualStyleBackColor = false;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_Last
            // 
            this.btn_Last.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Last.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Last.Location = new System.Drawing.Point(495, 324);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(85, 40);
            this.btn_Last.TabIndex = 10;
            this.btn_Last.Text = "Last";
            this.btn_Last.UseVisualStyleBackColor = false;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Next.Location = new System.Drawing.Point(371, 324);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(93, 40);
            this.btn_Next.TabIndex = 10;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // DataUpdateForm
            // 
            this.ClientSize = new System.Drawing.Size(776, 439);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Last);
            this.Controls.Add(this.btn_Previous);
            this.Controls.Add(this.btn_First);
            this.Controls.Add(this.QualificationcomboBox1);
            this.Controls.Add(this.DOJPicker1);
            this.Controls.Add(this.DOBPicker1);
            this.Controls.Add(this.LastNameText);
            this.Controls.Add(this.MiddleNameText);
            this.Controls.Add(this.CurrentCompanyText);
            this.Controls.Add(this.FirstNameText);
            this.Controls.Add(this.CurrentAddressText);
            this.Controls.Add(this.PrifixText);
            this.Controls.Add(this.SrNoText);
            this.Controls.Add(this.Qualification);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.MiddleName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.CurrentCompany);
            this.Controls.Add(this.DOJ);
            this.Controls.Add(this.DOB);
            this.Controls.Add(this.Prefix);
            this.Controls.Add(this.CurrentAddress);
            this.Controls.Add(this.SrNo);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Add);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataUpdateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void DOBPicker1_ValueChanged(object sender, EventArgs e)
        {
            // When the value changes, update the CustomFormat to display the selected date
            DOBPicker1.CustomFormat = "yyyy-MM-dd"; // Replace with your desired format
        }

        private void DOJPicker1_ValueChanged(object sender, EventArgs e)
        {
            // When the value changes, update the CustomFormat to display the selected date
            DOJPicker1.CustomFormat = "yyyy-MM-dd"; // Replace with your desired format
        }

        private void Add_Click(object sender, EventArgs e)
        {

            long SrNo = Employee_DetailsForm.serialNum;
            string firstName = FirstNameText.Text;
            string middleName = MiddleNameText.Text;
            string lastName = LastNameText.Text;
            string prefix = PrifixText.Text;
            DateTime dob = DOBPicker1.Value;          // Convert to DateTime
            DateTime doj = DOJPicker1.Value;
            string CurrentAdd = CurrentAddressText.Text;
            string CurrentCompany = CurrentCompanyText.Text;
            byte qualification = (byte)QualificationcomboBox1.SelectedIndex;


            // Create a Record instance

            EmployeeData newRecord = new EmployeeData
            {
                SrNo = SrNo,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Prefix = prefix,
                DOB = dob,
                DOJ = doj,
                CurrentAddress = CurrentAdd,
                CurrentCompany = CurrentCompany,
                Qualification = GetEducationLevelFromIndex(qualification).ToString(),
            };
            Object.EmployeeData = newRecord;
            // byte s = 0;
            if (entityHandle.CheckEmployeedata(Object))
            {


                entityHandle.AddData(newRecord);
                MessageBox.Show("Data Added Successfully");

                this.Close();
            }
            else
            {
                // MessageBox.Show("Please fill mandatory fields");               
                MessageBox.Show(Object.Message.ToString());

            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            long SrNo = Convert.ToInt64(SrNoText.Text);
            string firstName = FirstNameText.Text;
            string middleName = MiddleNameText.Text;
            string lastName = LastNameText.Text;
            string prefix = PrifixText.Text;
            DateTime dob = (DOBPicker1.Value);  // Convert to DateTime
            DateTime doj = (DOJPicker1.Value);
            string CurrentAdd = CurrentAddressText.Text;
            string CurrentCompany = CurrentCompanyText.Text;
            byte qualification = (byte)QualificationcomboBox1.SelectedIndex;

            EmployeeData newRecord = new EmployeeData
            {

                SrNo = SrNo,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Prefix = prefix,
                DOB = dob,
                DOJ = doj,
                CurrentAddress = CurrentAdd,
                CurrentCompany = CurrentCompany,
                Qualification = GetEducationLevelFromIndex(qualification).ToString(),

            };
            Object.EmployeeData = newRecord;
            byte s = 0;
            if (entityHandle.CheckEmployeedata(Object))
            {
                entityHandle.UpdateData(newRecord);
                MessageBox.Show("Edit Successfully");
            }
            else
            {
                // MessageBox.Show("Please fill mandatory fields");
                MessageBox.Show(msg.GetDescriptionStringFromByte(s));
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to clear the data?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            DateTime dob = DOBPicker1.Value;
            DateTime doj = DOJPicker1.Value;
            if (result == DialogResult.OK)
            {

                FirstNameText.Clear();
                MiddleNameText.Clear();
                LastNameText.Clear();
                PrifixText.Clear();
                CurrentAddressText.Clear();
                CurrentCompanyText.Clear();
                dob = (DateTime.Now);  // Convert to DateTime
                doj = (DateTime.Now);
                //byte qualification = QualificationText.Text;
            }
            else
            {
            }
        }
        public static EducationLevel GetEducationLevelFromIndex(byte index)
        {
            if (index >= 0 && index < Enum.GetNames(typeof(EducationLevel)).Length)
            {
                return (EducationLevel)index;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range for the EducationLevel enum.");
            }
        }

        private void DisplayRecord(EmployeeData record)
        {
            SrNoText.Text = record.SrNo.ToString();
            FirstNameText.Text = record.FirstName;
            MiddleNameText.Text = record.MiddleName;
            LastNameText.Text = record.LastName;
            PrifixText.Text = record.Prefix;
            CurrentAddressText.Text = record.CurrentAddress;
            CurrentCompanyText.Text = record.CurrentCompany;
            DOBPicker1.Text = record.DOB.ToString();
            DOJPicker1.Text = record.DOB.ToString();
            QualificationcomboBox1.Text = record.Qualification.ToString();

        }
        private void btn_First_Click(object sender, EventArgs e)
        {
            currentRecordIndex = 0;
            DisplayRecord(records[currentRecordIndex]);
            btn_Previous.Enabled = false;
            btn_Next.Enabled = true;
        }

        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (currentRecordIndex > 0)
            {
                currentRecordIndex--;
                DisplayRecord(records[currentRecordIndex]);
                btn_Next.Enabled = true;
            }

        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (currentRecordIndex < records.Count - 1)
            {
                currentRecordIndex++;
                DisplayRecord(records[currentRecordIndex]);
                btn_Previous.Enabled = true;
            }
        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            currentRecordIndex = records.Count - 1;
            DisplayRecord(records[currentRecordIndex]);
            btn_Next.Enabled = false;
            btn_Previous.Enabled = true;
        }

        public void switchToViewForm()
        {
            SrNoText.ReadOnly = true;
            FirstNameText.ReadOnly = true;
            MiddleNameText.ReadOnly = true;
            LastNameText.ReadOnly = true;
            PrifixText.ReadOnly = true;
            CurrentAddressText.ReadOnly = true;
            CurrentCompanyText.ReadOnly = true;
            DOBPicker1.Enabled = false;
            DOJPicker1.Enabled = true;

            Add.Visible = false;
            Edit.Visible = false;
            Clear.Visible = false;
            QualificationcomboBox1.Enabled = false;
        }
        public void switchToEditModeForm()
        {


            btn_First.Visible = false;
            btn_Last.Visible = false;
            btn_Previous.Visible = false;
            btn_Next.Visible = false;
        }

    }
}
