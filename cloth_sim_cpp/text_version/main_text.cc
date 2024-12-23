#include "Vecteur3D.h"
#include "Tissu.h"
#include "IntegrateurNewmark.h"
#include "IntegrateurEuler.h"
#include "Systeme.h"
#include "TextViewer.h"
using namespace std;

int main()
{

	TextViewer terminal(cout);
	TextViewer* terminal_(&terminal);
	Masse A(0.33,0.3,Vecteur3D(0.0,0.0,-3.0),Vecteur3D(0.0,0.0,0.0));
	Masse B(1.0,0.3,Vecteur3D(-0.5,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Masse C(1.0,0.3,Vecteur3D(0.5,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	IntegrateurEuler I;
	
	Tissu monTissu({&A, &B, &C}, terminal_);
	monTissu.connecte2(0, 1, 0.6, 2.5);			
	monTissu.connecte2(0, 2, 0.6, 2.5);
	
	Systeme systeme({&monTissu}, {}, terminal_);

	for (int n(0); n<10; ++n)
	{
		systeme.evolue(I, 0.1);
		systeme.dessine();
	}
	

	return 0;
}
