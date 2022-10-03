#ifndef NODE_H
#define NODE_H
#include <vector>
#include <string>
using namespace std;

class node
{
public:

    node();
    node(node*);
    void setdata(vector<string>);
    void setnext(node*);
    int getandis();
    void setandis(int);
    node *next;
    vector<string> data;
    int andis;
private:

};


#endif // NODE_H
