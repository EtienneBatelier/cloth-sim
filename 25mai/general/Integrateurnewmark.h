#ifndef INTEGRATEURNEWMARK_H
#define INTEGRATEURNEWMARK_H
#include "Integrateur.h"

class IntegrateurNewMark:public Integrateur
{
public:
    IntegrateurNewMark()
    :Integrateur()
    {}
    virtual void integre(Masse& M, double const& dt) override;
};

#endif // INTEGRATEURNEWMARK_H
