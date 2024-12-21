#ifndef PRJ_TISSU_CHAINE_H
#define PRJ_TISSU_CHAINE_H
#include "TissuChaine.h"

using namespace std;

//Masse::Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_,SupportADessin* support_)

TissuChaine::TissuChaine(double m,double frot_fluide,double raideur,double l0, vector<Vecteur3D> p,SupportADessin* s)
:Tissu({})
{
	Vecteur3D nul({0.0,0.0,0.0});
	unsigned int taille(p.size());
	if(taille>0)
	{
		Masse M(m,frot_fluide,p[0],nul);
		masses.push_back(new Masse(M));
		for(unsigned int i(0);i<taille;++i)
		{
			Masse M2(m,frot_fluide,p[i],nul);
			masses.push_back(new Masse(M));
			//On suppose que les boules sont connectees à la main
			connecte2(i-1,i,raideur,l0);
		}
	}
}

#endif
