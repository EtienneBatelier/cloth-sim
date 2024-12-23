#include "Crochet.h"
using namespace std;

Crochet::Crochet(Vecteur3D centre_, double rayon_)
    :Contrainte(centre_, rayon_){}

void Crochet::appliquer(Tissu* tissu, double const& temps)
{
    for (auto& m : tissu->get_masses())
    {
        if(est_contrainte(m))
        {
            m->set_vitesse(Vecteur3D(0, 0, 0));
            m->set_force_subie(Vecteur3D(0, 0, 0));
        }
    }
}

