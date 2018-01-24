# -*- coding: utf-8 -*-
"""
Created on Sat Jan 20 19:50:22 2018

@author: Admin
"""

class Calculator(object):
    
    def __init__(self):
       self.tempOper2 = ""
       self.tempOper1 = ""
       self.number = ""
       self.total = None
       self.answer = None
    
    isNumber = False
   
            
    operators2Num = {'+': lambda x,y:x+y,
                     '-': lambda x,y:x-y,
                     '/': lambda x,y:x/y if y != 0.0 else 0.0,
                     '*': lambda x,y:x*y,
                     '%': lambda x,y:x%y if y != 0.0 else 0.0,
                     }
    
    operators1Num = {'x^2': lambda x: x**2,
                     'sqR': lambda x: x**0.5 if x >= 0 else 0,
                     'cube': lambda x: x**3,
                     'cubeR': lambda x: abs(x)**(1./3),
                     'abs': lambda x: abs(x),
                     }
    
    def checkIsNumber(self,input):
        #check if user input is a number
        try:
            self.isNumber = float(input)
            return True
        except ValueError:
            return False
    
    def setInput(self,input):
        #assigning the validated input to either a number of operator variable
       if self.checkIsNumber(input) == True:
           #Input number can be concatenated until an operator has been entered
           if self.tempOper1 == "" and self.tempOper2 == "" and self.number == "":
               self.number =  str(input)
               return self.number
           elif self.tempOper1 == "" and self.tempOper2 == "":
               if float(input) < 1 and float(input) > 0:
                   self.number = float(self.number) + float(input)
               else:
                   self.number = str(self.number) + str(input)
                   return self.number
            #Calcs requiring 2 input numbers - second number assignment
           elif self.tempOper2 != "": 
               self.number = str(input)
               return self.number
           return self.number
       #Input is not a number => assigning the validated operator to the variable
       #Assigning the stored number into total
       elif str(input) in self.operators1Num:
           self.tempOper1 = input
           self.total = self.number
           return self.tempOper1
       else:
           self.tempOper2 = input
           self.total = self.number
           self.number = ""      #resetting number to "" for the required second input
           return self.tempOper2
       
       
        
    def getCalculator1NumResult(self,operation):
       self.answer = self.operators1Num[operation](float(self.total))
       self.tempOper1 = ""
       self.total = None
       self.number = ""
       return self.answer
   
    def getCalculator2NumResult(self,operation):
        self.answer = self.operators2Num[operation](float(self.total), float(self.number))
        self.tempOper2 = ""
        self.total = None
        self.number = ""
        return self.answer
        
        
        
        
        
        
   
            
        
        