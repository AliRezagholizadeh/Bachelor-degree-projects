#include "linklist.h"
#include "node.h"
#include <iostream>
#include <vector>
#include <string>
using std::ostream;

linklist::linklist()
{
    root=NULL;
    andis=0;

}
void linklist::push(vector<string> vec)
{
    node*d=new node(root);
    d->setdata(vec);
    d->setandis(andis);
    root=d;

    andis++;


}
int linklist::getandis()
{
    return andis;
}

vector<string> linklist::at(int l)
{
    node*d=root;
    while(d->next!=NULL)
    {
        if(d->getandis()==l)
            return d->data;
        else
            d=d->next;
    }
    vector<string>s;
    s.push_back("sa");
    return s;
}
void linklist::clear()
{
    node*d=root;
    while(d->next!=NULL)
    {
        node*r=d;
        d=d->next;
        delete r;
    }
}

int linklist::size()
{
    return root->getandis()+1;
}

