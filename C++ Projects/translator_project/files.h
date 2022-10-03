#ifndef FILES_H
#define FILES_H
//#include "linklist.h"
#include <fstream>
#include <iostream>
#include <vector>
#include <QString>
#include <string>
#include <stack>
using namespace std;

class files
{
public:
    files();
    void setstatements();  //jomle haye file ro dar khod negah midarad

    bool isendstatement(string);
    bool isendstatement(char);
    bool issign(char);
    bool issign(string);
    bool ispransis(char);
    bool ispransis(string);
    bool cunstractsrcpart(string,bool);  //har khooneye src ro barresi mikone bad kalemat ro dar scrpart mirizad

    bool haveatfirst(string,string);
    bool haveatlast(string,string);

    void filldatabase();
    void fillsource(QString);

    int numberofstatement(vector<string>);
    char line[20];
    ifstream database;
    ifstream source;
    vector <string> esm;
    vector <string> sefat;
    vector <string> gheyd;
    //vector <string> felgozashte;
    vector <string> fel;
    //vector <string> felayande;
    vector <string> sefatepishin;
    vector <string> sefatepasin;
    vector <string> zamir;

    vector<string> zamirmafauli;
    vector<string> sefatemelki;
    vector<string> zamirmelki;

    vector <string> harfezafe;
    //linklist <string>*src;
    vector <string> src;
    vector <string>srcpart;
    vector <string> *statements;

    int numberofstatements;




private:
    vector <string> stack;



};

#endif // FILES_H
