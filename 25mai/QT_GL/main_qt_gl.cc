#include <QApplication>
#include "glwidget.h"
#include "IntegrateurEuler.h"
#include "TissuRectangle.h"
#include "TissuDisque.h"
#include "ImpulsionSinusoidale.h"
#include "Crochet.h"
#include "TissuCompose.h"
using namespace std;


int main(int argc, char* argv[])
{
  QApplication a(argc, argv);

  IntegrateurEuler I;
  //TissuDisque::TissuDisque(double m,Vecteur3D centre, Vecteur3D rayon,double pas_radial,double frot_fluide ,double raideur,SupportADessin* s,double pas_angulaire)
  TissuDisque TD(1.0,Vecteur3D(0.0,0.0,0.0),Vecteur3D(10.0,10.0,10.0),2.0,1,50);
  //TissuRectangle (Vecteur3D longueur, Vecteur3D largeur, Vecteur3D pos, double densite, double m, double lambda, double k, double l0, SupportADessin* support)
  TissuRectangle TR(Vecteur3D(4, 0, 0), Vecteur3D(0, 4, 0), Vecteur3D(0.0,0.0,0.0), 2, 1, 1, 10, 1./2.);
  TissuRectangle TR2(Vecteur3D(4, 0, 0), Vecteur3D(0, 4, 0), Vecteur3D(2,3,1), 2, 1, 1, 10, 1./2.);
  //ImpulsionSinusoidale impsin(Vecteur3D(7.5, 7.5, 0), 1, 0, 50, Vecteur3D(0, 0, -30), 0.2, {&monTissu});

  //TissuCompose::TissuCompose(vector<Tissu*> ens,double eps,double raid,double l,SupportADessin* s)
  vector<Tissu*> ens({&TD,&TR,&TR2});
 TissuCompose monTissu(ens,2.0,6.0);
 // Impulsion compenser(Vecteur3D(), 50, 0, 1000, Vecteur3D(), {&monTissu});
  GLWidget w({&monTissu}, {}, &I);

  w.show();

  return a.exec();
}
