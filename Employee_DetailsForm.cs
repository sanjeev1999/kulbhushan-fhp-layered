using FHP_BM;
using FHP_Resource;
using FHP_VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FHP_VO;
using System.Runtime.ConstrainedExecution;
using FHP_DL;

namespace File_Handling_Program
{
    /// <summary>
    /// Represents the Employee_DetailsForm class for managing employee details.
    /// </summary>
    public partial class Employee_DetailsForm : Form
    {
        ValueObject_VO Object;
        EntityHandle entityHandle;
        FileInformation file;
        public string filePath;
        AboutUsForm aboutUsForm;
        User CurrentUser;

        // IDataHandle idatahandle;

        public static int serialNum = 1;
        Dictionary<string, string> filterDictionary;


        //   Dictionary<string, bool> currentUserPermissions;
        public Employee_DetailsForm(User CurrentUser, EntityHandle entityHandle)
        {
            this.entityHandle = entityHandle;
            // this.idatahandle = idatahandle;
            this.CurrentUser = CurrentUser;
            Object = new ValueObject_VO();
            filterDictionary = new Dictionary<string, string>();
            // entityHandle = new EntityHandle();
            file = new FileInformation();
            aboutUsForm = new AboutUsForm();
            filePath = file.FilePath();
            InitializeComponent();

            if (CurrentUser.UserRole == "SUPERADMIN")
            {

            }
            if (CurrentUser.UserRole == "ADMIN")
            {

            }
            if (CurrentUser.UserRole == "GUEST")
            {
                Update.Visible = false;
                Delete.Visible = false;
                Add.Visible = false;
            }
            if (CurrentUser.UserRole == "SELF")
            {

            }
            // }
            LoadDataIntoGridView();
            dataGridView1.RowHeaderMouseClick += dataGridView1_RowHeaderMouseClick;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;



        }

        /// <summary>
        /// Loads filtered records into the DataGridView based on the given filter text.
        /// </summary>
        public void LoadDataIntoGridView1(List<EmployeeData> filterrecord)
        {
            for (int rowIdx = dataGridView1.Rows.Count - 2; rowIdx > 0; rowIdx--)
            {
                dataGridView1.Rows.RemoveAt(rowIdx);
            }

            dataGridView1.RowCount = 2;
            dataGridView1.Rows.AddRange(filterrecord.Select(record => CreateDataGridViewRow(record)).ToArray());

        }
        /// <summary>
        /// Handles the CellValueChanged event of the DataGridView to apply column-wise filtering.
        /// </summary>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex >= 0)
            {
                string changedColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
                filterDictionary[changedColumnName] = dataGridView1.Rows[0].Cells[e.ColumnIndex].Value?.ToString();
                //filterRecord = ApplyFilterForColumn(dataGridView1.Rows[0].Cells[e.ColumnIndex].Value?.ToString(), changedColumnName);
                filterRecord = ApplyFilterForColumns(filterDictionary);
                LoadDataIntoGridView1(filterRecord);
                filterRecord.Clear();
            }

        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = e.Control as TextBox;

            if (textBox != null)
            {
                textBox.TextChanged -= TextBox_TextChanged;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)

        {
            const int triggerLength = 3;
            TextBox textBox = sender as TextBox;

            if (textBox != null && textBox.Text.Length >= triggerLength)
            {



                SendKeys.Send("{ENTER}");
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

                string columnName = dataGridView1.Columns[columnIndex].Name;
                string enteredValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value?.ToString();

                if (filterDictionary.ContainsKey(columnName))
                {
                    filterDictionary[columnName] = enteredValue;
                }
                else
                {
                    filterDictionary.Add(columnName, enteredValue);
                }

                filterRecord = ApplyFilterForColumns(filterDictionary);
                LoadDataIntoGridView1(filterRecord);
                filterRecord.Clear();

            }
        }
        private List<EmployeeData> ApplyFilterForColumns(Dictionary<string, string> filterDictionary)
        {
            if (filterDictionary == null || filterDictionary.Count == 0)
            {
                return filterRecord;
            }

            IEnumerable<EmployeeData> filteredData = records;

            foreach (var filterEntry in filterDictionary)
            {
                string columnName = filterEntry.Key;
                string filterText = filterEntry.Value;
                if (filterText != null)
                {
                    switch (columnName)
                    {
                        case "SrNo":
                            filteredData = filteredData.Where(t => t.SrNo == long.Parse(filterText));
                            break;
                        case "Prefix":
                            filteredData = filteredData.Where(t => t.Prefix.Contains(filterText));
                            break;
                        case "FirstName":
                            filteredData = filteredData.Where(t => t.FirstName.Contains(filterText));
                            break;
                        case "MiddleName":
                            filteredData = filteredData.Where(t => t.MiddleName.Contains(filterText));
                            break;
                        case "LastName":
                            filteredData = filteredData.Where(t => t.LastName.Contains(filterText));
                            break;
                        case "DOB":
                            filteredData = filteredData.Where(t => t.DOB.ToString().Contains(filterText));
                            break;
                        case "DOJ":
                            filteredData = filteredData.Where(t => t.DOJ.ToString().Contains(filterText));
                            break;
                        case "CurrentAddress":
                            filteredData = filteredData.Where(t => t.CurrentAddress.Contains(filterText));
                            break;
                        case "CurrentCompany":
                            filteredData = filteredData.Where(t => t.CurrentCompany.Contains(filterText));
                            break;
                            // Add cases for other columns as needed
                    }
                }

            }

            return filteredData.ToList();
        }

        /// <summary>
        /// Applies filter for a specific column based on the filter text and column name.
        /// </summary>
        private List<EmployeeData> ApplyFilterForColumn(string filterText, string columnName)
        {

            if (columnName == "SrNo")
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    return filterRecord;
                }
                else
                {
                    return filterRecord.Where(t => t.SrNo == long.Parse(filterText)).ToList();
                }
            }
            // ------------- searching prefix
            else if (columnName == "Prefix")
            {
                return filterRecord.Where(t => t.Prefix.Contains(filterText)).ToList();
            }
            else if (columnName == "FirstName")
            {
                return filterRecord.Where(t => t.FirstName.Contains(filterText)).ToList();
            }
            else if (columnName == "MiddleName")
            {
                return filterRecord.Where(t => t.MiddleName.Contains(filterText)).ToList();
            }
            else if (columnName == "Lastname")
            {
                return filterRecord.Where(t => t.LastName.Contains(filterText)).ToList();
            }
            else if (columnName == "DOB")
            {
                return filterRecord.Where(t => t.DOB.ToString().Contains(filterText)).ToList();
            }
            else if (columnName == "DOJ")
            {
                return filterRecord.Where(t => t.DOJ.ToString().Contains(filterText)).ToList();
            }
            else if (columnName == "CurrentAddress")
            {
                return filterRecord.Where(t => t.CurrentAddress.Contains(filterText)).ToList();
            }
            else if (columnName == "CurrentCompany")
            {
                return filterRecord.Where(t => t.CurrentCompany.Contains(filterText)).ToList();
            }
            /* else if (columnName == "Qualification")
             {
                 return filterRecord.Where(t => t.Qualification.Contains(filterText)).ToList();
             }*/
            else
            {
                return null;
            }
        }


        List<EmployeeData> records;     // instance of EmployeeData
        List<EmployeeData> filterRecord;       // Create new Variable
        /// <summary>
        /// Loads all records into the DataGridView and sets initial configurations.
        /// </summary>
        public void LoadDataIntoGridView()
        {
            dataGridView1.Rows.Clear();
            records = entityHandle.ReadAllDataData();
            Object.EmpList = records;
            filterRecord = records;// Fetch all records from the file
            dataGridView1.RowCount = 2;
            dataGridView1.Rows.AddRange(records.Select(record => CreateDataGridViewRow(record)).ToArray());
            for (int row = 1; row < records.Count; row++)
            {
                dataGridView1.Rows[row].ReadOnly = true;
            }
            dataGridView1.Refresh();
        }

        private DataGridViewRow CreateDataGridViewRow(EmployeeData record)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1);

            // Set cell values based on your column names
            row.Cells[0].Value = record.SrNo;
            row.Cells[1].Value = record.Prefix;
            row.Cells[2].Value = record.FirstName;
            row.Cells[3].Value = record.MiddleName;
            row.Cells[4].Value = record.LastName;
            row.Cells[5].Value = record.DOB;
            row.Cells[6].Value = record.Qualification;
            row.Cells[7].Value = record.CurrentAddress;
            row.Cells[8].Value = record.CurrentCompany;
            row.Cells[9].Value = record.DOJ;
            return row;
        }
        /// <summary>
        /// Handles the click event of the Add button to add a new record.
        /// </summary>
        private void Add_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count - 2 >= 0)
            {
                object cellValue = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["SrNo"].Value;   //    set  serialnum
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int lastSrNo))
                {
                    serialNum = Math.Max(dataGridView1.RowCount, lastSrNo);
                    if (lastSrNo >= dataGridView1.RowCount)
                    {
                        serialNum = serialNum + 1;
                    }
                }
                else
                {
                    serialNum = dataGridView1.RowCount;
                }
            }
            Object.EditMode = 0;
            DataUpdateForm dataUpdateForm = new DataUpdateForm(Object, entityHandle);
            dataUpdateForm.Edit.Enabled = false;
            dataUpdateForm.ShowDialog();
            LoadDataIntoGridView();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                // Extract data from the selected row
                long id = Convert.ToInt64(selectedRow.Cells["SrNo"].Value);
                EmployeeData recordToUpdate = records.FirstOrDefault(record => record.SrNo == id);
                Object.EditMode = 1;
                DataUpdateForm dataUpdateForm = new DataUpdateForm(Object, entityHandle);
                DisplayRecord(recordToUpdate);
                dataUpdateForm.ShowDialog();
                LoadDataIntoGridView();

                void DisplayRecord(EmployeeData record)
                {
                    dataUpdateForm.Add.Enabled = false;
                    dataUpdateForm.SrNoText.Text = record.SrNo.ToString();
                    dataUpdateForm.FirstNameText.Text = record.FirstName;
                    dataUpdateForm.MiddleNameText.Text = record.MiddleName;
                    dataUpdateForm.LastNameText.Text = record.LastName;
                    dataUpdateForm.PrifixText.Text = record.Prefix;
                    dataUpdateForm.CurrentAddressText.Text = record.CurrentAddress;
                    dataUpdateForm.CurrentCompanyText.Text = record.CurrentCompany;
                    dataUpdateForm.DOBPicker1.Text = record.DOB.ToString();
                    dataUpdateForm.DOJPicker1.Text = record.DOB.ToString();
                    dataUpdateForm.QualificationcomboBox1.Text = record.Qualification?.ToString() ?? "DefaultValue";
                }
            }
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Delete Row Data?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index > 0)
                {
                    Object.IsDelete = true;
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];                                    // Extract data from the selected row
                    long id = Convert.ToInt64(selectedRow.Cells["SrNo"].Value);                                     // Remove the row from the DataGridView
                    dataGridView1.Rows.Remove(selectedRow); 
                    EmployeeData recordToRemove = records.FirstOrDefault(record => record.SrNo == id);               // Remove the record from the allRecords list              
                    records.Remove(recordToRemove);
                    entityHandle.DeleteData(recordToRemove);
                   // UpdateFile();       // this is for file

                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
        }
        /// <summary>
        /// Updates the file after deleting a record by overwriting it with the updated records.
        /// </summary>
        private void UpdateFile()
        {
            File.WriteAllText(filePath, string.Empty);
            foreach (var record in records)
            {
                entityHandle.AddData(record);
            }
            MessageBox.Show("Record deleted successfully.");
        }

        /// <summary>
        /// Handles the click event on the row header to set button states based on the selected row.
        /// </summary>
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            Object.RowIndex = e.RowIndex - 1;


            if (rowIndex == 0)
            {

            }
            else if (rowIndex < dataGridView1.RowCount - 1)
            {
                Object.EditMode = 2;
                DataUpdateForm dataUpdateForm = new DataUpdateForm(Object, entityHandle);
                dataUpdateForm.ShowDialog();
            }
            else
            {
                if (dataGridView1.Rows.Count - 2 >= 0)
                {
                    object cellValue = dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells["SrNo"].Value;   //    set  serialnum
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int lastSrNo))
                    {
                        serialNum = Math.Max(dataGridView1.RowCount, lastSrNo);
                        if (lastSrNo >= dataGridView1.RowCount)
                        {
                            serialNum = serialNum + 1;
                        }
                    }
                    else
                    {
                        serialNum = dataGridView1.RowCount;
                    }
                }
                Object.EditMode = 0;
                DataUpdateForm dataUpdateForm = new DataUpdateForm(Object, entityHandle);
                dataUpdateForm.Edit.Enabled = false;
                dataUpdateForm.ShowDialog();
                LoadDataIntoGridView();
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            Object.RowIndex = e.RowIndex - 1;
            if (rowIndex == dataGridView1.Rows.Count - 1)
            {
                Add.Enabled = true;
                Update.Enabled = false;
                Delete.Enabled = false;
            }
            else
            {
                Add.Enabled = false;
                Update.Enabled = true;
                Delete.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the click event of the Search button to apply filter based on the search text.
        /// </summary>
        private void Search_Click(object sender, EventArgs e)
        {
            string serchText = SearchBox.Text;
            LoadDataIntoGridView1(ApplyFilterForAll(serchText));
        }
        /// <summary>
        /// Handles the click event of the AboutUs button to display the About Us form.
        /// </summary>
        private void AboutUs_Click(object sender, EventArgs e)
        {
            aboutUsForm.ShowDialog();
            LoadDataIntoGridView();
        }

        /// <summary>
        /// Handles the click event of the ClearSearchFilter button to clear the search filter and load all data.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ClearSearchFIlter_Click(object sender, EventArgs e)
        {
            LoadDataIntoGridView();
        }
        /// <summary>
        /// Applies the filter to all records based on the given filter text.
        /// </summary>
        private List<EmployeeData> ApplyFilterForAll(string filterText)
        {
            return records
    .Where(record =>
        record.Prefix.Contains(filterText) ||
        record.FirstName.Contains(filterText) ||
        record.MiddleName.Contains(filterText) ||
        record.LastName.Contains(filterText) ||
        record.DOB.ToString().Contains(filterText) ||
        record.Qualification.ToString().Contains(filterText) ||
        record.CurrentAddress.Contains(filterText) ||
        record.CurrentCompany.Contains(filterText) ||
        record.DOJ.ToString().Contains(filterText)
    )
    .ToList();
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows[0].Index > 0)
            {
                Object.EditMode = 2;
                DataUpdateForm dataUpdateForm = new DataUpdateForm(Object, entityHandle);
                dataUpdateForm.ShowDialog();
            }
        }


    }
}
