#ifndef INTEGRATEURNEWMARK_H
#define INTEGRATEURNEWMARK_H

#include "Integrateur.h"

class IntegrateurNewmark:public Integrateur
{
    double epsilon;
public:
    /*On initialise espilon dans le constructeur pour que la fonction integre
     * de IntegrateurNewmark ait le même protoype que celle d'Integrateur
     *On prend pour valeur par défaut 10^-6 comme suggeré sur le Forum du cours*/

    IntegrateurNewmark(const double& eps=pow(10,-6))
        :Integrateur(),epsilon(eps)
    {}

    virtual void integre(Masse& M, double const& dt) const override;
};

#endif // INTEGRATEURNEWMARK_H
