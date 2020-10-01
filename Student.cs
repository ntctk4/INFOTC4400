using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntctk4ClassesAndObjects
{
    class Student //: IComparable<Student>
    {
        //fields for storing the student data
        private int id;
        private double gpa;
        private string firstName;
        private string lastName;


        //default construtor that is originally called
        //uses the other consturctor to set default values
        //if for some reasso one of the values aren't set
        //this constructor calls the other one and sets default values
        //for all the fields.
        public Student() : this (4444, "Callahan", "Nathaniel", 3.8)
        {

        }

        public Student(int id, string lastName, string firstName, double gpa)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.gpa = gpa;
        }

        //Id property for student
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }

        }

        //gpa property for student
        //makes sure gpa is between 0.0 and 4.0
        public double Gpa
        {
            get { return gpa; }
            set {
                    if(value < 0.0 || value > 4.0)
                    {
                        gpa = -1.0;
                        return;
                    }

                    gpa = value;
                }
        }

        //first name property for student
        public string FirstName
        {
            get { return firstName;  }
            set {
                    if(value == "First Name")
                    {
                        firstName = "";
                        return;
                    }

                    firstName = value;
                }
        }

        //last name property for student
        public string LastName
        {
            get { return lastName; }
            set {
                    if (value == "Last Name")
                    {
                        lastName = "";
                        return;
                    }
                    lastName = value;
                }
        }

        //static method to compare two student objects gpas to sort the students list
        public static int CompareByGPA(Student student1, Student student2)
        {
            return student1.Gpa.CompareTo(student2.Gpa);
        }

        //static method to compare two student objects first names to sort the students list
        public static int CompareByFirstName(Student student1, Student student2)
        {
            return student1.FirstName.CompareTo(student2.FirstName);
        }

        //static method to compare two student objects last names to sort the students list
        public static int CompareByLastName(Student student1, Student student2)
        {
            return student1.LastName.CompareTo(student2.LastName);
        }

        //static method to compare two student objects ids to sort the students list
        public static int CompareById(Student student1, Student student2)
        {
            return student1.Id.CompareTo(student2.Id);
        }

    }
}
