using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCalculator
{
    class TDDCalculatorAPP
    {
        static void Main(string[] args)
        {
            try {
                Calculator calc = new Calculator();
                bool doLoop = true;

                Console.WriteLine("Welcome to the Calc App");
                Console.WriteLine("Calc functions include: +,-,/,*,%,x^2,sqR,cube,cubeR,abs\n");
                do
                {
                    Console.Write(value: "Enter a number, calc function or 'E' to Exit: ");
                    string tempInput = Console.ReadLine();
                    if (tempInput == "e" || tempInput == "E")
                    {
                        doLoop = false;
                        Console.WriteLine("Goodbye!");
                    }
                    else if (calc.IsValidNumber(tempInput) || calc.IsValidOperation1Num(tempInput)
                            || calc.IsValidOperation2Num(tempInput))
                    {
                        calc.SetInput(tempInput);
                        Console.WriteLine(calc.Number);
                        if (calc.tempOper1 != null)
                        {
                            calc.GetCalculator1NumResults(tempInput);
                            Console.WriteLine("Answer: " + calc.answer);
                        }
                        else if (calc.tempOper2 != null && calc.Number != null)
                        {
                            calc.GetCalculator2NumResults(calc.tempOper2);
                            Console.WriteLine("Answer: " + calc.answer);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input !");
                        calc.Number = null;
                        calc.tempOper1 = null;
                        calc.tempOper2 = null;
                    }
                } while (doLoop);

            }
            catch(Exception e)
            {
                Console.WriteLine("An error has occured, {0} ", e.Message);

            }
        }
        

    }
}
