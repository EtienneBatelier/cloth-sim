#ifndef TISSUCOMPOSE_H
#define TISSUCOMPOSE_H
#include "Tissu.h"


class TissuCompose:public Tissu
{
    std::vector<Tissu*> ensemble;
    double epsilon;
    double raideur;
public:
    TissuCompose(std::vector<Tissu*> ens,double eps,double raid,SupportADessin* s=nullptr);
    void raccomode();
};

#endif // TISSUCOMPOSE_H
