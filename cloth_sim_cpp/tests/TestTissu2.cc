#include "Tissu.h"
#include "IntegrateurEuler.h"
using namespace std;

int main()
{
  Masse A(0.33,0.3,Vecteur3D(0.0,0.0,-3.0),Vecteur3D(0.0,0.0,0.0));
    Masse B(1.0,0.3,Vecteur3D(-0.5,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
    Masse C(1.0,0.3,Vecteur3D(0.5,0.0,0.0),Vecteur3D(0.0,0.0,0.0));
    IntegrateurEuler I;

    Tissu monTissu({&A, &B, &C});
    monTissu.connecte2(0, 1, 0.6, 2.5);
    monTissu.connecte2(0, 2, 0.6, 2.5);

    cout << "Verification de l'integrite du Tissu : " << monTissu.check() << endl << endl << endl;

    int n(10);
    B.ajoute_force(-(B.get_force_subie()));
    C.ajoute_force(-(C.get_force_subie()));
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
            B.ajoute_force(-(B.get_force_subie()));
            C.ajoute_force(-(C.get_force_subie()));
            monTissu.evolue(I, 0.1);
            cout << monTissu << endl;
            cout << endl << endl;
        }

    return 0;
}
