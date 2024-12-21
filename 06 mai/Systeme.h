#ifndef PRJ_SYSTEME_H
#define PRJ_SYSTEME_H

#include "Tissu.h"


class Systeme : public Dessinable
{
	private : 
	std::vector<Tissu*> collection_tissus;
	
	public:
	//Fonctions
	void evolue(Integrateur&, double const&);
	virtual void dessine() const;
	void affiche(std::ostream& sortie) const;
	//Constructeur
	Systeme(std::vector<Tissu*>,SupportADessin* support_);
	//Destructeur
	virtual ~Systeme(){}
};

std::ostream& operator<<(std::ostream&, Systeme const&);

#endif
