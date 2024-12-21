#include <QApplication>
#include "glwidget.h"
#include "IntegrateurEuler.h"
#include "IntegrateurNewmark.h"
#include "TissuRectangle.h"
#include "TissuDisque.h"
#include "ImpulsionSinusoidale.h"
#include "Crochet.h"
#include "TissuCompose.h"
using namespace std;


int main(int argc, char* argv[])
{
  QApplication a(argc, argv);

  IntegrateurNewMark I;
  //TissuDisque::TissuDisque(double m,Vecteur3D centre, Vecteur3D rayon,double pas_radial,double frot_fluide ,double raideur,SupportADessin* s,double pas_angulaire)
  TissuDisque TD(1.0,Vecteur3D(0.0,0.0,0.0),Vecteur3D(0.0,0.0,6.0),2.0,10,100);

  //TissuRectangle (Vecteur3D longueur, Vecteur3D largeur, Vecteur3D pos, double densite, double m, double lambda, double k, double l0, SupportADessin* support)
  //TissuRectangle TR(Vecteur3D(6, 0, 0), Vecteur3D(0, 3, 0), Vecteur3D(0.0,0.0,0.0), 1, 1, 10, 200, 1);
  TissuRectangle TR2(Vecteur3D(2, 0, 0), Vecteur3D(0, 1, 0), Vecteur3D(2,3,1), 2, 1, 10, 100, 1./2.);

  TissuRectangle TR3(Vecteur3D(2, 0, 0), Vecteur3D(0, 2, 0), Vecteur3D(), 1, 1, 1, 1, 1);

  //TissuCompose::TissuCompose(vector<Tissu*> ens,double eps,double raid,double l,SupportADessin* s)
  vector<Tissu*> ens({&TD,&TR2});
 TissuCompose monTissu(ens,2.0,6.0);
  //Crochet compenser(Vecteur3D(3,1.5,0), 2);
  Impulsion compenser(Vecteur3D(),1000,0,10000,Vecteur3D(),{&monTissu});
  ImpulsionSinusoidale impsin(Vecteur3D(0, 0, 0), 5, 0, 50, Vecteur3D(0, 0, -50), 0.2, {&monTissu});
  Masse M();
  GLWidget w({&monTissu}, {&compenser,&impsin}, &I);

  w.show();
  return a.exec();
}
