using NUnit.Framework;
using System;

namespace StringCalculatorKata.Test
{
    public class Tests
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            var expectedResult = 0;
            Assert.AreEqual(expectedResult, StringCalculator.Add(string.Empty));
        }

        [Test]
        public void Add_StringContainingSingleNumber_ReturnsTheNumberItself()
        {
            var numbers = 4;
            var expectedResult = 4;
            Assert.AreEqual(expectedResult, StringCalculator.Add($"{numbers}"));
        }

        [Test]
        public void Add_TwoNumbersSeparatedByComma_ReturnsTheirSum()
        {
            var numbers = "5,3";
            var expectedResult = 8;
            Assert.AreEqual(expectedResult, StringCalculator.Add(numbers));
        }

        [TestCase("1,2,3", 6)]
        [TestCase("1, 2, 3, 5", 11)]
        [TestCase("22,0,14", 36)]
        [TestCase("1 \n2,3", 6)]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[*][%]\n1*2%3", 6)]
        public void Add_ThreeNumbersSeparatedByComma_ReturnsTheirSum(string numbers, int expectedResult)
        {
            Assert.AreEqual(expectedResult, StringCalculator.Add(numbers));
        }
       
        [TestCase("8,  7,   15", 30)]
        [TestCase("5,0,3,1001", 8)]
        [TestCase("5,0,4,1000", 1009)]
        [TestCase("1,2,3,4", 10)]
        [TestCase("24,26,65", 115)]
        public void Add_MoreThanThreeNumbersSeparatedByComma_ReturnsTheirSum(string input, int result)
        {
            Assert.AreEqual(result, StringCalculator.Add(input));
        }

        [TestCase("1,2,3,4,5,-5")]
        [TestCase("-1,1,2,9")]
        [TestCase("5,6,8, -5, -1")]
        public void Add_StringContainingNegativeNumbers_Throws(string numbers)
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.Add(numbers));
        }
    }
}