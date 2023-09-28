using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI
{
    public class BMICalculator
    {
        public double indexBMI { get; set; }
        public string BMIMessage { get; set; }  

        public BMICalculator Calculate(double weight, double haight)
        {
            Validate(weight, haight);
            BMICalculator bMICalculator = new BMICalculator();
            bMICalculator.indexBMI = Math.Round(weight / Math.Pow(haight / 100, 2), 2);
            bMICalculator.BMIMessage = DetermineBMIMessage(bMICalculator.indexBMI);
            return bMICalculator;
        }

        private static void Validate(double weight, double haight)
        {
            if (weight <= 0)
            {
                throw new Exception("Podana waga nie prawidlowa");
            }
            if (haight <= 0)
            {
                throw new Exception("Podany wzrost nie jest prawidlowy");
            }
        }

        public string DetermineBMIMessage(double indexBMI)
        {           
            if (indexBMI < 16) return "wygłodzenie";           
            if (indexBMI < 17) return "wychudzenie";
            if (indexBMI < 18.5) return "niedowaga";           
            if (indexBMI < 25) return "waga prawidłowa";           
            if (indexBMI < 30) return "nadwaga";           
            if (indexBMI < 35) return "I stopień otyłości";          
            if (indexBMI < 40) return "II stopień otyłości";
            
            return "otyłość skrajna";            
        }       
    }
}
