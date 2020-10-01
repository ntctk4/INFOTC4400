using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace Ntctk4ClassesAndObjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //using a list instead of an array list makes sorting 
        //the students much easyer
        List<Student> students = new List<Student>();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            double gpa;

            Student newStudent = new Student();

            //set the new students first name and last name.
            //if the name is empty or it is the default values, then 
            //a message is displayed and the user is asked to input new data
            newStudent.FirstName = fnameTextBox.Text;
            newStudent.LastName = lnameTextBox.Text;
            if(newStudent.FirstName == "" || newStudent.LastName == "")
            {
                MessageBox.Show("Please input a valid first name/last name");
                return;
            }


            //first checks to see if the value in the textbox is actually an int
            //I made it so that a 4 integer number doesn't have to be 4 integers as long
            //as there are enogh zeros in front of the number to have 4 digts
            //for exampel: 0003 is valid because there are 4 digits in total with the 
            //three zeros in front of the three.
            if (idTextBox.Text.Length != 4 || !Int32.TryParse(idTextBox.Text, out id))
            {
                MessageBox.Show("Incorrect formatting of the ID, Please try again");
                return;
            }
            //if value can be an int put it in the id value of new student 
            newStudent.Id = id;
            //next make sure the id is not negitive.
            //from the code above -124 is valid because the string length
            //is 4 and it converts to an int. Make sure that doesn't go through
            if (newStudent.Id < 0)
            {
                MessageBox.Show("ID can't be a negitive number");
                return;
            }

            //make sure the gpa value is a double
            if(!Double.TryParse(gpaTextBox.Text, out gpa))
            {
                MessageBox.Show("Please enter a correctly formatted GPA");
                return;
            }

            //if double set gpa to it.
            //new students gpa makes sure that the value is between 0.0 and 4.0
            newStudent.Gpa = gpa;
            if(newStudent.Gpa < 0.0)
            {
                MessageBox.Show("Incorrect values for GPA, please try again");
                return;
            }

            //all data is valid so the new student is added to the students list
            students.Add(newStudent);

            //since 0 to 999 is valid, need to make sure
            //the total number of digits is 4, so add 0's 
            //to the beginning of the number until the string length 
            //is 4. 
            string stringId = id.ToString();
            while(stringId.Length != 4)
            {
                stringId = "0" + stringId;
            }

            //make sure that if gpa is a whole nuber
            //that ".0" is added to make is look nicer.
            string stringGpa = newStudent.Gpa.ToString();
            while(stringGpa.Length < 3)
            {
                stringGpa = stringGpa + ".0";
            }

            //output the new student to the output textbox
            //to display new data with already collected data.
            Output.Text += "\n" + newStudent.FirstName + "\n" + newStudent.LastName + "\n" + stringId + "\n" + stringGpa + "\n" + "---------------------------";

        }

        //clears textbox so new data can be inputed
        private void clear_textBox(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "";
        }

        //called when any of the sort buttons are clicked.
        private void sort_Click(object sender, RoutedEventArgs e)
        {
            //does the specific sort (fname, lname, id, gpa) that calls this method
            DoSort(sender);

            //clears textbox with list in it.
            Output.Text = "";
            //prints the new sorted list out in the output textbox
            //also formats gpa and id so they look better
            foreach(Student student in students)
            {
                string stringId = student.Id.ToString();
                while (stringId.Length != 4)
                {
                    stringId = "0" + stringId;
                }

                string stringGpa = student.Gpa.ToString();
                while (stringGpa.Length < 3)
                {
                    stringGpa = stringGpa + ".0";
                }
                Output.Text += "\n" + student.FirstName + "\n" + student.LastName + "\n" + stringId + "\n" + stringGpa + "\n" + "---------------------------";
            }
            return;
        }
        
        //does the specific sort that was called by the specific button
        private void DoSort(object sender)
        {
            string sortType = (sender as Button).Name;

            switch(sortType)
            {
                case "gpa":
                    //calls a static Student method to compare all the students by gpa
                    students.Sort(Student.CompareByGPA);
                    break;
                case "id":
                    //calls a static Student method to compare all the students by id
                    students.Sort(Student.CompareById);
                    break;
                case "fname":
                    //calls a static Student method to compare all the students by fname
                    students.Sort(Student.CompareByFirstName);
                    break;
                case "lname":
                    //calls a static Student method to compare all the students by lname
                    students.Sort(Student.CompareByLastName);
                    break;
                default: break;
            }
        }
    }
}
