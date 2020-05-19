# -*- coding: utf-8 -*-
"""
Created on Tue May 19 13:46:12 2020

@author: ghdhf
"""


import k2rc4

#test 코드
if __name__ == '__main__':
    rc4 = k2rc4.RC4()
    rc4.set_key('PASSWORD1234')
    t1 = rc4.crypt('hello')
    
    rc4 = k2rc4.RC4()
    rc4.set_key('PASSWORD1234')
    t2 = rc4.crypt(t1)
    print(t2)
    