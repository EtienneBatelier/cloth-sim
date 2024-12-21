#include "Impulsion.h"
using namespace std;


bool Impulsion::est_contrainte(Masse* m) const
{
    for (auto const& masse : champ_action)
    {
        if (masse==m)
        {
            return true;
        }
    }
    return false;
}


Impulsion::Impulsion(Vecteur3D centre_, double rayon_, double debut_, double fin_, Vecteur3D force_, vector<Tissu*> cibles)
    :Contrainte(centre_, rayon_), debut(debut_), fin(fin_), force(force_)
{
    champ_action={};
    for (auto const& tissu : cibles)
    {
        for (auto const& m : tissu->get_masses())
        {
            if (Contrainte::est_contrainte(m))
            {
                champ_action.push_back(m);
            }
        }
    }
}

void Impulsion::appliquer(Tissu* tissu, const double& temps)
{
    if (temps <= fin and temps >= debut)
    {
        for (auto& m : tissu->get_masses())
        {
            if(est_contrainte(m))
            {
                m->ajoute_force(force + Vecteur3D(0, 0, 9.81*m->get_m()));
            }
        }
    }
}


