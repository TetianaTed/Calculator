﻿using System.Security.Cryptography.X509Certificates;

namespace BMI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double weight = 60;
            double height = 162;

            BMICalculator bMICalculator1 = new BMICalculator();
            bMICalculator1 = bMICalculator1.Calculate(weight,height);

            Console.WriteLine("BMI is: " + bMICalculator1.indexBMI + ". Message: " + bMICalculator1.BMIMessage);

            BMICalculatorByEnum bmiCalculator2 = new BMICalculatorByEnum(); 
            bmiCalculator2 = bmiCalculator2.CalculateE(weight,height);

            Console.WriteLine("BMI is: " + bmiCalculator2.indexBMI + ". Message: " + bmiCalculator2.BMIMessage);
        }
    }
}