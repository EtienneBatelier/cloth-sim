#ifndef PRJ_DESSINABLE_H
#define PRJ_DESSINABLE_H
#include "SupportADessin.h"

class Dessinable
{
	protected:
	SupportADessin* support;
	public:
    Dessinable(SupportADessin* support_nullptr);
    void set_support(SupportADessin* support_);
	virtual void dessine() const =0;
    virtual ~Dessinable() {}
};

#endif
