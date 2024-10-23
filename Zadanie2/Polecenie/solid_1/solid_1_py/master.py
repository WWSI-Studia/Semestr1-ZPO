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
        self.list_of_heros = []

    def show(self):
        for k in self.list_of_heros:
            print(k.describe())

    def play(self):
        for i in range(10):
            hero = choice(self.list_of_heros);
            print(hero.describe())
            while uniform(0, 1) < 0.75:        
                if hero.name_of_the_role == 'Knight':  # the inhabitant is a Knight
                    print(hero.fight())
                elif hero.name_of_the_role == 'Gardener':  # the inhabitant is a Gardener                  
                        print(hero.plant())

    def set_inhabitants(self):
        self.list_of_heros.append(Gardener('Slenderwillow','f','Oldoak','Sunnydaisy'));
        self.list_of_heros.append(Knight('Quickhand','m','Bravedeed',
                'Sunbell','sword','horse'));
        self.list_of_heros.append(Knight('Truefriend','m','Highspirit',
                'Mistymorning','spear','dragon'));
        self.list_of_heros.append(Gardener('Greenleaf','m','Brownleaf','Goldendaisy'));


def main():
    m = Master()
    m.set_inhabitants()
    m.list_of_heros.append(Gardener('Greenleaf','m','Brownleaf','Goldendaisy'));
    m.show()
    m.play()

if __name__ == '__main__':
    main()

