#ifndef PRJ_TISSU_RECTANGLE_H
#define PRJ_TISSU_RECTANGLE_H
#include "Tissu.h"

class TissuRectangle:public Tissu
{
	TissuRectangle(double m,Vecteur3D largeur,Vecteur3D longueur,Vecteur3D position,double frot_fluide,double densite_lin,double raideur,double l0);
};

#endif
