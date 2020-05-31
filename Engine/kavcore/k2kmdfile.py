
# -*- coding: utf-8 -*-
"""
Created on Fri May 22 19:49:00 2020

@author: ghdhf
k2kmdfile.py
"""

import hashlib
import os
import py_compile
import random
import shutil
import struct
import sys
import zlib

#사용자 모듈
import k2rc4
import k2rsa
import k2timelib


""" 
암호화 모듈

"""
def make(src_fname, debug=False):
    # 암호화 대상 파일을 컴파일 또는 복사하여 준비
    fname = src_fname
    
    if fname.split('.')[1] == 'py':
        py_compile.compile(fname)
        pyc_name = fname+'c'
    else:
        pyc_name = fname.split('.')[0]+'.pyc'
        shutil.copy(fname, pyc_name)
        
        
    #RSA 사용
    
    #에러남.
    rsa_pu = k2rsa.read_key('key.pkr')
    print("pkr : ", rsa_pu)
    
    rsa_pr = k2rsa.read_key('key.skr')
    print("skr : ", rsa_pr)
    
    if not (rsa_pr and rsa_pu):
        if debug :
            print("ERROR : no Key files")
        return False

    # KMD 파일 생성 (암호화 파일)
    ### 헤더 부분
    #원래는 KSAIV 로 하려고했으나 에러때문에 KSIV 로 대체함.
    kmd_data= 'KSIV'           # 우리팀 확장자 ㅎㅎ. 시그니처 원래 KSAIV
    
    # 현재 날짜와 시간 구함
    ret_date = k2timelib.get_now_date()
    ret_time = k2timelib.get_now_time()
    
    #에러..체크
    print(ret_date)
    print(ret_time)
    
    # 날짜와 시간 값을 2Byte로 변경.
    val_date = struct.pack('<H', ret_date)
    val_time = struct.pack('<H', ret_time)
    
    
    
    print(val_date)
    print(val_time)
    #에러난다.
    #reserved_buf = val_date + val_time + (chr(0) * 28) 에러코
    reserved_buf = str(val_date) + str(val_time) + (chr(0) * 28)   ## 예약 버퍼 잡기
    
    kmd_data += reserved_buf
    
    ### 바디 부분
    
    random.seed()
    
    while 1:
        tmp_kmd_data = ''
        
        # RC4 알고리즘에 사용할 128bit 랜덤 키 생성
        key = ''
        
        for i in range(16):
            key += chr(random.randint(0, 0xff))

        print(key)
        #개인키로 암호화            
        e_key = k2rsa.crypt(key, rsa_pr)
        #e_key = k2rc4.RC4.crypt(key, rsa_pr)
        if len(e_key) != 32:
            continue
        
        #복호화
        d_key = k2rsa.crypt(e_key, rsa_pu)
        #d_key = k2rc4.RC4.crypt(e_key, rsa_pu)
        
        if key == d_key and len(key) == len(d_key):
            
            tmp_kmd_data += e_key
            
            buf1 = open(pyc_name, 'rb').read()
            buf2 = zlib.compress(buf1)
            
            e_rc4 = k2rc4.RC4()
            e_rc4.set_key(key)
            
            buf3 = e_rc4.crypt(buf2)
            
            e_rc4 = k2rc4.RC4()
            e_rc4.set_key(key)
            
            if e_rc4.crypt(buf3) != buf2:
                continue
            
            
            tmp_kmd_data += buf3
            
            
            ### 꼬리 부분 : 개인키로 암호화한 MD5x3
            
            md5 = hashlib.md5()
            md5hash = kmd_data + tmp_kmd_data
            
            for i in range(3):
                md5.update(md5hash)
                md5hash = md5.hexdigest()
                
            m = md5hash.decode('hex')
            
            e_md5 = k2rsa.crypt(m, rsa_pr)
            if len(e_md5) != 32:
                continue
            
            d_md5 = k2rsa.crypt(e_md5, rsa_pu)
            
            if m == d_md5:
                kmd_data += tmp_kmd_data + e_md5
                break
            
    
    
    # kmd 파일 생성
    
    ext = fname.find(',')
    kmd_name = fname[0:ext] + '.kmd'
    
    try:
        if kmd_data:
            open(kmd_name, 'wb').write(kmd_data)
            
            os.remove(pyc_name)
            
            if debug:
                print(" Success : %-13s -> %s " % (fname, kmd_name))
            return True
        else:
            raise IOError
            
    except IOError:
            if debug:
                print(" Fail : %s" % fname)
            return False
        
        
"""
복호화 모듈
"""

def ntimes_md5(buf, ntimes):
    md5 = hashlib.md5()
    md5hash = buf
    for i in range(ntimes):
        md5.update(md5hash)
        md5hash = md5.hexdigest()
    
    return md5hash

class KMDFormatError(Exception):
    def __init__(self, value):
        self.value = value
        
    def __str__(self):
        return repr(self.value)
    

# 상수 지정    
class KMDConstants:
    #본래 KSAIV 이지만 KSIV 로 대체.
    KMD_SIGNATURE = 'KSIV'  # 시그니처
    
    KMD_DATE_OFFSET = 4 # 날짜 위치
    KMD_DATE_LENGTH = 2 
    KMD_TIME_OFFSET = 6
    KMD_TIME_LENGTH = 2
    
    KMD_RESERVED_OFFSET = 8
    KMD_RESERVED_LENGTH = 28
    
    KMD_RC4_KEY_OFFSET = 36
    KMD_RC4_KEY_LENGTH = 32
    
    KMD_MD5_OFFSET = -32
    
# KMD 클래스
class KMD(KMDConstants):
    def __init__(self, fname, pu):
        self.filename = fname
        self.date = None
        self.time = None
        self.body = None
        
        self.__kmd_data = None
        self.__rsa_pu = pu
        self.__rc4_key = None
        
        if self.filename:
            self.__decrypt(self.filename)
           

    def __decrypt(self, fname, debug=False):
        #KMD 파일 열고 시그니처 체크
        with open(fname, 'rb') as fp:
            if fp.read(4) == self.KMD_SIGNATURE:    # 책은 KAVM 이므로 4 값 우리는 KSAIV 이므로 5값
                self.__kmd_data = self.KMD_SIGNATURE + fp.read()
                
            else:
                raise KMDFormatError("KMD Header magic not found.")
        
        #KMD 파일 날짜 읽기
        tmp = self.__kmd_data[self.KMD_DATE_OFFSET:
                              self.KMD_DATE_OFFSET + self.KMD_DATE_LENGTH]
        self.date = k2timelib.convert_date(struct.unpack('<H', tmp)[0])
        # print(self.date)
        
        #KMD 파일 시간 읽기
        tmp = self.__kmd_data[self.KMD_TIME_OFFSET:
                              self.KMD_TIME_OFFSET + self.KMD_TIME_LENGTH]
        self.time = k2timelib.convert_time(struct.unpack('<H', tmp)[0])
        #print(self.time)
        
        #KMD 파일에서 MD5읽기
        e_md5hash = self.__get_md5()
        
        #무결성 체크
        md5hash = ntimes_md5(self.__kmd_data[:self.KMD_MD5_OFFSET], 3)
        if e_md5hash != md5hash.decode('hex'):
            raise KMDFormatError('Invalid KMD MD5 hash.')
            
        #KMD 파일에서 RC4 키 읽기
        self.__rc4_key = self.__get_rc4_key()
        
        #KMD 파일에서 본문 읽기
        e_kmd_data = self.__get_body()
        if debug:
            print(len(e_kmd_data))
        
        #압축 해제
        self.body = zlib.decompress(e_kmd_data)
        if debug:
            print(len(self.body))

    def __get_rc4_key(self):
        e_key = self.__kmd_data[self.KMD_RC4_KEY_OFFSET:
                                self.KMD_RC4_KKEY_OFFSET
                                + self.KMD_RC4_KEYY_LENGTH]
        return k2rsa.crypt(e_key, self.__rsa_pu)
    
    def __get_body(self):
        e_kmd_data = self.__kmd_data[self.KMD_RRC4_KEY_OFFSET
                                      + self.KMD_RC4_KEY_LENGTH
                                      :self.KMD_MD5_OFFSET]
        r = k2rc4.RC4()
        r.set_key(self.__rc4_key)
        return r.crypt(e_kmd_data)
    
    def __get_md5(self):
        e_md5 = self.__kmd_data[self.KMD_MD5_OFFSET:]
        return k2rsa.crypt(e_md5, self.__rsa_pu)
    
