# -*- coding: utf-8 -*-
"""
Created on Sat Jan 20 12:12:27 2018

@author: Admin
"""

from calculator import Calculator

calc = Calculator()

tempInput = None

print "Welcome to the Calc App"


while tempInput != 'e' or tempInput != 'E':
    try:
        print "Calc functions include: +,-,/,*,%,x^2,sqR,cube,cubeR,abs"
        tempInput = raw_input("Enter a number, calc function or 'E' to Exit: ")
        if tempInput == 'e' or tempInput == 'E':
            print "Goodbye!"
            break
        
        elif calc.checkIsNumber(tempInput) or str(tempInput) in calc.operators2Num.keys() or tempInput in calc.operators1Num.keys():
            calc.setInput(tempInput)
            if calc.number == "":
                print ""
            else:
                print float(calc.number)
            
            if calc.tempOper1 != "":
                calc.getCalculator1NumResult(tempInput)
                print "Answer: " , float(calc.answer),"\n"
                calc.answer = None
            
            elif calc.tempOper2 != "" and calc.number != "":
                calc.getCalculator2NumResult(calc.tempOper2)
                print "Answer: " , float(calc.answer),"\n"
                print calc.tempOper2
                calc.answer = None
        else:
            print "Incorrect Input, please try again !\n"
            calc.number = ""
            calc.tempOper1 = ""
            calc.tempOper2 = ""
    
    
    except ValueError:
        print "Incorrect Input, please enter a number first, then enter your calc function !\n"
        calc.number = ""
        calc.tempOper1 = ""
        calc.tempOper2 = ""
                
    