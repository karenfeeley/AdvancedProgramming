using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCalculator
{
    
    public class Calculator
    {
        private static readonly string[] operations2Num = { "+", "-", "/", "*", "%" };
        private static readonly string[] operations1Num = { "x^2", "sqR", "cube", "cubeR", "abs" };
        public string Number { get; set; }
        public string Total { get; set; }
        public string tempOper1;
        public string tempOper2;
        public double answer;

        //Methods - assigning the inputs
        public string SetInput(string tempInput)
        {
            //Check if tempInput is a number = assign to Number
            if (IsValidNumber(tempInput))
            {
                if (tempOper1 == null && tempOper2 == null)//concatenate the inputs into 1 number
                {
                    Number = Number + tempInput;
                    return Number;
                }
                else if(tempOper2 != null)//second number input for calcs requiring 2 inputs
                {
                    Number = tempInput;
                    return Number;
                }
                return Number;
            }
            //else assign the valid "operations" to tempOper1 or tempOper2
            else if(IsValidOperation1Num(tempInput))
            {
                tempOper1 = tempInput;
                Total = Number;
                return tempOper1;
            }
            else
            {
                tempOper2 = tempInput;
                Total = Number;
                Number = null;
                return tempOper2;
            }
        }

        //Methods - calculations - requires 1 input number
        public double GetCalculator1NumResults(string operation)
        {
             switch (operation)
            {
                //Calc functions: x^2,sqR,cube,cubeR,abs
                case "x^2":
                    answer = Squared(double.Parse(Total));
                    tempOper1 = null;
                    Total = null;
                    Number = null;
                    break;
                case "sqR":
                    answer = SquareRoot(double.Parse(Total));
                    tempOper1 = null;
                    Total = null;
                    Number = null;
                    break;
                case "cube":
                    answer = Cubed(double.Parse(Total));
                    tempOper1 = null;
                    Total = null;
                    Number = null;
                    break;
                case "cubeR":
                    answer = CubeRoot(double.Parse(Total));
                    tempOper1 = null;
                    Total = null;
                    Number = null;
                    break;
                case "abs":
                    answer = Absolute(double.Parse(Total));
                    tempOper1 = null;
                    Total = null;
                    Number = null;
                    break;
                default:
                    break;
            }
            return answer;
         }
        //Methods - calculations - requires 2 input numbers
        public double GetCalculator2NumResults(string operation)
        {
            switch (operation)
            {
                //Calc functions: +,-,/,*,%
                case "+":
                    answer = Add(double.Parse(Total), double.Parse(Number));
                    tempOper2 = null;
                    Total = null;
                    Number = null;
                    break;
                case "-":
                    answer = Subtract(double.Parse(Total), double.Parse(Number));
                    tempOper2 = null;
                    Total = null;
                    Number = null;
                    break;
                case "/":
                    answer = Divide(double.Parse(Total), double.Parse(Number));
                    tempOper2 = null;
                    Total = null;
                    Number = null;
                    break;
                case "*":
                    answer = Multiply(double.Parse(Total), double.Parse(Number));
                    tempOper2 = null;
                    Total = null;
                    Number = null;
                    break;
                case "%":
                    answer = Remainder(double.Parse(Total), double.Parse(Number));
                    tempOper2 = null;
                    Total = null;
                    Number = null;
                    break;
                default:
                    break;
            }
            return answer;
        }           
            
        //Function Calculation Methods
        public double Add(double first, double second)
        {
            return first + second;
        }

        public double Subtract(double first, double second)
        {
            return first - second;
        }

        public double Divide(double first, double second)
        {
            if (second == 0)
            {
                return 0;
            }
            return first / second;
        }

        public double Multiply(double first, double second)
        {
            return first * second;
        }

        public double Remainder(double first, double second)
        {
            if (second == 0)
            {
                return 0;
            }
            return first % second;
        }

        public double Squared(double first)
        {
            return first * first;
        }

        public double SquareRoot(double first)
        {
            if (first < 0)
            {
                return 0;
            }
            return Math.Sqrt(first);
        }

        public double Cubed(double first)
        {
            return first * first * first;
        }
        public double CubeRoot(double first)
        {
            if (first <= 0)
            {
                return 0;
            }
            return Math.Pow(first, (double)1.0 / 3.0);
        }
        public double Absolute(double first)
        {
            return Math.Abs(first);
        }
        
        //Methods - validating whether input is a number or operator
            public bool IsValidNumber(string input)
        {
            double parse;
            return double.TryParse(input, out parse);
        }

        //validating if operation is in readonly array => return true
        public bool IsValidOperation1Num(string input) => operations1Num.Contains(input);
        public bool IsValidOperation2Num(string input) => operations2Num.Contains(input);
     
    }
}
