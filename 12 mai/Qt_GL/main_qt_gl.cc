#include <QApplication>
#include "glwidget.h"
#include "IntegrateurEuler.h"
#include "Tissu.h"
using namespace std;

int main(int argc, char* argv[])
{
  QApplication a(argc, argv);

  IntegrateurEuler I;


  Masse A(0.33,0.3,Vecteur3D(0.0,0.0,-3.0),Vecteur3D(0.0,0.0,0.0));
  Masse B(1.0,0.3,Vecteur3D(-0.5,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
  Masse C(1.0,0.3,Vecteur3D(0.5,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
  vector<Masse*> mes_masses({&A, &B, &C});

  Tissu monTissu(mes_masses);
  monTissu.connecte2(0, 1, 0.6, 2.5);
  monTissu.connecte2(0, 2, 0.6, 2.5);
  monTissu.connecte_masses2();


  GLWidget w({&monTissu}, &I);
  w.show();



  return a.exec();
}
