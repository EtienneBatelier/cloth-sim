#ifndef TISSUCHAINE_H
#define TISSUCHAINE_H

#include "Tissu.h"

class TissuChaine : public Tissu
{
    public:
    TissuChaine(double,double,double,double,std::vector<Vecteur3D>,SupportADessin* =nullptr);
};

#endif // TISSUCHAINE_H
