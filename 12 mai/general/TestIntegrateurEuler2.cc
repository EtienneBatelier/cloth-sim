#include "IntegrateurEuler.h"

using namespace std;

int main()
{
	//Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_)
	//Ressort(Masse* depart,Masse* arrivee, double k_, double l0_)
	
	Masse M1(1.0,0.3,Vecteur3D(0.0,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Masse M2(1.0,0.3,Vecteur3D(2.0,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Masse M3(1.0,0.3,Vecteur3D(0.0,2.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Ressort R1(&M1,&M2,9.0,1.5);
	Ressort R2(&M1,&M3,1.9,1.75);
	Ressort R3(&M2,&M3,5.5,1.25);
	IntegrateurEuler I;
	int n(3);
	for(int i(0);i<n;i++)
	{
		cout<<"t="<<(i+1)*0.1<<endl;
		M1.mise_a_jour_forces();
		M2.mise_a_jour_forces();
		M3.mise_a_jour_forces();
		
		cout<<"Masse1"<<endl;
		
		M1.ajoute_force(Vecteur3D(0.0,0.0,9.81*M1.get_m()));
		I.integre(M1,0.1);
		cout<<M1<<endl;
		
		cout<<"Masse2"<<endl;
		
		M2.ajoute_force(Vecteur3D(0.0,0.0,9.81*M2.get_m()));
		I.integre(M2,0.1);
		cout<<M2<<endl;
		
		cout<<"Masse3"<<endl;
		
		M3.ajoute_force(Vecteur3D(0.0,0.0,9.81*M3.get_m()));
		I.integre(M3,0.1);
		cout<<M3<<endl;
		
		cout<<endl<<"Ressort 1"<<endl<<R1;
		cout<<endl<<"Ressort 2"<<endl<<R2;
		cout<<endl<<"Ressort 3"<<endl<<R3;
		
		
	}

	return 0;
}
