#include "Vecteur3D.h"
using namespace std;

//Operateurs
void affiche_addition(Vecteur3D V1,Vecteur3D V2)
{
	cout<<"Addition"<<endl;
	cout<<V1<<" + "<<V2<<" = "<<V1+V2<<endl;
}

void affiche_soustraction(Vecteur3D V1,Vecteur3D V2)
{
	cout<<"Soustraction"<<endl;
	cout<<V1<<" - "<<V2<<" = "<<V1-V2<<endl;
}

void affiche_oppose(Vecteur3D V)
{
	cout<<"Oppose"<<endl;
	cout<<"-"<<V<<" = "<<-1.0*V;
}

void affiche_multscal(Vecteur3D V,double a)
{
	cout<<"Multiplication par un scalaire"<<endl;
	cout<<a<<"*"<<V<<"="<<V*a<<endl;
}

void affiche_norme1(Vecteur3D V)
{
	cout<<"Norme1"<<endl;
	cout<<"||";
	V.affiche();
	cout<<"||² = ";
	cout<<V.norme()<<endl;
}

void affiche_norme2(Vecteur3D V)
{
	cout<<"Norme2"<<endl;
	cout<<"||"<<V<<"|| = "<<V.norme2()<<endl;
}

void affiche_produitvectoriel(Vecteur3D V1,Vecteur3D V2)
{
	cout<<"Produit vectoriel"<<endl;
	cout<<V1<<" ^ "<<V2<<" = "<<(V1^V2)<<endl;
}

void affiche_prodscal(Vecteur3D V1,Vecteur3D V2)
{
	cout<<"Produit scalaire"<<endl;
	cout<<V1<<" * "<<V2<<" = "<<V1*V2<<endl;
}

int main()
{
	Vecteur3D vect1;
	Vecteur3D vect2;
	Vecteur3D vect3;

	// Cette partie sera revue dans 2 semaines (constructeurs, surcharge des opérateurs)
	// v1 = (1.0, 2.0, -0.1)
	vect1.set_coord(0, 1.0);
	vect1.set_coord(1, 2.0);
	vect1.set_coord(2, -0.1);
	 
	// v2 = (2.6, 3.5,  4.1)
	vect2.set_coord(0, 2.6);
	vect2.set_coord(1, 3.5);
	vect2.set_coord(2, 4.1); 

	vect3 = vect1;

	cout << "Vecteur 1 : ";
	vect1.affiche();
	cout << endl;

	cout << "Vecteur 2 : ";
	vect2.affiche();
	cout << endl;

	cout << "Le vecteur 1 est ";
	if (vect1.compare(vect2)) {
		cout << "égal au";
	} else {
		cout << "différent du";
	}
	cout << " vecteur 2," << endl << "et est ";
	if (not vect1.compare(vect3)) {
		cout << "différent du";
	} else {
		cout << "égal au";
	}
	cout << " vecteur 3." << endl;

	Vecteur3D zero;
	zero.set_vecteur(0.0,0.0,0.0);
	affiche_addition(vect1,vect2);
	affiche_addition(vect2,vect1);
	affiche_addition(vect1,zero);
	affiche_addition(zero,vect1);
	affiche_soustraction(vect1,vect2);
	affiche_soustraction(vect2,vect2);
	affiche_oppose(vect1);
	affiche_addition(vect2.oppose(),vect1);
	affiche_multscal(vect1,3);
	affiche_produitvectoriel(vect1,vect2);
	affiche_produitvectoriel(vect2,vect1);
	affiche_norme1(vect1);
	affiche_norme2(vect1);
	affiche_norme1(vect2);
	affiche_norme2(vect2);
	return 0;
}
