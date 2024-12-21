#ifndef PRJ_SYSTEME_H
#define PRJ_SYSTEME_H

#include "Tissu.h"


class Systeme : public Dessinable
{
	private : 
	std::vector<Tissu*> collection_tissus;
	
	public:
    //Gets
    std::vector<Tissu*> get_tissus() const {return collection_tissus;}
	//Fonctions

	void evolue(Integrateur&, double const&);
	virtual void dessine() const;
	void affiche(std::ostream& sortie) const;
    void set_Support(SupportADessin* support);

	//Constructeur
    Systeme(std::vector<Tissu*>, SupportADessin* support_);
	//Destructeur
	virtual ~Systeme(){}
};

std::ostream& operator<<(std::ostream&, Systeme const&);

#endif
