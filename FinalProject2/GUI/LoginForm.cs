
using FinalProject2.Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject2.GUI
{
    public partial class LoginForm : Form
    {
        public User UserLogged { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        //private string usertype;
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            

            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    string enteredUserID = textBoxUserID.Text;
                    string enteredPassword = textBoxPassword.Text;
                 
                    var user = context.Users.FirstOrDefault(u => u.UserID.ToString() == enteredUserID);
                    

                    if (user != null)
                    {
                        if (user.Password == enteredPassword) // Verify the password
                        {
                            MessageBox.Show($"Welcome! You are a: {user.JobTitle}");
                            UserLogged = user;
                            CourseAssignmentForm courseAssignmentForm = new CourseAssignmentForm();
                            this.Hide();
                            courseAssignmentForm.Owner = this;
                            DialogResult = DialogResult.OK;
                            courseAssignmentForm.ShowDialog();
                            //LoginForm loginForm = new LoginForm();
                            //loginForm.Hide();
                            //loginForm.Close();
                        
                        }
                        else
                        {
                            MessageBox.Show("Password is incorrect. You are not allow to enter");
                            textBoxUserID.Clear();
                            textBoxPassword.Clear();
                        }
                    }

                    else
                    {
                        MessageBox.Show("UserID not found. You are not allow to enter");
                        textBoxUserID.Clear();
                        textBoxPassword.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxUserID.Clear();
            textBoxPassword.Clear();
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
