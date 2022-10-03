#include "node.h"
#include <vector>
#include <string>
using namespace std;

node::node()
{
    next=NULL;

    andis=0;

}

node::node(node * n)
{
    next=n;
    andis=0;
}

void node::setdata(vector<string> vec)
{
    data=vec;

}
void node::setnext(node* n)
{
    next=n;
}
void node::setandis(int an)
{
    andis=an;
}

int node::getandis()
{
    return andis;
}


