#include "Systeme.h"

using namespace std;

//Fonctions
void Systeme::evolue(Integrateur& I, double const& dt)
{
    temps+=dt;                              //On met a jour le temps
	for(auto& tissu : collection_tissus)
	{
        tissu->mise_a_jour_forces();
        for (auto const& c : contraintes)
        {
            c->appliquer(tissu,temps);
        }
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
Systeme::Systeme(vector<Tissu*> c_t, std::vector<Contrainte*> contraintes_, SupportADessin* support_)
:collection_tissus(c_t), contraintes(contraintes_), Dessinable(support_), temps(0.)
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
