#include "TissuCompose.h"

using namespace std;

TissuCompose::TissuCompose(vector<Tissu*> ens,double eps,double raid,SupportADessin* s)
    :Tissu({},s),ensemble(ens),epsilon(eps),raideur(raid),n(0)
{
    //Dans un premier temps on met dans les vector<masses*> et vector<pointeurs*> des pointeurs sur toutes les masses et tous les ressorts
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
    //Va créer des ressorts entre les masses trop proches
}

void TissuCompose::raccomode()
{
    double distance(0.0);
    /*On parcourt tous les Tissus dans une première boucle puis on les compare à tous les autres Tissus
     * Si on ne compare pas deux mêmes Tissus alors on compare chaque masse d'un Tissu à toutes les masses de l'autre Tissu
     * Si la distance entre ces deux masses est inférieure à epsilon mais strictement supérieure à 0 (car sinon on ne peut pas connecter deux masses à cause de la force de rappel)
     * Alors on connecte les masses avec une longueur à vide égale à la distance entre les deux masses
    */
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
                            ressorts.push_back(new Ressort(m,m2,raideur,distance));
                            n++;
                            //Cette variable de classe permettra de supprimer les n derniers pointeurs sur ressort dans le destructeur de TissuCompose
                        }
                    }
                }
            }
        }
    }
}

//Destructeur

TissuCompose::~TissuCompose()
{
    //On supprime les ressorts specifiques au tissu composes, car ceux deja existant seront supprmes lors de la destruction des tissus geometriques concernes.
    for(unsigned int i(ressorts.size()-1) ; i>ressorts.size()-n ;--i)
    {
        delete ressorts[i];
    }
    for(auto& e:ensemble)
    {
        e=nullptr;
    }
    ensemble.clear();
}
