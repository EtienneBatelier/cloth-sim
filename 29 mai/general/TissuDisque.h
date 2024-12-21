#ifndef TISSUDISQUE_H
#define TISSUDISQUE_H

#include "Tissu.h"

class TissuDisque:public Tissu
{
public:
    TissuDisque(double,Vecteur3D, Vecteur3D ,double ,double , double,int pas_angulaire=20,SupportADessin* s=nullptr );
    ~TissuDisque();

};

#endif // TISSUDISQUE_H
