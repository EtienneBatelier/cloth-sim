#ifndef PRJ_INTEGRATEUREULER_H
#define PRJ_INTEGRATEUREULER_H

#include "Integrateur.h"

class IntegrateurEuler: public Integrateur
{
	public:
	IntegrateurEuler()
	:Integrateur()
	{}
	virtual void integre(Masse& M, double const& dt);
};
#endif // PRJ_INTEGRATEUREULER_H
