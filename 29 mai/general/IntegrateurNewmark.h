#ifndef INTEGRATEURNEWMARK_H
#define INTEGRATEURNEWMARK_H

#include "Integrateur.h"

class IntegrateurNewMark:public Integrateur
{
    double epsilon;
public:
    IntegrateurNewMark(const double& eps=pow(10,-6))
        :Integrateur(),epsilon(eps)
    {}

    virtual void integre(Masse& M, double const& dt) const override;
};

#endif // INTEGRATEURNEWMARK_H
