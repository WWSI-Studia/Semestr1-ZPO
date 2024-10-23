# -*- coding: utf-8 -*-
"""
Created on Fri Nov 29 09:57:23 2019

@author: Ewa
"""


import random
from person import Person


class Gardener(Person):
    NICE_WEATHER_PROBABILITY = 0.75

    def __init__(self, name, gender, fatherName, motherName):
        super().__init__(name, gender, fatherName, motherName)
        self.numberOfPlantedTrees = 0
        self.random_generator = random.Random()  # instantiation of rand. gen.
        self.role = 'Gardener'

    def describe(self):
         return 'Gardener {0}, {1} of {2} and {3}. Planted {4} trees. '.format(
              self.name, 'son' if self.gender == 'm' else 'daugher',
              self.fatherName, self.motherName, self.numberOfPlantedTrees)

    def plant(self):
        if self.random_generator.random() < self.NICE_WEATHER_PROBABILITY:
            self.numberOfPlantedTrees += 1
            return 'Planting a tree...'
        return 'Looking at trees growing in the rain...'


def main():
    k = Gardener("Greenleaf",'m',"Brownleaf","Goldendaisy")
    print(k.describe())
    for i in range(6):
        print(k.plant())


if __name__ == '__main__':
    main()
