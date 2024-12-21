#include "Tissu.h"
#include "IntegrateurEuler.h"
using namespace std;

int main()
{
	SupportADessin* support;
	Masse M1(1.0,0.3,Vecteur3D(0.0,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Masse M2(1.0,0.3,Vecteur3D(2.0,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
	Masse M3(1.0,0.3,Vecteur3D(0.0,2.0,0.0),Vecteur3D(0.0,0.0,0.0));
	IntegrateurEuler I;
	
	Tissu monTissu({&M1, &M2, &M3},support);
	monTissu.connecte2(0, 1, 9., 1.5);
	monTissu.connecte2(0, 2, 1.9, 1.75);
	monTissu.connecte2(1, 2, 5.5, 1.25);

	monTissu.connecte_masses2();
	cout << "Verification de l'integrite du Tissu : " << monTissu.check() << endl << endl << endl;
	
	int n(3);
	cout << "Situation de départ : " << endl << endl << monTissu << endl;
	for (auto r : monTissu.get_ressorts())
	{
		cout << r;
	}
	cout << endl << endl;
	for(int i(0); i<n; i++)
		{
			cout << "================  t = "<<0.1*(i+1)<<"  ================" << endl;
			monTissu.mise_a_jour_forces();
			monTissu.ajoute_force(Vecteur3D(0, 0, 9.81));
			monTissu.evolue(I, 0.1);
			monTissu.affiche(cout);
			cout << endl << endl;
		}
	
	return 0;
}
