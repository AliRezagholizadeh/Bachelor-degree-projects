#include "mainwindow2.h"
#include "ui_mainwindow2.h"
#include <qmath.h>
#include <QString>
#include <sstream>
QString str="";
double num=0;
QString op="";
QString mos="";
bool b=false;

MainWindow2* MainWindow2::instance = NULL;

class d
{
public:
double sin(double x)
{

    double sum=0;
    for(int i=1;i<11;i++)
    {

        sum+=(pow(x,2*i-1)/fac(2*i-1))*pow(-1,i+1);
    }
    return sum;
}
double cos(double x)
{
    double sum=0;
    for(int i=0;i<10;i++)
    {

        sum+=pow(x,2*i)/fac(2*i);
    }
    return sum;
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
void mod()
{
    int num3=(int)num;
    int num2=str.toInt();
    num3=num3/num2;
    num=num-(double)(num2*num3);
    str="";
    op="";

}


void sum()
{

    num=str.toDouble()+num;

     str="";
     op="";
}
void minus()
{
    num=num-str.toDouble();

     str="";
     op="";
}
void mul()
{
    num=num*str.toDouble();

     str="";
     op="";
}
void div()
{
    num=num/str.toDouble();

     str="";
     op="";
}
void check()
{
    if(mos.compare("sin")!=0 && mos.compare("cos")!=0)

    {
    if(op.compare("%")==0)
    {
       mod();
    }
    else if(op.compare("+")==0)
    {
        sum();


    }
    else if(op.compare("-")==0)
    {
        minus();


    }
   else if(op.compare("*")==0)
    {
        mul();


    }
   else if(op.compare("/")==0)
    {
        div();


    }
    }
   else if(str.compare("")!=0 && mos.compare("sin")==0)
   {

       str=QString::number(sin(str.toDouble()));
       mos="";
       check();
   }
   else if(str.compare("")!=0 && mos.compare("cos")==0)
   {
       str=QString::number(cos(str.toDouble()));
       mos="";
       check();
   }
}
};
MainWindow2::MainWindow2(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow2)
{
    ui->setupUi(this);
}

MainWindow2* MainWindow2::getWindow()
{
    if(!instance)
        instance = new MainWindow2;
    return instance;
}

MainWindow2::~MainWindow2()
{
    delete ui;
}

void MainWindow2::on_pushButton_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("1");
    str=str+"1";
}

void MainWindow2::on_pushButton_2_clicked()
{

    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("2");
    str=str+"2";
}

void MainWindow2::on_pushButton_3_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("3");
    str=str+"3";
}

void MainWindow2::on_pushButton_4_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("4");
    str=str+"4";
}

void MainWindow2::on_pushButton_5_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("5");
    str=str+"5";
}

void MainWindow2::on_pushButton_6_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("6");
    str=str+"6";
}

void MainWindow2::on_pushButton_7_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("7");
    str=str+"7";
}

void MainWindow2::on_pushButton_8_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("8");
    str=str+"8";

}

void MainWindow2::on_pushButton_9_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("9");
    str=str+"9";
}

void MainWindow2::on_pushButton_10_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("0");
    str=str+"0";
}

void MainWindow2::on_pushButton_12_clicked()
{


    d ad;
    if(op.compare("")==0)
    {
        num=str.toDouble();
        ui->lineEdit->clear();
        op="+";
        str="";
    }
    else
    {
        ad.check();
        op="+";

        ui->lineEdit->clear();
        ui->lineEdit->insert(QString::number(num));
    }


   op="";
   op="+";
   str="";
   b=true;

}

void MainWindow2::on_pushButton_13_clicked()
{
    d ad;
    if(op.compare("")==0)
    {
        num=str.toDouble();
        ui->lineEdit->clear();
        op="-";
        str="";
    }
    else
    {
        ad.check();
        op="-";

        ui->lineEdit->clear();
        ui->lineEdit->insert(QString::number(num));
    }


        op="";
        op="-";
        str="";
        b=true;

}

void MainWindow2::on_pushButton_14_clicked()
{
    d ad;
    if(op.compare("")==0)
    {
        num=str.toDouble();
        ui->lineEdit->clear();
        op="*";
        str="";
    }
    else
    {
        ad.check();
        op="*";

        ui->lineEdit->clear();
        ui->lineEdit->insert(QString::number(num));
    }


        op="";
        op="*";
        str="";
        b=true;
}

void MainWindow2::on_pushButton_15_clicked()
{
    d ad;
    if(op.compare("")==0)
    {
        num=str.toDouble();
        ui->lineEdit->clear();
        op="/";
        str="";
    }
    else
    {
        ad.check();
        op="/";

        ui->lineEdit->clear();
        ui->lineEdit->insert(QString::number(num));
    }



        op="";
        op="/";
        str="";
        b=true;
}

void MainWindow2::on_pushButton_18_clicked()
{
    ui->lineEdit->clear();
    num=0;
    str="";
    op="";
    mos="";
    b=false;
}

void MainWindow2::on_pushButton_11_clicked()
{
    d ad;
   if(op.compare("")==0)
   {
       ui->lineEdit->clear();
       ui->lineEdit->insert(QString::number(num));
   }
   else
   {
       ad.check();
       ui->lineEdit->clear();
       ui->lineEdit->insert(QString::number(num));
   }
    b=true;
}

void MainWindow2::on_pushButton_16_clicked()
{
       d ad;
       mos="sin";
       ad.check();
       ui->lineEdit->clear();
       if(num!=0)
       ui->lineEdit->insert(QString::number(num));
       b=true;

}

void MainWindow2::on_pushButton_17_clicked()
{
    d ad;
    mos="cos";
    ad.check();
    ui->lineEdit->clear();
    if(num!=0)
    ui->lineEdit->insert(QString::number(num));
    b=true;

}

void MainWindow2::on_pushButton_19_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert(".");
    str=str+".";
}

void MainWindow2::on_pushButton_20_clicked()
{
    if(b==true)
        ui->lineEdit->clear();
    b=false;
    ui->lineEdit->insert("-");
    str="-"+str;
}

void MainWindow2::on_pushButton_21_clicked()
{
    d ad;
    if(op.compare("")==0)
    {
        num=str.toDouble();
        ui->lineEdit->clear();
        op="%";
        str="";
    }
    else
    {
        ad.check();
        op="%";

        ui->lineEdit->clear();
        ui->lineEdit->insert(QString::number(num));
    }




        str="";
        b=true;
}
