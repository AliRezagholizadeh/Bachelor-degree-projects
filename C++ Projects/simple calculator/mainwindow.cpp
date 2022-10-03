#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QString>
#include<QDate>
#include <sstream>
#include<QVector>
using std::ostringstream;
using std::vector;
QString str="";
ostringstream ostr;
int num=0;
QVector<QString>*vec=new QVector<QString>();
class d
{
public:

QVector<QString>* call(QVector<QString>*vec,int a,int b)
{
    for(int i=a+1;i<b;i++)
    {
        if(vec->at(i)=="sin")
        {

            vec->at(i)=QString::number(sin(vec->at(i+1)));
            vec->remove(i+1);

        }
        else if(vec->at(i)=="cos")
        {
            vec->at(i)=QString::number(cos(vec->at(i+1).toDouble()));
            vec->remove(i+1);

        }
        else if(vec->at(i)=="*")
        {
            QDate ::toString;                                                   //mikhastam convert be string konam ba too vec
                                                                                //berizam

            vec->at(i)=QString::number((vec->at(i-1).toDouble()*vec->at(i+1).toDouble()));
            vec->remove(i-1);
            vec->remove(i+1);

        }
        else if(vec->at(i)=="/")
        {
             vec->at(i)=QString::number((vec->at(i-1).toDouble()*vec->at(i+1).toDouble()));
            vec->remove(i-1);
            vec->remove(i+1);

        }
        if(vec->at(i)=="(")
        {
            for(int k=i;k<b;k++)
                if(k==")")
                {
                    vec=call(vec,i,k);
                }


        }

    }
    for(int i=a+1;i<b;i++)
    {
        if(vec->at(i)=="+")
        {
            vec->at(i)=QString::number((vec->at(i-1).toDouble()*vec->at(i+1).toDouble()));
            vec->remove(i-1);
            vec->remove(i+1);

        }
        if(vec->at(i)=="-")
        {
             vec->at(i)=QString::number((vec->at(i-1).toDouble()*vec->at(i+1).toDouble()));
            vec->remove(i-1);
            vec->remove(i+1);

        }
    }
    vec->remove(a);
    vec->remove(b);
    return vec;
}
double sin(double x)
{
    double sum=0;
    for(int i=1;i<11;i++)
    {

        sum+=(pow(x,2*i-1)/fac(2*i-1))*pow(-1,i+1);
    }
}
double cos(double x)
{
    double sum=0;
    for(int i=0;i<10;i++)
    {

        sum+=pow(x,2*i)/fac(2*i);
    }
}
double pow (double x,int a)
{
    double mul=1;
    for(int i=0;i<a;i++)
    {
        mul=mul*x;
    }
     return mul;


}
double fac(int a)
{
    if(a==1 || a==0)
        return 1;
    else
        return a*fac(a-1);
}

}
MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{
    ui->lineEdit->insert("1");
    str=str+"1";
}

void MainWindow::on_pushButton_2_clicked()
{

    ui->lineEdit->insert("2");
    str=str+"2";
}

void MainWindow::on_pushButton_3_clicked()
{
      ui->lineEdit->insert("3");
      str=str+"3";
}

void MainWindow::on_pushButton_4_clicked()
{
      ui->lineEdit->insert("4");
      str=str+"4";
}

void MainWindow::on_pushButton_5_clicked()
{
      ui->lineEdit->insert("5");
      str=str+"5";
}

void MainWindow::on_pushButton_6_clicked()
{
      ui->lineEdit->insert("6");
      str=str+"6";
}

void MainWindow::on_pushButton_7_clicked()
{
      ui->lineEdit->insert("7");
      str=str+"7";
}

void MainWindow::on_pushButton_8_clicked()
{
      ui->lineEdit->insert("8");
      str=str+"8";
}

void MainWindow::on_pushButton_9_clicked()
{
      ui->lineEdit->insert("9");
      str=str+"9";
}

void MainWindow::on_pushButton_16_clicked()
{
      ui->lineEdit->insert("0");
      str=str+"0";
}

void MainWindow::on_pushButton_10_clicked()
{
    vec->push_back(str);
    ui->lineEdit->insert("+");
    vec->push_back("+");
    str="";

}

void MainWindow::on_pushButton_11_clicked()
{
    vec->push_back(str);
    ui->lineEdit->insert("-");
    vec->push_back("-");
    str="";
}

void MainWindow::on_pushButton_12_clicked()
{
    vec->push_back(str);
    ui->lineEdit->insert("*");
    vec->push_back("*");
    str="";
}

void MainWindow::on_pushButton_13_clicked()
{
    vec->push_back(str);
    ui->lineEdit->insert("/");
    vec->push_back("/");
    str="";
}

void MainWindow::on_pushButton_18_clicked()
{
    vec->push_back(str);
    ui->lineEdit->insert("(");
    vec->push_back("(");
    str="";
}

void MainWindow::on_pushButton_19_clicked()
{
    vec->push_back(str);
    ui->lineEdit->insert(")");
    vec->push_back(")");
    str="";
}

void MainWindow::on_pushButton_14_clicked()
{
    vec->push_back(str);
    ui->lineEdit->insert("sin");
    vec->push_back("sin");
    str="";
}

void MainWindow::on_pushButton_15_clicked()
{
    vec->push_back(str);
    ui->lineEdit->insert("cos");
    vec->push_back("cos");
    str="";
}

d ad;


void MainWindow::on_pushButton_17_clicked()
{

    if(vec->size()==1)
    {
       ui->lineEdit->insert("=");
       ui->lineEdit->insert(vec->pop_back());
    }
    else
    {

    vec->push_back(str);
    str="";
    for(int i=0;i<vec->size();i++)
    {
        if(vec->at(i)=="(")
        {
            for(int j=i;j<vec->size();j++)
                if(vec->at(j)==")")
                       vec=ad.call(vec,i,j);
        }
        if(vec->at(i)=="sin")
        {
            vec->at(i)=QString::number(ad.sin(vec->at(i+1).toDouble()));
            vec->remove(i+1);

        }
        else if(vec->at(i)=="cos")
        {
            vec->at(i)=QString::number(ad.cos(vec->at(i+1).toDouble()));
            vec->remove(i+1);

        }
        else if(vec->at(i)=="*")
        {
            vec->at(i)=QString::number((vec->at(i-1).toDouble()*vec->at(i+1).toDouble()));
            vec->remove(i-1);
            vec->remove(i+1);

        }
        else if(vec->at(i)=="/")
        {
            vec->at(i)=QString::number((vec->at(i-1).toDouble()*vec->at(i+1).toDouble()));
            vec->remove(i-1);
            vec->remove(i+1);

        }


    }
    for(int i=0;i<vec->size();i++)
    {
        if(vec->at(i)=="+")
        {
           vec->at(i)=QString::number((vec->at(i-1).toDouble()*vec->at(i+1).toDouble()));
            vec->remove(i-1);
            vec->remove(i+1);

        }
        if(vec->at(i)=="-")
        {
            vec->at(i)=QString::number((vec->at(i-1).toDouble()*vec->at(i+1).toDouble()));
            vec->remove(i-1);
            vec->remove(i+1);

        }
    }
}

