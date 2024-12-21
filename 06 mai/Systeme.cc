#include "Systeme.h"

using namespace std;

//Fonctions
void Systeme::evolue(Integrateur& I, double const& dt)
{
	for(auto& tissu : collection_tissus)
	{
		tissu->mise_a_jour_forces();
		tissu->evolue(I,dt);
	}
}

void Systeme::dessine() const
{support->dessine(*this);}

void Systeme::affiche(std::ostream& sortie) const
{
	for (auto tissu : collection_tissus)
	{
		tissu->affiche(sortie);
	}
}

//Constructeur
Systeme::Systeme(vector<Tissu*> c_t,SupportADessin* support_)
:collection_tissus(c_t),Dessinable(support_){}

//Operateur
std::ostream& operator<<(std::ostream& sortie, const Systeme& systeme){
	systeme.affiche(sortie);
}
