#include <QApplication>
#include "glwidget.h"
#include "IntegrateurEuler.h"
#include "TissuRectangle.h"
#include "ImpulsionSinusoidale.h"
#include "Crochet.h"
using namespace std;


int main(int argc, char* argv[])
{
  QApplication a(argc, argv);

  IntegrateurEuler I;
  TissuRectangle monTissu(Vecteur3D(30, 0, 0), Vecteur3D(0, 30, 0), Vecteur3D(), 2, 1, 5, 10, 1./2.);
  Impulsion compenser(Vecteur3D(), 50, 0, 1000, Vecteur3D(), {&monTissu});
  ImpulsionSinusoidale impsin(Vecteur3D(15, 15, 0), 1, 0, 50, Vecteur3D(0, 0, -50), 1, {&monTissu});

  GLWidget w({&monTissu}, {&compenser, &impsin}, &I);

  w.show();

  return a.exec();
}
