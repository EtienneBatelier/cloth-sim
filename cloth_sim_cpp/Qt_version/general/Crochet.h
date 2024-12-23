#ifndef CROCHET_H
#define CROCHET_H
#include "Contrainte.h"

class Crochet : public Contrainte
{
    public:
    Crochet(Vecteur3D centre_, double);
    virtual void appliquer(Tissu* tissu, double const& temps) override;
};

#endif // CROCHET_H
