# -*- coding: utf-8 -*-
"""
Created on Fri Nov 29 09:57:32 2019

@author: Ewa
"""


from random import choice, uniform
from gardener import Gardener
from knight import Knight


class Master:
    def __init__(self):
        self.list_of_persons = []

    def show(self):
        for p in self.list_of_persons:
            print(p.describe())

    def play(self):
        for i in range(10):
            person = choice(self.list_of_persons);
            print(person.describe())
            while uniform(0, 1) < 0.5:
                if person.get_role() == 'Knight':
                    print(person.fight())
                else:
                    print(person.plant())

    def set_inhabitants(self):
        self.list_of_persons.append(Gardener('Greenleaf','m','Brownleaf','Goldendaisy'));
        self.list_of_persons.append(Gardener('Slenderwillow','f','Oldoak','Sunnydaisy'));
        self.list_of_persons.append(Knight('Quickhand','m','Bravedeed',
                'Sunbell','sword','horse'));
        self.list_of_persons.append(Knight('Truefriend','m','Highspirit',
                'Mistymorning','spear','dragon'));


def main():
    m = Master()
    m.set_inhabitants()
    m.play()

if __name__ == '__main__':
    main()

