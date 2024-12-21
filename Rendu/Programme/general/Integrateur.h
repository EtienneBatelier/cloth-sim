#ifndef PRJ_INTEGRATEUR_H
#define PRJ_INTEGRATEUR_H

#include "Ressort.h"
class Integrateur
{
	public:
    //Méthode virtuelle pure
    virtual void integre(Masse& M, double const& dt) const =0;
};

#endif // PRJ_INTEGRATEUR_H
