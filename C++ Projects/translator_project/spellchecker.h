#ifndef SPELLCHECKER_H
#define SPELLCHECKER_H
#include"files.h"
#include <string>
#include <vector>
using namespace std;

class spellchecker
{
public:
    spellchecker(int);
    void search(string,int);
    vector<string>* flexiblestatement;      //ke dar har khune avalin kalame:khode kalame,dovomish:ma'nish,sevomi:now'e kalame

    files file;

};

#endif // SPELLCHECKER_H
