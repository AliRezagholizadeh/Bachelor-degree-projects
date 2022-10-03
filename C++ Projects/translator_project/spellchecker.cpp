#include "spellchecker.h"
#include "files.h"
#include <string>
using namespace std;

spellchecker::spellchecker(int size)
{

    flexiblestatement=new vector<string> [size];
}

void spellchecker::search(string str,int l)
{
    bool f=false;
    flexiblestatement[l].push_back(str);

    if(f==false)
    for(int i=0;i<file.esm.size();i=i+2)
    {
        if(str.compare(file.esm[i])==0)
        {
            flexiblestatement[l].push_back(file.esm[i+1]);
            flexiblestatement[l].push_back("esm");
            f=true;
            break;
        }
    }
    if(f==false)
    for(int i=0;i<file.sefat.size();i=i+2)
    {
        if(str.compare(file.sefat[i])==0)
        {
            flexiblestatement[l].push_back(file.sefat[i+1]);
            flexiblestatement[l].push_back("sefat");
            f=true;
            break;
        }
    }

    if(f==false)
    for(int i=0;i<file.gheyd.size();i=i+2)
    {
        if(str.compare(file.gheyd[i])==0)
        {
            flexiblestatement[l].push_back(file.gheyd[i+1]);
            flexiblestatement[l].push_back("gheyd");
            f=true;
            break;
        }
    }

    if(f==false)
    for(int i=0;i<file.harfezafe.size();i=i+2)
    {
        if(str.compare(file.harfezafe[i])==0)
        {
            flexiblestatement[l].push_back(file.harfezafe[i+1]);
            flexiblestatement[l].push_back("harfezfe");
            f=true;
            break;
        }
    }
/*
    if(f==false)
    for(int i=0;i<file.felgozashte.size();i=i+2)
    {
        if(str.compare(file.felgozashte[i])==0)
        {
            flexiblestatement[l].push_back(file.felgozashte[i+1]);
            flexiblestatement[l].push_back("felgozashte");
            f=true;
            break;
        }
    }
*/
    if(f==false)
    for(int i=0;i<file.fel.size();i=i+2)
    {
        if(str.compare(file.fel[i])==0)
        {
            flexiblestatement[l].push_back(file.fel[i+1]);
            flexiblestatement[l].push_back("fel");
            f=true;
            break;
        }
    }
/*
    if(f==false)
    for(int i=0;i<file.felayande.size();i=i+2)
    {
        if(str.compare(file.felayande[i])==0)
        {
            flexiblestatement[l].push_back(file.felayande[i+1]);
            flexiblestatement[l].push_back("felayande");
            f=true;
            break;
        }
    }
*/

}
