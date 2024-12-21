#include "IntegrateurEuler.h"

using namespace std;

int main()
{
	//Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_)
	//Ressort(Masse* depart,Masse* arrivee, double k_, double l0_)
	
	Masse M(0.127,0.0,Vecteur3D(0.0,0.0,1.0),Vecteur3D(1.0,0.0,2.0));
	IntegrateurEuler I;
	int n(5);
	for(int i(0);i<n;i++)
	{
		cout<<"t="<<i*0.01<<endl<<M;
		I.integre(M,0.01);
		M.mise_a_jour_forces();
	}

	return 0;
}
