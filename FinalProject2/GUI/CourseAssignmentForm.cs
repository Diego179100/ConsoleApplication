
using FinalProject2.Data_Access;
using FinalProject2.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace FinalProject2
{
    public partial class CourseAssignmentForm : Form
    {
        private User UserLogged;
        //private UserType userinstance;


        public CourseAssignmentForm()
        {
            InitializeComponent();
            addTeacherToDataList();
            addCourseToDataList();
            addRegistrationToDataList();

        }

        private void buttonAddT_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    //add Teacher to database

                    var teacherToAdd = new Teacher();
                    teacherToAdd.TeacherId = Int32.Parse(textBoxTeachearId.Text);
                    teacherToAdd.FirstName = textBoxFirstNameT.Text;
                    teacherToAdd.LastName = textBoxLastNameT.Text;
                    teacherToAdd.Email = textBoxEmailT.Text;
                    context.Teachers.Add(teacherToAdd);
                    context.SaveChanges();
                    MessageBox.Show($"Teacher Added Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeacherToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addTeacherToDataList()
        {
            // select Teacher from database 
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var selectTeacher = from Teacher in context.Teachers select Teacher;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Id");
                    dt.Columns.Add("First Name");
                    dt.Columns.Add("Last Name");
                    dt.Columns.Add("Email");

                    foreach (var teacher in selectTeacher)
                    {
                        dt.Rows.Add(teacher.TeacherId, teacher.FirstName, teacher.LastName,
                                    teacher.Email);
                    }

                    dataGridView1.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void buttonEditT_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var teacherToEdit = from Teacher
                                        in context.Teachers
                                        where Teacher.TeacherId.ToString() == textBoxTeachearId.Text
                                        select Teacher;

                    foreach (var teacher in teacherToEdit)
                    {
                        teacher.FirstName = textBoxFirstNameT.Text;
                        teacher.LastName = textBoxLastNameT.Text;
                        teacher.Email = textBoxEmailT.Text;    
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Teacher Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeacherToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDeleteT_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var teacherTodelete = from Teacher
                                          in context.Teachers
                                          where Teacher.TeacherId.ToString() == textBoxTeachearId.Text
                                          select Teacher;

                    foreach (var teacher in teacherTodelete)
                    {
                        context.Teachers.Remove(teacher);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Teacher Deleted Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeacherToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSearchT_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var teacherToserach = from Teacher
                                          in context.Teachers
                                          where Teacher.TeacherId.ToString() == textBoxSearchT.Text
                                          select Teacher;

                    if (!teacherToserach.Any())
                    {
                        MessageBox.Show("TeacherId not found" +
                            "" +
                            ".");
                        return;
                    }

                    foreach (var teacher in teacherToserach)
                    {
                        labelInfoT.Text = "Full Name "+ teacher.FirstName + " " + teacher.LastName + " " + "email: "+ teacher.Email;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAddC_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    //add Course to database

                    var courseToAdd = new Cours();
                    courseToAdd.CourseNumber = textBoxCourseN.Text;
                    courseToAdd.CourseTitle = textBoxCourseT.Text;
                    courseToAdd.Duration = Int32.Parse(textBoxDuration.Text);
                    context.Courses.Add(courseToAdd);
                    context.SaveChanges();
                    MessageBox.Show($"Course Added Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCourseToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addCourseToDataList()
        {
            // select Course from database 
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var selectCourse = from Cours in context.Courses select Cours;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("CourseNumber");
                    dt.Columns.Add("CourseTitle");
                    dt.Columns.Add("Duration");

                    foreach (var cours in selectCourse)
                    {
                        dt.Rows.Add(cours.CourseNumber, cours.CourseTitle, cours.Duration);
                    }

                    dataGridView2.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void buttonEditC_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var courseToEdit = from Cours
                                        in context.Courses
                                        where Cours.CourseNumber.ToString() == textBoxCourseN.Text
                                        select Cours;

                    foreach (var cours in courseToEdit)
                    {
                        cours.CourseNumber = textBoxCourseN.Text;
                        cours.CourseTitle = textBoxCourseT.Text;
                        cours.Duration = Int32.Parse(textBoxDuration.Text);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Course Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCourseToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDeleteC_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var courseTodelete = from Cours
                                          in context.Courses
                                          where Cours.CourseNumber.ToString() == textBoxCourseN.Text
                                          select Cours;

                    foreach (var cours in courseTodelete)
                    {
                        context.Courses.Remove(cours);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Course Deleted Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCourseToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSearchC_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var courseToserach = from Cours
                                          in context.Courses
                                          where Cours.CourseNumber.ToString() == textBoxSearchC.Text
                                          select Cours;

                    if (!courseToserach.Any())
                    {
                        MessageBox.Show("CourseNumber not found.");
                        return;
                    }

                    foreach (var cours in courseToserach)
                    {
                        labelInfoC.Text = "Code : " + cours.CourseNumber + "  "+ "Name : " + cours.CourseTitle + "  " + "Duration : " + cours.Duration+ " Hours";
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExitC_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void buttonAddRegistration_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    // Get the Course and Teacher IDs from the input
                    int teacherId = Int32.Parse(textBoxTId.Text);
                    string courseNumber = textBoxCN.Text;

                    // Check if the CourseNumber exists in Courses table
                    var courseExists = context.Courses.Any(c => c.CourseNumber == courseNumber);

                    // Check if the TeacherId exists in Teachers table
                    var teacherExists = context.Teachers.Any(t => t.TeacherId == teacherId);

                    if (courseExists && teacherExists)
                    {
                        var registrationToAdd = new Registration();
                        registrationToAdd.RegistrationID = Int32.Parse(textBoxRegistrationiD.Text);
                        registrationToAdd.TeacherId = teacherId;
                        registrationToAdd.CourseNumber = courseNumber;
                        context.Registrations.Add(registrationToAdd);
                        context.SaveChanges();
                        MessageBox.Show($"Registration Added Successfully", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        addRegistrationToDataList();
                    }
                    else
                    {
                        MessageBox.Show($"Course Number or Teacher ID doesn't exist in the data.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addRegistrationToDataList()
        {
            // select Registration from database 
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var selectRegistration = from Registration in context.Registrations select Registration;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Registration");
                    dt.Columns.Add("TeacherId");
                    dt.Columns.Add("CourseNumber");

                    foreach (var registration in selectRegistration)
                    {
                        dt.Rows.Add(registration.RegistrationID, registration.TeacherId, registration.CourseNumber);
                    }

                    dataGridView3.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void buttonEditRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var registrationToEdit = from Registration
                                        in context.Registrations
                                       where Registration.RegistrationID.ToString() == textBoxRegistrationiD.Text
                                       select Registration;

                    foreach (var registration in registrationToEdit)
                    {
                        registration.RegistrationID = Int32.Parse(textBoxRegistrationiD.Text);
                        registration.TeacherId = Int32.Parse(textBoxTId.Text);
                        registration.CourseNumber = textBoxCN.Text;
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Registration Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addRegistrationToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDeleteRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var registrationTodelete = from Registration
                                          in context.Registrations
                                         where Registration.RegistrationID.ToString() == textBoxRegistrationiD.Text
                                         select Registration;

                    foreach (var registration in registrationTodelete)
                    {
                        context.Registrations.Remove(registration);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Registration Deleted Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addRegistrationToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonsearchRegistration_Click(object sender, EventArgs e)
        {
            
                try
                {
                    using (var context = new TeacherCourseDBEntities())
                    {
                        var registrationToserach = from Registration
                                              in context.Registrations
                                                   where Registration.RegistrationID.ToString() == textBoxsearchRegistrationID.Text
                                                   select Registration;

                        if (!registrationToserach.Any())
                        {
                            MessageBox.Show("RegistrationID not found.");
                            return;
                        }

                        foreach (var registration in registrationToserach)
                        {
                            labelInfoR1.Text = "TeacherId : " + registration.TeacherId;
                            labelInfoR2.Text = "CourseNumber : " + registration.CourseNumber;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            

        }

        private void buttonExitRegistration_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabCourses_Click(object sender, EventArgs e)
        {

        }

        private void CourseAssignmentForm_Load(object sender, EventArgs e )
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    LoginForm loginForm = (LoginForm)this.Owner;
                    UserLogged = loginForm.UserLogged;
                    
                    if (UserLogged != null)
                    {
                        modifyUser();
                    }
                    else
                    {
                        MessageBox.Show("Quitting the application", "Error");
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


        }

        private void modifyUser()
        {
            try
            {
                if (UserLogged.JobTitle != null)
                {
                    using (var context = new TeacherCourseDBEntities())
                    {
                       

                        if (UserLogged.JobTitle == "Teacher")
                        {
                            tabControl1.TabPages.Remove(tabRegistration);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

