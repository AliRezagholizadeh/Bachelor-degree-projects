#include "translate.h"
#include "jomle.h"
#include "files.h"
//#include "linklist.h"
#include <vector>
#include <QtGui>
#include <string>
#include <iostream>
#include <fstream>
#include <fstream>
using namespace std;


translate::translate(QTextEdit* text2,QString filesourcename)
{
    text=text2;
    file.fillsource(filesourcename);
    //cout<<file.numberofstatements<<" ";
    numberofstatements=file.numberofstatements;
    vector<string>*statements=new vector<string>[numberofstatements];
    for(int i=0;i<numberofstatements;i++)
           for(int j=0;j<file.statements[i].size();j++)
               statements[i].push_back(file.statements[i][j]);
/*

    cout<<"\n";
    for(int i=0;i<numberofstatements;i++)
    {
        cout<<"\n";
        for(int j=0;j<statements[i].size();j++)
            cout<<statements[i][j]<<"  ";
    }
    */
//-----------------------------------------------------------------------------------------------------tested

   setstatement(statements);
}

void translate::setstatement(vector<string>* statements)
{

    //cout<<"\n\n";
    for(int i=0;i<numberofstatements;i++){
        farsistatement=statements[i];
        loadjomle();
        farsistatement.clear();
    }


    qstrenglish=QString::fromStdString(strenglish);

    text->setText(qstrenglish);                             //

}

void translate::loadjomle()
{

    jomle jom;
    //cout<<"\n";
    string propertisofstatement[5];
    jom.fillextravec();
    //for(int i=0;i<farsistatement.size();i++)
      //  cout<<farsistatement[i]<<"  "<<farsistatement.size();

    jom.setstatement(farsistatement);
   // cout<<"\n\n";
    //for(int i=0;i<farsistatement.size();i++)
      //  cout<<jom.statement[i]<<"  ";
    jom.jodasaziyeneshaneha();
    jom.makeflexiblestatement();     //**baraye har kalame ;mani,va inke dar kodum file hast va age nabashe "harf" gharar mide.
   jom.ajzayejomle();
    //--------------------------------------------------------------------------------------------tested
    int numberofworld=jom.statement.size();
    cout<<jom.statement.size()<<" *  ";
   flexiblestatement=new vector<string>[numberofworld];


    for(int i=0;i<numberofworld;i++)
       for(int j=0;j<jom.flexiblestatement[i].size();j++)
            flexiblestatement[i].push_back(jom.flexiblestatement[i][j]);
    cout<<"\n";


    for(int i=0;i<farsistatement.size();i++){
        cout<<"\n";
        for(int j=0;j<flexiblestatement[i].size();j++)
            cout<<"("<<flexiblestatement[i][j]<<")"<<"  ";
    }

   // cout<<numberofworld<<"***85";

    //---------------------------------------------------------------------------------------------tested



    propertisofstatement[0]=jom.propertisofstatement[0];
    propertisofstatement[1]=jom.propertisofstatement[1];
    propertisofstatement[2]=jom.propertisofstatement[2];
    propertisofstatement[3]=jom.propertisofstatement[3];
    propertisofstatement[4]=jom.propertisofstatement[4];

    cout<<"\n";
    for(int i=0;i<5;i++)
        cout<<jom.propertisofstatement[i]<<"  ";

    //---------------------------------------------------------------------------------------------------tested
    translatejomle(flexiblestatement,propertisofstatement,farsistatement.size());


}

void translate::translatejomle(vector<string>*flexiblestatement,string propertisofstatement[],int numberofworld)
{


/*
    linklist fael;
    linklist mafaul;
    linklist gheyd;
    linklist motammam;
    linklist mosnad;
    linklist fel;


    for(int i=0;i<numberofworld;i++){
        if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"fael"))
            fael.push(flexiblestatement[i]);
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"mafaul"))
            mafaul.push(flexiblestatement[i]);
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"gheyd"))
            gheyd.push(flexiblestatement[i]);
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"motammam"))
            motammam.push(flexiblestatement[i]);
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"mosnad"))
            mosnad.push(flexiblestatement[i]);
        else if(flexiblestatement[i][1]!="null")
            fel.push(flexiblestatement[i]);
    }
*/



    int numfael=0;
    int nummafaul=0;
    int nummotammam=0;
    int numgheyd=0;
    int nummosnad=0;
    int numfel=0;

    //[]..........tedade kalemat e har joz ra moshakhas mikone

    for(int i=0;i<numberofworld;i++){
        if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"fael"))
            numfael++;
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"mafaul"))
            nummafaul++;
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"gheyd"))
            numgheyd++;
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"motammam"))
            nummotammam++;
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"mosnad"))
            nummosnad++;
        else if(flexiblestatement[i][1]!="null" && have(flexiblestatement[i][2],"fel"))
            numfel++;
    }



            //[].......be andaze ye kalemat e har joz , baraye an joz araye i be in tool az vector misazad

    if(numfael!=0)
          fael=new vector<string>[numfael];
          else
              fael=new vector<string>[1];
    mafaul=new vector<string>[nummafaul];
    motammam=new vector<string>[nummotammam];
    gheyd=new vector<string>[numgheyd];
    mosnad=new vector<string>[nummosnad];
    fel=new vector<string>[numfel];



            //[].......... har kalame ro dar joze khod gharar midahad

    int n1=0,n2=0,n3=0,n4=0,n5=0,n6=0;
    int numberoftransedword=0;

    for(int i=0;i<numberofworld;i++){
        if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"fael")){
            for(int j=0;j<flexiblestatement[i].size();j++)
                fael[n1].push_back(flexiblestatement[i][j]);
            numberoftransedword++;
            n1++;
        }
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"mafaul")){
            for(int j=0;j<flexiblestatement[i].size();j++)
                mafaul[n2].push_back(flexiblestatement[i][j]);
            numberoftransedword++;
            n2++;
        }
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"gheyd")){
            for(int j=0;j<flexiblestatement[i].size();j++)
                gheyd[n3].push_back(flexiblestatement[i][j]);
            numberoftransedword++;
            n3++;
        }
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"motammam")){
            for(int j=0;j<flexiblestatement[i].size();j++)
                motammam[n4].push_back(flexiblestatement[i][j]);
            numberoftransedword++;
            n4++;
        }
        else if(flexiblestatement[i].size()>=4 && flexiblestatement[i][1]!="null" && have(flexiblestatement[i][3],"mosnad")){
            for(int j=0;j<flexiblestatement[i].size();j++)
                mosnad[n5].push_back(flexiblestatement[i][j]);
            numberoftransedword++;
            n5++;
        }
        else if(flexiblestatement[i][1]!="null" && have(flexiblestatement[i][2],"fel")){
            for(int j=0;j<flexiblestatement[i].size();j++)
                fel[n6].push_back(flexiblestatement[i][j]);
            numberoftransedword++;
            n6++;
        }
    }

            //[]...................baraye inke agar faele barez nadasht


    if(numfael==0 && numfel==1){
        numberoftransedword++;
        propertisofstatement[3]="fael ba shenase";
        if(propertisofstatement[4]=="empty"){
             fael[0].push_back(fel[0][3]);
             fael[0].push_back(fel[0][3]);
             fael[0].push_back("zamir");
             fael[0].push_back("goruhe esmi fael shenase");
             propertisofstatement[4]=fel[0][3];
        }
        else
        {
            fael[0].push_back(propertisofstatement[4]);
            fael[0].push_back(propertisofstatement[4]);
            fael[0].push_back("zamir");
            fael[0].push_back("goruhe esmi ayande shenase ");
        }
    }
   // if(numfael==0)
     //   numfael=1;


    cout<<"\n\n===========================================================================";









            //[]............har joz ra bar asas ghavaede tarjomei MORATAB mikone
     if(numfael!=0)
     fael=transjoz(fael,numfael);
     else
         fael=transjoz(fael,1);
     if(nummafaul!=0)
        mafaul=transjoz(mafaul,nummafaul);
     if(nummotammam!=0)
        motammam=transjoz(motammam,nummotammam);
     if(numgheyd!=0)
        gheyd=transjoz(gheyd,numgheyd);
     if(nummosnad!=0)
        mosnad=transjoz(mosnad,nummosnad);
     //cout<<fael[0][1];

   //  if(nummafaul!=0)
     //for(int i=0;i<nummafaul;i++)
       //  cout<<mafaul[i][1]<<" ";

   //  if(numfael!=0)
     //for(int i=0;i<numfael;i++)
       //  cout<<fael[i][1]<<" ";



    cout<<nummafaul<<"<---";

     //[][][][][].........CHAP TARJOME YE KALEMAT


if(propertisofstatement[0]!="soali")
 {
     int counter=0;
    while(counter<numberoftransedword)
    {
        if(numfael!=0)
            for(int i=0;i<numfael;i++,counter++)
                strenglish+=(fael[i][1]+" ");
        else{
            strenglish+=(fael[0][1]+" ");
            counter++;
        }
        if(propertisofstatement[1]=="manfi" && propertisofstatement[2]!="ayande")
        {
            if(fel[0][1]!="am" && fel[0][1]!="is" && fel[0][1]!="are")
                strenglish+="don't ";
            counter++;

        }
        if(propertisofstatement[2]=="ayande"){
            if(propertisofstatement[1]=="mosbat")
                strenglish+="will ";
            else
                strenglish+="willnot ";
            counter++;
        }

       // if(propertisofstatement[2]=="ayande")
            strenglish+=(fel[0][1]+" ");
        counter++;
        if(propertisofstatement[1]=="manfi" && propertisofstatement[2]!="ayande")
        {
             if(fel[0][1]=="am" || fel[0][1]=="is" || fel[0][1]=="are")
                 strenglish+="not ";
             counter++;
         }
        for(int i=0;i<nummafaul;i++,counter++)
            strenglish+=(mafaul[i][1]+" ");
        for(int i=0;i<nummotammam;i++,counter++){
            if(motammam[i].size()>4){
                strenglish+=(motammam[i][4]+" ");
                strenglish+=(motammam[i][1]+" ");
            }
             else
                 strenglish+=(motammam[i][1]+" ");
         }

        for(int i=0;i<numgheyd;i++,counter++)
            strenglish+=(gheyd[i][1]+" ");
        for(int i=0;i<nummosnad;i++,counter++)
            strenglish+=(mosnad[i][1]+" ");

    }

    strenglish+=(flexiblestatement[numberofworld-1][0]+"  ");
}


   // cout<<withoutsubstring("darmadrese","dar");

   //  text->setText(QString::append(flexiblestatement[numberofworld-1]));


    //fael->clear();
    //mafaul->clear();
    //gheyd->clear();
    //motammam->clear();
    //mosnad->clear();
    //fel->clear();


}

vector<string>* translate::transjoz(vector<string> * flexible,int size)  //[]::har joz (mesle fael )ra ke besh bedim
        // moratab mikone ;haminja ham age kalamei jam bud an ra dar khune ye marbut be mani e'mal mikone
{


    vector<string>* vecptr=new vector<string>[size];

    int counter=0;


    if(size==1){
        if(flexible[0].size()>=4 && have(flexible[0][3],"jam"))
        {
            flexible[0][1]=jamnuon(flexible[0][1]);

        }
        return flexible;
    }

 while(counter<size)
 {

     //[][][] ...... harfe azafe
     if(counter<size && !have(flexible[1][3],"motammam"))
     {
        for(int i=0;i<size;i++)
        {

            if(counter<size && flexible[i][2]=="harfezafe"){
                for(int j=0;j<flexible[i].size();j++)
                 vecptr[counter].push_back(flexible[i][j]);
             counter++;
         }
        }
    }
     else if(counter<size && have(flexible[1][3],"motammam")){
     for(int i=0;i<size;i++)
     {
         if(have(flexible[i][2],"esm") && flexible[i].size()>4)
            if(counter<size)
            {
                vecptr[counter].push_back(flexible[i][4]);
                vecptr[counter].push_back(flexible[i][4]);
                counter++;
                break;
            }
         if(i<size-2 && flexible[i+1][2]=="harfe rabt" && have(flexible[i+2][2],"esm"))
         {
             for(int j=0;j<flexible[i+1].size();j++)
                 vecptr[counter].push_back(flexible[i+1][j]);
             counter++;
             vecptr[counter].push_back(flexible[i][4]);
             vecptr[counter].push_back(flexible[i][4]);
         }

     }
 }

    for(int i=0;i<size;i++)
    {
        if(counter<size && flexible[i][2]=="sefatepishin"){
            for(int j=0;j<flexible[i].size();j++)
                vecptr[counter].push_back(flexible[i][j]);

            if(flexible[i].size()>=4 && have(flexible[i][3],"jam"))
            {
                if(flexible[i][1]=="that")
                    vecptr[counter][1]="those";
                else if(flexible[i][1]=="this")
                    vecptr[counter][1]="these";

            }
            counter++;
            if(counter<size && i<size-1 && flexible[i+1].size()>=4 && have(flexible[i+1][3],"harfe rabt")){
                for(int j=0;j<flexible[i+1].size();j++)
                    vecptr[counter].push_back(flexible[i+1][j]);
             counter++;
            }
        }
    }

     for(int i=0;i<size;i++)
     {
        if(counter<size && flexible[i].size()>=4 && have(flexible[i][3],"mozafonelayh")){
            for(int j=0;j<flexible[i].size();j++)
                vecptr[counter].push_back(flexible[i][j]);

            if(counter<size && have(flexible[i][3],"jam"))
            {
                vecptr[counter][1]=jamnuon(flexible[i][1]);
            }
            if(counter<size && flexible[i][2]!="zamir")
                vecptr[counter][1]+="'s";

            counter++;


            if(counter<size && i<size-1 && flexible[i+1].size()>=4 && have(flexible[i+1][3],"harfe rabt")){
                for(int j=0;j<flexible[i+1].size();j++)
                    vecptr[counter].push_back(flexible[i+1][j]);

             counter++;
            }
        }
    }

     for(int i=0;i<size;i++)
     {
         if(counter<size && flexible[i][2]=="sefatepasin"){
            for(int j=0;j<flexible[i].size();j++)
                vecptr[counter].push_back(flexible[i][j]);
            counter++;

            if(counter<size && i<size-1 && flexible[i+1].size()>=4 && have(flexible[i+1][3],"harfe rabt")){
                for(int j=0;j<flexible[i+1].size();j++)
                    vecptr[counter].push_back(flexible[i+1][j]);

             counter++;
            }
        }
     }
     for(int i=0;i<size;i++)
     {
         if(counter<size && have(flexible[i][2],"esm") &&((flexible[i].size()>=4 && !have(flexible[i][3],"mozafonelayh"))|| flexible[i].size()<4)){
            for(int j=0;j<flexible[i].size();j++)
                vecptr[counter].push_back(flexible[i][j]);

            if(counter<size && flexible[i].size()>=4 && have(flexible[i][3],"jam"))
            {
                //cout<<"KKKK";
                vecptr[counter][1]=jamnuon(flexible[i][1]);
            }
            counter++;
            if(counter<size && i<size-1 && flexible[i+1].size()>=4 && have(flexible[i+1][3],"harfe rabt")){
                for(int j=0;j<flexible[i+1].size();j++)
                    vecptr[counter].push_back(flexible[i+1][j]);

             counter++;
            }

        }
     }

 }
return vecptr;

//---------



}







bool translate::ispronunce(char ch)          //harfe seda dar
{
    if(ch=='a' || ch=='e' || ch=='i' || ch=='o' || ch=='u')
    {
        return true;
    }
    return false;

}
string translate::jamnuon(string str)
{
    if(str.at(str.size()-1)=='s' || str.at(str.size()-1)=='z' || str.at(str.size()-1)=='x' )
    {
       return str+="es";
    }
    else if((str.at(str.size()-2)=='s' ||str.at(str.size()-2)=='c') && str.at(str.size()-1)=='h')
       return str+="es";
    else if(str.at(str.size()-1)=='f')
    {
        return withoutsubstringfromend(str,"f")+="ves";
    }
    else if(str.at(str.size()-2)=='f' && str.at(str.size()-1)=='e')
    {
        return withoutsubstringfromend(str,"fe")+="ves";
    }
    else if(str.at(str.size()-1)=='y' && !ispronunce(str.at(str.size()-2)))
        return withoutsubstringfromend(str,"y")+="ies";
    else
        return str+="s";

}

    bool translate::have(string str,string tr)
    {
        int j=0;
        for(int i=0;i<str.size();i++){
            if(str.at(i)==tr.at(j))
                j++;
            else
                j=0;
            if(j==tr.size())
                return true;
        }
        return false;
    }


    bool translate::haveatfirst(string str,string tr)
    {
        int j=0;
        if(str.compare("")!=0){
        for(int i=0;i<tr.size();i++){
            if(tr.at(i)==str.at(j))
                j++;
            if(j==tr.size())
                return true;
        }
        return false;
        }
        else
            return false;
    }
    bool translate::haveatlast(string str,string tr)
    {
        int j=str.size()-1;
        int k=0;
        if(str.compare("")!=0){
        for(int i=tr.size()-1;i>=0;i--){
            if(tr.at(i)==str.at(j)){
                j--;
                k++;
            }
            if(k==tr.size())
                return true;
        }
        return false;
        }
        else
            return false;
    }

    string translate::withoutsubstring(string str,string tr) ///tr ra az str joda mikone
    {
        string sub;
        bool f[str.size()];
        int j=0;
        for(int i=0;i<str.size();i++)
        {
            if(str.at(i)==tr.at(j))
            {
                f[i]=true;
                j++;
            }
            else if(j<tr.size())
            {
                j=0;
                for(int k=0;k<i;k++)
                    f[k]=false;
            }
            if(j==tr.size()){
                for(int k=0;k<str.size();k++)
                    if(f[k]==false)
                        sub+=str.at(k);
                break;
            }
        }

        return sub;
    }

    string translate::withoutsubstringfromend(string str,string tr)
    {
        string sub;
        for(int i=0;i<(str.size()-tr.size());i++)
            sub+=str.at(i);
        return sub;

    }

    string translate::firstcommonsubstring(string str,string tr)
    {
        int j=0,k=0;
        string sub;
        for(int i=0;i<str.size();i++)
            if(str.at(i)==tr.at(j))
                j++;
            else
            {
                k=j;
                break;
            }
            for(int i=0;i<k;i++)
                sub+=str.at(i);

            if(sub.compare("")==0)
                return "null";
            else
                return sub;



    }
