#ifndef IMPULSION_H
#define IMPULSION_H
#include "Contrainte.h"

class Impulsion : public Contrainte
{
    protected :

    double debut;
    double fin;
    Vecteur3D force;
    std::vector<Tissu*> cibles;
    std::vector<Masse*> champ_action;

    public:
    Impulsion(Vecteur3D centre_, double rayon_, double debut_, double fin_, Vecteur3D force_, std::vector<Tissu*> cibles_={});
    //virtual void appliquer(Tissu *tissu, const double &temps) const override;
    virtual void appliquer(Tissu* tissu, double const& temps) override;
    virtual bool est_contrainte(Masse* m) const override;
    //Destructeur
    virtual ~Impulsion() {}
};

#endif // IMPULSION_H
