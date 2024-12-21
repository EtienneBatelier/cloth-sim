#include "integrateurnewmark.h"

void IntegrateurNewMark::integre(Masse& M, double const& dt) const
{
    Vecteur3D pos(M.get_position());
    Vecteur3D vit(M.get_vitesse());
    Vecteur3D khil;//χ initilisé au vecteur nul
    Vecteur3D khil2(M.get_acceleration());//χ' initilisé au vecteur nul
    Vecteur3D xi;//ξ initilisé au vecteur nul
    do
    {
        xi=M.get_position();
        khil=M.get_acceleration();
        M.set_vitesse(vit+(dt/2.0)*(khil+khil2));
        M.set_position(pos+dt*vit+((dt*dt)/3.0)*(0.5*khil+khil2));
    }while((M.get_position()-xi).norme()>=epsilon);

}
