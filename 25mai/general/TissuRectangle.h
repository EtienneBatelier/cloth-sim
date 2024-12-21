#ifndef TISSURECTANGLE_H
#define TISSURECTANGLE_H
#include "Tissu.h"

class TissuRectangle: public Tissu
{
    public:
    TissuRectangle(Vecteur3D, Vecteur3D, Vecteur3D, double, double, double, double, double, SupportADessin* support = nullptr);
};

#endif // TISSURECTANGLE_H
