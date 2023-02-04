using DieticianDiary.App.Helpers;
using System.Globalization;

namespace DieticianDiary.App.Concrete
{
    public class CalculateBmiService
    {
        public double GetWeight()
        {
            double weight;
            string message = "Enter weight [kg]: ";
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out weight))
                Messages.Negative("Wrong data type, enter a numeric value");

            return weight;
        }

        public double GetHeight()
        {
            double height;
            string message = "Enter height [cm]: ";
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out height))
                Messages.Negative("Wrong data type, enter a numeric value");
            height /= 100;

            return height;
        }

        public double CalculateBmi(double weight, double height)
        => weight / Math.Pow(height, 2);

        public void GetBmiMessage(double bmi)
        {
            Messages.Notice($"\nBMI is {bmi.ToString("0.00", CultureInfo.InvariantCulture)}");
            if (bmi < 18.1)
                Messages.Negative("Underweight");
            else if (bmi < 25 && bmi >= 18.1)
                Messages.Positive("Normal weight");
            else if (bmi < 30 && bmi >= 25)
                Messages.Warning("Overweight");
            else if (bmi > 30)
                Messages.Negative("Obesity");
        }
    }
}
