#include "integrateurnewmark.h"

void IntegrateurNewmark::integre(Masse& M, double const& dt) const
{
    Vecteur3D pos(M.get_position());
    Vecteur3D vit(M.get_vitesse());
    Vecteur3D khil;//χ initilisé au vecteur nul
    Vecteur3D khil2(M.acceleration());//χ' initilisé
    Vecteur3D xi;//ξ initilisé au vecteur nul
    Vecteur3D memoire_contraintes;
    do
    {
        memoire_contraintes=M.get_force_contraintes();          //Ici, on memorise les forces dues aux contraintes pour les ré ajouter apres avoir
        xi=M.get_position();                                    //utilisé mise_a_jour_forces().
        khil=M.acceleration();
        M.set_vitesse(vit+(dt/2.0)*(khil+khil2));
        M.set_position(pos+dt*vit+((dt*dt)/3.0)*(0.5*khil+khil2));
        M.mise_a_jour_forces();
        M.ajoute_force(memoire_contraintes);
    }while((M.get_position()-xi).norme()>=epsilon);

}
