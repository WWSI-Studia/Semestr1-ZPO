# -*- coding: utf-8 -*-
"""
Created on Fri Nov 29 14:09:45 2019

@author: Ewa
"""


class Person:
    def __init__(self, name, gender, fatherName, motherName):
        self.name = name
        self.gender = gender
        self.fatherName = fatherName
        self.motherName = motherName
        self.role = ''

    def describe(self):
        return '{0}, {1} of {2} and {3}. '.format(
              self.name, 'son' if self.gender == 'm' else 'daugher',
              self.fatherName, self.motherName)

    def get_role(self):
        return self.role


def main():
    p = Person('Quickhand', 'm', 'Bravedeed', "Goldendaisy")
    print(p.describe()) 


if __name__ == '__main__':
    main()