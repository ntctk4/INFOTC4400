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

namespace Ntctk4CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //a list of numbers to be used in operations
        List<String> list = new List<string>();

        //a list of operations (+, -, / ,*) to be used
        //I used a list just in case I want to continous operations later
        List<String> operation = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        //This method is called when a button with a number is clicked
        //the number is added to the textblock with the rest to form the 
        //full number to be manipulated
        private void number_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = textBlock.Text + Convert.ToString((sender as Button).Content);
        }

        //This method is called when a button with an operation is clicked
        //adds the operation to a list to be stored an used later when "=" is clicked
        private void operation_Click(object sender, RoutedEventArgs e)
        {
            //made operation a list so I can do more than two number operations later.
            operation.Insert(0, Convert.ToString((sender as Button).Content));
            Console.Write(Convert.ToString((sender as Button).Content));
            //if there is no sumber in the textblock before the operation is clicked
            //make the first number a zero
            if (!String.IsNullOrEmpty(textBlock.Text))
            {
                list.Insert(0, textBlock.Text);
            }
            //once an operation is added, clear the textbox for the next number.
            textBlock.Text = "";
        }

        //this method is called when the "=" button is pressed
        //it performs the specified operation on two numbers
        //if not enough numbers, just print out "0"
        private void equals_Click(object sender, RoutedEventArgs e)
        {
            double second;
            //if not second number, then it's zero
            //otherwise convert the second number into a double
            if(textBlock.Text.Equals(""))
            {
                second = 0;
            }
            else
            { 
                second = Convert.ToDouble(textBlock.Text);
            }
            //clear out textblock to the solution can be put in it
            textBlock.Text = "";
            double first;

            //if no first number make it zero
            //otherwise grab the first number from the list
            if (list.ElementAtOrDefault(0) == null)
            {
                list.Add("0");
                first = 0;
            }
            else
            {
                first = Convert.ToDouble(list[0]);
            }
            //remove the first number from the list
            //so it can't accidently be used again
            list.RemoveAt(0);

            //if not operation then send "" to the list 
            //witch will cause the default behavior in
            //the switch statment
            if(operation.ElementAtOrDefault(0) == null)
            {
                operation.Add("");
            }
            double answer;
            //perform the operation on the two numbers otherwise 
            //just keep the first number as an answer
            switch (operation[0])
            {
                case "+" :
                    answer = first + second;
                    break;
                case "-" :
                    answer = first - second;
                    break;
                case "*":
                    answer = first * second;
                    break;
                case "/":
                    answer = first / second;
                    break;
                case "Square":
                    answer = first * first;
                    break;
                default :
                    answer = first;
                    break;
            }
            //if the second number is zero for division
            //send out an alert that the user tried an illigal operation
            //(even though in C# the answer is infinity)
            if (operation[0].Equals("/") && second == 0)
            {
                operation.RemoveAt(0);
                //put this into a message box
                MessageBox.Show("Error, can't divide by zero");
                textBlock.Text = "";
                //clear out the operation and list lists
                //to try another operation after the alert
                if (operation.ElementAtOrDefault(0) != null)
                {
                    operation.RemoveAt(0);
                }
                if (list.ElementAtOrDefault(0) != null)
                {
                    list.RemoveAt(0);
                }
            }
            else
            {
                //clear the operation list at element zero
                //and print out the solution in the textblock
                operation.RemoveAt(0);
                textBlock.Text = Convert.ToString(answer);
            }

        }

        //this method is called when the clear button is clicked
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            //when clicked this method clears out the textblock
            //and makes sure that both lists are cleared at element zero
            //so there is a clean slate when staring a new oeration
            textBlock.Text = "";
            if (operation.ElementAtOrDefault(0) != null)
            {
                operation.RemoveAt(0);
            }
            if (list.ElementAtOrDefault(0) != null)
            {
                list.RemoveAt(0);
            }
        }
    }
}
