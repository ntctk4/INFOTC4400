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

namespace Ntctk4ConverterApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.Write(comboBox.SelectedItem.ToString());
            //comboBox1.Items.Clear();
            //comboBox1.Items.Add("Cori");
            ComboBoxItem item = (ComboBoxItem)comboBox.SelectedItem;
            String value = item.Content.ToString();
            if (value.Equals("Inches") ||
                value.Equals("Feet") ||
                value.Equals("Yards") ||
                value.Equals("Miles") ||
                value.Equals("Centimeters") ||
                value.Equals("Meters") ||
                value.Equals("Kilometers"))
            {
                if (comboBox1.Items.Count <= 0 || !comboBox1.Items[0].ToString().Equals("Inches"))
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("Inches");
                    comboBox1.Items.Add("Feet");
                    comboBox1.Items.Add("Yards");
                    comboBox1.Items.Add("Miles");
                    comboBox1.Items.Add("Centimeters");
                    comboBox1.Items.Add("Meters");
                    comboBox1.Items.Add("Kilometers");
                }
            }
            else if (value.Equals("Fahrenheit") ||
                value.Equals("Celsius") ||
                value.Equals("Kelvin"))
            {
                if (comboBox1.Items.Count <= 0 || !comboBox1.Items[0].ToString().Equals("Fahrenheit"))
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("Fahrenheit");
                    comboBox1.Items.Add("Celsius");
                    comboBox1.Items.Add("Kelvin");
                }
            }
            else if(value.Equals("Pounds") ||
                value.Equals("Grams") ||
                value.Equals("Kilograms"))
            {
                if (comboBox1.Items.Count <= 0 || !comboBox1.Items[0].ToString().Equals("Pounds"))
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("Pounds");
                    comboBox1.Items.Add("Grams");
                    comboBox1.Items.Add("Kilograms");
                }
            }

        }

        //not sure I need this event since I don't change anything if the user 
        //closes the drop box without changing anything
        private void comboBox_DropDownClosed(object sender, EventArgs e)
        {
            Console.Write(comboBox.SelectedItem);
        }

        private void convert_Click(object sender, RoutedEventArgs e)
        {
            Double startValue = 0;
            Double convertedValue = 0;
            Boolean success = true;
            if (!Double.TryParse(startingNumTextBox.Text, out startValue))
            {
                solutionTextBlock.Text = "Invalid starting value! Please reenter a numerical value to convert.";
                return;
            }

            String value1 = "";
            String value2 = "";
            try
            {
                ComboBoxItem item = (ComboBoxItem)comboBox.SelectedItem;
                value1 = item.Content.ToString();
                value2 = comboBox1.SelectedItem.ToString();
            }
            catch(NullReferenceException ex)
            {
                solutionTextBlock.Text = "Please select a starting unit and ending unit from the drop down boxes and try again!";
                Console.Write(ex.Message);
                return;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            switch (value2)
            {
                case ("Inches"):
                    if (startValue < 0)
                    {
                        solutionTextBlock.Text = "Distance can't be negitive, try again.";
                        success = false;
                    }
                    else
                        convertedValue = Converter.toInches(startValue, value1);
                    break;
                case ("Feet"):
                    if (startValue < 0)
                    {
                        solutionTextBlock.Text = "Distance can't be negitive, try again.";
                        success = false;
                    }
                    else
                        convertedValue = Converter.toFeet(startValue, value1);
                    break;
                case ("Yards"):
                    if (startValue < 0)
                    {
                        solutionTextBlock.Text = "Distance can't be negitive, try again.";
                        success = false;
                    }
                    else
                        convertedValue = Converter.toYards(startValue, value1);
                    break;
                case ("Miles"):
                    if (startValue < 0)
                    {
                        solutionTextBlock.Text = "Distance can't be negitive, try again.";
                        success = false;
                    }
                    else
                        convertedValue = Converter.toMiles(startValue, value1);
                    break;
                case ("Centimeters"):
                    if (startValue < 0)
                    {
                        solutionTextBlock.Text = "Distance can't be negitive, try again.";
                        success = false;
                    }
                    else
                        convertedValue = Converter.toCentimeters(startValue, value1);
                    break;
                case ("Meters"):
                    if (startValue < 0)
                    {
                        solutionTextBlock.Text = "Distance can't be negitive, try again.";
                        success = false;
                    }
                    else
                        convertedValue = Converter.toMeters(startValue, value1);
                    break;
                case ("Kilometers"):
                    if (startValue < 0)
                    {
                        solutionTextBlock.Text = "Distance can't be negitive, try again.";
                        success = false;
                    }
                    else
                        convertedValue = Converter.toKilometers(startValue, value1);
                    break;
                case ("Fahrenheit"):
                    convertedValue = Converter.toFahrenheit(startValue, value1);
                    break;
                case ("Celsius"):
                    convertedValue = Converter.toCelsius(startValue, value1);
                    break;
                case ("Kelvin"):
                    convertedValue = Converter.toKelvin(startValue, value1);
                    break;
                case ("Pounds"):
                    if (startValue < 0)
                    {
                        solutionTextBlock.Text = "Mass can't be negitive, try again.";
                        success = false;
                    }
                    else
                        convertedValue = Converter.toPounds(startValue, value1);
                    break;
                case ("Grams"):
                    if (startValue < 0)
                    {
                        solutionTextBlock.Text = "Mass can't be negitive, try again.";
                        success = false;
                    }
                    else
                        convertedValue = Converter.toGrams(startValue, value1);
                    break;
                case ("Kilograms"):
                    if (startValue < 0)
                    {
                        solutionTextBlock.Text = "Mass can't be negitive, try again.";
                        success = false;
                    }
                    else
                        convertedValue = Converter.toKilograms(startValue, value1);
                    break;
                default: break;
            }
            if(success.Equals(true))
                solutionTextBlock.Text = convertedValue.ToString();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a measurement converter made for Infotec 4400 (C#) final project \nby: Nathaniel Callahan");
        }
    }
}
