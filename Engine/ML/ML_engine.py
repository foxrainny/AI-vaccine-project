from sklearn.model_selection import train_test_split
from sklearn import svm, metrics
from sklearn.model_selection import train_test_split
from sklearn.tree import DecisionTreeClassifier
from sklearn.model_selection import train_test_split
from sklearn.neighbors import KNeighborsClassifier
import pandas as pd

malware_data = pd.read_csv('/content/drive/My Drive/test/mal & exe.csv')
data = malware_data[["OH_DLLchar0","OH_DLLchar2","packer","E_text"]]
label = malware_data["mal"]

train_data, test_data, train_label, test_label = train_test_split(data,label)

clf = svm.SVC()
clf.fit(train_data, train_label)
result = clf.predict(test_data)
score1 = metrics.accuracy_score(result,test_label)

clf2 = DecisionTreeClassifier(random_state=0)
clf2.fit(train_data, train_label)
score2 = clf.score(test_data,test_label)

clf = KNeighborsClassifier(n_neighbors=10)
clf.fit(train_data, train_label)
score3 = clf.score(test_data,test_label)
if score1>=score2 and score1>score3:
    print("svm 정답률: ",score1)
elif score2>score1 and score2>score3:
    print("DecisionTree 정답률: ",score2)
else:
    print("K-NN 정답률: ",score3)
