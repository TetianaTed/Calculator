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
            Assert.Equal("waga prawid�owa", bMICalculator1t.BMIMessage);
        }



        [Theory]
        [InlineData(55, 165, 20.20, "waga prawid�owa")]
        [InlineData(30, 170, 10.38, "wyg�odzenie")]
        [InlineData(180, 154, 75.90, "oty�o�� skrajna")]
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
 poni�ej 16 - wyg�odzenie
16 - 16.99 - wychudzenie
17 - 18.49 - niedowag�
18.5 - 24.99 - wag� prawid�ow�
25.0 - 29.9 - nadwag�
30.0 - 34.99 - 
35.0 - 39.99 - II stopie� oty�o�ci
powy�ej 40.0 - oty�o�� skrajn�
 */

        [Theory]
        [InlineData(20.20, "waga prawid�owa")]
        [InlineData(10.38, "wyg�odzenie")]
        [InlineData(75.90, "oty�o�� skrajna")]
        [InlineData(15.99, "wyg�odzenie")]
        [InlineData(16,    "wychudzenie")]
        [InlineData(16.99, "wychudzenie")]
        [InlineData(17,     "niedowaga")]
        [InlineData(18.49, "niedowaga")]
        [InlineData(18.5, "waga prawid�owa")]
        [InlineData(24.99, "waga prawid�owa")]
        [InlineData(25.0, "nadwaga")]
        [InlineData(29.9, "nadwaga")]
        [InlineData(30,   "I stopie� oty�o�ci")]
        [InlineData(34.99, "I stopie� oty�o�ci")]
        [InlineData(35,    "II stopie� oty�o�ci")]
        [InlineData(39.99, "II stopie� oty�o�ci")]
        [InlineData(40,    "oty�o�� skrajna")]
        [InlineData(40.10, "oty�o�� skrajna")]
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