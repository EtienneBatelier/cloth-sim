#include "Tissucompose.h"

using namespace std;

TissuCompose::TissuCompose(vector<Tissu*> ens,double eps,double raid,SupportADessin* s)
    :Tissu({},s),ensemble(ens),epsilon(eps),raideur(raid)
{
    for(auto const& T :ensemble)
    {
        for(auto m:T->get_masses())
        {
            masses.push_back(m);
        }
        for(auto r:T->get_ressorts())
        {
            ressorts.push_back(r);
        }
    }
    raccomode();
}

void TissuCompose::raccomode()
{
    double distance(0.0);
    for(auto const& T : ensemble)
    {
        for(auto const& T2:ensemble)
        {
            if(T!=T2)
            {
                for(auto const& m:T->get_masses())
                {
                    for(auto const& m2:T2->get_masses())
                    {
                        distance=(m->get_position()-m2->get_position()).norme();
                        if(distance<epsilon and distance>0)
                        {
                            //Ressort::Ressort(Masse* depart,Masse* arrivee, double const& k_, double const& l0_)

                            ressorts.push_back(new Ressort(m,m2,raideur,distance));
                        }
                    }
                }
            }
        }
    }
}
