#include <iostream>
#include "TextViewer.h"
#include "Systeme.h"
#include "IntegrateurEuler.h"
using namespace std;

int main()
{
  TextViewer ecran(cout);
  Systeme c({}, &ecran);
  IntegrateurEuler I;
  double dt(0.1);

  cout << "Au départ :" << endl;
  c.dessine();

  c.evolue(I, dt);
  cout << "Après un pas de calcul :" << endl;
  c.dessine();

  c.evolue(I, dt);
  cout << "Après deux pas de calcul :" << endl;
  c.dessine();

  return 0;
}
