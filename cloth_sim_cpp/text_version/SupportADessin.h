#ifndef PRJ_SUPPORTADESSIN_H
#define PRJ_SUPPORTADESSIN_H

class Masse;
class Tissu;
class Systeme;

class SupportADessin
{
	public:
	virtual ~SupportADessin(){}

    virtual void dessine(Tissu   const&) = 0;
    virtual void dessine(Systeme const&) = 0;
    virtual void dessine(Masse const&)  = 0;
};

#endif
