# -*- coding: utf-8 -*-
"""
Created on Fri May 22 18:29:23 2020

@author: ghdhf

10.3.2.1 암호화 도구 만들기  
6.3장의 kmake.py 와 같은 이름이므로 반드시 구별할것
"""

import os
import sys
import k2kmdfile


if __name__ == '__main__':
    if len(sys.argv) != 2:
        print("Usage : kmake_10.py [python source]")
        sys.exit()
        
    k2kmdfile.make(sys.argv[1], True)
        