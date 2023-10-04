using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI
{
    public class BMICalculatorByEnum
    {
        enum BMICalculatorE
        {
            wygłodzenie,
            wychudzenie,
            niedowaga,
            waga_prawidłowa,
            nadwaga,
            I_stopień_otyłości,
            II_stopień_otyłości,
            otyłość_skrajna
        }

        public double indexBMI { get; set; }
        public string BMIMessage { get; set; }

        public BMICalculatorByEnum CalculateE(double weight, double haight)
        {
            Validate(weight, haight);
            BMICalculatorByEnum bMICalculator = new BMICalculatorByEnum();
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
            if (indexBMI < 16) return BMICalculatorE.wygłodzenie.ToString();
            if (indexBMI < 17) return BMICalculatorE.wychudzenie.ToString();
            if (indexBMI < 18.5) return BMICalculatorE.niedowaga.ToString();
            if (indexBMI < 25) return BMICalculatorE.waga_prawidłowa.ToString();
            if (indexBMI < 30) return BMICalculatorE.nadwaga.ToString();
            if (indexBMI < 35) return BMICalculatorE.I_stopień_otyłości.ToString();
            if (indexBMI < 40) return BMICalculatorE.II_stopień_otyłości.ToString();

            return BMICalculatorE.otyłość_skrajna.ToString();
        }


    }
}
