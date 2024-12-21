#include "IntegrateurEuler.h"

using namespace std;

void IntegrateurEuler::integre(Masse& M, double const& dt)
{
	Vecteur3D pos(M.get_position()),vit(M.get_vitesse());
	Vecteur3D acc((M.acceleration()));
	M.set_vitesse(vit+dt*acc);
	M.set_position(pos+dt*M.get_vitesse());
}
