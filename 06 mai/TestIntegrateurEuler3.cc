#include "IntegrateurEuler.h"

using namespace std;

int main()
{
	//Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_)
	//Ressort(Masse* depart,Masse* arrivee, double k_, double l0_)
	Masse A(0.33,0.3,Vecteur3D(0.0,0.0,-3.0),Vecteur3D(0.0,0.0,0.0));
	Masse B(1.0,0.3,Vecteur3D(-0.5,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Masse C(1.0,0.3,Vecteur3D(0.5,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Ressort R1(&A,&B,0.6,2.5);
	Ressort R2(&A,&C,0.6,2.5);
	
	IntegrateurEuler I;
	
	int n(250);
	
	for(int i(0);i<n;i++)
	{
		cout<<"t="<<(i+1)*0.1<<endl;
		A.mise_a_jour_forces();
		B.mise_a_jour_forces();
		C.mise_a_jour_forces();
		B.ajoute_force(-B.get_force_subie());
		C.ajoute_force(-C.get_force_subie());
		I.integre(A,0.1);
		I.integre(B,0.1);
		I.integre(C,0.1);

		
		cout<<"Masse A:"<<endl<<A<<endl;
		cout<<"Masse B:"<<endl<<B<<endl;
		cout<<"Masse C:"<<endl<<C<<endl;
		//~ cout<<"Ressort1:"<<endl<<R1<<endl;
		//~ cout<<"Ressort2:"<<endl<<R2<<endl;
	}
	return 0;
}
