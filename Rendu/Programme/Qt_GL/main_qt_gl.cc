#include <QApplication>
#include "glwidget.h"
#include "IntegrateurEuler.h"
#include "integrateurnewmark.h"
#include "TissuRectangle.h"
#include "TissuDisque.h"
#include "ImpulsionSinusoidale.h"
#include "Crochet.h"
#include "TissuCompose.h"
using namespace std;


/*Prototypes utiles pour Tests :
 * Tissus :
 * TissuDisque(double m,Vecteur3D centre, Vecteur3D rayon,double pas_radial,double frot_fluide ,double raideur,SupportADessin* s,double pas_angulaire)
 * TissuRectangle (Vecteur3D longueur, Vecteur3D largeur, Vecteur3D pos, double densite, double m, double lambda, double k, double l0, SupportADessin* support)
 * TissuChaine(double m,double frot_fluide,double raideur,double l0, vector<Vecteur3D> p,SupportADessin* s)
 * TissuCompose(vector<Tissu*> ens,double eps,double raid,SupportADessin* s)
 *
 * Impulsions :
 * Crochet(Vecteur3D centre_, double rayon_)
 * Impulsion(Vecteur3D centre_, double rayon_, double debut_, double fin_, Vecteur3D force_, std::vector<Tissu*> cibles_={})
 * ImpulsionSinusoidale(Vecteur3D centre_, double rayon_, double debut_, double fin_, Vecteur3D force_init_, double f_, std::vector<Tissu*> cibles_)
*/
int main(int argc, char* argv[])
{
  QApplication a(argc, argv);


  //Tissus :
  TissuRectangle rect(Vecteur3D(20, 0, 0), Vecteur3D(0, 20, 0), Vecteur3D(), 1.2, 1, 5, 120, 1/1.2);

  TissuRectangle rect2(Vecteur3D(10, 0, 0), Vecteur3D(0, 0, 10), Vecteur3D(25.0,0.0,.0), 1., 1, 5, 10, 1./1.);
  TissuRectangle rect3(Vecteur3D(10, 0, 0), Vecteur3D(0, 0, 10), Vecteur3D(25.0,10.0,0.0), 1., 1, 5, 10, 1./1.);

  TissuDisque disque2(1.0,Vecteur3D(-10.0,-10.0,-10.0),Vecteur3D(0.0,0.0,15.0),2.0,5,120);
  TissuCompose ens({&rect3,&rect2},10.001,120);
  vector<Tissu*> mesTissus({&rect,&ens,&disque2});

  //Impulsions :
  Impulsion imp(Vecteur3D(), 1000, 0.0, 10000, Vecteur3D(),{&ens,&disque2});
  ImpulsionSinusoidale impsin(Vecteur3D(-10.0,-10.0,-10), 5, 0.0, 50,Vecteur3D(0.0,0.0,30.0),0.1,{&disque2});
  Crochet table_ronde (Vecteur3D(10, 10, 0), 8);
  vector<Contrainte*> mesImpulsions({&table_ronde,&imp,&impsin});

  //Integrateurs :
  IntegrateurNewmark N;
  IntegrateurEuler E;
  vector<Integrateur*> mesIntegrateurs({&E, &N});



  GLWidget w(mesTissus, mesImpulsions, mesIntegrateurs);
  w.show();
  return a.exec();
}
