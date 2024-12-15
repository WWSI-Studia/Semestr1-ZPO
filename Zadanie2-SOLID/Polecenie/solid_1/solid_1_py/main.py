# -*- coding: utf-8 -*-
"""
Created on Fri Nov 29 09:57:40 2019

@author: Ewa
"""


from master import Master


def main():
    print('\n\nSOLID exercise 1\n')
    master = Master()
    master.set_inhabitants()
    print('\nList of inhabitants:\n')
    master.show()
    print('\nPlaying:\n')
    master.play()


if __name__ == '__main__':
    main()
