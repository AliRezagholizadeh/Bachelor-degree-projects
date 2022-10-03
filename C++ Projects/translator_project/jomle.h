#ifndef JOMLE_H
#define JOMLE_H
#include "files.h"
#include <vector>
#include <string>
using namespace std;


class jomle
{
public:
    jomle();
    files file;
    void partofstatement();                     //DAR .CPP BE KAR NARAFTE
    void makeflexiblestatement();
    void makeflexiblestatementbyjodasazi();         //DAR .CPP BE KAR NARAFTE
    void fillextravec();

    bool isendstatement(string);
    bool isendstatement(char);
    bool issign(char);
    bool issign(string);
    bool have(string str,string tr);
    bool haveatfirst(string,string);
    bool haveatlast(string,string);

    void search(string,int);
    void havefael();
    void nowejomle();
    void ajzayejomle();
    void jodasaziyeneshaneha();
    void setflexilestatement(vector<string>*);      //EHTEMALAN DAR .CPP BE KAR NARAFTE
    void zamanejomle();

    string search(string);
    string withoutsubstring(string,string);
    string withoutsubstringfromend(string,string);
    string withoutsubstring2(string,string);
    string withoutsubstringatfirst(string,string);
    string firstcommonsubstring(string,string);
    string makeassignstr2properti(string,string,string);

    vector <string> esm;
    vector <string> sefat;
    vector <string> gheyd;
    //vector <string> felgozashte;
    vector <string> fel;
    //vector <string> felayande;
    vector <string> harfezafe;
    vector <string> sefatepishin;
    vector <string> sefatepasin;
    vector <string> zamir;


    vector<string> zamirmafauli;
    vector<string> sefatemelki;
   // vector<string> zamirmelki;


    vector <string> translatestatement;

    void setstatement(vector<string>vec);       //dar inja statement ra meghdar midahad(tanha yr jomle)
    vector<string> statement;                    //ye jole az jomle haye statements az files ast
    vector<string>*flexiblestatement;

    string propertisofstatement[5];
private:
        int partofmainstatement;
        int numberofharf(string);
        vector <string> neshanehayeayande;
        vector <string> neshanehayejam;
};

#endif // JOMLE_H
