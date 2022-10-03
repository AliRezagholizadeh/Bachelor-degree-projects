#include "files.h"
//#include "linklist.h"
#include "translate.h"
#include <fstream>
#include <vector>
#include <QString>
#include <ios>
#include <iostream>
#include <string>

using namespace std;
using std::ios;

files::files()
{



}

void files::filldatabase()
{

    //[0] :::::esm
    string tr;
    database.open("esm.txt");
    while(database>>tr){
        esm.push_back(tr);
    }

    database.close();


    //[1] :::::sefat
    string tr1;
    database.open("sefat.txt");
    while(database>>tr1){
      sefat.push_back(tr1);
    }

    database.close();

    //[2] :::::gheyd
    string tr2;
    database.open("gheyd.txt");
    while(database>>tr2){
      gheyd.push_back(tr2);
    }

    database.close();

    //[3] [0]:::::fel
        //[0]::::: gozashte
    string tr3;
//    database.open("felgozashte.txt");
//    while(database>>tr3){
//      felgozashte.push_back(tr3);
//    }

  //  database.close();
        //[1] :::: hal
    database.open("fel.txt");
    while(database>>tr3){
      fel.push_back(tr3);
    }
      database.close();
        //[2]:::: ayande
//      database.open("felayande.txt");
  //    while(database>>tr3){
    //    felayande.push_back(tr3);
    //}
      //  database.close();




     //[4]::::::harfezafe
      string tr4;
      database.open("harfezafe.txt");
      while(database>>tr4){
        harfezafe.push_back(tr4);
        }
        database.close();

        //[5] ::sefatepishin
        database.open("sefatepishin.txt");
        while(database>>tr4){
          sefatepishin.push_back(tr4);
          }
          database.close();

          //[6] ::sefatepasin
          database.open("sefatepasin.txt");
          while(database>>tr4){
            sefatepasin.push_back(tr4);
            }
            database.close();


            //[7] ::zamir
            database.open("zamir.txt");
            while(database>>tr4){
              zamir.push_back(tr4);
              }
              database.close();

              database.open("zamirmafauli.txt");
              while(database>>tr4){
                zamirmafauli.push_back(tr4);
                }
                database.close();

                database.open("sefatemelki.txt");
                while(database>>tr4){
                  sefatemelki.push_back(tr4);
                  }
                  database.close();

}

void files::fillsource(QString filesourcename)
{

    string tr5;
    string d;

    if(filesourcename.toStdString().compare("")!=0)
        d="source.txt";
    else
        d="source.txt";
    if(filesourcename.compare("")==0)
        filesourcename="source.txt";
    //cout<<filesourcename.toStdString()<<"file **";
    char* g=(char*)(filesourcename.toStdString().c_str());

    source.open(g);
    while(source>>tr5){
      src.push_back(tr5);
    }


    source.close();




    //[6] ::::::joda kardane jomleha va gozashtane har jomle dar khane i az vector(pointer az vector)

bool signback=false;                        //mige aya alaeme payane jomle dar kalameye(src[i]) ghabli rokh dade ya na.
    for(int i=0;i<src.size();i++)
        signback=cunstractsrcpart(src[i],signback);

    numberofstatements=numberofstatement(srcpart);
    statements=new vector<string>[numberofstatements];
setstatements();                         //jomle ha ro az ruye srcpart joda mikonad V har kodumo tu ye khune ye vrctor mirizad

}

void files::setstatements()                        //har jomle ro dar har khoone i az araye be soorate vector negah midarad
{

    vector <string> komaki;
    int i=0,j=0,l=0;
    while(i!=srcpart.size())
    {
        if(isendstatement(srcpart[i]))
        {
            for(int x=j;x<=i;x++)
                statements[l].push_back(srcpart[x]);
            j=i+1;
            l++;
        }
        i++;
    }
    if(!isendstatement(srcpart[srcpart.size()-1])){
        for(int k=j;k<srcpart.size();k++)
            statements[l].push_back(srcpart[k]);
    }
    //for(int i=0;i<3;i++)
      //  for(int j=0;j<statement[i].size();j++)
        //    cout<<statement[i][j]<<" ";
    //cout<<"tof";

}


            bool files::isendstatement(string str)
            {
                if(str.size()==1)
                    if(str.compare(".")==0 || str.compare("?")==0 || str.compare("!")==0)
                        return true;
                      else
                        return false;
                else
                    if(str.at(0)=='.' || str.at(0)=='?' || str.at(0)=='!')
                        return true;
                    else
                        return false;
            }
            bool files::isendstatement(char str)
            {
                if(str=='.' || str=='?' || str=='!')
                    return true;
                else
                    return false;
            }

            bool files::issign(char str)
            {
                if(str=='.' || str=='?' || str=='!'|| str==',' || str==':' || str==';' || str=='@' || str=='%' || str=='"')
                    return true;
                else if(str=='&' || str=='*' || str=='(' || str==')' || str=='_' || str=='-' || str=='=' || str=='+')
                    return true;
                else if(str=='{' || str=='[' || str==']' || str=='}' || str=='|' || str=='/' || str=='<' || str=='>')
                    return true;
                else if(str=='#' || str=='$' || str=='^' )
                    return true;
                else
                    return false;
            }

            bool files::issign(string str)
            {
                if(str.at(0)=='.' || str.at(0)=='?' || str.at(0)=='!' || str.at(0)==',')
                    return true;
                else if(str.at(0)==':' || str.at(0)==';' || str.at(0)=='@' || str.at(0)=='%' || str.at(0)=='"')
                    return true;
                else if(str.at(0)=='&' || str.at(0)=='*' || str.at(0)=='(' || str.at(0)==')')
                    return true;
                else if(str.at(0)=='_' || str.at(0)=='-' || str.at(0)=='=' || str.at(0)=='+')
                    return true;
                else if(str.at(0)=='{' || str.at(0)=='[' || str.at(0)==']' || str.at(0)=='}')
                    return true;
                else if(str.at(0)=='|' || str.at(0)=='/' || str.at(0)=='<' || str.at(0)=='>')
                    return true;
                else if(str.at(0)=='#' || str.at(0)=='$' || str.at(0)=='^' )
                    return true;
                else
                    return false;
            }

            bool files::ispransis(char str)
            {
                if(str=='(' || str==')' || str=='{' || str=='[' || str==']' || str=='}')
                    return true;
                else
                    return false;

            }

            bool files::ispransis(string str)
            {
                if(str.at(0)=='(' || str.at(0)==')' || str.at(0)=='{' || str.at(0)=='[' || str.at(0)==']' || str.at(0)=='}')
                    return true;
                else
                    return false;

            }

            bool files::cunstractsrcpart(string str,bool signback)
            {
                string word="";
                string sign="";
                int num=0;
                bool f[2];                         //age f false bashe yani ke akharin bar be yek endof statement barkhorde

                if(isendstatement(str.at(0))){
                    f[0]=false;
                    f[1]=false;
                   num=1;

                }
                if(issign(str.at(0)) && !ispransis(str.at(0))){
                    f[0]=false;
                    f[1]=false;


                }

                else if(ispransis(str.at(0)))
                {
                    f[0]=false;
                    f[1]=true;
                }
                else{
                    f[0]=true;
                    f[1]=false;
                }



                int j=0;
                for(int i=0;i<str.size();i++){

                    if(issign(str.at(i)) && !ispransis(str.at(i)))
                    {
                        if(f[0]==true)
                            srcpart.push_back(word);

                        word="";
                        sign+=str.at(i);
                        if(i==str.size()-1){
                            srcpart.push_back(sign);
                            sign="";
                        }

                        f[0]=false;
                        f[1]=false;


                    }
                    else if(!issign(str.at(i)))
                    {
                        if(f[0]==false && f[1]==false && num==1 && signback==true)
                        {
                            srcpart.pop_back();
                            sign=stack[0]+sign;
                            srcpart.push_back(sign);
                            stack.clear();
                            num=0;
                        }
                        else if(f[0]==false && f[1]==false)
                            srcpart.push_back(sign);
                        word+=str.at(i);
                        if(i==str.size()-1){
                            srcpart.push_back(word);
                            word="";
                        }
                        sign="";
                        f[0]=true;
                    }


                    if(ispransis(str.at(i)))
                    {
                        if(f[0]==true){
                            srcpart.push_back(word);
                            word="";
                        }
                        else if(f[0]==false && f[1]==false && num==1 && signback==true){       //f[1]=false yani pranthis nist
                            srcpart.pop_back();
                            sign=stack[0]+sign;
                            srcpart.push_back(sign);
                            stack.clear();
                            num=0;

                        }
                         else if(f[0]==false && f[1]==false)
                        {
                            srcpart.push_back(sign);
                        }

                        sign="";
                        word="";
                        sign+=str.at(i);
                        srcpart.push_back(sign);
                        sign="";
                        f[1]=true;
                        f[0]=false;
                    }


                }

                if(issign(srcpart[srcpart.size()-1]) && !ispransis(srcpart[srcpart.size()-1]))
                {
                     stack.push_back(srcpart[srcpart.size()-1]);
                     return true;
                }
                else
                     return false;

            }



            int files::numberofstatement(vector<string> vec)
            {
                int number=0;
                for(int i=0;i<vec.size();i++)
                    if(isendstatement(vec[i]))
                        number++;
                if(!isendstatement(vec[vec.size()-1]))
                    number++;
                return number;
            }

            bool files::haveatfirst(string str,string tr)
            {
                int j=0;
                for(int i=0;i<tr.size();i++){
                    if(str.at(i)==str.at(j))
                        j++;
                    if(j==tr.size())
                        return true;
                }
                return false;
            }
            bool files::haveatlast(string str,string tr)
            {
                int j=str.size()-1;
                int k=0;
                for(int i=tr.size()-1;i>=0;i--){
                    if(str.at(i)==str.at(j)){
                        j--;
                        k++;
                    }
                    if(k==tr.size())
                        return true;
                }
                return false;
            }



