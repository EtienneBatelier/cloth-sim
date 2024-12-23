#include "ImpulsionSinusoidale.h"
using namespace std;

ImpulsionSinusoidale::ImpulsionSinusoidale(Vecteur3D centre_, double rayon_, double debut_, double fin_, Vecteur3D force_init_, double f_, std::vector<Tissu*> cibles_)
    :Impulsion(centre_, rayon_, debut_, fin_, Vecteur3D(), cibles_),  force_init(force_init_),f(f_){}


void ImpulsionSinusoidale::appliquer(Tissu* tissu, const double& temps)
{
    force = force_init * sin((2 * M_PI * f * (temps - debut)));
    Impulsion::appliquer(tissu, temps);
}
