import sys
from PyQt5.QtWidgets import QApplication, QWidget, QPushButton

class MyApp(QWidget):
    def __init__(self):
        super().__init__()
        self.initUI()

    def initUI(self):
        btn = QPushButton('asdcvb', self)
        btn.resize(btn.sizeHint())
        btn.setToolTip('툴팁')
        btn.move(20, 30)

        self.setGeometry(300, 300, 400, 500)
        self.setWindowTitle('dfdfd')
        self.show()

if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MyApp()

    sys.exit(app.exec_())

    def setIndex(self, index):
        self.index = index


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MyApp()

    sys.exit(app.exec_())
