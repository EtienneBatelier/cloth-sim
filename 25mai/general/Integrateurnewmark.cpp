#include "Integrateurnewmark.h"

void integre(Masse& M, double const& dt, const double& epsilon) const
{
    Vecteur3D pos(M.get_position());
    Vecteur3D vit(M.get_vitesse());
    Vecteur3D khil();
    Vecteur3D xi();
    Vecteur3D khil2(M.evolue());
}

/*
#include "IntegrateurEuler.h"

using namespace std;

void IntegrateurEuler::integre(Masse& M, double const& dt)
{
    Vecteur3D pos(M.get_position()),vit(M.get_vitesse());
    Vecteur3D acc((M.acceleration()));
    M.set_vitesse(vit+dt*acc);
    M.set_position(pos+dt*M.get_vitesse());
}

 * */

#include "integrateur_newmark.h"

void IntegrateurNewmark:: integre( Masse& M, const double& dt_, const double& epsilon) const{

    // Initialistations

    Masse M2(M); // sert à garder l'état initial de la boule

    boule.setEtat_dt(boule2.getEtat_dt());
    boule.setEtat(boule2.getEtat());


    Vecteur khi1(6);  //  χ, initialisé au vecteur nul de dimension 6
    Vecteur xi(6);                    //  ξ, initialisé aussi au vecteur nul
    Vecteur khi2(boule2.evolution());  //  χ' = f(t, Ω, Ω')
    Vecteur ecart(6);

    do{
        xi = boule.getEtat();                                                                     //  ξ = Ω
        khi1 = boule.evolution();                                                                 //  χ = f(t, Ω, Ω')
        boule.setEtat_dt(boule2.getEtat_dt() + (dt_/2.0)*(khi1+khi2));                               //  Ω' = Ω' + dt/2 . (χ + χ')
        boule.setEtat(boule2.getEtat()+ dt_*boule2.getEtat_dt()+ ((dt_*dt_)/3.0)*((0.5 * khi1) + khi2)); //  Ω = Ω + dt . Ω'+ dt²/3(1/2χ + χ')
        ecart = boule.getEtat()- xi; // Ω - ξ

    }while(ecart.norme() >= epsilon);    // Tant que ||Ω - ξ|| ≥ ε

}
