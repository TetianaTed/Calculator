using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI
{
    public readonly struct BMI
    {
        public string PolishMessage { get; }
        public double MinIndexValue { get; }
        public double MaxIndexValue { get; }

        public static readonly BMI WYGLODZENIE = new BMI("wygłodzenie", 0, 16);
        public static readonly BMI WYCHUDZENIE = new BMI("wychudzenie", 16, 17);
        public static readonly BMI NIEDOWAGA = new BMI("niedowaga", 17, 18.5);
        public static readonly BMI WAGA_PRAWIDLOWA = new BMI("waga_prawidłowa", 18.5, 25);
        public static readonly BMI NADWAGA = new BMI("nadwaga", 25, 30);
        public static readonly BMI I_STOPIEN_OTYLOSCI = new BMI("I_stopień_otyłości", 30, 35);
        public static readonly BMI II_STOPIEN_OTYLOSCI = new BMI("II_stopień_otyłości", 35, 40);
        public static readonly BMI OTYLOSC_SKRAJNA = new BMI("otyłość_skrajna", 40, double.MaxValue);

        private BMI(string polishMessage, double minIndexValue, double maxIndexValue)
        {
            this.PolishMessage = polishMessage;
            this.MinIndexValue = minIndexValue;
            this.MaxIndexValue = maxIndexValue;
        }

        public static BMI[] Values()
        {
            return new BMI[]
            {
                WYGLODZENIE,
                WYCHUDZENIE,
                NIEDOWAGA,
                WAGA_PRAWIDLOWA,
                NADWAGA,
                I_STOPIEN_OTYLOSCI,
                II_STOPIEN_OTYLOSCI,
                OTYLOSC_SKRAJNA
            };
        }

        public static BMI Calculate(double weight, double height)
        {
            Validate(weight, height);

            double indexBMI = Math.Round(weight / Math.Pow(height / 100, 2), 2);

            foreach (var item in Values())
            {
                if (indexBMI >= item.MinIndexValue && indexBMI < item.MaxIndexValue)
                {
                    return item;
                }
            }
            throw new ApplicationException("Should never happen");
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

        public bool IsNormal()
        {
            return this.Equals(BMI.WAGA_PRAWIDLOWA);
        }

        public bool IsWorstThan(BMI bmi)
        {
            return this.MinIndexValue < bmi.MinIndexValue;
        }
    }
}
