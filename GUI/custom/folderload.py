from PyQt5.QtWidgets import QWidget, QApplication, QTreeView, QFileSystemModel, QVBoxLayout, QPushButton, QInputDialog, QLineEdit

class MyApp(QWidget):
    def __init__(self):
        super().__init__()


        self.path = "C:"
        self.index = None
        self.tv = QTreeView(self)
        self.model = QFileSystemModel()
        self.layout = QVBoxLayout()
        self.setUi()
        self.show()


    def setUi(self):
        self.setGeometry(300, 300, 700, 350)
        self.setWindowTitle("QFileSystemModel")
        self.model.setRootPath(self.path)
        self.tv.setModel(self.model)
        self.tv.setColumnWidth(0, 250)
        self.layout.addWidget(self.tv)
        self.setLayout(self.layout)

    def setIndex(self, index):
        self.index = index



if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MyApp()

    sys.exit(app.exec_())
