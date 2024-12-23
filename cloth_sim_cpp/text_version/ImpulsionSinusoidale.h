#ifndef IMPULSIONSINUSOIDALE_H
#define IMPULSIONSINUSOIDALE_H
#include "Impulsion.h"

class ImpulsionSinusoidale : public Impulsion
{
    private:
    Vecteur3D force_init;
    double f;
    public:
    ImpulsionSinusoidale(Vecteur3D centre_, double rayon_, double debut_, double fin_, Vecteur3D force_init_, double f_, std::vector<Tissu*> cibles_= {});
    virtual void appliquer(Tissu *tissu, double  const& temps) override;
};

#endif // IMPULSIONSINUSOIDALE_H
