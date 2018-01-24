# -*- coding: utf-8 -*-
"""
Created on Sat Jan 20 12:12:37 2018

@author: Admin
"""

import unittest
from calculator import Calculator

class CalculatorTest(unittest.TestCase):
    
    def setUp(self):
        self.calc = Calculator()
     
  
    def testPrintDecimalNumbers(self):
        self.calc.setInput(1)
        self.calc.setInput(.23)
        self.calc.setInput(45)
        self.assertEqual("1.2345", self.calc.number)
        
    def testShowInputError(self):
        self.calc.setInput('df')
        self.assertEqual("Incorrect Input, please try again !", "Incorrect Input, please try again !")
        self.calc.setInput('*123')
        self.assertEqual("Incorrect Input, please try again !", "Incorrect Input, please try again !")
    
    def testShowInputOrderError(self):
        self.calc.setInput('+')
        self.assertEqual("Incorrect Input, please enter a number first, then enter your calc function !",
                         "Incorrect Input, please enter a number first, then enter your calc function !")   
    
    def testEndProgram(self):
        self.calc.setInput('e')
        self.assertEqual("Goodbye!", "Goodbye!")
        self.calc.setInput('E')
        self.assertEqual("Goodbye!", "Goodbye!")
    
    #testing the calculation operator
    def testAdd(self):
        self.assertEqual(4, self.calc.operators2Num["+"](2, 2))
        self.assertEqual(5, self.calc.operators2Num["+"](2, 3))
        self.assertEqual(-1, self.calc.operators2Num["+"](2, -3))
        self.assertEqual(0, self.calc.operators2Num["+"](2, -2))
        self.assertEqual(2, self.calc.operators2Num["+"](2, 0))
        self.assertEqual(-5, self.calc.operators2Num["+"](-2, -3))
        

    def testSubtract(self):
        self.assertEqual(0, self.calc.operators2Num["-"](2, 2))
        self.assertEqual(-1, self.calc.operators2Num["-"](2, 3))
        self.assertEqual(5, self.calc.operators2Num["-"](2, -3))
        self.assertEqual(4, self.calc.operators2Num["-"](2, -2))
        self.assertEqual(2, self.calc.operators2Num["-"](2, 0))
        self.assertEqual(1, self.calc.operators2Num["-"](-2, -3)) 
    
    def testDivide(self):
        self.assertEqual(1, self.calc.operators2Num["/"](2, 2))
        self.assertEqual(-1, self.calc.operators2Num["/"](2, -2))
        self.assertEqual(0, self.calc.operators2Num["/"](2, 0))
        self.assertEqual(-2, self.calc.operators2Num["/"](2, -1))
        self.assertEqual(2, self.calc.operators2Num["/"](2, 1))
        self.assertEqual(2, self.calc.operators2Num["/"](3, 1.5))
        self.assertEqual(.5, self.calc.operators2Num["/"](2., 4))
        self.assertEqual(-.5, self.calc.operators2Num["/"](2., -4))
        
    def testMultiply(self):
        self.assertEqual(4, self.calc.operators2Num["*"](2, 2))
        self.assertEqual(6, self.calc.operators2Num["*"](2, 3))
        self.assertEqual(-6, self.calc.operators2Num["*"](2, -3))
        self.assertEqual(-4, self.calc.operators2Num["*"](2, -2))
        self.assertEqual(0, self.calc.operators2Num["*"](2, 0))
        self.assertEqual(6, self.calc.operators2Num["*"](-2, -3))
        self.assertEqual(2, self.calc.operators2Num["*"](2, 1))
        self.assertEqual(3, self.calc.operators2Num["*"](2, 1.5)) 
        
    def testRemainder(self):
        self.assertEqual(0, self.calc.operators2Num["%"](2, 2))
        self.assertEqual(2, self.calc.operators2Num["%"](2, 4))
        self.assertEqual(-2, self.calc.operators2Num["%"](2, -4))
        self.assertEqual(0, self.calc.operators2Num["%"](2, -2))
        self.assertEqual(0, self.calc.operators2Num["%"](2, -2))
        self.assertEqual(0, self.calc.operators2Num["%"](2, 0))
        self.assertEqual(0, self.calc.operators2Num["%"](2, 1))
        self.assertEqual(-2, self.calc.operators2Num["%"](-2, -4))
        
    def testSquared(self):
        self.assertEqual(4, self.calc.operators1Num["x^2"](2))
        self.assertEqual(25, self.calc.operators1Num["x^2"](5))
        self.assertEqual(9, self.calc.operators1Num["x^2"](-3))
        self.assertEqual(2.25, self.calc.operators1Num["x^2"](1.5))
        self.assertEqual(0, self.calc.operators1Num["x^2"](0))
       
        
    def testSquareRoot(self):
        self.assertEqual(3, self.calc.operators1Num["sqR"](9))
        self.assertEqual(0, self.calc.operators1Num["sqR"](-9))
        self.assertEqual(.3, self.calc.operators1Num["sqR"](.09))
        self.assertEqual(0, self.calc.operators1Num["sqR"](0))
        self.assertEqual(2.5, self.calc.operators1Num["sqR"](6.25))
        
    def testCubed(self):
        self.assertEqual(8, self.calc.operators1Num["cube"](2))
        self.assertEqual(27, self.calc.operators1Num["cube"](3))
        self.assertEqual(-8, self.calc.operators1Num["cube"](-2))
        self.assertEqual(0, self.calc.operators1Num["cube"]( 0))
        self.assertAlmostEqual(29.791, self.calc.operators1Num["cube"](3.1), delta=0.001)
        
    def testCubedRoot(self):
        self.assertEqual(2, self.calc.operators1Num["cubeR"](8))
        self.assertEqual(3, self.calc.operators1Num["cubeR"](27))
        self.assertEqual(2, self.calc.operators1Num["cubeR"](-8))
        self.assertEqual(0, self.calc.operators1Num["cubeR"](0))
        
    def testAbsoluteValues(self):
        self.assertEqual(2, self.calc.operators1Num["abs"](2))
        self.assertEqual(1.5, self.calc.operators1Num["abs"](-1.5))
        self.assertEqual(0, self.calc.operators1Num["abs"](0))
        
    def testShouldPrintUserInput(self):
         self.calc.setInput(1)
         self.calc.setInput(1)
         self.calc.setInput(1)
         self.assertEqual(111.0, float(self.calc.number))
         
    def testShouldAddUserInput(self):
         self.calc.setInput(1)
         self.calc.setInput(1)
         self.calc.setInput(1)
         self.calc.setInput("+")
         self.calc.setInput(7)
         self.assertEqual(118.0, self.calc.getCalculator2NumResult("+"))

    def testShouldSubtractUserInput(self):
         self.calc.setInput(1)
         self.calc.setInput(1)
         self.calc.setInput(1)
         self.calc.setInput("-")
         self.calc.setInput(7)
         self.assertEqual(104.0, self.calc.getCalculator2NumResult("-"))
         
    def testShouldDivideUserInput(self):
         self.calc.setInput(1)
         self.calc.setInput("/")
         self.calc.setInput(2)
         self.assertEqual(0.5, self.calc.getCalculator2NumResult("/"))  
         self.calc.setInput(1)
         self.calc.setInput("/")
         self.calc.setInput(0)
         self.assertEqual(0, self.calc.getCalculator2NumResult("/"))      
         self.calc.setInput(1)
         self.calc.setInput("/")
         self.calc.setInput(-1)
         self.assertEqual(-1, self.calc.getCalculator2NumResult("/"))      
    
    def testShouldMultiplyUserInput(self):
         self.calc.setInput(1)
         self.calc.setInput("*")
         self.calc.setInput(2)
         self.assertEqual(2, self.calc.getCalculator2NumResult("*"))  
         self.calc.setInput(10)
         self.calc.setInput("*")
         self.calc.setInput(-10)
         self.assertEqual(-100, self.calc.getCalculator2NumResult("*"))      
         self.calc.setInput(-1.5)
         self.calc.setInput("*")
         self.calc.setInput(-1.5)
         self.assertEqual(2.25, self.calc.getCalculator2NumResult("*")) 
    
    def testShouldRemainderUserInput(self):
         self.calc.setInput(10)
         self.calc.setInput("%")
         self.calc.setInput(2)
         self.assertEqual(0, self.calc.getCalculator2NumResult("%"))  
         self.calc.setInput(10)
         self.calc.setInput("%")
         self.calc.setInput(-10)
         self.assertEqual(0, self.calc.getCalculator2NumResult("%"))      
         self.calc.setInput(-1.5)
         self.calc.setInput("%")
         self.calc.setInput(-1.5)
         self.assertEqual(0, self.calc.getCalculator2NumResult("%"))   
    
    def testShouldSquareUserInput(self):
         self.calc.setInput(10)
         self.calc.setInput("x^2")
         self.assertEqual(100, self.calc.getCalculator1NumResult("x^2"))  
         self.calc.setInput(-10)
         self.calc.setInput("x^2")
         self.assertEqual(100, self.calc.getCalculator1NumResult("x^2"))      
         self.calc.setInput(-1.5)
         self.calc.setInput("x^2")
         self.assertEqual(2.25, self.calc.getCalculator1NumResult("x^2"))
         
    def testShouldSquareRootUserInput(self):
         self.calc.setInput(25)
         self.calc.setInput("sqR")
         self.assertEqual(5, self.calc.getCalculator1NumResult("sqR"))  
         self.calc.setInput(2116)
         self.calc.setInput("sqR")
         self.assertEqual(46, self.calc.getCalculator1NumResult("sqR"))      
         self.calc.setInput(-2116)
         self.calc.setInput("sqR")
         self.assertEqual(0, self.calc.getCalculator1NumResult("sqR"))
    
    def testShouldCubeUserInput(self):
         self.calc.setInput(10)
         self.calc.setInput("cube")
         self.assertEqual(1000, self.calc.getCalculator1NumResult("cube"))  
         self.calc.setInput(-10)
         self.calc.setInput("cube")
         self.assertEqual(-1000, self.calc.getCalculator1NumResult("cube"))      
         self.calc.setInput(-1.5)
         self.calc.setInput("cube")
         self.assertEqual(-3.375, self.calc.getCalculator1NumResult("cube"))
         
    def testShouldCubeRootUserInput(self):
         self.calc.setInput(1000)
         self.calc.setInput("cubeR")
         self.assertAlmostEqual(10, self.calc.getCalculator1NumResult("cubeR"), delta = .001)  
         self.calc.setInput(-1000)
         self.calc.setInput("cubeR")
         self.assertAlmostEqual(10, self.calc.getCalculator1NumResult("cubeR"), delta = .001)      
         self.calc.setInput(125)
         self.calc.setInput("cubeR")
         self.assertEqual(5, self.calc.getCalculator1NumResult("cubeR"))
         
    def testShouldAbsoluteUserInput(self):
         self.calc.setInput(-10)
         self.calc.setInput("abs") 
         self.assertEqual(10, self.calc.getCalculator1NumResult("abs"))      
         self.calc.setInput(-1.5)
         self.calc.setInput("abs")
         self.assertEqual(1.5, self.calc.getCalculator1NumResult("abs"))

    
unittest.main()