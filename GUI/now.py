import sys
from PyQt5.QtWidgets import QApplication, QWidget, QMainWindow, QAction, qApp, QDesktopWidget, \
QGridLayout, QLabel, QLineEdit, QTextEdit,QPushButton, QMessageBox, QTreeView, QFileSystemModel, QVBoxLayout
from PyQt5.QtGui import QIcon

class MyApp(QWidget):
    def __init__(self):
        super().__init__()
        self.initUI()

class MyApp(QMainWindow):
    def __init__(self):
        super().__init__()
        self.initUI()

    def initUI(self):
        self.setWindowTitle('KSAIV')
        self.setWindowIcon(QIcon('icon.png'))
        self.setGeometry(300, 100, 1000, 800)




        btn = QPushButton('스캔', self)
        btn.setGeometry(50, 500, 200, 80)
        btn = QPushButton('치료', self)
        btn.setGeometry(260, 500, 200, 80)
        btn = QPushButton('중지', self)
        btn.setGeometry(50, 600, 200, 80)
        btn = QPushButton('열기', self)
        btn.setGeometry(260, 600, 200, 80)
        btn = QPushButton('icon.png', self)
        btn.setGeometry(50, 50, 410, 410)


        self.show()


    def center(self):
        qr = self.frameGeometry()
        cp = QDesktopWidget().availableGeometry().center()
        qr.moveCenter(cp)
        self.move(qr.topLeft())

    def closeEvent(self, QCloseEvent):
        ans = QMessageBox.question(self, "종료", "종료하시겠습니까?", QMessageBox.Yes | QMessageBox.No, QMessageBox.Yes)
        if ans == QMessageBox.Yes:
            QCloseEvent.accept()

        else:
            QCloseEvent.ignore()

    def setIndex(self, index):
        self.index = index


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MyApp()

    sys.exit(app.exec_())
