#ifndef TISSUCOMPOSE_H
#define TISSUCOMPOSE_H
#include "Tissu.h"


class TissuCompose:public Tissu
{
    std::vector<Tissu*> ensemble;
    double epsilon;
    double raideur;
    unsigned int n;
public:
    TissuCompose(std::vector<Tissu*> ens,double eps,double raid,SupportADessin* s=nullptr);
    void raccomode();
    //Destructeur
    ~TissuCompose();
};

#endif // TISSUCOMPOSE_H
