import sys, os, shutil
from PyQt5.QtWidgets import QWidget, QApplication, QTreeView, QFileSystemModel, QVBoxLayout, QPushButton, QInputDialog, QLineEdit

class MyApp(QWidget):
    def __init__(self):
        super().__init__()


        self.path = "C:"
        self.index = None

        self.tv = QTreeView(self)
        self.model = QFileSystemModel()
        self.btnRen = QPushButton("이름바꾸기")
        self.btnDel = QPushButton("파일삭제")
        self.layout = QVBoxLayout()

        self.setUi()
        self.setSlot()
        self.show()
    def setUi(self):
        self.setGeometry(300, 300, 700, 350)
        self.setWindowTitle("QFileSystemModel")
        self.model.setRootPath(self.path)
        self.tv.setModel(self.model)
        self.tv.setColumnWidth(0, 250)

        self.layout.addWidget(self.tv)
        self.layout.addWidget(self.btnDel)
        self.layout.addWidget(self.btnRen)
        self.setLayout(self.layout)

    def setSlot(self):
        self.tv.clicked.connect(self.setIndex)
        self.btnRen.clicked.connect(self.ren)
        self.btnDel.clicked.connect(self.rm)

    def setIndex(self, index):
        self.index = index

    def ren(self):
        os.chdir(self.model.filePath(self.model.parent(self.index)))
        fname = self.model.fileName(self.index)
        text, res = QInputDialog.getText(self, "이름바꾸기", "바꿀이름을 입력하세요", QLineEdit.Normal, fname)

        if res:
            while True:
                self.ok = True
                for i in os.listdir(os.getcwd()):
                    print(i)
                    if i == text:
                        text, res = QInputDialog.getText(self, "중복오류!", "바꿀이름을 입력하세요", QLineEdit.Normal, text)

                        if not res:
                            return
                        self.ok = False
                if self.ok:
                    break
            os.rename(fname, text)

    def rm(self):
        os.chdir(self.model.filePath(self.model.parent(self.index)))
        fname = self.model.fileName(self.index)
        try:
            if not self.model.isDir(self.index):
                os.unlike(fname)
                print(fname + '파일 삭제')
            else:
                shutil.rmtree(fname)
                print(fname + '폴더 삭제')

        except:
            print("에러발생")


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MyApp()

    sys.exit(app.exec_())
