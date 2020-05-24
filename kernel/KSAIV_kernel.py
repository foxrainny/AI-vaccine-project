import os
import io
from io import StringIO

import k2kmdfile
import k2rsa

class Engine:

	def __init__(self, debug=False):
		self.debug = debug
		self.plugins_path = None  
		self.kmdfiles = []

	def set_plugins(self, plugins_path):
		self.plugins_path = plugins_path
		#pu = k2rsa.read_key(plugins_path +os.sep+'key.pkr')
		pu= k2rsa.read_key('key.pkr')
		
		if not pu:
			print('not load pkr')
			return False
			
		#ret = self.__get_kmd_list(plugins_path + os.sep +'kicom.kmd', pu)
		ret = self.__get_kmd_list('kicom.kmd', pu)
		
		if not ret:
			print('not exist KDM file')
			return False

		if self.debug:
			print ('[*] kicom.kmd:')
			print ('   ', self.kmdfiles)
    
		return True
		
	def __get_kmd_list(self, kicom_kmd_file, pu):
		kmdfiles = []
		
		k = k2kmdfile.KMD(kicom_kmd_file, pu)
		
		if k.body:
			msg = StringIO.StringIO(k.body)
			while True:
				line = msg.readline().strip()
				
				if not line:  
					break
				elif line.find('.kmd') != -1: 
					kmdfiles.append(line)  
				else:  
					continue
					
		if len(kmdfiles):  
			self.kmdfiles = kmdfiles
			return True
		else: 
			return False
			
