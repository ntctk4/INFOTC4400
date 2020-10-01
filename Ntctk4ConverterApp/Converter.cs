using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntctk4ConverterApp
{
    static class Converter
    {
        public static Double toInches(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Inches"):
                    answer = startValue;
                    break;
                case ("Feet"):
                    answer = startValue * 12;
                    break;
                case ("Yards"):
                    answer = startValue * 36;
                    break;
                case ("Miles"):
                    answer = startValue * 63360;
                    break;
                case ("Centimeters"):
                    answer = startValue * 0.393701;
                    break;
                case ("Meters"):
                    answer = startValue * 39.3701;
                    break;
                case ("Kilometers"):
                    answer = startValue * 39370.1;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toFeet(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Inches"):
                    answer = startValue / 12;
                    break;
                case ("Feet"):
                    answer = startValue;
                    break;
                case ("Yards"):
                    answer = startValue * 3;
                    break;
                case ("Miles"):
                    answer = startValue * 5280;
                    break;
                case ("Centimeters"):
                    answer = startValue * 0.0328084;
                    break;
                case ("Meters"):
                    answer = startValue * 3.28084;
                    break;
                case ("Kilometers"):
                    answer = startValue * 3280.84;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toYards(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Inches"):
                    answer = startValue * 0.0277778;
                    break;
                case ("Feet"):
                    answer = startValue * 0.333333;
                    break;
                case ("Yards"):
                    answer = startValue;
                    break;
                case ("Miles"):
                    answer = startValue * 1760;
                    break;
                case ("Centimeters"):
                    answer = startValue * 0.0109361;
                    break;
                case ("Meters"):
                    answer = startValue * 1.09361;
                    break;
                case ("Kilometers"):
                    answer = startValue * 1093.61;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toMiles(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Inches"):
                    answer = startValue * 1.57826e-5;
                    break;
                case ("Feet"):
                    answer = startValue * 0.000189394;
                    break;
                case ("Yards"):
                    answer = startValue * 0.000568182;
                    break;
                case ("Miles"):
                    answer = startValue;
                    break;
                case ("Centimeters"):
                    answer = startValue * 6.21371e-6;
                    break;
                case ("Meters"):
                    answer = startValue * 0.000621371;
                    break;
                case ("Kilometers"):
                    answer = startValue * 0.621371;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toCentimeters(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Inches"):
                    answer = startValue * 2.54;
                    break;
                case ("Feet"):
                    answer = startValue * 30.48;
                    break;
                case ("Yards"):
                    answer = startValue * 91.44;
                    break;
                case ("Miles"):
                    answer = startValue * 160934;
                    break;
                case ("Centimeters"):
                    answer = startValue;
                    break;
                case ("Meters"):
                    answer = startValue * 100;
                    break;
                case ("Kilometers"):
                    answer = startValue * 100000;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toMeters(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Inches"):
                    answer = startValue * 0.0254;
                    break;
                case ("Feet"):
                    answer = startValue * 0.3048;
                    break;
                case ("Yards"):
                    answer = startValue * 0.9144;
                    break;
                case ("Miles"):
                    answer = startValue * 1609.34;
                    break;
                case ("Centimeters"):
                    answer = startValue * 0.01;
                    break;
                case ("Meters"):
                    answer = startValue;
                    break;
                case ("Kilometers"):
                    answer = startValue * 1000;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toKilometers(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Inches"):
                    answer = startValue * 2.54e-5;
                    break;
                case ("Feet"):
                    answer = startValue * 0.0003048;
                    break;
                case ("Yards"):
                    answer = startValue * 0.0009144;
                    break;
                case ("Miles"):
                    answer = startValue * 1.60934;
                    break;
                case ("Centimeters"):
                    answer = startValue * 1e-5;
                    break;
                case ("Meters"):
                    answer = startValue * 0.001;
                    break;
                case ("Kilometers"):
                    answer = startValue;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toFahrenheit(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Fahrenheit"):
                    answer = startValue;
                    break;
                case ("Celsius"):
                    answer = (startValue * 1.8)+32;
                    break;
                case ("Kelvin"):
                    answer = (startValue * 1.8) - 459.67;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toCelsius(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Fahrenheit"):
                    answer = (startValue - 32) * 1.8;
                    break;
                case ("Celsius"):
                    answer = startValue;
                    break;
                case ("Kelvin"):
                    answer = startValue - 273.15;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toKelvin(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Fahrenheit"):
                    answer = (startValue + 459.67) * 1.8;
                    break;
                case ("Celsius"):
                    answer = startValue + 273.15;
                    break;
                case ("Kelvin"):
                    answer = startValue;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toPounds(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Pounds"):
                    answer = startValue;
                    break;
                case ("Grams"):
                    answer = startValue * 0.00220462;
                    break;
                case ("Kilograms"):
                    answer = startValue * 2.20462;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toGrams(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Pounds"):
                    answer = startValue * 453.592;
                    break;
                case ("Grams"):
                    answer = startValue;
                    break;
                case ("Kilograms"):
                    answer = startValue * 1000;
                    break;
                default: break;
            }

            return answer;
        }

        public static Double toKilograms(Double startValue, String units)
        {
            Double answer = 0;
            switch (units)
            {
                case ("Pounds"):
                    answer = startValue * 0.453592;
                    break;
                case ("Grams"):
                    answer = startValue * 0.001;
                    break;
                case ("Kilograms"):
                    answer = startValue;
                    break;
                default: break;
            }

            return answer;
        }

    }
}
