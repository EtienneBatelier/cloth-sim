#include "TissuRectangle.h"
using namespace std;

TissuRectangle::TissuRectangle (Vecteur3D longueur, Vecteur3D largeur, Vecteur3D pos, double densite, double m, double lambda, double k, double l0, SupportADessin* support)
: Tissu({})
{
    if (longueur*largeur != largeur.norme()*longueur.norme())
        {
                if(longueur*largeur != 0)
                {
                    largeur -= largeur*((largeur*longueur)/longueur.norme2());
                }
                int nbr_masses_longueur(longueur.norme()*densite);
                int nbr_masses_largeur(largeur.norme()*densite);

                for(int i(0); i < nbr_masses_longueur; i++)
                {

                        for(int j(0); j<nbr_masses_largeur; j++)
                        {
                                masses.push_back(new Masse(m, lambda, pos+(i*(longueur*(1./nbr_masses_longueur)))+(j*(largeur*(1./nbr_masses_largeur))),Vecteur3D(), {}, support));
                                if(j>0)
                                {
                                    connecte(i*nbr_masses_largeur+j, i*nbr_masses_largeur+j-1, k, l0);
                                }
                        }
                        if (i>0)
                        {
                                for(int j(0); j<nbr_masses_largeur; j++)
                                {
                                    connecte(i*nbr_masses_largeur+j, (i-1)*nbr_masses_largeur+j, k, l0);
                                }
                        }
                }
        }
}

TissuRectangle::~TissuRectangle()
{
    for(auto& m:masses)
    {
        delete m;
    }
    masses.clear();
    for(auto& r:ressorts)
    {
        delete r;
    }
    ressorts.clear();
}
