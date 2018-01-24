using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCalculator;



namespace TDDCalculatorTests
{
    [TestClass]
    public class TDDCalculatorTest
    {
        [TestMethod]
        public void ShouldPrintWholeNumbersEntered()
        {
            Calculator calc = new Calculator();
            calc.SetInput("1");
            calc.SetInput("5");
            calc.SetInput("7");
            Assert.AreEqual("157", calc.Number);
        }
        [TestMethod]
        public void ShouldPrintDecimalNumbersEntered()
        {
            Calculator calc = new Calculator();
            calc.SetInput("1.3");
            calc.SetInput("5");
            calc.SetInput("7");
            Assert.AreEqual("1.357", calc.Number);
        }
        [TestMethod]
        public void ShouldEndProgram()
        {
            Calculator calc = new Calculator();
            calc.SetInput("e");
            Assert.AreEqual("Goodbye!", actual:"Goodbye!");
            calc.SetInput("E");
            Assert.AreEqual("Goodbye!", actual: "Goodbye!");
        }
        [TestMethod]
        public void ShouldShowInvalidEntry()
        {
            Calculator calc = new Calculator();
            calc.SetInput("f");
            Assert.AreEqual("Incorrect input !", actual: calc.SetInput("Incorrect input !"));
            calc.SetInput("x^5");
            Assert.AreEqual("Incorrect input !", actual: calc.SetInput("Incorrect input !"));
            calc.SetInput("123v");
            Assert.AreEqual("Incorrect input !", actual: calc.SetInput("Incorrect input !"));
        }
        [TestMethod]
        public void ShouldShowLastNumberAfterOperEntry()
        {
            Calculator calc = new Calculator();
            calc.SetInput("13");
            calc.SetInput("5");
            calc.SetInput("7");
            Assert.AreEqual("1357", calc.Number);
            calc.SetInput("+");
            calc.SetInput("34");
            Assert.AreEqual("34", calc.Number);
        }
        [TestMethod]
        public void ShouldAddNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(4, calc.Add(2, 2));
            Assert.AreEqual(5, calc.Add(2, 3));
            Assert.AreEqual(-1, calc.Add(2, -3));
            Assert.AreEqual(0, calc.Add(2, -2));
            Assert.AreEqual(2, calc.Add(2, 0));
            Assert.AreEqual(-5, calc.Add(-2, -3));
        }
        [TestMethod]
        public void ShouldSubtractNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(0, calc.Subtract(2, 2));
            Assert.AreEqual(-1, calc.Subtract(2, 3));
            Assert.AreEqual(5, calc.Subtract(2, -3));
            Assert.AreEqual(4, calc.Subtract(2, -2));
            Assert.AreEqual(2, calc.Subtract(2, 0));
            Assert.AreEqual(1, calc.Subtract(-2, -3));
        }
        [TestMethod]
        public void ShouldDivideNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(1, calc.Divide(2, 2));
            Assert.AreEqual(.5, calc.Divide(2, 4));
            Assert.AreEqual(-.5, calc.Divide(2, -4));
            Assert.AreEqual(-1, calc.Divide(2, -2));
            Assert.AreEqual(0, calc.Divide(2, 0));
            Assert.AreEqual(.5, calc.Divide(-2, -4));
        }
        [TestMethod]
        public void ShouldMultiplyNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(4, calc.Multiply(2, 2));
            Assert.AreEqual(8, calc.Multiply(2, 4));
            Assert.AreEqual(-8, calc.Multiply(2, -4));
            Assert.AreEqual(-4, calc.Multiply(2, -2));
            Assert.AreEqual(0, calc.Multiply(2, 0));
            Assert.AreEqual(8, calc.Multiply(-2, -4));
        }
        [TestMethod]
        public void ShouldGiveRemainderNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(0, calc.Remainder(2, 2));
            Assert.AreEqual(2, calc.Remainder(2, 4));
            Assert.AreEqual(2, calc.Remainder(2, -4));
            Assert.AreEqual(0, calc.Remainder(2, -2));
            Assert.AreEqual(0, calc.Remainder(2, 0));
            Assert.AreEqual(-2, calc.Remainder(-2, -4));
        }
        [TestMethod]
        public void ShouldSquareNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(4, calc.Squared(2));
            Assert.AreEqual(9, calc.Squared(3));
            Assert.AreEqual(4, calc.Squared(-2));
            Assert.AreEqual(2.25, calc.Squared(1.5));
            Assert.AreEqual(9, calc.Squared(-3));
            Assert.AreEqual(0, calc.Squared(0));
        }
        [TestMethod]
        public void ShouldSquareRootNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(3, calc.SquareRoot(9));
            Assert.AreEqual(0, calc.SquareRoot(-9));
            Assert.AreEqual(.3, calc.SquareRoot(.09));
            Assert.AreEqual(0, calc.SquareRoot(0));
        }
        [TestMethod]
        public void ShouldCubeNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(8, calc.Cubed(2));
            Assert.AreEqual(27, calc.Cubed(3));
            Assert.AreEqual(-8, calc.Cubed(-2));
            Assert.AreEqual(-27, calc.Cubed(-3));
            Assert.AreEqual(0, calc.Cubed(0));
        }
        [TestMethod]
        public void ShouldCubeRootNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(2, calc.CubeRoot(8));
            Assert.AreEqual(3, calc.CubeRoot(27));
            Assert.AreEqual(0, calc.CubeRoot(-8));
            Assert.AreEqual(0, calc.CubeRoot(0));
        }
        [TestMethod]
        public void ShouldAbsoluteNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(2, calc.Absolute(2));
            Assert.AreEqual(1.5, calc.Absolute(-1.5));
            Assert.AreEqual(0, calc.Absolute(0));
        }
        [TestMethod]
        public void ShouldAddUserInput()
        {
            Calculator calc = new Calculator();
            calc.Total = "5";
            calc.Number = "5";
            calc.GetCalculator2NumResults(operation:"+");
            Assert.AreEqual(10, actual: calc.answer);
        }
        [TestMethod]
        public void ShouldSubtractUserInput()
        {
            Calculator calc = new Calculator();
            calc.SetInput("5");
            calc.SetInput("-");
            calc.SetInput("5");
            calc.GetCalculator2NumResults(operation: "-");
            Assert.AreEqual(0, actual: calc.answer);
        }
        [TestMethod]
        public void ShouldDivideUserInput()
        {
            Calculator calc = new Calculator();
            calc.SetInput("5");
            calc.SetInput("/");
            calc.SetInput("5");
            calc.GetCalculator2NumResults(operation:"/");
            Assert.AreEqual(1, actual: calc.answer);
            calc.SetInput("5");
            calc.SetInput("/");
            calc.SetInput("0");
            calc.GetCalculator2NumResults(operation:"/");
            Assert.AreEqual(0, actual: calc.answer);
        }
        [TestMethod]
        public void ShouldMultiplyUserInput()
        {
            Calculator calc = new Calculator();
            calc.SetInput("5");
            calc.SetInput("*");
            calc.SetInput("5");
            calc.GetCalculator2NumResults(operation: "*");
            Assert.AreEqual(25, actual: calc.answer);
        }
        [TestMethod]
        public void ShouldRemainderUserInput()
        {
            Calculator calc = new Calculator();
            calc.SetInput("5");
            calc.SetInput("%");
            calc.SetInput("4");
            calc.GetCalculator2NumResults(operation: "%");
            Assert.AreEqual(1, actual: calc.answer);
        }
        [TestMethod]
        public void ShouldSquareUserInput()
        {
            Calculator calc = new Calculator();
            calc.SetInput("5");
            calc.SetInput("x^2");
            calc.GetCalculator1NumResults(operation: "x^2");
            Assert.AreEqual(25, actual: calc.answer);
        }
        [TestMethod]
        public void ShouldSquareRootUserInput()
        {
            Calculator calc = new Calculator();
            calc.SetInput("2116");
            calc.SetInput("sqR");
            calc.GetCalculator1NumResults(operation: "sqR");
            Assert.AreEqual(46, actual: calc.answer);
        }
        [TestMethod]
        public void ShouldcubeUserInput()
        {
            Calculator calc = new Calculator();
            calc.SetInput("5");
            calc.SetInput("cube");
            calc.GetCalculator1NumResults(operation: "cube");
            Assert.AreEqual(125, actual: calc.answer);
        }
        [TestMethod]
        public void ShouldcubeRUserInput()
        {
            Calculator calc = new Calculator();
            calc.SetInput("216");
            calc.SetInput("cubeR");
            calc.GetCalculator1NumResults(operation: "cubeR");
            Assert.AreEqual(6, actual: calc.answer, delta: .0001);
        }
        [TestMethod]
        public void ShouldAbsoluteUserInput()
        {
            Calculator calc = new Calculator();
            calc.SetInput("-125");
            calc.SetInput("abs");
            calc.GetCalculator1NumResults(operation: "abs");
            Assert.AreEqual(125, actual: calc.answer);
        }
    }
}
