
"""
Created on Tue May 19 12:51:55 2020

@author: Lee
"""
# -*- coding: utf-8 -*-
import csv
import pefile
import glob
import os
import sys
import math

def __entropy(path):
    #print(path)
    f = open(path,"rb")
    byteArr = list(f.read())
    f.close()
    fileSize = len(byteArr)
    freqList = []
    for b in range(256):
        ctr = 0
        for byte in byteArr:
            if byte == b:
                ctr +=1
        freqList.append(float(ctr)/fileSize)
    ent = 0.0
    for freq in freqList:
        if freq > 0:
            ent = ent+freq*math.log(freq,2)
    ent = -ent
    #print('entropy : {}'.format(ent))
    return ent,fileSize   


path = "./"
file_list = os.listdir(path)
file_list_exe =[file for file in file_list if file.endswith(".exe")]
if __name__ == '__main__':
    for file in file_list_exe:
        entropy , filesize = __entropy(file)
        #print('entropy : {}'.format(entropy))
        #print('file_size : {}'.format(filesize))
        



'''    

#file_list = os.listdir(path)
file_list = glob.glob(path)
#print("list:{}".format(file_list))

f = open('Mal_ML_Fit.csv','w',newline='')
wr = csv.writer(f,delimiter=',')
wr.writerow(['filesize','entropy','IAT_ratio','IAT_num',
             'section','Dll_Characteristics'])

f.close()

'''    
