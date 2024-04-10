using FHP_BM;
using FHP_DL;
using FHP_VO;
using System;
using System.Windows.Forms;

namespace File_Handling_Program
{
    /// <summary>
    /// User Validation form
    /// </summary>
    public partial class UserValidationForm : Form
    {
        ValidateUsers validatUser;
        User CurrentUser;
        Employee_DetailsForm employeeform;
        bool IsUserExist;
        IDataHandle iDtatHandle;
        EntityHandle entityHandle;
        ValidateUsers validateUser;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="validate"></param>
        public UserValidationForm(EntityHandle entityHandle, ValidateUsers validateUser)
        {    this.entityHandle = entityHandle;
             this.validateUser = validateUser;

            ///this.iDtatHandle = iDtatHandle;
            CurrentUser= new User();
           // validatUser = new ValidateUsers();
            InitializeComponent();
            this.FormClosing += UserValidation_FormClosing;
            //Text_Password.UseSystemPasswordChar = true;
         
        }
        /// <summary>
        /// Login Event for User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogIn_Click(object sender, EventArgs e)
        {
            CurrentUser.UserName = UserName.Text;
            CurrentUser.Password = Text_Password.Text;
           

            IsUserExist = validateUser.isUserPresent(CurrentUser);
            if (IsUserExist)
            {
                employeeform = new Employee_DetailsForm(CurrentUser, entityHandle);
                this.Visible = false;
                employeeform.ShowDialog();
                this.Close();
                            
            }
            else
            {
                MessageBox.Show("invalid User");
                CurrentUser.ErrorMessage = string.Empty;
            }

        }
        private void UserValidation_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (!IsUserExist)
            {
                DialogResult result = MessageBox.Show("Are you want to Exit?", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Text_Passwod_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserValidationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
