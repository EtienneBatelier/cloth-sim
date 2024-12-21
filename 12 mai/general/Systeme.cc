#include "Systeme.h"

using namespace std;

//Fonctions
void Systeme::evolue(Integrateur& I, double const& dt)
{
	for(auto& tissu : collection_tissus)
	{
		tissu->mise_a_jour_forces();
        tissu->compenser_poids();
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

void Systeme::set_Support(SupportADessin* support)
{
    for (auto& t : collection_tissus)
    {
        t->set_support(support);
    }
}

//Constructeur
Systeme::Systeme(vector<Tissu*> c_t,SupportADessin* support_)
:collection_tissus(c_t),Dessinable(support_)
{
    for (auto& t: collection_tissus)
    {
        t->set_support(support_);
    }
}

//Operateur
std::ostream& operator<<(std::ostream& sortie, const Systeme& systeme){
	systeme.affiche(sortie);
}
