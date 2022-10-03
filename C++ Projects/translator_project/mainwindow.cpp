#include "mainwindow.h"
#include "translate.h"
#include<files.h>
#include <QPushButton>
#include <QMenu>
#include <QAction>
#include <QtGui>
#include <QString>
#include <string>
#include <QLayout>
using namespace std;

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent)
{
    files file;

    QWidget*wid=new QWidget;
    QWidget*wid1=new QWidget;
    QWidget*wid2=new QWidget;
    QVBoxLayout*vlay=new QVBoxLayout;

    QVBoxLayout*lay1=new QVBoxLayout();
    QVBoxLayout*lay2=new QVBoxLayout();

    QPlainTextEdit*g=new QPlainTextEdit();
    text1=new QTextEdit;
    text2=new QTextEdit;

    QLabel*label1=new QLabel;
    QLabel*label2=new QLabel;

    label1->setText("Farsi");
    label2->setText("English");


   QString d;
   d.fromWCharArray(L"21as");
    //d=file.vec[0];
  //////  wchar_t* vf;


    text1->setText(d);
    text2->setText("relay in wid2");

    lay1->addWidget(label1,0);
    lay1->addWidget(text1,1);
    lay2->addWidget(label2,0);
    lay2->addWidget(text2,1);

    wid1->setLayout(lay1);
    wid2->setLayout(lay2);

    vlay->addWidget(wid1,0);
    vlay->addWidget(wid2,1);

    wid->setLayout(vlay);
    QTextEdit*text4=new QTextEdit;
    QVBoxLayout*lay4=new QVBoxLayout();
    lay4->addWidget(text4);

    setCentralWidget(wid);

    wid3=wid;


//string e="hi";

//text2->setText((QString) e);




//string s;
//QString n;
//n=QString::fromStdString(s);
//s=n.toStdString();






    createaction();
    createmenus();








}
void MainWindow::createaction()
{
    saveact=new QAction(tr("save"),this);
    QObject::connect(saveact,SIGNAL(triggered()),this,SLOT(save()));
    openact=new QAction(tr("open"),this);
    saveAsact=new QAction("saveAs",this);
    QObject::connect(saveAsact,SIGNAL(triggered()),this,SLOT(saveAs()));
     QObject::connect(openact,SIGNAL(triggered()),this,SLOT(open()));
     NEWact=new QAction("NEW",this);
     QObject::connect(NEWact,SIGNAL(triggered()),this,SLOT(NEW()));
    translateact=new QAction(tr("translate"),this);
    QObject::connect(translateact,SIGNAL(triggered()),this,SLOT(TRANSLATE()));
    exitact=new QAction("exit",this);
    QObject::connect(exitact,SIGNAL(triggered()),this,SLOT(close()));
}
void MainWindow::createmenus()
{
    filemenu=menuBar()->addMenu(tr("&file"));
    filemenu->addAction(openact);
    filemenu->addAction(saveact);
    filemenu->addAction(saveAsact);
    filemenu->addAction(NEWact);
    filemenu->addAction(exitact);
    translatemen=menuBar()->addMenu("Translate");
    translatemen->addAction(translateact);


}
void MainWindow::open()
{

    currentfile=QFileDialog::getOpenFileName(this);
    QFile file(currentfile);
    file.open(QFile::Text | QFile::ReadOnly);
    QTextStream stream(&file);
    text1->setText(stream.readAll());

}
void MainWindow::save()
{
    if (currentfile.isEmpty()) {
        saveAs();
    } else {
        saveFile(currentfile);
    }
}
void MainWindow::saveAs()
{
    QString filename=QFileDialog::getSaveFileName(this);
    QFile file(filename);
        file.open(QFile::Text | QFile::WriteOnly);
        QTextStream ostream(&file);
        ostream<<text1->toPlainText();
        setcurrentfile(filename);

}

void MainWindow::saveFile(QString filename)
{
    QFile file(filename);
    file.open(QFile::Text | QFile::WriteOnly);
    QTextStream ostream(&file);
    ostream<<text1->toPlainText();
    setcurrentfile(filename);
}

void MainWindow::setcurrentfile(QString filename)
{
    currentfile=filename;
}

void MainWindow::TRANSLATE()
{
    translate trans(text2,currentfile);

}
void MainWindow::NEW()
{
    text1->clear();
}
void MainWindow::exit()
{

}
