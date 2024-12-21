#include "Systeme.h"
#include "IntegrateurEuler.h"

using namespace std;

int main()
{
	SupportADessin* support;
	//Masse(double const& m_, double const& lambda_ , Vecteur3D const& position_, Vecteur3D const& vitesse_,vector<Ressort*> ressorts_associes_)
	//Ressort(Masse* depart,Masse* arrivee, double k_, double l0_)
	Masse A(0.33,0.3,Vecteur3D(0.0,0.0,-3.0),Vecteur3D(0.0,0.0,0.0));
	Masse B(1.0,0.3,Vecteur3D(-0.5,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Masse C(1.0,0.3,Vecteur3D(0.5,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Tissu T({&A,&B,&C},support);
	T.connecte2(0,1,0.6,2.5);
	T.connecte2(0,2,0.6,2.5);
	T.connecte_masses2();
	IntegrateurEuler I;
	
	int n(10);
	
	for(int i(0);i<n;i++)
	{
		cout << "================  t = "<<0.1*(i+1)<<"  ================" << endl;
		T.mise_a_jour_forces();
		B.ajoute_force(-B.get_force_subie());
		C.ajoute_force(-C.get_force_subie());
		T.evolue(I,0.1);
		
		cout<<T<<endl;
	}
	
	
	return 0;
}
