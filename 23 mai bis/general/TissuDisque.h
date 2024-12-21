#ifndef TISSUDISQUE_H
#define TISSUDISQUE_H

#include "Tissu.h"

class TissuDisque:public Tissu
{
public:
    TissuDisque(double,Vecteur3D, Vecteur3D ,double ,double , double,SupportADessin* s=nullptr ,double pas_angulaire=20);

};

#endif // TISSUDISQUE_H
