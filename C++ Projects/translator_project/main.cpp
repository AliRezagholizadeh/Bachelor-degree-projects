#include "mainwindow.h"
#include "files.h"
#include "translate.h"
#include <QApplication>
#include <QVBoxLayout>
#include <QPushButton>
#include <QLayout>
#include <vector>
#include <QtGui>
int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    QTextEdit*text=new QTextEdit;
    text->setText("related in mw");


    QWidget*w=new QWidget;
    QVBoxLayout*vbl=new QVBoxLayout;
    MainWindow*mw=new MainWindow;

    //files file;                             //dar nahayat har jomle ro dar har khoone ye vector mirizad;
    /*
    for(int i=0;i<file.esm.size();i++)
        cout<<file.esm.at(i)<<" ";
    for(int i=0;i<file.sefat.size();i++)
        cout<<file.sefat.at(i)<<" ";
    for(int i=0;i<file.gheyd.size();i++)
        cout<<file.gheyd[i]<<" ";
    //for(int i=0;i<file.felgozashte.size();i++)
     //   cout<<file.felgozashte[i]<<" ";
    //for(int i=0;i<file.felayande.size();i++)
     //   cout<<file.felayande[i]<<" ";

    for(int i=0;i<file.srcpart.size();i++)
        cout<<file.srcpart[i]<<" ";
        */

cout<<"\n";

/*
for(int i=0;i<file.numberofstatements;i++){
    cout<<"\n";
        for(int j=0;j<file.statements[i].size();j++)
            cout<<file.statements[i][j]<<" ";
   }


*/
    //translate trans(text);

    mw->show();


    return a.exec();
}
