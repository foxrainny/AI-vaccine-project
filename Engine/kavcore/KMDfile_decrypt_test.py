# -*- coding: utf-8 -*-
"""
Created on Mon May 25 07:48:18 2020

@author: ghdhf
KMD 파일 생성 및 복호화 모듈 테스트
"""

import k2rsa
import k2kmdfile

k2rsa.create_key('key.pkr', 'key.skr', True)


#이부분이 에러..
ret = k2kmdfile.make('readme.txt')
if ret:
    pu = k2rsa.read_key('key.pkr')
    k = k2kmdfile.KMD('readme.kmd', pu)
    print(k.body)

    

