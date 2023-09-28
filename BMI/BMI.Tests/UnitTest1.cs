namespace BMI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldConvertToBMI()
        {
            //arrange
            double weight = 55;
            double height = 165;
            BMICalculator bMICalculator1t = new BMICalculator();

            //act
            bMICalculator1t = bMICalculator1t.Calculate(weight, height);

            //assert
            Assert.Equal(20.20, bMICalculator1t.indexBMI);
            Assert.Equal("waga prawid³owa", bMICalculator1t.BMIMessage);
        }



        [Theory]
        [InlineData(55, 165, 20.20, "waga prawid³owa")]
        [InlineData(30, 170, 10.38, "wyg³odzenie")]
        [InlineData(180, 154, 75.90, "oty³oœæ skrajna")]
        public void Should_Correct_BMIIndex_With_Message(double givenWeight,
                                                         double givenHeight,
                                                         double expectedIndexBMI,
                                                         string expectedBMIMessage)
        {
            //arrange
            BMICalculator bMICalculator1t = new BMICalculator();

            //act
            bMICalculator1t = bMICalculator1t.Calculate(givenWeight, givenHeight);

            //assert
            Assert.Equal(expectedIndexBMI, bMICalculator1t.indexBMI);
            Assert.Equal(expectedBMIMessage, bMICalculator1t.BMIMessage);
        }

        /*
 poni¿ej 16 - wyg³odzenie
16 - 16.99 - wychudzenie
17 - 18.49 - niedowagê
18.5 - 24.99 - wagê prawid³ow¹
25.0 - 29.9 - nadwagê
30.0 - 34.99 - 
35.0 - 39.99 - II stopieñ oty³oœci
powy¿ej 40.0 - oty³oœæ skrajn¹
 */

        [Theory]
        [InlineData(20.20, "waga prawid³owa")]
        [InlineData(10.38, "wyg³odzenie")]
        [InlineData(75.90, "oty³oœæ skrajna")]
        [InlineData(15.99, "wyg³odzenie")]
        [InlineData(16,    "wychudzenie")]
        [InlineData(16.99, "wychudzenie")]
        [InlineData(17,     "niedowaga")]
        [InlineData(18.49, "niedowaga")]
        [InlineData(18.5, "waga prawid³owa")]
        [InlineData(24.99, "waga prawid³owa")]
        [InlineData(25.0, "nadwaga")]
        [InlineData(29.9, "nadwaga")]
        [InlineData(30,   "I stopieñ oty³oœci")]
        [InlineData(34.99, "I stopieñ oty³oœci")]
        [InlineData(35,    "II stopieñ oty³oœci")]
        [InlineData(39.99, "II stopieñ oty³oœci")]
        [InlineData(40,    "oty³oœæ skrajna")]
        [InlineData(40.10, "oty³oœæ skrajna")]
        public void Should_Correct_Message(double givenIndexBMI,
                                           string expectedBMIMessage)
        {
            //arrange
            BMICalculator bMICalculator1t = new BMICalculator();

            //act
            bMICalculator1t.indexBMI = givenIndexBMI;
            bMICalculator1t.BMIMessage = bMICalculator1t.DetermineBMIMessage(givenIndexBMI);

            //assert
            Assert.Equal(expectedBMIMessage, bMICalculator1t.BMIMessage);
        }

    }

}