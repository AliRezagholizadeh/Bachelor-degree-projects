#include <QtGui/QApplication>
#include "mainwindow2.h"

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    MainWindow2 *w = MainWindow2::getWindow();
    w->show();

    return a.exec();
}
