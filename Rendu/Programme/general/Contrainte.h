#ifndef CONTRAINTE_H
#define CONTRAINTE_H
#include "Tissu.h"

class Contrainte
{
    protected:

    double rayon;
    Vecteur3D centre;

    public:
    Contrainte(Vecteur3D centre_ = Vecteur3D(0, 0, 0), double rayon_ = 0);
    virtual bool est_contrainte(Masse* m) const;
    virtual void appliquer(Tissu* tissu, double  const& temps)=0;

};

#endif // CONTRAINTE_H
