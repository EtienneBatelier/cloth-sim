#ifndef PRJ_DESSINABLE_H
#define PRJ_DESSINABLE_H
#include "SupportADessin.h"

class Dessinable
{
	protected:
	SupportADessin* support;
	public:
	virtual void dessine() const =0;
	Dessinable(SupportADessin* support_nullptr);
	virtual ~Dessinable() {}
};

#endif
