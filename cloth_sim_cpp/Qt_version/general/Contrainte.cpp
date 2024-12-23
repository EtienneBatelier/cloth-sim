#include "Contrainte.h"
using namespace std;

Contrainte::Contrainte(Vecteur3D centre_, double rayon_)
    :centre(centre_), rayon(rayon_){}

bool Contrainte::est_contrainte(Masse* m) const
{
    return (m->get_position()-centre).norme() <= rayon;
}

void appliquer(Tissu* tissu, double const& temps)
{
    for (auto& m : tissu->get_masses())
    {

    }
}
