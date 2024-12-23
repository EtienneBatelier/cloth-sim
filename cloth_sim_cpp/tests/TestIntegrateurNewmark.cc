#include <iostream>
#include "TextViewer.h"
#include "Systeme.h"
#include "IntegrateurNewmark.h"

using namespace std;

int main()
{
	//Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_)
	//Ressort(Masse* depart,Masse* arrivee, double k_, double l0_)
	
	IntegrateurNewmark I;
	
	Masse M(0.127,0.0,Vecteur3D(0.0,0.0,1.0),Vecteur3D(1.0,0.0,2.0));
	int n(100);
	for(int i(0);i<n;i++)
	{
		cout<<"t="<<i*0.01<<endl<<M.get_position();
		I.integre(M,0.01);
		M.mise_a_jour_forces();
	}

	return 0;
}
