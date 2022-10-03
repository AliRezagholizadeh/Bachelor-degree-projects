#ifndef MAINWINDOW_H
#define MAINWINDOW_H
#include <QtGui>
#include <QMainWindow>

class MainWindow : public QMainWindow
{
    Q_OBJECT
public:
    explicit MainWindow(QWidget*parent=0 );
    void createaction();
    void createmenus();

private:
    QWidget*wid3;
    QAction*saveact;
    QAction*openact;
    QAction*translateact;
    QAction*saveAsact;
    QAction*NEWact;
    QAction*exitact;
    QMenu* filemenu;
    QMenu*translatemen;

    QTextEdit*text1;
    QTextEdit*text2;

    QString currentfile;
    void setcurrentfile(QString);
    void saveFile(QString);



signals:

public slots:
    void open();
    void exit();
    void save();
    void TRANSLATE();
    void saveAs();
    void NEW();

};

#endif // MAINWINDOW_H
