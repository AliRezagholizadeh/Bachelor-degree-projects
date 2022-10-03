#ifndef TRANSLATE_H
#define TRANSLATE_H
//#include "linklist.h"
#include "files.h"
#include "jomle.h"
#include <vector>
#include <string>
#include <QtGui>
#include <fstream>
using namespace std;


class translate
{
public:
    translate(QTextEdit*,QString);
    string strenglish;
    QString qstrenglish;
    QTextEdit* text;
    files file;
    //jomle jom;
    bool have(string str,string tr);
    bool haveatfirst(string,string);
    bool haveatlast(string,string);



    void setstatement(vector<string>*);
    void translatejomle(vector<string>*,string [],int);

    string withoutsubstring(string,string);
    string withoutsubstringfromend(string,string);
    string firstcommonsubstring(string,string);


    vector<string>*fael;
   // vector<string>*faelshenase;
    vector<string>*mafaul;
    vector<string>*motammam;
    vector<string>*gheyd;
    vector<string>*mosnad;
    vector<string>*fel;
    vector<string>src;

    vector<string>* transjoz(vector<string>*,int);

    vector<string> farsistatement;
    vector<string>* flexiblestatement;
    //vector<string>* statements;

    void loadjomle();
    int numberofstatements;
    bool ispronunce(char);
    string jamnuon(string);


};

#endif // TRANSLATE_H
