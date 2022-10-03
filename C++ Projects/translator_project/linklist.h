#ifndef LINKLIST_H
#define LINKLIST_H
#include "node.h"
#include <iostream>
#include <vector>
#include <string>
using namespace std;






class linklist
{
public:
    linklist();
    void push(vector<string>);
    vector<string> at(int);
    int size();
    void clear();
    int getandis();

private:
    node* root;
    int andis;

};

#endif // LINKLIST_H
