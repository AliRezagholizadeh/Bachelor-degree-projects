#include "jomle.h"
#include "files.h"
//#include "spellchecker.h"
#include <vector>
#include <string>
#include <iostream>


using namespace std;
jomle::jomle()
{
  // files file;

}

void jomle::fillextravec()
{


    file.filldatabase();
     esm=file.esm;
     sefat=file.sefat;
     gheyd=file.gheyd;
     harfezafe=file.harfezafe;
     //felayande=file.felayande;
     //felgozashte=file.felgozashte;
     fel=file.fel;
     sefatepasin=file.sefatepasin;
     sefatepishin=file.sefatepishin;
     zamir=file.zamir;

     zamirmafauli=file.zamirmafauli;
     sefatemelki=file.sefatemelki;



     neshanehayeayande.push_back("khaham");
     neshanehayeayande.push_back("i");
     neshanehayeayande.push_back("khahi");
     neshanehayeayande.push_back("you");
     neshanehayeayande.push_back("khahad");
     neshanehayeayande.push_back("he");
     neshanehayeayande.push_back("khahim");
     neshanehayeayande.push_back("we");
     neshanehayeayande.push_back("khahid");
     neshanehayeayande.push_back("you");
     neshanehayeayande.push_back("khahand");
     neshanehayeayande.push_back("they");
     neshanehayejam.push_back("ha");
     neshanehayejam.push_back("an");

     propertisofstatement[1]="mosbat";
     propertisofstatement[0]="khabari";
     propertisofstatement[2]="gheyreayande";
     propertisofstatement[3]="daraye faele barez";
     propertisofstatement[4]="empty";

}

bool jomle::isendstatement(string str)
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
bool jomle::isendstatement(char str)
{
    if(str=='.' || str=='?' || str=='!')
        return true;
    else
        return false;
}

bool jomle::issign(char str)
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

bool jomle::issign(string str)
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

void jomle::setstatement(vector<string> vec)
{
    statement.clear();
    for(int i=0;i<vec.size();i++)
        statement.push_back(vec[i]);

   // cout<<"\n\n\n";
    //for(int i=0;i<statement.size();i++)
     //   cout<<statement[i]<<"   ";

    //partofstatement();

}
void jomle::partofstatement()
{
    /*
    string str="";
    for(int i=0;i<statement.size()-1;i++)
    {
        if(issign(statement[i])){
            str=statement[i];
            for(int j=i;j<statement.size();j++)
                if(str.compare(statement[j])==0)
                    str="";
                }

    }
    */
}

void jomle::makeflexiblestatement()
{

    flexiblestatement=new vector<string>[statement.size()];
   // spellchecker spl(statement.size());
    for(int i=0;i<statement.size();i++)
    {
            search(statement[i],i);
    }



/*

    for(int i=0;i<statement.size();i++){
        cout<<"\n";
        for(int j=0;j<flexiblestatement[i].size();j++)
            cout<<"("<<flexiblestatement[i][j]<<")"<<"  ";
    }

*/





}

void jomle::jodasaziyeneshaneha()           // esme khas ham dar inja moshakhas mishe
{
    bool f;
    bool g=false;
    string str=""; //gharare fele bedune neshane ra negah darad
    vector<string> statementbajodasazieneshaneha;

            //[]::::joda sazi harfezafe az kalame ii ke flexiblestatement[i][2] an "harf" ast
    for(int i=0;i<statement.size();i++)
    {
        f=false;
        if(search(statement[i]).compare("harf")!=0 || statement[i]=="e" || statement[i]=="ye"){
            statementbajodasazieneshaneha.push_back(statement[i]);


            for(int l=0;l<neshanehayeayande.size();l+=2){
                if(have(statement[i],neshanehayeayande[l]))
                {
                   propertisofstatement[2]="ayande";
                   propertisofstatement[4]=neshanehayeayande[l+1];

                   break;
                }
            }




        }
        else
        {

             for(int l=0;l<neshanehayejam.size();l++){
                 if(haveatlast(statement[i],neshanehayejam[l])){
                     if(search(withoutsubstringfromend(statement[i],neshanehayejam[l])).compare("harf")!=0){
                         statementbajodasazieneshaneha.push_back(withoutsubstringfromend(statement[i],neshanehayejam[l]));
                         statementbajodasazieneshaneha.push_back(neshanehayejam[l]);
                     }
                     else                         //*******age kalame bedune neshane HAM da file nabud an ra esme shakhs migire
                         statementbajodasazieneshaneha.push_back(statement[i]);

                     f=true;
                 }
            }
             if(f==false){
             for(int l=0;l<harfezafe.size();l++)
             {
                 string w;
                 if(haveatfirst(statement[i],harfezafe[l])){
                    w=withoutsubstring(statement[i],harfezafe[l]);
                   // cout<<w<<"  .........\n";
                         if(search(w)=="harf")
                        {
                            statementbajodasazieneshaneha.push_back(statement[i]);

                         }
                        else
                        {
                            statementbajodasazieneshaneha.push_back(harfezafe[l]);
                            //statementbajodasazieneshaneha.push_back(w);

                         }
                         f=true;
                    }



                 }
             }




             if(f==false){
                 for(int l=0;l<neshanehayeayande.size();l=l+2){
                     if(have(statement[i],neshanehayeayande[l]))
                     {
                         string w="";
                        propertisofstatement[2]="ayande";
                        propertisofstatement[4]=neshanehayeayande[l+1];
                        //statementbajodasazieneshaneha.push_back(neshanehayeayande[l]);
                        w=withoutsubstring(statement[i],neshanehayeayande[l]);

                        if(search(w)!="harf"){
                            statementbajodasazieneshaneha.push_back(withoutsubstring(statement[i],neshanehayeayande[l]));

                        }
                        else
                            if(haveatfirst(w,"na"))
                            {
                                 str=withoutsubstring(statement[i],neshanehayeayande[l]);
                                 //cout<<"*259*";
                                 propertisofstatement[1]="manfi";
                                 if(withoutsubstring(str,"na").compare("")!=0)
                                   statementbajodasazieneshaneha.push_back(withoutsubstring(str,"na"));

                            }


                        f=true;
                     }
                 }
             }




             if(f==false)
             {
                 if(haveatfirst(statement[i],"ne"))
                 {
                     propertisofstatement[1]="manfi";
                     statementbajodasazieneshaneha.push_back(withoutsubstring(statement[i],"ne"));
                     f=true;
                 }
             }

             if(f==false)
             {
                 if(haveatfirst(statement[i],"na"))
                 {
                     propertisofstatement[1]="manfi";
                     statementbajodasazieneshaneha.push_back(withoutsubstring(statement[i],"na"));
                     f=true;
                 }
             }

             if(f==false){
               statementbajodasazieneshaneha.push_back("'"+statement[i]);
             f=true;
         }


         }

    }

    setstatement(statementbajodasazieneshaneha);
   // cout<<withoutsubstring("darffff","dar")<<":294";
    //cout<<search("madrese")<<"<---";
    //cout<<"\n";
  //  for(int i=0;i<statement.size();i++)
    //   cout<<statement[i]<<" ";
   // cout<<statementbajodasazieneshaneha.size();
   // cout<<"\n";
   // for(int i=0;i<3;i++)
     //   cout<<propertisofstatement[i]<<" ";
   // makeflexiblestatement();

}

void jomle::ajzayejomle()
{
    int j=0;
    //[0]::::goruhe esmi
                    //[0][0]:::sefatepishin o pasin
    for(int i=0;i<statement.size();i++)
    {
            if(flexiblestatement[i][2]=="sefatepishin")
                flexiblestatement[i].push_back("goruheesmi sefatepishin");
            if(flexiblestatement[i][2]=="sefatepasin")
                flexiblestatement[i].push_back("goruheesmi sefatepasin");
    }
                    //[0][1]::::haste ye an ke momkene in goruh,goruhe faeli bashad ya mafauli
    for(int i=0;i<statement.size();i++)
    {
        if(flexiblestatement[i].size()<4){
        if(have(flexiblestatement[i][2],"esm"))
        {
              flexiblestatement[i].push_back("goruheesmi haste");
        }

    }

    }

                    //[0][2]:::::mazafonelayh ro moshakhas mikone
    for(int i=0;i<statement.size();i++)
    {
        if(i>0 && (flexiblestatement[i][2]=="harf"))        //mesle "e" baraye tarkibate vasfi o ezafi
        {


            for(j=i-1;j>=0;j--)
                if(haveatfirst(flexiblestatement[j][2],"esm"))
                    break;


            if(flexiblestatement[i+1][2]=="sefatepasin"){
                 if(flexiblestatement[j].size()<4)
                    flexiblestatement[j].push_back("goruheesmi haste mowsuf");
                 else
                     flexiblestatement[j][3]+=" mowsuf";
            }
            else
            {
                if(flexiblestatement[j].size()<4)
                    flexiblestatement[j].push_back("goruheesmi haste mozaf");
                else
                     flexiblestatement[j][3]+=" mozaf";
               if(flexiblestatement[i+1].size()<4)
                   flexiblestatement[i+1].push_back("goruheesmi mozafonelayh");
               else
                   flexiblestatement[i+1][3]+=" mozafonelayh";
           }
        }
    }
    for(int i=0;i<statement.size();i++)                         //age zamir mozafonelayh nabood hatman hasteye goruhe khod ast
    {
        if(flexiblestatement[i][2]=="zamir" && flexiblestatement[i].size()<4)
            flexiblestatement[i].push_back("goruheesmi haste");
    }

j=0;
string str="";
for(int i=0;i<statement.size();i++){
        if(i>0 && flexiblestatement[i][0]=="ra")
        {
            for(j=i-1;j>=0;j--)
                if(flexiblestatement[j].size()>=4 && have(flexiblestatement[j][3],"haste"))
                    break;
            for(int k=j;k<i;k++)
                if(flexiblestatement[k].size()>=4){
                     str=flexiblestatement[k][3];
                     str+=" mafaul";
                     flexiblestatement[k].pop_back();
                     flexiblestatement[k].push_back(str);
                     str="";
                 }


        }
    }


        //[]...........gheyd
for(int i=0;i<statement.size();i++)
{
    if(flexiblestatement[i][2]=="gheyd"){
        if(flexiblestatement[i].size()>=4)
            flexiblestatement[i][3]+="gheyd";
        else
            flexiblestatement[i].push_back("goruhe gheydi");
        if(i>0 && flexiblestatement[i-1][2]=="harfezafe")
            if( flexiblestatement[i-1].size()<4)
                flexiblestatement[i-1].push_back("harfezafe gheydi");
            else
                flexiblestatement[i-1][3]+=" gheydi";

    }
}


            //[]............motammam
    for(int i=0;i<statement.size();i++)
    {
        if(flexiblestatement[i][2]=="harfezafe" ){
            if(flexiblestatement[i].size()>=4 && !have(flexiblestatement[i][3],"gheyd")){
                if(haveatfirst(flexiblestatement[i+1][2],"esm")){
                    flexiblestatement[i+1][3]+=" motammam";
                    flexiblestatement[i+1].push_back(flexiblestatement[i][1]);

                    flexiblestatement[i][3]+=" motammami";
                }
            }


            else if(flexiblestatement[i].size()<4)
            {
                if(haveatfirst(flexiblestatement[i+1][2],"esm")){
                    flexiblestatement[i+1][3]+=" motammam";
                    flexiblestatement[i+1].push_back(flexiblestatement[i][1]);

                    flexiblestatement[i].push_back("harfezafe motammami");
                }
            }


            if(i+2<statement.size() && flexiblestatement[i+2][2]=="harfe rabt"){
                if(have(flexiblestatement[i+3][2],"esm")){
                    flexiblestatement[i+3][3]+=" motammam";
                    flexiblestatement[i+3].push_back(flexiblestatement[i][1]);

                }
                flexiblestatement[i+2].push_back("harfe rabt motammami");
            }

            flexiblestatement[i][1]="null";     //baraye tarjome lazeme,dar translatejomle va tar jome ye in dar lahzeye...
                                                //CHAP emal mikone
        }

    }

            //[] ......... neshne ye jam

    for(int i=0;i<statement.size();i++)
        for(int j=0;j<neshanehayejam.size();j++)
            if(i>0 && flexiblestatement[i][0]==neshanehayejam[j] && flexiblestatement[i-1][2]=="esm")
            {
                 if(flexiblestatement[i].size()<4)
                      flexiblestatement[i].push_back("neshane jam");
                 else
                      flexiblestatement[i][3]+=" neshane jam";

                 for(int k=i;k>=0;k--)
                     if(haveatfirst(flexiblestatement[k][2],"esm")){
                         flexiblestatement[k][3]+=" jam";
                          break;
                     }
            }


            //[] ..........mosnad

    for(int i=0;i<statement.size();i++)
            if(flexiblestatement[i][2]=="sefatepasin" && flexiblestatement[i+1][2]=="fel")
            {
                 if(flexiblestatement[i].size()<4)
                      flexiblestatement[i].push_back("goruhe mosnad");
                 else
                      flexiblestatement[i][3]+=" mosnad";


            }


            //[] ..............harfe rabt
    string common;


/*
     string ezafi="";
    for(int i=0;i<statement.size();i++)
    {
        if(flexiblestatement[i][2]=="harfe rabt")
            if(i>0 && flexiblestatement[i-1].size()>=4 && flexiblestatement[i+1].size()>=4 && (have(flexiblestatement[i-1][2],"esm")) && have(flexiblestatement[i+1][2],"esm"))
            {
                common=firstcommonsubstring(flexiblestatement[i-1][3],flexiblestatement[i+1][3]);
                cout<<"@ "<<common<<"##$##";
                ezafi=withoutsubstring(flexiblestatement[i-1][3],common);
                flexiblestatement[i-1][3]+=(" "+withoutsubstring(flexiblestatement[i+1][3],common));
                flexiblestatement[i+1][3]+=(" "+ezafi);

               // if(have(flexiblestatement[i-1][3],"faeli"))
                 //   flexiblestatement[i].push_back("harfe rabte faeli");

            }
    }
    */

    //[][];;;;;;;;;;;;;;;;;makeassign sefat va esm

    for(int i=0;i<statement.size();i++)
    {
        if(i<statement.size() && flexiblestatement[i].size()>=4 && flexiblestatement[i][2]=="sefatepishin" && flexiblestatement[i+1].size()>=4 && have(flexiblestatement[i+1][3],"haste"))
            flexiblestatement[i][3]=makeassignstr2properti(flexiblestatement[i][3],"sefat",flexiblestatement[i+1][3]);
        else if(i>0 && flexiblestatement[i].size()>=4 && flexiblestatement[i][2]=="sefatepasin" && flexiblestatement[i-1][2]=="harfezafe" && flexiblestatement[i-2].size()>=4 && have(flexiblestatement[i-2][3],"haste"))
            flexiblestatement[i][3]=makeassignstr2properti(flexiblestatement[i][3],"sefat",flexiblestatement[i-2][3]);

        else if(i>0 && flexiblestatement[i].size()>=4 && (have(flexiblestatement[i][2],"esm") || flexiblestatement[i][2]=="zamir") && have(flexiblestatement[i][3],"mozafonelayh"))
        {
            int j;
            if(i-1>0)
            for(j=i-1;j>=0;j--)
                if(have(flexiblestatement[j][2],"esm"))
                    break;
            //string st=makeassignstr2properti(flexiblestatement[j][3],"mozaf",flexiblestatement[i][3]);
             flexiblestatement[j][3]=makeassignstr2properti(flexiblestatement[j][3],"mozafonelayh",flexiblestatement[i][3]);
             //flexiblestatement[j][3]=st;


        }
    }





        //[].......................find fael va harfe rabte faeli

    for(int i=0;i<statement.size();i++)
    {
        if(flexiblestatement[i].size()>=4)
        if(!have(flexiblestatement[i][3],"mafaul") && !have(flexiblestatement[i][3],"gheyd") && !have(flexiblestatement[i][3],"motammam") && !have(flexiblestatement[i][2],"fel") && !have(flexiblestatement[i][3],"mosnad"))
            flexiblestatement[i][3]+=" faeli";

    }

    common="";
     string str1;
    for(int i=0;i<statement.size();i++)
    {
        if(flexiblestatement[i][2]=="harfe rabt")
            if(i>0 && (have(flexiblestatement[i-1][2],"esm") && have(flexiblestatement[i-1][3],"fael") && have(flexiblestatement[i+1][2],"esm") && have(flexiblestatement[i+1][3],"fael")))
            {
                str1=flexiblestatement[i-1][3];
                flexiblestatement[i-1][3]=makeassignstr2properti(flexiblestatement[i-1][3],"esm",flexiblestatement[i+1][3]);
                flexiblestatement[i+1][3]=makeassignstr2properti(flexiblestatement[i+1][3],"esm",str1);


                if(flexiblestatement[i].size()>=4)
                    flexiblestatement[i][3]+=("harfe rabte faeli");
                else
                    flexiblestatement[i].push_back("harfe rabt faeli");

            }
    }



    // [] anvae zamayer   FELAN BE JOZ ZAMIRE MELKI
    for(int i=0;i<statement.size();i++)
    {
        if(flexiblestatement[i][2]=="zamir" && have(flexiblestatement[i][3],"mafaul"))
            for(int j=0;j<zamirmafauli.size();j=j+2)
                if(have(zamirmafauli[j],flexiblestatement[i][0]))
                    flexiblestatement[i][1]=zamirmafauli[j+1];

        if(have(flexiblestatement[i][2],"zamir") && have(flexiblestatement[i][3],"mozafonelayh"))
            for(int j=0;j<sefatemelki.size();j=j+2)
                if(have(sefatemelki[j],flexiblestatement[i][0]))
                    flexiblestatement[i][1]=sefatemelki[j+1];


    }



    havefael();
    nowejomle();
    //zaman ro nanveshtam chun ehtemal dare dar statement neshane ayande nabashe (dar joda sazi bardashte shode bashe)




}


void jomle::search(string str,int l)
{

    bool f=false;
       flexiblestatement[l].push_back(str);

       if(f==false){
           if(issign(str))
           {
               flexiblestatement[l].push_back("null");
               flexiblestatement[l].push_back("sign");
               f=true;
           }
       }

       if(f==false){
       for(int i=0;i<esm.size();i=i+2)
       {
           if(str.compare(esm[i])==0)
           {
               flexiblestatement[l].push_back(esm[i+1]);
               flexiblestatement[l].push_back("esm");
               f=true;
               break;
           }
       }
   }
       if(f==false){
       for(int i=0;i<sefat.size();i=i+2)
       {
           if(str.compare(sefat[i])==0)
           {
               flexiblestatement[l].push_back(sefat[i+1]);
               flexiblestatement[l].push_back("sefat");
               f=true;
               break;
           }
       }
   }

       if(f==false){
       for(int i=0;i< gheyd.size();i=i+2)
       {
           if(str.compare( gheyd[i])==0)
           {
               flexiblestatement[l].push_back( gheyd[i+1]);
               flexiblestatement[l].push_back("gheyd");
               f=true;
               break;
           }
       }
   }

       if(f==false){
       for(int i=0;i< harfezafe.size();i=i+2)
       {
           if(str.compare( harfezafe[i])==0)
           {
               flexiblestatement[l].push_back( harfezafe[i+1]);
               flexiblestatement[l].push_back("harfezafe");
               f=true;
               break;
           }
       }
   }
/*
       if(f==false){
       for(int i=0;i< felgozashte.size();i=i+2)
       {
           if(str.compare( felgozashte[i])==0)
           {
               flexiblestatement[l].push_back( felgozashte[i+1]);
               flexiblestatement[l].push_back("felgozashte");
               f=true;
               break;
           }
       }
   }
*/
       if(f==false){
       for(int i=0;i< fel.size();i=i+3)
       {
           if(str.compare( fel[i])==0)
           {


               if(propertisofstatement[2]=="ayande"){
                   flexiblestatement[l].push_back(fel[i+5]);
                   flexiblestatement[l].push_back("fel");
                   flexiblestatement[l].push_back(fel[i+4]);
               }
               else{
                   flexiblestatement[l].push_back(fel[i+2]);
                   flexiblestatement[l].push_back("fel");
                   flexiblestatement[l].push_back(fel[i+1]);
               }

               f=true;
               break;
           }
       }
   }
/*
       if(f==false){
       for(int i=0;i< felayande.size();i=i+2)
       {
           if(str.compare( felayande[i])==0)
           {
               flexiblestatement[l].push_back( felayande[i+1]);
               flexiblestatement[l].push_back("felayande");
               f=true;
               break;
           }
       }
   }
 */
       if(f==false){
       for(int i=0;i<sefatepasin.size();i=i+2)
       {
           if(str.compare(sefatepasin[i])==0)
           {
               flexiblestatement[l].push_back(sefatepasin[i+1]);
               flexiblestatement[l].push_back("sefatepasin");
               f=true;
               break;
           }
       }
   }


       if(f==false){
       for(int i=0;i<sefatepishin.size();i=i+2)
       {
           if(str.compare(sefatepishin[i])==0)
           {
               flexiblestatement[l].push_back(sefatepishin[i+1]);
               flexiblestatement[l].push_back("sefatepishin");
               f=true;
               break;
           }
       }
   }
       if(f==false){
       for(int i=0;i<zamir.size();i=i+2)
       {
           if(str.compare(zamir[i])==0)
           {
               flexiblestatement[l].push_back(zamir[i+1]);
               flexiblestatement[l].push_back("zamir");
               f=true;
               break;
           }
       }
   }

       if(f==false){
       for(int i=0;i<neshanehayejam.size();i++)
       {
           if(str.compare(neshanehayejam[i])==0)
           {
               flexiblestatement[l].push_back("null");
               flexiblestatement[l].push_back("neshaneye jam");
               f=true;
               break;
           }
       }
   }

       if(f==false){
       for(int i=0;i<neshanehayeayande.size();i+=2)
       {
           if(str.compare(neshanehayeayande[i])==0)
           {
               flexiblestatement[l].push_back("null");
               flexiblestatement[l].push_back("neshaneye ayande");
               propertisofstatement[2]="ayande";
               f=true;
               break;
           }
       }
   }

       if(f==false){
           if(str.compare("ra")==0)
           {
               flexiblestatement[l].push_back("null");
               flexiblestatement[l].push_back("neshaneye mafauli");
               f=true;
           }
       }



       if(f==false)
       {
            if(str.compare("va")==0)
           {
                flexiblestatement[l].push_back("and");
                flexiblestatement[l].push_back("harfe rabt");
                f=true;
            }
       }


       if(f==false)
       {
           if(have(str,"'")){
               cout<<withoutsubstring(str,"'")<<"814%";
               flexiblestatement[l].push_back(withoutsubstring(str,"'"));
               flexiblestatement[l].push_back("esmeshakhs");
               f=true;
           }
           else {
           flexiblestatement[l].push_back("null");
           flexiblestatement[l].push_back("harf");              //yek harf mesle "e"
           f=true;
       }
       }




}


string jomle::search(string str)
{



    if(issign(str))
    {
        return ("sign");
    }
    for(int i=0;i<esm.size();i=i+2)
    {
        if(str.compare(esm[i])==0)
        {
            return ("esm");
        }
    }


    for(int i=0;i<sefat.size();i=i+2)
    {
        if(str.compare(sefat[i])==0)
        {
            return ("sefat");
        }
    }



    for(int i=0;i< gheyd.size();i=i+2)
    {
        if(str.compare( gheyd[i])==0)
        {
            return ("gheyd");
        }
    }



    for(int i=0;i< harfezafe.size();i=i+2)
    {
        if(str.compare( harfezafe[i])==0)
        {
            return ("harfezfe");
        }
    }
/*
    for(int i=0;i< felgozashte.size();i=i+2)
    {
        if(str.compare( felgozashte[i])==0)
        {
            return ("felgozashte");
        }
    }
*/
    for(int i=0;i< fel.size();i=i+3)
    {
        if(str.compare( fel[i])==0)
        {
            return ("fel");
        }
    }
/*
    for(int i=0;i< felayande.size();i=i+2)
    {
        if(str.compare( felayande[i])==0)
        {
            return ("felayande");
        }
    }

*/

    for(int i=0;i<sefatepasin.size();i=i+2)
    {
        if(str.compare(sefatepasin[i])==0)
        {
            return("sefatepasin");
        }
    }

    for(int i=0;i<sefatepishin.size();i=i+2)
    {
        if(str.compare(sefatepishin[i])==0)
        {
            return("sefatepishin");
        }
    }

    for(int i=0;i<zamir.size();i=i+2)
    {
        if(str.compare(zamir[i])==0)
        {
            return ("zamir");
        }
    }


    for(int i=0;i<neshanehayejam.size();i++)
    {
        if(str.compare(neshanehayejam[i])==0)
        {
            return ("neshaneye jam");
        }
    }

    for(int i=0;i<neshanehayeayande.size();i+=2)
    {
        if(str.compare(neshanehayeayande[i])==0)
        {
            return ("neshaneye ayande");
        }
    }

        if(str.compare("ra")==0)
        {
            return("neshaneye mafauli");
        }


             if(str.compare("va")==0)
            {
                 return ("harfe rabt");
            }


        if(haveatfirst(str,"'")){
            return("esmeshakhs");
        }



            return "harf";              //yek harf mesle "e"  YA  har kalamei ke tu hich filei nabud


}
/*
int jomle::numberofharf(string str)
{
    return str.size();
}
*/

void jomle::havefael()
{
    bool f=false;
    for(int i=0;i<statement.size();i++)
        if(flexiblestatement[i].size()>=4 && have( flexiblestatement[i][3],"fael")){
            propertisofstatement[3]="daraye fael barez";
            f=true;
        }
    if(f==false)
        propertisofstatement[3]="fael ba shenase";


}

void jomle::nowejomle()
{
    if(flexiblestatement[statement.size()-1][0]=="?")
        propertisofstatement[0]="soali";
    else if(flexiblestatement[statement.size()-1][0]=="!")
        propertisofstatement[0]="taajobi";
    else if(flexiblestatement[statement.size()-1][0]==".")
        propertisofstatement[0]="khabari";

}

bool jomle::have(string str,string tr)
{
    int j=0;
    if(str.size()!=0 || tr.size()!=0){
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
    else
        return false;
}


bool jomle::haveatfirst(string str,string tr)
{
    int j=0;
   // if(str.compare("")!=0 || tr.size()!=0){
    for(int i=0;i<tr.size();i++){
        if(tr.at(i)==str.at(j))
            j++;

        if(j==tr.size())
            return true;
    }
    return false;
    }
    //else
     //   return false;
//}
bool jomle::haveatlast(string str,string tr)
{
    int j=str.size()-1;
    int k=0;
    if(str.compare("")!=0 || tr.size()!=0){
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

string jomle::withoutsubstring(string str,string tr) ///tr ra az str joda mikone
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
/*
string jomle::withoutsubstring(string str,string tr)
{
    string sub="k";
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
*/
string jomle::withoutsubstringfromend(string str,string tr)
{
    string sub="";
    if(tr.compare("")==0 && str.compare("")!=0)
        return str;
    else if(tr.compare("")!=0 && str.compare("")!=0){
    if(str.size()!=0 && tr.size()!=0)
    for(int i=0;i<(str.size()-tr.size());i++)
        sub+=str.at(i);
    return sub;
    }
    else
        return "";

}

string jomle::firstcommonsubstring(string str,string tr)
{
    int j=0,k=0;
    string sub="";
    if(str.compare("")!=0 && tr.compare("")!=0){
    for(int i=0;i<str.size();i++){
        if(str.at(i)==tr.at(j))
            j++;
        else if(i>0)
        {
            break;
        }
    }
    if(j!=0)
        for(int i=0;i<j;i++)
            sub+=str.at(i);

        if(sub.compare("")!=0)
            return sub;
        else
            return "sas";
    }
    else
        return "";



}

string jomle::makeassignstr2properti(string str1,string typestr1,string str2)
{
    string common="";
    string withoutstr1="";
    if(str1.compare("")!=0){
    common=firstcommonsubstring(str1,str2);
    withoutstr1=withoutsubstring(str2,common);
     str1+=(" "+withoutstr1);
     if(typestr1=="mozafonelayh")
     {
         if(have(str1,"mowsuf"))
             str1=withoutsubstring(str1,"mowsuf");
         //if(have(str1,"mozaf"))
           //  str1=withoutsubstring(str1,"mozaf");
     }
     return str1;
}
    else
    return str2;
}

void jomle::zamanejomle()
{
    bool f=false;
    for(int i=statement.size()-1;i>=0;i--)
    {
        for(int l=0;l<neshanehayeayande.size();l+=2)
            if(statement[i]==neshanehayeayande[l] || have(statement[i],neshanehayeayande[l]))
            {
            propertisofstatement[2]="ayande";
            f=true;
            break;
        }
    }
    if(f==false)
        propertisofstatement[2]="gheyre ayande";


}

