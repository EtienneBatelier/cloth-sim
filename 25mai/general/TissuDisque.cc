#include "TissuDisque.h"

using namespace std;


//Masse::Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_,SupportADessin* support_)
TissuDisque::TissuDisque(double m, Vecteur3D centre,Vecteur3D rayon,double pas_radiale, double frot_fluide, double raideur, int pas_angulaire,SupportADessin* s)
    :Tissu({},s)
{
    Vecteur3D rayon_norme(rayon*(1.0/rayon.norme()));
    Vecteur3D u;
    if (rayon.get_vecteur()[1]==0 and rayon.get_vecteur()[2]==0)
    {
        Vecteur3D v(0.0,1.0,0.0);
        u=v;
    }
    else
    {
        Vecteur3D v(0.0,-rayon.get_vecteur()[2],rayon.get_vecteur()[1]);
        u=v;
    }
    u.normalise();
    int nbr_masse(rayon.norme()/pas_radiale);
    int nbr_chaine(360/pas_angulaire);
    while(360%pas_angulaire!=0)
    {
        ++pas_angulaire;
    }
    double nb(nbr_masse);//pour etre sur de ne pas avoir de division euclidienne
    u=u*rayon.norme()*(1.0/nb);
    double longueur(u.norme());
    double angle_radian(pas_angulaire*2*M_PI/360.0);
    Vecteur3D nul;
    masses.push_back(new Masse(m,frot_fluide,centre,nul));
    for(int i(1);i<=nbr_masse;++i)
    {
        masses.push_back(new Masse(m,frot_fluide,centre+u*i,nul));
        connecte(i-1,i,raideur,longueur);
    }
    for(int j(1);j<nbr_chaine;++j)
    {
        u=cos(angle_radian)*u+(1-cos(angle_radian))*(u*rayon_norme)*rayon_norme+(sin(angle_radian))*(rayon_norme^u);
        u.normalise();
        u=u*longueur;
        masses.push_back(new Masse(m,frot_fluide,centre+u,nul));
        connecte(0,j*nbr_masse+1,raideur,longueur);
        connecte((j-1)*nbr_masse+1,j*nbr_masse+1,raideur,(masses[(j-1)*nbr_masse+1]->get_position()-masses[j*nbr_masse+1]->get_position()).norme());
        for(int i(2);i<=nbr_masse;++i)
        {
            masses.push_back(new Masse(m,frot_fluide,centre+u*i,nul));
            connecte(j*nbr_masse+i-1,j*nbr_masse+i,raideur,longueur);
            connecte((j-1)*nbr_masse+i,j*nbr_masse+i,raideur,(masses[(j-1)*nbr_masse+i]->get_position()-masses[j*nbr_masse+i]->get_position()).norme());
        }
    }

    for(int i(1);i<=nbr_masse;++i)
    {
       connecte(nbr_masse*(nbr_chaine-1)+i,i,raideur,(masses[nbr_masse*(nbr_chaine-1)+i]->get_position()-masses[i]->get_position()).norme());
    }
}
