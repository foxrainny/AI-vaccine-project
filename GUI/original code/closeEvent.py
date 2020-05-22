import sys
from PyQt5.QtWidgets import QApplication, QWidget, QMainWindow, QPushButton, QMessageBox
from PyQt5.QtCore import QCoreApplication

class MyApp(QWidget):
    def __init__(self):
        super().__init__()
        self.initUI()

    def initUI(self):
        btn = QPushButton("push me!", self)
        btn.resize(btn.sizeHint())
        btn.move(50, 50)
        btn.clicked.connect(QCoreApplication.instance().quit)

        self.resize(500, 500)
        self.setWindowTitle("KSAIV")
        self.show()

    def closeEvent(self, QCloseEvent):
        ans = QMessageBox.question(self, "종료확인", "종료하시겠습니까?", QMessageBox.Yes |QMessageBox.No, QMessageBox.Yes)
        if ans == QMessageBox.Yes:
            QCloseEvent.accept()

        else:
            QCloseEvent.ignore()

if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = MyApp()
    sys.exit(app.exec_())



    app = QApplication(sys.argv)
    ex = MyApp()
    sys.exit(app.exec_())
